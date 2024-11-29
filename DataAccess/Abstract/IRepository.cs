using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
    //generic constraint
    //class:referans tip, IEntity: IEntity olabilir veya implemente eden bir nesne olabilir.
{
    public interface IRepository<T>where T: class,IEntity,new()
    {
        T Get(Expression<Func<T, bool>> filter);
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
