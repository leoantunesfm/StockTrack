using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillGaps.StockTrack.ConsoleApp.Domain.Entities
{
    public class Categoria
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;

        public Categoria() { }
        public Categoria(string nome)
        {
            Id = Guid.NewGuid();
            Nome = nome;
        }
    }
}
