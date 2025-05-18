using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FillGaps.StockTrack.ConsoleApp.Application.Factories;
using FillGaps.StockTrack.ConsoleApp.Application.Services;
using FillGaps.StockTrack.ConsoleApp.Domain.Entities;
using FillGaps.StockTrack.ConsoleApp.Domain.ValueObjects;
using FillGaps.StockTrack.ConsoleApp.Infrastructure;

namespace FillGaps.StockTrack.ConsoleApp.Application
{
    public class StockTrackApp
    {
        private readonly ProdutoAppService _produtoAppService;
        private readonly MovimentacaoAppService _movimentacaoAppService;
        private readonly StockTrackDbContext _context;

        public StockTrackApp(
            ProdutoAppService produtoAppService,
            MovimentacaoAppService movimentacaoAppService,
            StockTrackDbContext context)
        {
            _produtoAppService = produtoAppService;
            _movimentacaoAppService = movimentacaoAppService;
            _context = context;
        }

        public void ListarProdutos()
        {
            var produtos = _produtoAppService.ListarTodos();
            Console.WriteLine("\nProdutos cadastrados:");
            foreach (var p in produtos)
            {
                Console.WriteLine($"- [{p.Id}] {p.Nome.Valor} | Categoria: {p.Categoria.Nome} | Estoque: {p.Estoque.Valor}");
            }
        }

        public void AdicionarProduto()
        {
            Console.WriteLine("\nTipos de produto: Eletronico, Alimento, Vestuario");
            Console.Write("Escolha o tipo: ");
            var tipo = Console.ReadLine() ?? "";

            Console.Write("Nome: ");
            var nome = Console.ReadLine() ?? "";
            Console.Write("Categoria: ");
            var categoriaNome = Console.ReadLine() ?? "";
            Console.Write("Estoque inicial: ");
            var estoqueStr = Console.ReadLine();

            if (!int.TryParse(estoqueStr, out int estoqueVal) || estoqueVal < 0)
                throw new Exception("Estoque inválido!");

            var categoria = _context.Categorias.FirstOrDefault(c => c.Nome == categoriaNome)
                ?? new Categoria(categoriaNome);

            var nomeProduto = new NomeProduto(nome);
            var quantidade = new Quantidade(estoqueVal);

            // Solicita campos específicos conforme o tipo
            string? voltagem = null;
            DateTime? dataValidade = null;
            string? tamanho = null;
            switch (tipo)
            {
                case "Eletronico":
                    Console.Write("Voltagem: ");
                    voltagem = Console.ReadLine() ?? "";
                    break;
                case "Alimento":
                    Console.Write("Data de validade (yyyy-MM-dd): ");
                    var dataStr = Console.ReadLine();
                    if (!DateTime.TryParse(dataStr, out var data))
                        throw new Exception("Data inválida!");
                    dataValidade = data;
                    break;
                case "Vestuario":
                    Console.Write("Tamanho: ");
                    tamanho = Console.ReadLine() ?? "";
                    break;
                default:
                    throw new Exception("Tipo inválido!");
            }

            // Salva nova categoria caso necessário
            if (categoria.Id == Guid.Empty || _context.Categorias.All(c => c.Id != categoria.Id))
                _context.Categorias.Add(categoria);

            var produto = ProdutoFactory.CriarProduto(tipo, nomeProduto, categoria, quantidade, voltagem, dataValidade, tamanho);
            _produtoAppService.Adicionar(produto);

            Console.WriteLine("Produto adicionado com sucesso!");
        }

        public void RegistrarMovimentacao(bool entrada)
        {
            ListarProdutos();
            Console.Write("Informe o ID do produto: ");
            var idStr = Console.ReadLine();
            if (!Guid.TryParse(idStr, out Guid id))
                throw new Exception("ID inválido!");

            Console.Write("Quantidade: ");
            var qtdStr = Console.ReadLine();
            if (!int.TryParse(qtdStr, out int qtd) || qtd <= 0)
                throw new Exception("Quantidade inválida!");

            var quantidade = new Quantidade(qtd);

            if (entrada)
                _movimentacaoAppService.RegistrarEntrada(id, quantidade);
            else
                _movimentacaoAppService.RegistrarSaida(id, quantidade);

            Console.WriteLine("Movimentação registrada com sucesso!");
        }

        public void ListarMovimentacoes()
        {
            ListarProdutos();
            Console.Write("Informe o ID do produto: ");
            var idStr = Console.ReadLine();
            if (!Guid.TryParse(idStr, out Guid id))
                throw new Exception("ID inválido!");

            var movimentacoes = _movimentacaoAppService.ListarPorProduto(id);
            Console.WriteLine("\nMovimentações:");
            foreach (var m in movimentacoes)
            {
                Console.WriteLine($"{m.Data:dd/MM/yyyy HH:mm} | {m.Tipo} | Quantidade: {m.Quantidade.Valor}");
            }
        }
    }
}
