using System;
using System.Collections.Generic;

namespace Science_searcher.Models
{
    public partial class TArticlesAuthorsIndex
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int ArticleId { get; set; }
    }
}
