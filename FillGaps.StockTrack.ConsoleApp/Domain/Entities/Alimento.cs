using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FillGaps.StockTrack.ConsoleApp.Domain.ValueObjects;

namespace FillGaps.StockTrack.ConsoleApp.Domain.Entities
{
    public class Alimento : Produto
    {
        public DateTime DataValidade { get; set; }

        public Alimento() { }
        public Alimento(Guid id, string codigoCurto, NomeProduto nome, Categoria categoria, Quantidade estoque, DateTime dataValidade)
            : base(id, codigoCurto, nome, categoria, estoque)
        {
            DataValidade = dataValidade;
        }

        public override string DescricaoDetalhada()
            => $"{Nome.Valor} (Alimento) - Validade: {DataValidade:dd/MM/yyyy} - Estoque: {Estoque.Valor}";
    }
}
