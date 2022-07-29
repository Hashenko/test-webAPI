using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Accounter.DB;
using Accounter.DB.Entities;
using Accounter.Services.Interfaces;

namespace Accounter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentsController : ControllerBase
    {
        private readonly IIncidentService _incidentService;

        public IncidentsController(IIncidentService incidentService)
        {
            _incidentService = incidentService;
        }

        // GET: api/Incidents
        [HttpGet]
        public IEnumerable<IEntity> GetIncidents()
        {
            return _incidentService.Get<Incident>();
        }

        // GET: api/Incidents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Incident>> GetIncident(string id)
        {
            var incident = _incidentService.Get<Incident>().FirstOrDefault();

            if (incident == null)
            {
                return NotFound();
            }

            return incident;
        }

        // PUT: api/Incidents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIncident(string id, Incident incident)
        {
            _incidentService.Update<Incident>(incident);
            return NoContent();
        }

        // POST: api/Incidents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Incident> PostIncident(Incident incident)
        {
            _incidentService.Create<Incident>(incident);
            return CreatedAtAction("GetIncident", new { id = incident.Name }, incident);
        }

        // DELETE: api/Incidents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIncident(string name)
        {
            _incidentService.Delete(name);

            return NoContent();
        }
    }
}
