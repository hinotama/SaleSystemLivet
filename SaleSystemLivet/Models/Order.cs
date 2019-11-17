﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Livet;

namespace SaleSystemLivet.Models
{
    public partial class Order : NotificationObject
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int? Quantity { get; set; }

        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
