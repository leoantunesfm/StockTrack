using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FillGaps.StockTrack.ConsoleApp.Domain.Entities;

namespace FillGaps.StockTrack.ConsoleApp.Domain.Repositories
{
    public interface IProdutoRepository
    {
        void Adicionar(Produto produto);
        Produto? ObterPorId(Guid id);
        IEnumerable<Produto> ObterTodos();
        void Atualizar(Produto produto);
        void Remover(Guid id);
    }
}
