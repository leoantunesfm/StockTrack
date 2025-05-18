using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FillGaps.StockTrack.ConsoleApp.Domain.Entities;
using FillGaps.StockTrack.ConsoleApp.Domain.Repositories;
using FillGaps.StockTrack.ConsoleApp.Domain.ValueObjects;

namespace FillGaps.StockTrack.ConsoleApp.Domain.Services
{
    public class MovimentacaoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMovimentacaoRepository _movimentacaoRepository;

        public MovimentacaoService(IProdutoRepository produtoRepository, IMovimentacaoRepository movimentacaoRepository)
        {
            _produtoRepository = produtoRepository;
            _movimentacaoRepository = movimentacaoRepository;
        }

        public void RegistrarEntrada(Guid produtoId, Quantidade quantidade)
        {
            var produto = _produtoRepository.ObterPorId(produtoId)
                ?? throw new InvalidOperationException("Produto não encontrado.");

            produto.IncluirEstoque(quantidade);

            var movimentacao = new Movimentacao(produto, quantidade, TipoMovimentacao.Entrada);
            _movimentacaoRepository.Adicionar(movimentacao);

            _produtoRepository.Atualizar(produto);
        }

        public void RegistrarSaida(Guid produtoId, Quantidade quantidade)
        {
            var produto = _produtoRepository.ObterPorId(produtoId)
                ?? throw new InvalidOperationException("Produto não encontrado.");

            produto.BaixarEstoque(quantidade);

            var movimentacao = new Movimentacao(produto, quantidade, TipoMovimentacao.Saida);
            _movimentacaoRepository.Adicionar(movimentacao);

            _produtoRepository.Atualizar(produto);
        }
    }
}
