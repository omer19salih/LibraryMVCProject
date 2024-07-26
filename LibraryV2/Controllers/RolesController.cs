using MVC_Library_Otomasyon.DAL;
using MVC_Library_Otomasyon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryV2.Controllers
{
    [AllowAnonymous]
    public class RolesController : Controller
    {
        // GET: Roles
        Librarycontext context= new Librarycontext();
        RolesDAL RolesDAL = new RolesDAL();

        public ActionResult Index()
        {
            var model =  RolesDAL.GetAll(context);
            return View(model);
        }

        public ActionResult Add() 
        { 
           return View();
        }
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Add(Roles entity)
        {
            if (!ModelState.IsValid) 
            { 
                return View( entity);
          
            
            }

            RolesDAL.InsertorUpdate(context, entity);
            RolesDAL.save(context); 
            return RedirectToAction("Index");

        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            { 
               return HttpNotFound("Id Degeri girilmedi ");
            }

            var model =RolesDAL.GetByFilter(context,x=>x.Id == id);
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(Roles entity)
        {
            if (!ModelState.IsValid)
            {
                return View(entity);


            }

            RolesDAL.InsertorUpdate(context, entity);
            RolesDAL.save(context);
            return RedirectToAction("Index");

        }


        public ActionResult Delete(int id)
        {
            RolesDAL.Delete(context,x=> x.Id == id);
            RolesDAL.save(context);
            return RedirectToAction("Index");
        }



    }
}