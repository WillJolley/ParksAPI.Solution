using System.Linq.Expressions;
using ParksAPI.Interfaces;
using ParksAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ParksAPI.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ParksAPIContext RepositoryContext { get; set; }

        public RepositoryBase(ParksAPIContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public IQueryable<T> FindAll()
        {
            return RepositoryContext.Set<T>()
            .AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return RepositoryContext.Set<T>()
            .Where(expression)
            .AsNoTracking();
        }
    }
}