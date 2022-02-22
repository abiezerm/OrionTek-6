using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Repository.EFCore.Repositories
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext Context;
        public RepositoryBase(ApplicationDbContext context)
        {
            Context = context;
        }

        public Task<int> Count(Expression<Func<T, bool>> criteria, CancellationToken cancellationToken = default) 
            => Task.FromResult(Context.Set<T>().AsNoTracking().Count(criteria));

        public Task<T> Create(T entity, CancellationToken cancellationToken = default)
        {
            EntityEntry<T> Result = Context.Set<T>().Add(entity);
            Context.SaveChanges();
            return Task.FromResult(Result.Entity);
        }

        public Task<bool> Create(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            Context.Set<T>().AddRange(entities);
            return Task.FromResult(Context.SaveChanges() != 0);
        }

        public Task<bool> Delete(Expression<Func<T, bool>> criteria, CancellationToken cancellationToken = default)
        {
            Context.Set<T>().Remove(Context.Set<T>().FirstOrDefault(criteria));
            return Task.FromResult(Context.SaveChanges() != 0);
        }

        public Task<bool> Delete(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            Context.Set<T>().RemoveRange(entities);
            return Task.FromResult(Context.SaveChanges() != 0);
        }

        public Task<T> GetFirstOrDefault(Expression<Func<T, bool>> criteria, bool enableTracking = false, CancellationToken cancellationToken = default)
        {
            if (enableTracking)
                return Task.FromResult(Context.Set<T>().FirstOrDefault(criteria));
            else
                return Task.FromResult(Context.Set<T>().AsNoTracking().FirstOrDefault(criteria));
        }

        public Task<T> GetFirstOrDefault(Expression<Func<T, bool>> criteria, string include1, bool enableTracking = false, CancellationToken cancellationToken = default)
        {
            if (enableTracking)
                return Task.FromResult(Context.Set<T>().Include(include1).FirstOrDefault(criteria));
            else
                return Task.FromResult(Context.Set<T>().Include(include1).AsNoTracking().FirstOrDefault(criteria));
        }

        public Task<T> GetLastOrDefault(Expression<Func<T, bool>> criteria, bool enableTracking = false, CancellationToken cancellationToken = default)
        {
            if (enableTracking)
                return Task.FromResult(Context.Set<T>().LastOrDefault(criteria));
            else
                return Task.FromResult(Context.Set<T>().AsNoTracking().LastOrDefault(criteria));
        }

        public Task<T> GetLastOrDefault(Expression<Func<T, bool>> criteria, string include1, bool enableTracking = false, CancellationToken cancellationToken = default)
        {
            if (enableTracking)
                return Task.FromResult(Context.Set<T>().Include(include1).LastOrDefault(criteria));
            else
                return Task.FromResult(Context.Set<T>().Include(include1).AsNoTracking().LastOrDefault(criteria));
        }

        public Task<List<T>> GetList(Expression<Func<T, bool>> criteria, bool enableTracking = false, CancellationToken cancellationToken = default)
        {
            if (enableTracking)
                return Task.FromResult(Context.Set<T>().Where(criteria).ToList());
            else
                return Task.FromResult(Context.Set<T>().AsNoTracking().Where(criteria).ToList());
        }

        public Task<List<T>> GetList(Expression<Func<T, bool>> criteria, string include1, bool enableTracking = false, CancellationToken cancellationToken = default)
        {
            if (enableTracking)
                return Task.FromResult(Context.Set<T>().Include(include1).Where(criteria).ToList());
            else
                return Task.FromResult(Context.Set<T>().Include(include1).AsNoTracking().Where(criteria).ToList());
        }

        public Task<bool> Update(T entity, CancellationToken cancellationToken = default)
        {
            Context.Set<T>().Update(entity);
            return Task.FromResult(Context.SaveChanges() != 0);
        }

        public Task<bool> Update(Expression<Func<T, bool>> criteria, string propertyName, object value, CancellationToken cancellationToken = default)
        {
            Context!.Entry(Context.Set<T>().FirstOrDefault(criteria)).Property(propertyName).CurrentValue = value;
            return Task.FromResult(Context.SaveChanges() != 0);
        }

        public Task<bool> Update(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            Context.Set<T>().UpdateRange(entities);
            return Task.FromResult(Context.SaveChanges() != 0);
        }
    }
}