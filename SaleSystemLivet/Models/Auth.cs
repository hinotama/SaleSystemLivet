using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Livet;

namespace SaleSystemLivet.Models
{
    public partial class Auth : NotificationObject
    {
        public int AuthId { get; set; }
        public string Token { get; set; }
        public DateTime? Expiration { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
