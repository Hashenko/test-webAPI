using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accounter.DB.Entities;
using Accounter.DB.UnitOfWork;
using Accounter.Services.Interfaces;

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

        public override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
