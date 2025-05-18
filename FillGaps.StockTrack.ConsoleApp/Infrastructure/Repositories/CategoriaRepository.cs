using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FillGaps.StockTrack.ConsoleApp.Domain.Entities;
using FillGaps.StockTrack.ConsoleApp.Domain.Repositories;

namespace FillGaps.StockTrack.ConsoleApp.Infrastructure.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly StockTrackDbContext _context;

        public CategoriaRepository(StockTrackDbContext context)
        {
            _context = context;
        }

        public Categoria? ObterPorId(Guid id)
            => _context.Categorias.FirstOrDefault(c => c.Id == id);

        public Categoria? ObterPorNome(string nome)
            => _context.Categorias.FirstOrDefault(c => c.Nome == nome);

        public void Adicionar(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
        }

        public IEnumerable<Categoria> ObterTodas()
            => _context.Categorias.ToList();
    }
}
