using Accounter.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test_webAPI.Services.Interfaces;

namespace Accounter.Services.Interfaces
{
    public interface IIncidentService : IBaseService
    {
        void Delete(string name);
        Incident Get(string name);
    }
}
