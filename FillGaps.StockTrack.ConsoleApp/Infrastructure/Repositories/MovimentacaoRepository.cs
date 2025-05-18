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
    public class MovimentacaoRepository : IMovimentacaoRepository
    {
        private readonly StockTrackDbContext _context;

        public MovimentacaoRepository(StockTrackDbContext context)
        {
            _context = context;
        }

        public void Adicionar(Movimentacao movimentacao)
        {
            _context.Movimentacoes.Add(movimentacao);
            _context.SaveChanges();
        }

        public IEnumerable<Movimentacao> ObterPorProduto(Guid produtoId)
        {
            return _context.Movimentacoes
                .Include(m => m.Produto)
                .Where(m => m.ProdutoId == produtoId)
                .ToList();
        }

        public IEnumerable<Movimentacao> ObterTodas()
        {
            return _context.Movimentacoes
                .Include(m => m.Produto)
                .ToList();
        }
    }
}
