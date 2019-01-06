using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Science_searcher.Model
{
    [Table("t_Articles_Authors_Index")]
    public partial class TArticlesAuthorsIndex
    {
        public int Id { get; set; }
        [Column("Author_Id")]
        public int AuthorId { get; set; }
        [Column("Article_Id")]
        public int ArticleId { get; set; }
    }
}
