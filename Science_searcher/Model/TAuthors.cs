using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Science_searcher.Model
{
    [Table("t_Authors")]
    public partial class TAuthors
    {
        public int Id { get; set; }
        [Required]
        public string AuthorName { get; set; }
        [Required]
        public string AuthorSurename { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateTime { get; set; }
    }
}
