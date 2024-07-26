using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Library_Otomasyon.Interfaces
{
    public interface IGenericRepository<TContext,TEntitiy>
        where TContext : DbContext, new()
        where TEntitiy : class, new()
    {   
        List<TEntitiy> GetAll(TContext context,Expression<Func<TEntitiy,bool>> filter=null, params  string[] tbl);//null ise tüm listeyi getir 
        TEntitiy GetByFilter(TContext context,Expression<Func<TEntitiy,bool>>filter, params string []  tbl);
        TEntitiy GetById(TContext context,int? id);
        void InsertorUpdate(TContext context,TEntitiy entitiy);
        void Delete(TContext context,Expression<Func<TEntitiy,bool>>filter);


        void save(TContext context);
    }
}
