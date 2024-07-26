using MVC_Library_Otomasyon.DAL;
using MVC_Library_Otomasyon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace LibraryV2.Controllers
{
    [AllowAnonymous]
    public class UserRolesController : Controller
    {
        private readonly Librarycontext context = new Librarycontext();
        private readonly UserRolesDAL userRolesDAL = new UserRolesDAL();

        public ActionResult Index()
        {
            // Gerçek veri alma işlemini uygulayın
            List<UserRoles> userRoles = context.UserRoles.ToList();

            if (userRoles == null)
            {
                throw new Exception("userRoles is null");
            }

            return View(userRoles);
        }

        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.list = new SelectList(context.Roles, "Id", "RoleName");
            return View(new UserRoles());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(UserRoles userRole)
        {
            if (ModelState.IsValid)
            {
                context.UserRoles.Add(userRole);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.list = new SelectList(context.Roles, "Id", "RoleName");
            return View(userRole);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var userRole = context.UserRoles.Find(id);
            if (userRole == null)
            {
                return HttpNotFound("UserRole not found");
            }

            ViewBag.list = new SelectList(context.Roles, "Id", "RoleName");

            return View(userRole);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserRoles userRole)
        {
            if (ModelState.IsValid)
            {
                context.Entry(userRole).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.list = new SelectList(context.Roles, "Id", "RoleName");
            return View(userRole);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var userRole = context.UserRoles.Find(id);
            if (userRole == null)
            {
                return HttpNotFound("UserRole not found");
            }

            context.UserRoles.Remove(userRole);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
