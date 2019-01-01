using System;
using System.Collections.Generic;

namespace Science_searcher.Models
{
    public partial class TSession
    {
        public int Id { get; set; }
        public Guid SessionId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Status { get; set; }
        public string RaportFilePath { get; set; }
    }
}
