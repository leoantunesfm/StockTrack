using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FillGaps.StockTrack.ConsoleApp.Domain.ValueObjects;

namespace FillGaps.StockTrack.ConsoleApp.Domain.Entities
{
    public class Eletronico : Produto
    {
        public string Voltagem { get; set; } = string.Empty;

        public Eletronico() { }
        public Eletronico(Guid id, string codigoCurto, NomeProduto nome, Categoria categoria, Quantidade estoque, string voltagem)
            : base(id, codigoCurto, nome, categoria, estoque)
        {
            Voltagem = voltagem;
        }

        public override string DescricaoDetalhada()
            => $"{Nome.Valor} (Eletrônico) - Voltagem: {Voltagem} - Estoque: {Estoque.Valor}";
    }
}
