using System;
using System.Collections.Generic;
using System.Text;
using URLShortnerApp.Library.Models;

namespace URLShortnerApp.Library.DataAccess
{
    public interface IUrlData
    {
        URLModel GetItemFromDbByShortUrl(string shortUrl);
        URLModel GetItemFromDbByLongUrl(string longUrl);
        int SaveItemToDb(URLModel model);
        URLModel GetItemFromDbByToken(string token);
    }
}
