using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FillGaps.StockTrack.ConsoleApp.Domain.Entities;
using FillGaps.StockTrack.ConsoleApp.Domain.Repositories;

namespace FillGaps.StockTrack.ConsoleApp.Application.Services
{
    public class CategoriaAppService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaAppService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public IEnumerable<Categoria> ListarTodas()
        {
            return _categoriaRepository.ObterTodas();
        }

        public Categoria? ObterPorId(Guid id)
        {
            return _categoriaRepository.ObterPorId(id);
        }

        public Categoria? ObterPorNome(string nome)
        {
            return _categoriaRepository.ObterPorNome(nome);
        }

        public void Adicionar(Categoria categoria)
        {
            _categoriaRepository.Adicionar(categoria);
        }
    }
}
