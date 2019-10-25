// <copyright file="HomeController.cs" company="PlanB. GmbH">
//     Copyright (c) PlanB. GmbH.  All rights reserved.
// </copyright>

namespace LabelWebApp.Controllers
{
    using System;
    using System.Web.Mvc;

    using LabelWebApp.Models;
    using Microsoft.Ajax.Utilities;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using NiceLabel.SDK;

    /// <summary>
    /// class HomeController.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class HomeController : Controller
    {
        IndexModel index = new IndexModel();

        /// <summary>
        /// Indexes the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>Index View.</returns>
        public ActionResult Index(IndexModel index)
        {
            return this.View(index);
        }

        /// <summary>
        /// Abouts this instance.
        /// </summary>
        /// <returns>About view.</returns>
        public ActionResult About()
        {
            this.ViewBag.Message = "Your application description page.";

            return this.View();
        }

        /// <summary>
        /// Contacts this instance.
        /// </summary>
        /// <returns>Contact view.</returns>
        public ActionResult Contact()
        {
            this.ViewBag.Message = "Your contact page.";

            return this.View();
        }

        /// <summary>
        /// Gets the image preview as base64.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="company">The company.</param>
        /// <param name="title">The title.</param>
        /// <param name="email">The email.</param>
        /// <param name="phone">The phone.</param>
        /// <param name="filename">The filename.</param>
        /// <param name="barcode">The barcode.</param>
        /// <param name="picture">The picture.</param>
        /// <returns>image bitmap for preview.</returns>
        private string GetImagePreviewAsBase64(string name, string company, string title, string email, string phone, string filename, string barcode, string picture)
        {
            // Create Printengine object
            IPrintEngine printEngine = PrintEngineFactory.PrintEngine;

            // initialice printengine object
            printEngine.Initialize();

            // Open label that will be printed
            ILabel label = printEngine.OpenLabel(@"C:\Users\PeterS\Desktop\Labels\GetLabelPreviewSample.nlbl");

            // get the location of the image
            picture = string.Empty;

            // sets the image in the label
            label.Variables["picture"].SetValue(picture);

            // getting the data from db
            GetPreview data = GetPreviewsController.Details("qwertzu.,mnbvcdftgzh", 0);

            // serializing the data
            string serializedData = JsonConvert.SerializeObject(data);

            // convert the data to an JObject
            JObject jObjectData = JObject.Parse(serializedData);

            // Goes throuw every element on the label and fills it
            foreach (var item in label.Variables)
            {
                // checks if the right label is in the db object
                if (jObjectData.ContainsKey(item.Name))
                {
                    string value = jObjectData[item.Name].Value<string>();
                    item.SetValue(value);
                }
            }

            // Set up LabelPreviewSettings to be passed to the GetLabelPreview method.
            ILabelPreviewSettings labelPreviewSettings = new LabelPreviewSettings();

            // if true, result will be the file name, if false, result will be a byte array.
            labelPreviewSettings.PreviewToFile = false;

            // fileformat for preview
            labelPreviewSettings.ImageFormat = "PNG";

            // generates the front side of the label
            labelPreviewSettings.FormatPreviewSide = FormatPreviewSide.FrontSide;

            // set the dimensions of the preview
            labelPreviewSettings.Width = 500;
            labelPreviewSettings.Height = 500;

            // Generate Preview File as bytemap
            var rawImage = label.GetLabelPreview(labelPreviewSettings) as byte[];

            // returns the bytemap
            return Convert.ToBase64String(rawImage);
        }

        /// <summary>
        /// Validats the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="address">The address.</param>
        /// <param name="barcode">The barcode.</param>
        /// <returns>data from db.</returns>
        private string Validat(string name, string address, string barcode)
        {
            string data = string.Empty;
            if (name.IsNullOrWhiteSpace() && address.IsNullOrWhiteSpace() && barcode.IsNullOrWhiteSpace())
            {
                data = "There are missing Values";
            }
            else
            {
                data = name;
            }

            return data;
        }

        /// <summary>
        /// Called when [post values].
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>View Index.</returns>
        private ActionResult OnPostValues(IndexModel index)
        {
            index.NameValue = this.Request.Form["NameValue"];
            index.CompanyValue = this.Request.Form["CompanyValue"];
            index.TitleValue = this.Request.Form["TitleValue"];
            index.EmailValue = this.Request.Form["EmailValue"];
            index.PhoneValue = this.Request.Form["PhoneValue"];
            index.FileName = "asd";

            index.imageObj = this.GetImagePreviewAsBase64(index.NameValue, index.CompanyValue, index.TitleValue, index.EmailValue, index.PhoneValue, index.FileName, index.BarcodeValue, index.PictureValue);
            return this.View("../Home/Index", index);
        }
    }
}