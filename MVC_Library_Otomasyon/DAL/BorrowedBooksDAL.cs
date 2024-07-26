using MVC_Library_Otomasyon.Model;
using MVC_Library_Otomasyon.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Library_Otomasyon.DAL
{
    public class BorrowedBooksDAL:GenericRepository<Librarycontext ,BorrowedBooks>
    {
        public void Delete(Librarycontext context, int id)
        {
            var entity = context.BorrowedBooks.Find(id);
            if (entity != null)
            {
                context.BorrowedBooks.Remove(entity);
                context.SaveChanges();
            }
        }

    }
}
