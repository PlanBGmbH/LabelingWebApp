using LabelWebApp.Models;
using NiceLabel.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace LabelWebApp.Controllers
{
    public class HomeController : Controller
    {
        IndexModel index = new IndexModel();
        public ActionResult Index(IndexModel index)
        {

            return View(index);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        private string GetImagePreviewAsBase64(string name, string company, string title, string email, string phone, string filename, string barcode, string picture)
        {
            IPrintEngine printEngine = PrintEngineFactory.PrintEngine;
            printEngine.Initialize();


            // Open label that will be printed
            ILabel label = printEngine.OpenLabel(@"C:\Users\PeterS\Desktop\Labels\GetLabelPreviewSample.nlbl");
            //Counts fields of labels
            int counter = label.Variables.Count;
            //string name1 = label.Variables.;
            picture = @"";
            // Setting of variables on the label
            label.Variables["Name"].SetValue(name);
            label.Variables["Company"].SetValue(company);
            label.Variables["Title"].SetValue(title);
            label.Variables["Email"].SetValue(email);
            label.Variables["Phone"].SetValue(phone);
            label.Variables["Barcode"].SetValue(barcode);
            label.Variables["picture"].SetValue(picture);

            // Set up LabelPreviewSettings to be passed to the GetLabelPreview method.
            ILabelPreviewSettings labelPreviewSettings = new LabelPreviewSettings();

            labelPreviewSettings.PreviewToFile = false;     // if true, result will be the file name, if false, result will be a byte array.
                                                          

            // CHeck how to print to byte array
            labelPreviewSettings.ImageFormat = "PNG";                                    // file format of graphics.  Valid formats: JPG, PNG, BMP.
            //labelPreviewSettings.Destination = filename;
            labelPreviewSettings.FormatPreviewSide = FormatPreviewSide.FrontSide;            // generates the front side of the label  
                                                                                           

            labelPreviewSettings.Width = 1000;
            labelPreviewSettings.Height = 1000;
            // Generate Preview File

            var rawImage = label.GetLabelPreview(labelPreviewSettings) as byte[];

            return Convert.ToBase64String(rawImage);
        }

        public ActionResult OnPostValues(IndexModel index)
        {
            index.NameValue = Request.Form["NameValue"];
            index.CompanyValue = Request.Form["CompanyValue"];
            index.TitleValue = Request.Form["TitleValue"];
            index.EmailValue = Request.Form["EmailValue"];
            index.PhoneValue = Request.Form["PhoneValue"];
            index.FileName = "asd";

            //index.FileName = Request.Form["FileName"];

            index.imageObj = GetImagePreviewAsBase64(index.NameValue, index.CompanyValue, index.TitleValue, index.EmailValue, index.PhoneValue, index.FileName, index.BarcodeValue, index.PictureValue);
            return View("../Home/Index", index);

        }
    }
}