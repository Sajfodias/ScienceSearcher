using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Science_searcher.Model
{
    [Table("t_Session")]
    public partial class TSession
    {
        public int Id { get; set; }
        [Column("Session_Id")]
        public Guid SessionId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateStart { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateEnd { get; set; }
        [Required]
        public string Status { get; set; }
        public string RaportFilePath { get; set; }
    }
}
