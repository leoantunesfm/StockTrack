using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillGaps.StockTrack.ConsoleApp.Domain.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message) { }
    }

    public class ValorInvalidoException : DomainException
    {
        public ValorInvalidoException()
            : base("Valor inválido para operação.") { }
    }

    public class NomeProdutoInvalidoException : DomainException
    {
        public NomeProdutoInvalidoException()
            : base("O nome do produto não pode ser vazio.") { }
    }

    public class QuantidadeCaracteresException : DomainException
    {
        public QuantidadeCaracteresException()
            : base("A quantidade máxima de caracteres para o nome do produto é de 100.") { }
    }

    public class QuantidadeInsuficienteException : DomainException
    {
        public QuantidadeInsuficienteException()
            : base("Não há quantidade em estoque suficiente para essa movimentação.") { }
    }
}
