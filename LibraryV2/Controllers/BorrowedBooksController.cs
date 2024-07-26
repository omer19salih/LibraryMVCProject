using MVC_Library_Otomasyon.DAL;
using MVC_Library_Otomasyon.Model;
using System.Linq;
using System.Web.Mvc;

namespace LibraryV2.Controllers
{
    [AllowAnonymous]
    public class BorrowedBooksController : Controller
    {
        private readonly Librarycontext _context;
        private readonly BorrowedBooksDAL _borrowedBooksDAL;
        private readonly BooksDAL _booksDAL;

        public BorrowedBooksController()
        {
            _context = new Librarycontext();
            _borrowedBooksDAL = new BorrowedBooksDAL();
            _booksDAL = new BooksDAL();
        }

        // GET: BorrowedBooks
        public ActionResult Index()
        {
            var model = _borrowedBooksDAL.GetAll(_context, x => x.BorrowedDate != null, "Books", "Members");
            return View(model);
        }

        // GET: BorrowedBooks/Edit/1
        public ActionResult Edit(int id)
        {
            var borrowedBook = _borrowedBooksDAL.GetById(_context, id);
            if (borrowedBook == null)
            {
                return HttpNotFound();
            }

            PopulateViewBag();
            return View(borrowedBook);
        }

        // POST: BorrowedBooks/Edit
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(BorrowedBooks entity)
        {
            if (ModelState.IsValid)
            {
                _borrowedBooksDAL.InsertorUpdate(_context, entity);
                _borrowedBooksDAL.save(_context);
                return RedirectToAction("Index");
            }

            PopulateViewBag();
            return View(entity);
        }

        // GET: BorrowedBookgive
        public ActionResult BorrowedBookgive()
        {
            PopulateViewBag();
            return View();
        }

        // POST: BorrowedBookgive
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult BorrowedBookgive(BorrowedBooks entity)
        {
            if (ModelState.IsValid)
            {
                var book = _booksDAL.GetById(_context, entity.BookId);
                if (book != null)
                {
                    if (book.StockQuantity >= entity.BookCount)
                    {
                        book.StockQuantity -= entity.BookCount;
                        _borrowedBooksDAL.InsertorUpdate(_context, entity);
                        _borrowedBooksDAL.save(_context);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Insufficient stock quantity.");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Selected book not found.");
                }
            }

            PopulateViewBag();
            return View(entity);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var borrowedBook = _borrowedBooksDAL.GetById(_context, id.Value);
            if (borrowedBook == null)
            {
                return HttpNotFound();
            }

            return View(borrowedBook);
        }


        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var borrowedBook = _borrowedBooksDAL.GetById(_context, id);
            if (borrowedBook != null)
            {
                _borrowedBooksDAL.Delete(_context, id);
                _borrowedBooksDAL.save(_context);
            }

            return RedirectToAction("Index");
        }

        private void PopulateViewBag()
        {
            ViewBag.MembersList = new SelectList(_context.Members, "Id", "FullName", "Select a member");
            ViewBag.BookList = new SelectList(_context.Books, "Id", "BookName", "Select a book");
        }
    }
}
