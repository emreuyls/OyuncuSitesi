using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Web.DataAccess.Abstract
{
    public interface IBaseRepository<T> where T:class
    {
        T Get(int id);
        IQueryable<T> GetAll();
        IQueryable<T> Find(Expression<Func<T, bool>> expression);
        int  Create(T entity);
        int Update(T entity);
        int Delete(T entity);
        int save();

        //TODO: burada kullanıcı adı ve eposta kontrolu için bir yer oluştur
    }
}
