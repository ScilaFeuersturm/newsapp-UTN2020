using System.Collections.Generic;

namespace Models
{
    public class CreateNewsDTO
    {
        public string Photo {set;get;}
        public string Title {set;get;}
        public string Subtitle{set;get;}
        public string Body{set;get;}
         public string UserId { get; set; }
    }
}