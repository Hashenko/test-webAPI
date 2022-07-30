using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accounter.DB.Entities;

namespace Accounter.DB
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Incident>();

            modelBuilder.Entity<Account>()
                .Navigation(i => i.Incident)
                .AutoInclude();

            modelBuilder.Entity<Contact>()
                .Navigation(i => i.Account)
                .AutoInclude();
        }

        public DbSet<Incident> Incidents { get; set; }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Contact> Contacts { get; set; }
    }
}
