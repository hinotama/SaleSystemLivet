using System;
using System.Collections.Generic;

namespace SaleSystemWPF.Models
{
    public partial class Auth
    {
        public int AuthId { get; set; }
        public string Token { get; set; }
        public DateTime? Expiration { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
