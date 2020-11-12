using System.Collections.Generic;

namespace Models
{
    public class NewsEntity
    {
        public int Id {set;get;}
        public string Image {set;get;}
        public string Title {set;get;}
        public string Subtitle{set;get;}
        public string Body{set;get;}
        public string SignedBy{set;get;}
        public string DateCreated{set;get;}
    }    
}