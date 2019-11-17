using Newtonsoft.Json;
using SaleSystemWPF.Localization;
using SaleSystemWPF.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace SaleSystemWPF.Models
{
    public partial class Order : INotifyPropertyChanged
    {
        private readonly ProductService productService = new ProductService();

        int _ProductId;
        string _Description;
        string _Unit;
        double? _Price;
        int? _Quantity;
        double? _TotalPrice;

        public int OrderId { get; set; }
        public int UserId { get; set; }

        public virtual Product Product { get; set; }
        public virtual User User { get; set; }

        public int ProductId
        {
            get
            {
                return _ProductId;
            }
            set
            {
                if (_ProductId != value)
                {
                    _ProductId = value;
                    RaisePropertyChanged("ProductId");
                    RefreshData(_ProductId);
                    CalculateTotalPrice(_Price, _Quantity);
                }
            }
        }

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
                    RaisePropertyChanged("Description");
                }
            }
        }

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
                    RaisePropertyChanged("Unit");
                }
            }
        }

        public double? Price
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
                    RaisePropertyChanged("Price");
                }
            }
        }

        public int? Quantity
        {
            get
            {
                return _Quantity;
            }
            set
            {
                if (_Quantity != value)
                {
                    _Quantity = value;
                    RaisePropertyChanged("Quantity");
                    CalculateTotalPrice(_Price, _Quantity);
                }
            }
        }

        public double? TotalPrice
        {
            get
            {
                return _TotalPrice;
            }
            set
            {
                if (_TotalPrice != value)
                {
                    _TotalPrice = value;
                    RaisePropertyChanged("TotalPrice");
                }
            }
        }

        // Private Methods
        private async void RefreshData(int _ProductId)
        {
            // Function call the API to get Product.
            Product product = await productService.GetProduct(_ProductId);
            this.Description = (product == null ? "" : product.Description);
            this.Unit = (product == null ? "" : product.Unit);
            this.Price = (product == null ? 0 : product.Price);
        }

        private void CalculateTotalPrice(double? _Price, int? _Quantity)
        {
            this.TotalPrice = _Price * _Quantity;
        }

        internal void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
