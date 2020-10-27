
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Web.DataAccess.Abstract;

namespace Web.DataAccess.EntityFramework
{
    public class EFBaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected DbContext context;
        public EFBaseRepository(DbContext ctx)
        {
            context = ctx;
        }
        public int Create(T entity)
        {
            context.Set<T>().Add(entity);
            return save();
        }

        public int Delete(T entity)
        {
            context.Set<T>().Remove(entity);
            return save();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> expression)
        {

            return context.Set<T>().Where(expression);
        }

        public T Get(int id)
        {
            return context.Set<T>().Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return context.Set<T>();
        }

        public int save()
        {
            return context.SaveChanges();
        }
     
        public  int Update(T entity)
        {
            context.Entry<T>(entity).State = EntityState.Modified;
            return save();
        }
    }
}
