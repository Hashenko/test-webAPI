using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Accounter.DB.Entities;

namespace Accounter.DB.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;

        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
        }

        public List<TEntity> Get<TEntity>() where TEntity : class, IEntity
        {
            return _context.Set<TEntity>().ToList();
        }

        public TEntity Get<TEntity>(int id) where TEntity : class, IEntity
        {
            return _context.Set<TEntity>().Find(id);
        }

        public void Insert<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            var x = _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public void Delete<TEntity>(int id) where TEntity : class, IEntity
        {
            var entity = Get<TEntity>(id);
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();

        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }

        public void Update<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            _context.Set<TEntity>().Update(entity);
            _context.SaveChanges();
        }

        public void Detach<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            _context.Entry(entity).State = EntityState.Detached;
            _context.SaveChanges();
        }
    }
}
