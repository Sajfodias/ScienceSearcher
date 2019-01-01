using System;
using System.Collections.Generic;

namespace Science_searcher.Models
{
    public partial class TArticles
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AbstractText { get; set; }
        public DateTime DateTime { get; set; }
        public string Keywords { get; set; }
        public int? Year { get; set; }
        public string Country { get; set; }
        public string AuthorsLine { get; set; }
        public string Organizations { get; set; }
        public string Url { get; set; }
    }
}
