using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FillGaps.StockTrack.ConsoleApp.Domain.ValueObjects
{
    [Owned]
    public readonly struct NomeProduto
    {
        [MaxLength(100)]
        public string Valor { get; }

        public NomeProduto(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                throw new ArgumentException("O nome do produto não pode ser vazio.");

            Valor = valor.Trim();
        }

        public override string ToString() => Valor;
    }
}
