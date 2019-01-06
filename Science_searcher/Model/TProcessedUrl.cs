using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Science_searcher.Model
{
    [Table("t_ProcessedUrl")]
    public partial class TProcessedUrl
    {
        public int Id { get; set; }
        [Required]
        [Column("Processed_url")]
        public string ProcessedUrl { get; set; }
        [Column("Processing_date", TypeName = "datetime")]
        public DateTime ProcessingDate { get; set; }
    }
}
