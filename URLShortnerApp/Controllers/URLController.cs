using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using URLShortnerApp.DataAccess.Models;

namespace URLShortnerApp.Controllers
{
    public class URLController : Controller
    {
        // Bind Property - means you can write data when you post
        [BindProperty]
        public URLModel UrlModel { get; set; }

        public URLController()
        {
            //UrlModel = new URLModel();
        }

        public IActionResult Index(URLModel? model)
        {
            if (model != null)
            {
                return View(model);
            }

            return View();
        }

        [HttpGet]
        public IActionResult PostURL()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PostURL([FromForm] URLModel model)
        {
            // clear before each request
            //UrlModel = new URLModel();

            if (ModelState.IsValid)
            {
                // store url in db
                // perform operations
                // return short URL

                // testing to check binding working ok
                UrlModel.Id = model.Id;
                UrlModel.ShortURL = model.URL;
            }

            return RedirectToAction("Index", new { id = model.Id });

            //UrlModel = model;
            //return View(UrlModel);
        }

    }
}
