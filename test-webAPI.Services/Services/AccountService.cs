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
    public class AccountService : BaseService, IAccountService
    {
        public AccountService(IUnitOfWork unitOfWork) 
            : base(unitOfWork)
        {

        }
        public override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
