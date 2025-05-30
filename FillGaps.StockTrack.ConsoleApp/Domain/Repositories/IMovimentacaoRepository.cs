﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FillGaps.StockTrack.ConsoleApp.Domain.Entities;

namespace FillGaps.StockTrack.ConsoleApp.Domain.Repositories
{
    public interface IMovimentacaoRepository
    {
        void Adicionar(Movimentacao movimentacao);
        IEnumerable<Movimentacao> ObterPorProduto(Guid produtoId);
        IEnumerable<Movimentacao> ObterTodas();
    }
}
