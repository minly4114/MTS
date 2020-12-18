using Microsoft.EntityFrameworkCore;
using MTS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTS.Data
{
    public class PostgresContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Cost> Costs { get; set; }
        public DbSet<Call> Calls { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public PostgresContext(DbContextOptions<PostgresContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Mts");
            modelBuilder.Entity<Client>()
                .HasMany(x => x.Calls)
                .WithOne(x => x.Client)
                .HasForeignKey(x => x.IdClient)
                .HasPrincipalKey(x => x.Id);
            modelBuilder.Entity<Call>()
                .HasOne(x => x.Cost)
                .WithMany(x => x.Calls)
                .HasForeignKey(x => x.IdCost)
                .HasPrincipalKey(x => x.Id);
            modelBuilder.Entity<Call>()
                .HasOne(x => x.Payment)
                .WithOne(x => x.Call)
                .HasForeignKey<Payment>(x => x.Id)
                .HasPrincipalKey<Call>(x => x.Id);
        }
    }
}
