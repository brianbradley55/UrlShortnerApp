using System;
using System.Collections.Generic;
using System.Text;

namespace URLShortnerApp.Library.Models
{
    public class URLModel
    {
        public int Id { get; set; }
        public string URL { get; set; }
        public string ShortURL { get; set; }
        public string Token { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;    
    }
}
