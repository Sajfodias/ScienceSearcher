using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Science_searcher.Models
{
    public partial class TUsers
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateRegistry { get; set; }
    }
}
