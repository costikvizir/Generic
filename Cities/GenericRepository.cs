using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Text;

namespace Cities
{
    class GenericRepository<T> : IGenericRepository<T> where T: class
    {
        private CityDbContext _context = null;
        private DbSet<T> table = null;
        public GenericRepository()
        {
            this._context = new CityDbContext();
            
        }
        public GenericRepository(CityDbContext _context)
        {
            this._context = _context;
           
        }
        public IEnumerable<T> GetAll()
        {
            //return table.ToList();
            return default;
        }
        public T GetById(object id)
        {
            return table.Find(id);
           
        }
        public TEntity GetByIdWithInclude<TEntity>(int id, params Expression<Func<TEntity, object>>[] includeProperties) where TEntity : class
        {
            var query = IncludeProperties(includeProperties);
            return  query.FirstOrDefault(entity => entity.Id == id);
        }
        public void Insert(T obj)
        {
            table.Add(obj);
        }
        public void Update(T obj)
        {
            table.Attach(obj);
           // _context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }
        public void Save()
        {
            //_context.SaveChanges();
        }
        private IQueryable<TEntity> IncludeProperties<TEntity>(params Expression<Func<TEntity, object>>[] includeProperties) where TEntity : class
        {
            IQueryable<TEntity> entities = _context.Set<TEntity>();
            foreach (var includeProperty in includeProperties)
            {
                entities = entities.Include(includeProperty);
            }
            return entities;
        }
    }
}
