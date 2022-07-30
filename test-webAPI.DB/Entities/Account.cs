using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accounter.DB.Entities
{
    public class Account : IEntity
    {
        public string Name { get; set; }
        public int Id { get; set; }

        [Required]
        public string IncidentId { get; set; }
        [ForeignKey("IncidentId")]
        public Incident Incident { get; set; }

/*        public List<Contact> Contacts { get; set; }*/
    }
}
