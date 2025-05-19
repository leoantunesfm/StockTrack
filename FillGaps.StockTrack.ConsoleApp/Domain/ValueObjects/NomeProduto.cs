using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FillGaps.StockTrack.ConsoleApp.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace FillGaps.StockTrack.ConsoleApp.Domain.ValueObjects
{
    [Owned]
    public class NomeProduto
    {
        [MaxLength(100)]
        public string Valor { get; private set; }

        public NomeProduto(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new NomeProdutoInvalidoException();
            if (nome.Trim().Length > 100)
                throw new QuantidadeCaracteresException();
            Valor = nome.Trim();
        }

        private NomeProduto() { }

        public override string ToString() => Valor;
    }
}
