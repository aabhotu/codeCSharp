using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq.Expressions;

namespace RestApi.Contracts
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> All(); 
        IQueryable<T> Find(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void SaveChanges();
    }
}
