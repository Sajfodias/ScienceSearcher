using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Science_searcher.Model
{
    [Table("t_Articles")]
    public partial class TArticles
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string AbstractText { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateTime { get; set; }
        public string Keywords { get; set; }
        public int? Year { get; set; }
        public string Country { get; set; }
        public string AuthorsLine { get; set; }
        public string Organizations { get; set; }
        public string Url { get; set; }
    }
}
