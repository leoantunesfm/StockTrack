using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FillGaps.StockTrack.ConsoleApp.Domain.ValueObjects;

namespace FillGaps.StockTrack.ConsoleApp.Domain.Entities
{
    public class Movimentacao
    {
        public Guid Id { get; set; }
        public Guid ProdutoId { get; set; }
        public Produto Produto { get; set; } = null!;
        public Quantidade Quantidade { get; set; }
        public TipoMovimentacao Tipo { get; set; }
        public DateTime Data { get; set; }

        public Movimentacao() { }
        public Movimentacao(Produto produto, Quantidade quantidade, TipoMovimentacao tipo)
        {
            Id = Guid.NewGuid();
            Produto = produto;
            ProdutoId = produto.Id;
            Quantidade = quantidade;
            Tipo = tipo;
            Data = DateTime.UtcNow;
        }
    }
}
