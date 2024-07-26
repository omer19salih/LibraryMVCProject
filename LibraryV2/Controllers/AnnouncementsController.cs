using MVC_Library_Otomasyon.Model;
using MVC_Library_Otomasyon.Validations;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace LibraryV2.Controllers
{
    [AllowAnonymous]
    public class AnnouncementsController : Controller
    {
        private Librarycontext db = new Librarycontext();

        // GET: Announcements
        public ActionResult Index()
        {
            return View(db.Announcements.ToList());
        }

        // GET: Announcements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Announcements announcement = db.Announcements.Find(id);
            if (announcement == null)
            {
                return HttpNotFound();
            }
            return View(announcement);
        }

        // GET: Announcements/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Announcements/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Announcement,Description,Date")] Announcements announcement)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Create an instance of the validator
                    var validator = new AnnouncementsValidator();
                    var result = validator.Validate(announcement);

                    if (!result.IsValid)
                    {
                        // Log validation errors
                        foreach (var error in result.Errors)
                        {
                            // Example logging (replace with your logging mechanism)
                            Console.WriteLine($"Property: {error.PropertyName}, Error: {error.ErrorMessage}");
                            ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                        }

                        // Return the view with validation errors
                        return View(announcement);
                    }

                    // If valid, save to database
                    db.Announcements.Add(announcement);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    // Handle exception
                    Console.WriteLine(ex.Message);
                    ModelState.AddModelError("", "An error occurred while creating the announcement.");
                    return View(announcement);
                }
            }

            return View(announcement);
        }

        // GET: Announcements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Announcements announcement = db.Announcements.Find(id);
            if (announcement == null)
            {
                return HttpNotFound();
            }
            return View(announcement);
        }

        // POST: Announcements/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Announcement,Description,Date")] Announcements announcement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(announcement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(announcement);
        }

        // GET: Announcements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Announcements announcement = db.Announcements.Find(id);
            if (announcement == null)
            {
                return HttpNotFound();
            }
            return View(announcement);
        }

        // POST: Announcements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Announcements announcement = db.Announcements.Find(id);
            db.Announcements.Remove(announcement);
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
