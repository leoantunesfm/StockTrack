using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillGaps.StockTrack.ConsoleApp.Domain.Entities
{
    public class Alimento : Produto
    {
        public DateTime DataValidade { get; set; }

        public Alimento() { }
        public Alimento(NomeProduto nome, Categoria categoria, Quantidade estoque, DateTime dataValidade)
            : base(nome, categoria, estoque)
        {
            DataValidade = dataValidade;
        }

        public override string DescricaoDetalhada()
            => $"{Nome.Valor} (Alimento) - Validade: {DataValidade:dd/MM/yyyy} - Estoque: {Estoque.Valor}";
    }
}
