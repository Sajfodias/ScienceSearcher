using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Science_searcher.Model
{
    [Table("t_OutputFiles")]
    public partial class TOutputFiles
    {
        public Guid Id { get; set; }
        [Required]
        [Column("Source_url")]
        [StringLength(255)]
        public string SourceUrl { get; set; }
        [Required]
        [Column("File_name")]
        [StringLength(255)]
        public string FileName { get; set; }
        [Column("Download_date", TypeName = "datetime")]
        public DateTime DownloadDate { get; set; }
    }
}
