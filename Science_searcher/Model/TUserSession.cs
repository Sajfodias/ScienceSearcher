using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Science_searcher.Model
{
    [Table("t_UserSession")]
    public partial class TUserSession
    {
        public int Id { get; set; }
        [Column("userId")]
        public int UserId { get; set; }
        [Required]
        [Column("userName")]
        public string UserName { get; set; }
        [Column("userSession")]
        public Guid UserSession { get; set; }
    }
}
