using Microsoft.EntityFrameworkCore;
using OA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OA.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationContext _context;
        private DbSet<T> _entities;
        string _errorMessage = string.Empty;

        public Repository( ApplicationContext context)
        {
            this._context = context;
            _entities = context.Set<T>();
        
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public T Get(long id)
        {
            return _entities.SingleOrDefault(x => x.Id == id);
        
        }
        public void Insert(T entity)
        {
            if (entity == null) throw new ArgumentException($"{entity}");
            this._entities.Add(entity);
            _context.SaveChanges();

        }

        public void Update(T entity)
        {
            if (entity == null) throw new ArgumentException($"{entity}");
            _context.SaveChanges();
        }
        public void Delete(T entity)
        {
            if (entity == null) throw new ArgumentException($"{entity}");
            _entities.Remove(entity);
            _context.SaveChanges();
        }
        public void Remove(T entity)
        {
            if (entity == null) throw new ArgumentException($"{entity}");
            _entities.Remove(entity);

        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    

    }
}
