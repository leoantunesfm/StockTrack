using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FillGaps.StockTrack.ConsoleApp.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace FillGaps.StockTrack.ConsoleApp.Domain.ValueObjects
{
    [Owned]
    public class Quantidade
    {
        public int Valor { get; private set; }

        public Quantidade(int valor)
        {
            if (valor <= 0)
                throw new ValorInvalidoException();
            Valor = valor;
        }

        private Quantidade() { }

        public Quantidade Somar(Quantidade quantidade) => new Quantidade(this.Valor + quantidade.Valor);

        public Quantidade Subtrair(Quantidade quantidade)
        {
            if (this.Valor < quantidade.Valor)
                throw new QuantidadeInsuficienteException();
            return new Quantidade(this.Valor - quantidade.Valor);
        }

        public override string ToString() => Valor.ToString();
    }
}
