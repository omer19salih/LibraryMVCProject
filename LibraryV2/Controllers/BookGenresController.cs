using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_Library_Otomasyon.Model;

namespace LibraryV2.Controllers
{
    [AllowAnonymous]
    public class BookGenresController : Controller
    {
        private Librarycontext db = new Librarycontext();

        // GET: BookGenres
        public ActionResult Index()
        {
            return View(db.BookGenres.ToList());
        }

        // GET: BookGenres/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookGenres bookGenres = db.BookGenres.Find(id);
            if (bookGenres == null)
            {
                return HttpNotFound();
            }
            return View(bookGenres);
        }

        // GET: BookGenres/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookGenres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Genre,Description")] BookGenres bookGenres)
        {
            if (ModelState.IsValid)
            {
                db.BookGenres.Add(bookGenres);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookGenres);
        }

        // GET: BookGenres/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookGenres bookGenres = db.BookGenres.Find(id);
            if (bookGenres == null)
            {
                return HttpNotFound();
            }
            return View(bookGenres);
        }

        // POST: BookGenres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Genre,Description")] BookGenres bookGenres)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookGenres).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookGenres);
        }

        // GET: BookGenres/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookGenres bookGenres = db.BookGenres.Find(id);
            if (bookGenres == null)
            {
                return HttpNotFound();
            }
            return View(bookGenres);
        }

        // POST: BookGenres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookGenres bookGenres = db.BookGenres.Find(id);
            db.BookGenres.Remove(bookGenres);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

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
