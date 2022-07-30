using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounter.Services.DTOs
{
    public class AccountDto
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public int? IncidentId { get; set; }
        public IncidentDto Incident { get; set; }
    }
}
