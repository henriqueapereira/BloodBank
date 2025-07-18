using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodBank.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Infrastructure.Data
{
    public class BloodBankDbContext : DbContext
    {
        public BloodBankDbContext(DbContextOptions<BloodBankDbContext> options) : base(options)
        {

        }
        public DbSet<Doador> Doadores { get; set; } = null!;
        public DbSet<Endereco> Enderecos { get; set; } = null!;
        public DbSet<Doacao> Doacoes { get; set; } = null!;
        public DbSet<EstoqueSangue> EstoquesDeSangue { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Regra de negócio: Email único
            modelBuilder.Entity<Doador>()
                .HasIndex(d => d.Email)
                .IsUnique();

            // Relacionamento 1:1 Doador ↔ Endereco
            modelBuilder.Entity<Doador>()
                .HasOne(d => d.Endereco)
                .WithOne(e => e.Doador)
                .HasForeignKey<Endereco>(e => e.DoadorId);

            // Relacionamento 1:N Doador ↔ Doacao
            modelBuilder.Entity<Doacao>()
                .HasOne(d => d.Doador)
                .WithMany(doa => doa.Doacoes)
                .HasForeignKey(d => d.DoadorId);

            base.OnModelCreating(modelBuilder);
        }

    }
}