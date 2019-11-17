using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Livet;
using SaleSystemLivet.Localization;

namespace SaleSystemLivet.Models
{
    public class Model : NotificationObject
    {
        #region ViewModel Property
        private INotifyPropertyChanged _ViewModel = default(INotifyPropertyChanged);
        public INotifyPropertyChanged ViewModel
        {
            get { return _ViewModel; }
            set
            {
                if (value != _ViewModel)
                {
                    _ViewModel = value;
                    RaisePropertyChanged();
                }
            }
        }
        #endregion ViewModel Property

        public string Username { get; set; }

        public ObservableCollection<Language> LanguageList { get; set; }
    }
}
