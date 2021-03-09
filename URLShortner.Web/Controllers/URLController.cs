using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using URLShortnerApp.Library.DataAccess;
using URLShortnerApp.Library.DataAccess.Internal;
using URLShortnerApp.Library.Models;
using URLShortnerApp.Utility;

namespace URLShortnerApp.Controllers
{
    public class URLController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUrlData _urlData;
        private readonly IValidations _validations;

        [BindProperty]
        public URLModel UrlModel { get; set; }

        public URLController(IUrlData urlData, IHttpContextAccessor httpContextAccessor, IValidations validations)
        {
            _urlData = urlData;
            _httpContextAccessor = httpContextAccessor;
            _validations = validations;
        }

        public IActionResult Index(string? token)
        {
            if (token != null)
            {
                var record = _urlData.GetItemFromDbByToken(token);
                return View(record);
            }

            return View();
        }

        [HttpGet, Route("/{token}")]
        public IActionResult URLRedirect([FromRoute] string token)
        {
            URLModel urlModel = _urlData.GetItemFromDbByToken(token);

            if (urlModel != null)
            {        
                return Redirect(urlModel.URL);               
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PostURL([FromForm] URLModel model)
        {
            if (ModelState.IsValid)
            {
                // check to make sure url has http prefix
                if (!model.URL.Contains("http"))
                {
                    model.URL = "https://" + model.URL;
                }

                // Validate URL
                bool isUrlValid = _validations.IsValidUri(model.URL);
                if (isUrlValid == false)
                {
                    return NotFound("URL not valid. Please try entering one in the correct format");
                }

                // check to make sure url record doesnt already exist in the db
                URLModel result = _urlData.GetItemFromDbByLongUrl(model.URL);
                if (result == null)
                {
                    // generate token
                    model.Token = TokenGenerator.GenerateToken();
                    
                    // get local host
                    string hostVal = _httpContextAccessor.HttpContext.Request.Host.Value;

                    // set short URL
                    model.ShortURL = "https://" + hostVal + "/" + model.Token;

                    try
                    {
                        _urlData.SaveItemToDb(model);
                        return RedirectToAction("Index", new { Token = model.Token });
                    }
                    catch (Exception)
                    {

                        throw;
                    }    
                }
                else
                {
                    return NotFound("A record for URL already exists. Please try a different one");
                }
            }
            return View();
        }
    }
}
