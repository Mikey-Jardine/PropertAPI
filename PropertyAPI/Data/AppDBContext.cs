using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using PropertyAPI.Entities;
using PropertyAPI.Helpers;

namespace PropertyAPI.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext (DbContextOptions<AppDBContext> options)
            : base(options)
        {
        }

        public DbSet<PropertyEntitiy> Properties { get; set; }
        public DbSet<PhotoEntity> Photos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}
