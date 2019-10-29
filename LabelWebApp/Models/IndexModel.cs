// <copyright file="IndexModel.cs" company="PlanB. GmbH">
//     Copyright (c) PlanB. GmbH.  All rights reserved.
// </copyright>

namespace LabelWebApp.Models
{
    /// <summary>
    /// class IndexModel.
    /// </summary>
    public class IndexModel
    {
        /// <summary>
        /// Gets or sets the name value.
        /// </summary>
        /// <value>
        /// The name value.
        /// </value>
        public string NameValue { get; set; }

        /// <summary>
        /// Gets or sets the company value.
        /// </summary>
        /// <value>
        /// The company value.
        /// </value>
        public string CompanyValue { get; set; }

        /// <summary>
        /// Gets or sets the title value.
        /// </summary>
        /// <value>
        /// The title value.
        /// </value>
        public string TitleValue { get; set; }

        /// <summary>
        /// Gets or sets the email value.
        /// </summary>
        /// <value>
        /// The email value.
        /// </value>
        public string EmailValue { get; set; }

        /// <summary>
        /// Gets or sets the phone value.
        /// </summary>
        /// <value>
        /// The phone value.
        /// </value>
        public string PhoneValue { get; set; }

        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>
        /// The name of the file.
        /// </value>
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets the image object.
        /// </summary>
        /// <value>
        /// The image object.
        /// </value>
        public string imageObj { get; set; }

        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <value>
        /// The count.
        /// </value>
        public int Count { get; }

        /// <summary>
        /// Gets or sets the barcode value.
        /// </summary>
        /// <value>
        /// The barcode value.
        /// </value>
        public string BarcodeValue { get; set; }

        /// <summary>
        /// Gets or sets the picture value.
        /// </summary>
        /// <value>
        /// The picture value.
        /// </value>
        public string PictureValue { get; set; }
    }
}