using System;
using System.Collections.Generic;

namespace Science_searcher.Models
{
    public partial class TUserSession
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public Guid UserSession { get; set; }
    }
}
