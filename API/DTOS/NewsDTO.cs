using System.Collections.Generic;

namespace Models
{
    public class NewsDTO
    {
        public long Id { get; set; }
        public string Image {set;get;}
        public string Title {set;get;}
        public string Subtitle{set;get;}
        public string Body{set;get;}
        public string Responsible { get; set; }

    }    
}