using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabelWebApp.Models
{
    public class IndexModel
    {
        public string NameValue { get; set; }
        public string CompanyValue { get; set; }
        public string TitleValue { get; set; }
        public string EmailValue { get; set; }
        public string PhoneValue { get; set; }
        public string FileName { get; set; }
        public string imageObj { get; set; }
        public int Count { get; }
        public string BarcodeValue { get; set; }
        public string PictureValue { get; set; }
    }
}