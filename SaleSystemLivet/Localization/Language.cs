using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Livet;

namespace SaleSystemLivet.Localization
{
    public class Language : NotificationObject
    {
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
        public string LanguageCode { get; set; }
    }
}
