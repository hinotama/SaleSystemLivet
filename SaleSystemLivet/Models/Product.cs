using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

using Livet;
using SaleSystemLivet.Helpers;

namespace SaleSystemLivet.Models
{
    public partial class Product : ValidationBase
    {
        public Product()
        {
            Order = new HashSet<Order>();
        }

        public int ProductId { get; set; }

        private string _ProductName;
        [Display(Name = "Product Name")]
        [StringLength(20, ErrorMessage = "Product Name must not longer than 20 characters")]
        [Required]
        public string ProductName
        {
            get
            {
                return _ProductName;
            }
            set
            {
                if (_ProductName != value)
                {
                    _ProductName = value;
                    ValidateProperty(value);
                    base.RaisePropertyChanged("ProductName");
                }
            }
        }

        private string _Description;
        [Display(Name = "Description")]
        [Required]
        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                if (_Description != value)
                {
                    _Description = value;
                    ValidateProperty(value);
                    base.RaisePropertyChanged("Description");
                }
            }
        }

        private string _Unit;
        [Display(Name = "Unit")]
        [StringLength(10, ErrorMessage = "Unit must not longer than 10 characters")]
        [Required]
        public string Unit
        {
            get
            {
                return _Unit;
            }
            set
            {
                if (_Unit != value)
                {
                    _Unit = value;
                    ValidateProperty(value);
                    base.RaisePropertyChanged("Unit");
                }
            }
        }

        private decimal? _Price;
        [Display(Name = "Price")]
        [RegularExpression(@"^\d+\.?\d*$", ErrorMessage = "Please enter a valid number")]
        [Required]
        public decimal? Price
        {
            get
            {
                return _Price;
            }
            set
            {
                if (_Price != value)
                {
                    _Price = value;
                    ValidateProperty(value);
                    base.RaisePropertyChanged("Price");
                }
            }
        }

        public virtual ICollection<Order> Order { get; set; }
    }
}
