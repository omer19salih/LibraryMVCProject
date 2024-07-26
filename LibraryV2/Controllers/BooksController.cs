using MVC_Library_Otomasyon.DAL;
using MVC_Library_Otomasyon.Model;   
using System.Linq;
using System.Web.Mvc;

namespace LibraryV2.Controllers
{

    [AllowAnonymous]
    public class BooksController : Controller
    {
        Librarycontext context = new Librarycontext();
        BooksDAL BooksDAL = new BooksDAL();

        public ActionResult Index()
        {
            var model = context.Books.Include("BookGenres").ToList();
            return View(model);
        }

        public ActionResult Add()
        {
            ViewBag.list = new SelectList(context.BookGenres, "Id", "Genre");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Books entity)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.list = new SelectList(context.BookGenres, "Id", "Genre");
                return View(entity);
            }

            BooksDAL.InsertorUpdate(context, entity);
            BooksDAL.save(context);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id )
        {
            if(id == null)
            {
                return HttpNotFound();
            }
            ViewBag.list = new SelectList(context.BookGenres, "Id", "Genre");
             var model = BooksDAL.GetByFilter(context,x=>x.Id == id,"BookGenres");
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Books entity)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.list = new SelectList(context.BookGenres, "Id", "Genre");
                return View(entity);
            }

            BooksDAL.InsertorUpdate(context, entity);
            BooksDAL.save(context);
            return RedirectToAction("Index");
        }
        public ActionResult Details(int? id)
        {
            var model = BooksDAL.GetByFilter(context, x => x.Id == id, "BookGenres");
            return View(model);
    
        
        
        }
        public ActionResult Delete(int ? id)
        
        {
            if (id == null) 
            {
                return HttpNotFound();
            }
            BooksDAL.Delete(context,x=> x.Id == id);
            BooksDAL.save(context);
            return RedirectToAction("Index");
        }

    }
}
