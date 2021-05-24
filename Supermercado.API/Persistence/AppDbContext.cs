using Microsoft.EntityFrameworkCore;
using Supermercado.API.Domain.Models;

namespace Supermercado.API.Persistence
{
    public class AppDbContext : DbContext
    {
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(option)
        {

        }

        public DbSet<Categoria> Categorias{get; set;}

        public DbSet<Produtos> Produtos {get; set;}

        public override void OnModelCreating (ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<Categorias>().ToTable("Categorias");
            builder.Entity<Categorias>().HasKey(p => p.Id);
            builder.Entity<Categorias>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Categorias>().Property(p => p.Nome).IsRequired().HasMaxLength(30);
            builder.Entity <Categoria> ()
                .HasMany (p => p.Produtos)
                    .WithOne (p => p.Categoria)
                        .HasForeignKey (p => p.CategoriaId);

            builder.Entity <Categoria>().HasData
                (
                new categoria {Id = 100, Nome = "Frutas e Legumes"},
                new categoria {Id = 101, Nome = "Lacticineos"}
                );

            builder.Entity<Categorias>().ToTable("Produtos");
            builder.Entity<Categorias>().HasKey(p => p.Id);
            builder.Entity<Categorias>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Categorias>().Property(p => p.Nome).IsRequired().HasMaxLength(50);
            builder.Entity<Categorias>().Property(p => p.QuantidadePacote).IsRequired();
            builder.Entity<Categorias>().Property(p => p.UnidadeMedida).IsRequired();
        }
    }
}