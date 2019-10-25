// <copyright file="FilterConfig.cs" company="PlanB. GmbH">
//     Copyright (c) PlanB. GmbH.  All rights reserved.
// </copyright>

namespace LabelWebApp
{
    using System.Web.Mvc;

    /// <summary>
    /// Class FilterConfig.
    /// </summary>
    public class FilterConfig
    {
        /// <summary>
        /// Registers the global filters.
        /// </summary>
        /// <param name="filters">The filters.</param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
