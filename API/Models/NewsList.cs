using System.Collections.Generic;

namespace Models
{
    public class NewsList
    {
        public long Id { get; set; }
        public string Category { get; set; }

        public List<NewsEntity> NewsItem { get; set; }
    }
}