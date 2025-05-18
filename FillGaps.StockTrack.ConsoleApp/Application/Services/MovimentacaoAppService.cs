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

        public void RegistrarEntrada(Guid produtoId, Quantidade quantidade)
        {
            _movimentacaoService.RegistrarEntrada(produtoId, quantidade);
        }

        public void RegistrarSaida(Guid produtoId, Quantidade quantidade)
        {
            _movimentacaoService.RegistrarSaida(produtoId, quantidade);
        }

        public IEnumerable<Movimentacao> ListarPorProduto(Guid produtoId)
        {
            return _movimentacaoRepository.ObterPorProduto(produtoId);
        }
    }
}
