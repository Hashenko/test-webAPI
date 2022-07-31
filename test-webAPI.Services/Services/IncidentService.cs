using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accounter.DB.Entities;
using Accounter.DB.UnitOfWork;
using Accounter.Services.DTOs;
using Accounter.Services.Interfaces;
using AutoMapper;

namespace Accounter.Services.Services
{
    public class IncidentService : BaseService, IIncidentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public IncidentService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Delete(string name)
        {
            var incident = _unitOfWork.Get<Incident>()
                .FirstOrDefault(i => i.Name == name);
            _unitOfWork.Delete(incident);
        }

        public Incident Get(string name)
        {
            var entities = _unitOfWork.Get<Incident>(name);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Incident, IncidentDto>());
            var mapper = new Mapper(config);
            var dto = mapper.Map<IncidentDto>(entities);
            return _unitOfWork.Get<Incident>(name);
        }

        public override void Validate()
        {
            throw new NotImplementedException();
        }

    }
}
