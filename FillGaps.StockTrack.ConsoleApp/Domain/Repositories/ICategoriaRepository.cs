using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FillGaps.StockTrack.ConsoleApp.Domain.Entities;

namespace FillGaps.StockTrack.ConsoleApp.Domain.Repositories
{
    public interface ICategoriaRepository
    {
        Categoria? ObterPorId(Guid id);
        Categoria? ObterPorNome(string nome);
        void Adicionar(Categoria categoria);
        IEnumerable<Categoria> ObterTodas();
    }

}
