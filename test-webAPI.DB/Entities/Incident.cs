using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accounter.DB.Entities
{
    public class Incident : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Name { get; set; }

        public string Description { get; set; }

/*        public List<Account> Accounts { get; set; }*/
    }
}
