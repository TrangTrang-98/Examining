using ApplicationCore.Interfaces;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq; // ToList() thuoc Linq

namespace Infrastructure.Persistence.Repository
{
    public class EFRepository<T> : IRepository<T> where T : class, IAggregateRoot // class ???
    {
        private readonly DbContext _context;

        public EFRepository(DbContext context)
        {
            _context = context;
        }

        protected DbContext Context => _context;

        public T GetBy(string id)
        {
            return _context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public IEnumerable<T> Find(ISpecification<T> spec)
        {
            return ApplySpecification(_context.Set<T>().AsQueryable(), spec);
    
        }

        private IEnumerable<T> ApplySpecification(IQueryable<T> query, ISpecification<T> spec)
        {
            if (spec.Criteria != null)
                query = query.Where(spec.Criteria);

            if (spec.IsPaginated)
                query = query.Skip((spec.PageIndex - 1) * spec.PageSize).Take(spec.PageSize);

            return query.ToList();
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _context.Attach(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }


        public int Count()
        {
            return _context.Set<T>().Count();
        }
    }
}