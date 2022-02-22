using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> Create(T entity, CancellationToken cancellationToken = default);
        Task<bool> Create(IEnumerable<T> entities, CancellationToken cancellationToken = default);

        Task<T> GetFirstOrDefault(Expression<Func<T, bool>> criteria, bool enableTracking = false, CancellationToken cancellationToken = default);
        Task<T> GetLastOrDefault(Expression<Func<T, bool>> criteria, bool enableTracking = false, CancellationToken cancellationToken = default);
        Task<List<T>> GetList(Expression<Func<T, bool>> criteria, bool enableTracking = false, CancellationToken cancellationToken = default);

        Task<bool> Update(T entity, CancellationToken cancellationToken = default);
        Task<bool> Update(Expression<Func<T, bool>> criteria, string propertyName, object value, CancellationToken cancellationToken = default);
        Task<bool> Update(IEnumerable<T> entities, CancellationToken cancellationToken = default);

        Task<bool> Delete(Expression<Func<T, bool>> criteria, CancellationToken cancellationToken = default);
        Task<bool> Delete(IEnumerable<T> entities, CancellationToken cancellationToken = default);

        Task<int> Count(Expression<Func<T, bool>> criteria, CancellationToken cancellationToken = default);
    }
}