using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FillGaps.StockTrack.ConsoleApp.Domain.Entities;
using FillGaps.StockTrack.ConsoleApp.Domain.Repositories;
using FillGaps.StockTrack.ConsoleApp.Domain.Services;
using FillGaps.StockTrack.ConsoleApp.Domain.ValueObjects;

namespace FillGaps.StockTrack.ConsoleApp.Application.Services
{
    public class MovimentacaoAppService
    {
        private readonly MovimentacaoService _movimentacaoService;
        private readonly IMovimentacaoRepository _movimentacaoRepository;

        public MovimentacaoAppService(MovimentacaoService movimentacaoService, IMovimentacaoRepository movimentacaoRepository)
        {
            _movimentacaoService = movimentacaoService;
            _movimentacaoRepository = movimentacaoRepository;
        }

        public void RegistrarEntrada(Produto produto, Quantidade quantidade)
        {
            _movimentacaoService.RegistrarEntrada(produto, quantidade);
        }

        public void RegistrarSaida(Produto produto, Quantidade quantidade)
        {
            _movimentacaoService.RegistrarSaida(produto, quantidade);
        }

        public IEnumerable<Movimentacao> ListarPorProduto(Guid produtoId)
        {
            return _movimentacaoRepository.ObterPorProduto(produtoId);
        }
    }
}
