using System.Collections.Generic;

namespace Models
{
    public class NewsEntity
    {
        public long Id {set;get;}
        public string Photo {set;get;}
        public string Title {set;get;}
        public string Subtitle {set;get;} 
        public string Body {set;get;}
        public ApplicationUser Responsible { get; set; }

    }    
}