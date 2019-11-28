using System.Collections.Generic;
using ApplicationCore.Interfaces;
namespace ApplicationCore.Interfaces
{
    public interface IRepository<T> where T : IAggregateRoot
    {
        T GetBy(string id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(ISpecification<T> spec);

        void Add(T entity);
        void Remove(T entity);

        void Update(T entity);

        void AddRange(IEnumerable<T> entities);
        void RemoveRange(IEnumerable<T> entities);

        int Count();
    }
}