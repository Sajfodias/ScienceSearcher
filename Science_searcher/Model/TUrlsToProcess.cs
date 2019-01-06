using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Science_searcher.Model
{
    [Table("t_UrlsToProcess")]
    public partial class TUrlsToProcess
    {
        public int Id { get; set; }
        [Required]
        [Column("Parent_url")]
        public string ParentUrl { get; set; }
        [Required]
        [Column("New_url")]
        public string NewUrl { get; set; }
    }
}
