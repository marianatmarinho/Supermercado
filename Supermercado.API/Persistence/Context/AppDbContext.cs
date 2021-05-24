using Microsoft.EntityFrameworkCore;
using Supermercado.API.Domain.Models;

namespace Supermercado.API.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Categoria> Categorias{get; set;}

        public DbSet<Produto> Produtos {get; set;}

        protected override void OnModelCreating (ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<Categoria>().ToTable("Categorias");
            builder.Entity<Categoria>().HasKey(p => p.Id);
            builder.Entity<Categoria>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Categoria>().Property(p => p.Nome).IsRequired().HasMaxLength(30);
            builder.Entity <Categoria> ()
                .HasMany (p => p.Produtos)
                    .WithOne (p => p.Categoria)
                        .HasForeignKey (p => p.CategoriaId);

            builder.Entity <Categoria>().HasData
                (
                new Categoria {Id = 100, Nome = "Frutas e Legumes"},
                new Categoria {Id = 101, Nome = "Lacticineos"}
                );

            builder.Entity<Produto>().ToTable("Produtos");
            builder.Entity<Produto>().HasKey(p => p.Id);
            builder.Entity<Produto>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Produto>().Property(p => p.Nome).IsRequired().HasMaxLength(50);
            builder.Entity<Produto>().Property(p => p.QuantidadePacote).IsRequired();
            builder.Entity<Produto>().Property(p => p.UnidadeMedida).IsRequired();
        }
    }
}