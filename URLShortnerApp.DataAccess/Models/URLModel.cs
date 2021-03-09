using System;
using System.Collections.Generic;
using System.Text;

namespace URLShortnerApp.DataAccess.Models
{
    public class URLModel
    {
        public Guid Id { get; set; }
        public string URL { get; set; }
        public string ShortURL { get; set; }
        public string Token { get; set; }
        public int NoOfClicks { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.Now;    
    }
}
