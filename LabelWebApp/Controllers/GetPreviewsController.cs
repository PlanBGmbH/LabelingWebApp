// <copyright file="GetPreviewsController.cs" company="PlanB. GmbH">
//     Copyright (c) PlanB. GmbH.  All rights reserved.
// </copyright>

namespace LabelWebApp.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    /// <summary>
    /// Class GetPreviewsController.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class GetPreviewsController : Controller
    {
        private static LabelStorageEntities db = new LabelStorageEntities();

        // GET: GetPreviews/Details/5

        /// <summary>
        /// Detailses the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="id2">The id2.</param>
        /// <returns>getLabelPreviewview.</returns>
        public static GetPreview Details(string id, int id2)
        {
            GetPreview getLabelPreviewView = db.GetPreviews.Find(id, id2);
            return getLabelPreviewView;
        }

        // GET: GetPreviews

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>View.</returns>
        public ActionResult Index()
        {
            return this.View(db.GetPreviews.ToList());
        }

        // GET: GetPreviews/Create

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>View.</returns>
        public ActionResult Create()
        {
            return this.View();
        }

        // POST: GetPreviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        /// <summary>
        /// Creates the specified get preview.
        /// </summary>
        /// <param name="getPreview">The get preview.</param>
        /// <returns>view Index.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Artikelname,Artikelnummer,Artikeltyp,Kundenlogonummer,Artikeldaten,EtikettenVariante,Kundenartikelnummer,Barcode,Etikett,Logo")] GetPreview getPreview)
        {
            if (this.ModelState.IsValid)
            {
                db.GetPreviews.Add(getPreview);
                db.SaveChanges();
                return this.RedirectToAction("Index");
            }

            return this.View(getPreview);
        }

        // GET: GetPreviews/Edit/5

        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>HttpStatus.</returns>
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            GetPreview getPreview = db.GetPreviews.Find(id);
            if (getPreview == null)
            {
                return this.HttpNotFound();
            }

            return this.View(getPreview);
        }

        // POST: GetPreviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        /// <summary>
        /// Edits the specified get preview.
        /// </summary>
        /// <param name="getPreview">The get preview.</param>
        /// <returns>View Index or getpreview.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Artikelname,Artikelnummer,Artikeltyp,Kundenlogonummer,Artikeldaten,EtikettenVariante,Kundenartikelnummer,Barcode,Etikett,Logo")] GetPreview getPreview)
        {
            if (this.ModelState.IsValid)
            {
                db.Entry(getPreview).State = EntityState.Modified;
                db.SaveChanges();
                return this.RedirectToAction("Index");
            }

            return this.View(getPreview);
        }

        // GET: GetPreviews/Delete/5

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Http status or view getPreview.</returns>
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            GetPreview getPreview = db.GetPreviews.Find(id);
            if (getPreview == null)
            {
                return this.HttpNotFound();
            }

            return this.View(getPreview);
        }

        // POST: GetPreviews/Delete/5

        /// <summary>
        /// Deletes the confirmed.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>View Index.</returns>
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            GetPreview getPreview = db.GetPreviews.Find(id);
            db.GetPreviews.Remove(getPreview);
            db.SaveChanges();
            return this.RedirectToAction("Index");
        }

        /// <summary>
        /// Releases unmanaged resources and optionally releases managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
