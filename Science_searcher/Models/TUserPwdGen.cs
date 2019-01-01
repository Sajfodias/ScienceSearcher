using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Science_searcher.Models
{
    public partial class TUserPwdGen
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Salt { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateAdd { get; set; }
    }
}
