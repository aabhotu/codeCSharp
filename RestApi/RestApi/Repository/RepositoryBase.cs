using Microsoft.EntityFrameworkCore;
using RestApi.Contracts;
using RestApi.Entities;
using System.Linq.Expressions;

namespace RestApi.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext repositoryContext { set; get; }
        public RepositoryBase(RepositoryContext repoContext)
        {
            repositoryContext = repoContext;
        }

        public IQueryable<T> All()
        {
           return repositoryContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> expression)
        {
            return repositoryContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)=> repositoryContext.Set<T>().Add(entity);

        public void Update(T entity)=> repositoryContext.Set<T>().Update(entity);

        public void Delete(T entity) => repositoryContext.Set<T>().Remove(entity);
        public void SaveChanges()
        {
            repositoryContext.SaveChanges();
        }

    }
}
