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
        public Guid Id { get; set; }
        public NomeProduto Nome { get; set; }
        public Guid CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        public Quantidade Estoque { get; set; }

        public Produto() { }

        protected Produto(NomeProduto nome, Categoria categoria, Quantidade estoque)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Categoria = categoria;
            CategoriaId = categoria.Id;
            Estoque = estoque;
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
