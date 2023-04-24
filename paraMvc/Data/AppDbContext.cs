using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using paraMvc.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using StackExchange.Redis;
using System;
using System.Numerics;

namespace paraMvc.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        internal object DemmandeItemss;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DemmandeItems>().HasKey(am => new
            {
                am.ProductId,
                am.DemmandeId
            });
            modelBuilder.Entity<DemmandeItems>().HasOne(m => m.Product).WithMany(am => am.DemmandeItems).HasForeignKey(m => m.ProductId);
            modelBuilder.Entity<DemmandeItems>().HasOne(m => m.Demmande).WithMany(am => am.DemmandeItems).HasForeignKey(m => m.DemmandeId);
            base.OnModelCreating(modelBuilder);
        }

        internal Task GetAll()
        {
            throw new NotImplementedException();
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Fournisseur> Fournisseur { get; set; }
        public DbSet<DemmandeItems> DemmandeItems { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }



        //Orders related tables
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        public DbSet<Demmande> Demmande { get; set; }
     
    }
}
