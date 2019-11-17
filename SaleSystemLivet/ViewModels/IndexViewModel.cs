using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

using Livet;
using Livet.Commands;
using Livet.Messaging;
using Livet.Messaging.IO;
using Livet.EventListeners;
using Livet.Messaging.Windows;

using SaleSystemLivet.Models;
using System.Windows.Controls;
using SaleSystemLivet.Localization;
using System.Collections.ObjectModel;
using System.Globalization;

namespace SaleSystemLivet.ViewModels
{
    public class IndexViewModel : ViewModel
    {
        // Some useful code snippets for ViewModel are defined as l*(llcom, llcomn, lvcomm, lsprop, etc...).

        #region Parameter definition
        private Model _Model;
        #endregion Parameter definition

        #region Constructor
        public IndexViewModel()
        {
            //Modelインスタンス作成
            _Model = new Model();

            _Model.Username = "Administrator";
            //_Model.Username = Application.Current.Properties["username"].ToString();

            SetupLanguage();

            RaisePropertyChanged("Model");
        }
        #endregion Constructor

        #region Model property definition
        public Model Model
        {
            get
            {
                return _Model;
            }
            set
            {
                if (_Model == value)
                {
                    return;
                }
                _Model = value;
                RaisePropertyChanged("Model");
            }
        }
        #endregion Model property definition

        #region LanguageChangeCommand
        private ListenerCommand<Language> _ChangeLanguageCommand;

        public ListenerCommand<Language> ChangeLanguageCommand
        {
            get
            {
                if (_ChangeLanguageCommand == null)
                {
                    _ChangeLanguageCommand = new ListenerCommand<Language>(ChangeLanguage);
                }
                return _ChangeLanguageCommand;
            }
        }

        private static void ChangeLanguage(Language language)
        {
            TranslationSource.Instance.CurrentCulture = new CultureInfo(language.LanguageCode);
        }
        #endregion LanguageChangeCommand

        #region Private functions
        private void SetupLanguage()
        {
            _Model.LanguageList = new ObservableCollection<Language>()
            {
                new Language()
                {
                LanguageId = 1,
                LanguageName = "English",
                LanguageCode = "en-US"
                },
                new Language()
                {
                LanguageId = 2,
                LanguageName = "日本語",
                LanguageCode = "ja-JP"
                }
            };
        }
        #endregion Private functions

        // This method would be called from View, when ContentRendered event was raised.
        //public void Initialize()
        //{
        //}
    }
}
