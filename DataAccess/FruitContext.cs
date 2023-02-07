using Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using DataAccess.Models;

namespace DataAcess
{
    public class FruitContext : DbContext
    {

        public FruitContext(DbContextOptions<FruitContext> options)
        : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fruit>();
            modelBuilder.Entity<FruitType>();
        }

        public DbSet<Fruit> Fruits { get; set; }
        public DbSet<FruitType> FruitTypes { get; set; }
    }
}
