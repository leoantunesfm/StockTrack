using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FillGaps.StockTrack.ConsoleApp.Domain.ValueObjects
{
    [Owned]
    public class Quantidade
    {
        public int Valor { get; private set; }

        public Quantidade(int valor)
        {
            if (valor < 0)
                throw new ArgumentException("A quantidade não pode ser negativa.");
            Valor = valor;
        }

        private Quantidade() { }

        public Quantidade Somar(Quantidade outra) => new Quantidade(this.Valor + outra.Valor);

        public Quantidade Subtrair(Quantidade outra)
        {
            if (this.Valor < outra.Valor)
                throw new InvalidOperationException("Não é possível subtrair uma quantidade maior que a disponível.");
            return new Quantidade(this.Valor - outra.Valor);
        }

        public override string ToString() => Valor.ToString();
    }
}
