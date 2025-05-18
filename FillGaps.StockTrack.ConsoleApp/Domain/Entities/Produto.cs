using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FillGaps.StockTrack.ConsoleApp.Domain.ValueObjects;

namespace FillGaps.StockTrack.ConsoleApp.Domain.Entities
{
    public abstract class Produto
    {
        public Guid Id { get; private set; }
        public string CodigoCurto { get; private set; }
        public NomeProduto Nome { get; private set; }
        public Categoria Categoria { get; private set; }
        public Quantidade Estoque { get; private set; }

        protected Produto(Guid id, string codigoCurto, NomeProduto nome, Categoria categoria, Quantidade estoque)
        {
            Id = id;
            CodigoCurto = codigoCurto;
            Nome = nome;
            Categoria = categoria;
            Estoque = estoque;
        }

        public Produto() { }

        public static string GerarCodigoCurto(Guid guid)
        {
            var bytes = guid.ToByteArray();
            int valor = BitConverter.ToInt32(bytes, 0);
            valor = Math.Abs(valor);
            return valor.ToString("D6").Substring(0, 6);
        }

        public abstract string DescricaoDetalhada();

        public void IncluirEstoque(Quantidade quantidade)
        {
            Estoque = Estoque.Somar(quantidade);
        }

        public void BaixarEstoque(Quantidade quantidade)
        {
            Estoque = Estoque.Subtrair(quantidade);
        }
    }
}
