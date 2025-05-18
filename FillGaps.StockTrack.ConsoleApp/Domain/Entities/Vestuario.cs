using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FillGaps.StockTrack.ConsoleApp.Domain.ValueObjects;

namespace FillGaps.StockTrack.ConsoleApp.Domain.Entities
{
    public class Vestuario : Produto
    {
        public string Tamanho { get; set; } = string.Empty;

        public Vestuario() { }
        public Vestuario(NomeProduto nome, Categoria categoria, Quantidade estoque, string tamanho)
            : base(nome, categoria, estoque)
        {
            Tamanho = tamanho;
        }

        public override string DescricaoDetalhada()
            => $"{Nome.Valor} (Vestuário) - Tamanho: {Tamanho} - Estoque: {Estoque.Valor}";
    }
}
