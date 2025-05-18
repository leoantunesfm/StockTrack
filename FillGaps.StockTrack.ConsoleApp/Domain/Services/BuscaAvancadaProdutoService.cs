using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FillGaps.StockTrack.ConsoleApp.Domain.Entities;
using FillGaps.StockTrack.ConsoleApp.Domain.Repositories;

namespace FillGaps.StockTrack.ConsoleApp.Domain.Services
{
    public class BuscaAvancadaProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public BuscaAvancadaProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        /// <summary>
        /// Busca produtos por nome e/ou categoria, com busca parcial e case-insensitive.
        /// </summary>
        public IEnumerable<Produto> Buscar(string? nome, string? categoria)
        {
            var produtos = _produtoRepository.ObterTodos();

            if (!string.IsNullOrWhiteSpace(nome))
            {
                var nomeBusca = nome.Trim().ToLowerInvariant();
                produtos = produtos.Where(p => p.Nome.Valor.ToLowerInvariant().Contains(nomeBusca));
            }

            if (!string.IsNullOrWhiteSpace(categoria))
            {
                var categoriaBusca = categoria.Trim().ToLowerInvariant();
                produtos = produtos.Where(p => p.Categoria.Nome.ToLowerInvariant().Contains(categoriaBusca));
            }

            return produtos;
        }
    }
}
