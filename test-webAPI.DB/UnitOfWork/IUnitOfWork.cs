using Accounter.DB.Entities;
using System.Collections.Generic;

namespace Accounter.DB.UnitOfWork
{
    public interface IUnitOfWork
    {
        List<TEntity> Get<TEntity>() where TEntity : class, IEntity;

        TEntity Get<TEntity>(int id) where TEntity : class, IEntity;

        void Insert<TEntity>(TEntity entity) where TEntity : class, IEntity;

        void Delete<TEntity>(int id) where TEntity : class, IEntity;

        void Update<TEntity>(TEntity entity) where TEntity : class, IEntity;

        void Delete<TEntity>(TEntity entity) where TEntity : class, IEntity;

        void Detach<TEntity>(TEntity entity) where TEntity : class, IEntity;
    }      
}
