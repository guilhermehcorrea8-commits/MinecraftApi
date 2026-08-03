using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Web_Api_29_07_Mine.Models;

namespace Web_Api_29_07_Mine.Context
{
    public class MinecraftContext : DbContext
    {
        public MinecraftContext(DbContextOptions<MinecraftContext> options)
            : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Mundo> Mundos { get; set; }
        public DbSet<Item> Itens { get; set; }
        public DbSet<Inventario> Inventarios { get; set; }

        public DbSet<Bloco> Blocos { get; set; }
        public DbSet<Mob> Mobs { get; set; }
        public DbSet<Bioma> Biomas { get; set; }
        public DbSet<Encantamento> Encantamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relacionamento N:N
            modelBuilder.Entity<Inventario>()
                .HasKey(i => new { i.PlayerId, i.ItemId });

            modelBuilder.Entity<Inventario>()
                .HasOne(i => i.Player)
                .WithMany(p => p.Inventarios)
                .HasForeignKey(i => i.PlayerId);

            modelBuilder.Entity<Inventario>()
                .HasOne(i => i.Item)
                .WithMany(i => i.Inventarios)
                .HasForeignKey(i => i.ItemId);

            SeedData.Seed(modelBuilder);
        }
    }
}