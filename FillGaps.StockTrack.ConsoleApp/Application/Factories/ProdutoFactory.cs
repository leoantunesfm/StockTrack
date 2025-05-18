using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FillGaps.StockTrack.ConsoleApp.Domain.Entities;
using FillGaps.StockTrack.ConsoleApp.Domain.ValueObjects;

namespace FillGaps.StockTrack.ConsoleApp.Application.Factories
{
    public static class ProdutoFactory
    {
        public static Produto CriarProduto(
            string tipo,
            NomeProduto nome,
            Categoria categoria,
            Quantidade estoque,
            string? voltagem = null,
            DateTime? dataValidade = null,
            string? tamanho = null)
        {
            return tipo switch
            {
                "Eletronico" => new Eletronico(nome, categoria, estoque, voltagem ?? throw new ArgumentNullException(nameof(voltagem))),
                "Alimento" => new Alimento(nome, categoria, estoque, dataValidade ?? throw new ArgumentNullException(nameof(dataValidade))),
                "Vestuario" => new Vestuario(nome, categoria, estoque, tamanho ?? throw new ArgumentNullException(nameof(tamanho))),
                _ => throw new ArgumentException("Tipo de produto inválido.")
            };
        }
    }
}
