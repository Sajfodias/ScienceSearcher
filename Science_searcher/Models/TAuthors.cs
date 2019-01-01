using System;
using System.Collections.Generic;

namespace Science_searcher.Models
{
    public partial class TAuthors
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string AuthorSurename { get; set; }
        public DateTime DateTime { get; set; }
    }
}
