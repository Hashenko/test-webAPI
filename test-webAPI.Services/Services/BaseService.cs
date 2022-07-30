using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accounter.DB.Entities;
using Accounter.DB.UnitOfWork;
using test_webAPI.Services.Interfaces;

namespace Accounter.Services.Services
{
    public abstract class BaseService : IBaseService
    {
        private readonly IUnitOfWork _unitOfWork;

        protected BaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<TEntity> Get<TEntity>() where TEntity : class, IEntity
        {
            return _unitOfWork.Get<TEntity>();
        }
        public IEntity Get<TEntity>(int id) where TEntity : class, IEntity
        {
            return _unitOfWork.Get<TEntity>(id);
        }
        public void Create<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            _unitOfWork.Insert(entity);
        }
        public void Delete<TEntity>(int id) where TEntity : class, IEntity
        {
            _unitOfWork.Delete<TEntity>(id);
        }
        public void Update<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            _unitOfWork.Update(entity);
        }
        public abstract void Validate();
    }
}
