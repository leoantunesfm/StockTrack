using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using FillGaps.StockTrack.ConsoleApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FillGaps.StockTrack.ConsoleApp.Infrastructure
{
    public class StockTrackDbContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Movimentacao> Movimentacoes { get; set; }

        public StockTrackDbContext(DbContextOptions<StockTrackDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Herança TPH para Produto
            modelBuilder.Entity<Produto>()
                .HasDiscriminator<string>("TipoProduto")
                .HasValue<Eletronico>("Eletronico")
                .HasValue<Alimento>("Alimento")
                .HasValue<Vestuario>("Vestuario");

            // Value Objects como Owned
            modelBuilder.Entity<Produto>().OwnsOne(p => p.Nome);
            modelBuilder.Entity<Produto>().OwnsOne(p => p.Estoque);
            modelBuilder.Entity<Movimentacao>().OwnsOne(m => m.Quantidade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
