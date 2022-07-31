using Accounter.DB.Entities;
using Accounter.DB.UnitOfWork;
using Accounter.Services.DTOs;
using AutoMapper;
using System.Collections.Generic;
using test_webAPI.Services.Interfaces;

namespace Accounter.Services.Services
{
    public abstract class BaseService : IBaseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Mapper _mapper;

        protected BaseService(IUnitOfWork unitOfWork)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Incident, IncidentDto>();
                cfg.CreateMap<List<Incident>,List<IncidentDto>>();
                cfg.CreateMap<Contact, ContactDto>();
                cfg.CreateMap<List<Contact>, List<ContactDto>>();
                cfg.CreateMap<Account, AccountDto>();
                cfg.CreateMap<List<Account>, List<AccountDto>>();
            });
            _mapper = new Mapper(config);
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<TEntity> Get<TEntity>() where TEntity : class, IEntity
        {
            return _unitOfWork.Get<TEntity>();
        }
        public IEntity Get<TEntity>(int id) where TEntity : class, IEntity
        {
            var entity = _unitOfWork.Get<TEntity>(id);
            return entity;
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
