using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FillGaps.StockTrack.ConsoleApp.Domain.Entities;
using FillGaps.StockTrack.ConsoleApp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FillGaps.StockTrack.ConsoleApp.Infrastructure.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly StockTrackDbContext _context;

        public ProdutoRepository(StockTrackDbContext context)
        {
            _context = context;
        }

        public void Adicionar(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
        }

        public Produto? ObterPorId(Guid id)
        {
            return _context.Produtos
                .Include(p => p.Categoria)
                .FirstOrDefault(p => p.Id == id);
        }

        public Produto? ObterPorCodigoCurto(string codigoCurto)
        {
            return _context.Produtos
                .Include(p => p.Categoria)
                .FirstOrDefault(p => p.CodigoCurto == codigoCurto);
        }

        public IEnumerable<Produto> ObterTodos()
        {
            return _context.Produtos
                .Include(p => p.Categoria)
                .ToList();
        }

        public void Atualizar(Produto produto)
        {
            _context.Produtos.Update(produto);
            _context.SaveChanges();
        }

        public void Remover(Guid id)
        {
            var produto = _context.Produtos.Find(id);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
                _context.SaveChanges();
            }
        }
    }
}
