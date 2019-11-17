using System;
using System.Collections.Generic;

namespace SaleSystemData.Models
{
    public partial class User
    {
        public User()
        {
            Auth = new HashSet<Auth>();
            Order = new HashSet<Order>();
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Auth> Auth { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
