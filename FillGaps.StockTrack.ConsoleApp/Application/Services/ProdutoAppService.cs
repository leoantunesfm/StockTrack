using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FillGaps.StockTrack.ConsoleApp.Domain.Entities;
using FillGaps.StockTrack.ConsoleApp.Domain.Repositories;

namespace FillGaps.StockTrack.ConsoleApp.Application.Services
{
    public class ProdutoAppService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoAppService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public IEnumerable<Produto> ListarTodos()
        {
            return _produtoRepository.ObterTodos();
        }

        public Produto? ObterPorId(Guid id)
        {
            return _produtoRepository.ObterPorId(id);
        }

        public Produto? ObterPorCodigoCurto(string codigoCurto)
        {
            return _produtoRepository.ObterPorCodigoCurto(codigoCurto);
        }

        public void Adicionar(Produto produto)
        {
            _produtoRepository.Adicionar(produto);
        }
    }
}
