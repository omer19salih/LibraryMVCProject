using MVC_Library_Otomasyon.Model;
using MVC_Library_Otomasyon.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace LibraryV2.Controllers
{ [AllowAnonymous]
    public class MembersController : Controller
    {
        // GET: Members
        Librarycontext context = new Librarycontext();
        MembersDAL membersDAL = new MembersDAL();
        //UsersDAL UsersDal = new UsersDAL();

        public ActionResult Index()
        {
            //var model = UsersDal.GetAll(context);
            var model = membersDAL.GetAll(context);
            foreach(var item in model)
            {
                if (!string.IsNullOrEmpty(item.ImagePath))
                {
                    item.ImagePath = "/Images/" + item.ImagePath;   
                }
                else
                {
                    item.ImagePath = "/Images/no-image.jpg";
                     
                }
            }
            return View(model);
        }


        public ActionResult Add() 
        { 
            return View();
        }
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Add(Members entity, HttpPostedFileBase ImagePath)
        {

            if (ModelState.IsValid)
            {
                if (ImagePath != null && ImagePath.ContentLength > 0) 
                {
                    var Images = Path.GetFileName(ImagePath.FileName);
                    string path = Path.Combine(Server.MapPath("~/Images"), Images);

                    if (System.IO.File.Exists(path)==false)
                    {
                        ImagePath.SaveAs(path);

                    }
                    entity.ImagePath = "~/Images" + Images;
                }
                membersDAL.InsertorUpdate(context, entity);
                membersDAL.save(context);

                return RedirectToAction("Index");
            }



          return View(entity);
        }


        public ActionResult Edit(int? id)

        {
            if (id==null)
            {
                return HttpNotFound();

            }


            var model = membersDAL.GetByFilter(context,x=>x.Id == id);   
            return View(model);

        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(Members entity, HttpPostedFileBase ImagePath)
        {

            if (ModelState.IsValid)
            {
                var model = membersDAL.GetByFilter(context, x => x.Id == entity.Id);
                entity.ImagePath=model.ImagePath;
                if (ImagePath != null && ImagePath.ContentLength > 0)
                {
                    var Images = Path.GetFileName(ImagePath.FileName);
                    string path = Path.Combine(Server.MapPath("~/Images"), Images);

                    if (System.IO.File.Exists(path) == false)
                    {
                        ImagePath.SaveAs(path);

                    }
                    entity.ImagePath = "~/Images" + Images;
                }
                membersDAL.InsertorUpdate(context, entity);
                membersDAL.save(context);

                return RedirectToAction("Index");
            }



            return View(entity);
        }



        public ActionResult Delete(int? id) 
        {

            if (id==null) 
            {
               return HttpNotFound();
            }
           membersDAL.Delete(context,x=>x.Id == id);
            membersDAL.save(context);
            return RedirectToAction("Index");
        }

    }
}