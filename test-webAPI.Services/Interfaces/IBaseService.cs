using Accounter.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_webAPI.Services.Interfaces
{
    public interface IBaseService
    {
        public IEnumerable<TEntity> Get<TEntity>() where TEntity : class, IEntity;
        public IEntity Get<TEntity>(int id) where TEntity : class, IEntity;
        public void Create<TEntity>(TEntity entity) where TEntity : class, IEntity;
        public void Delete<TEntity>(int id) where TEntity : class, IEntity;
        public void Update<TEntity>(TEntity entity) where TEntity : class, IEntity;
        abstract void Validate();
    }
}
