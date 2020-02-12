using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Persons.Domain.Entities;
using Persons.Domain.Interfaces;
using Persons.Infra.Data.Mappings;
using System;
using System.Linq;
using System.Reflection;

namespace Persons.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        private readonly string _connectionString;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, string connectionString= null) : base(options)
        {
            _connectionString = connectionString;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var typesToMapping = (from x in Assembly.GetExecutingAssembly().GetTypes()
                                  where x.IsClass && typeof(IMapping).IsAssignableFrom(x)
                                  select x).ToList();

            foreach (var mapping in typesToMapping)
            {
                dynamic mappingClass = Activator.CreateInstance(mapping);
                modelBuilder.ApplyConfiguration(mappingClass);
            }

            modelBuilder.Seed();
        }
    }
}
