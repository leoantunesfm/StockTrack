using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FillGaps.StockTrack.ConsoleApp.Application.Services;
using FillGaps.StockTrack.ConsoleApp.Domain.Entities;
using FillGaps.StockTrack.ConsoleApp.Domain.Factories;
using FillGaps.StockTrack.ConsoleApp.Domain.Repositories;
using FillGaps.StockTrack.ConsoleApp.Domain.Services;
using FillGaps.StockTrack.ConsoleApp.Domain.ValueObjects;
using FillGaps.StockTrack.ConsoleApp.Infrastructure;

namespace FillGaps.StockTrack.ConsoleApp.Application
{
    public class StockTrackApp
    {
        private readonly ProdutoAppService _produtoAppService;
        private readonly MovimentacaoAppService _movimentacaoAppService;
        private readonly StockTrackDbContext _context;
        private readonly BuscaAvancadaProdutoService _buscaAvancadaProdutoService;
        private readonly CategoriaAppService _categoriaAppService;

        public StockTrackApp(
            ProdutoAppService produtoAppService,
            MovimentacaoAppService movimentacaoAppService,
            StockTrackDbContext context,
            BuscaAvancadaProdutoService buscaAvancadaProdutoService,
            CategoriaAppService categoriaAppService)
        {
            _produtoAppService = produtoAppService;
            _movimentacaoAppService = movimentacaoAppService;
            _context = context;
            _buscaAvancadaProdutoService = buscaAvancadaProdutoService;
            _categoriaAppService = categoriaAppService;
        }

        public void ListarProdutos()
        {
            var produtos = _produtoAppService.ListarTodos();
            Console.WriteLine("\nProdutos cadastrados:");
            foreach (var p in produtos)
            {
                Console.WriteLine($"- [{p.CodigoCurto}] {p.Nome.Valor} | Categoria: {p.Categoria.Nome} | Estoque: {p.Estoque.Valor}");
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

            var categoria = _categoriaAppService.ObterPorNome(categoriaNome)
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
            if (categoria.Id == Guid.Empty || _categoriaAppService.ObterPorId(categoria.Id) == null)
                _categoriaAppService.Adicionar(categoria);

            var produto = ProdutoFactory.CriarProduto(tipo, nomeProduto, categoria, quantidade, voltagem, dataValidade, tamanho);
            _produtoAppService.Adicionar(produto);

            Console.WriteLine("Produto adicionado com sucesso!");
        }

        public void RegistrarMovimentacao(bool entrada)
        {
            ListarProdutos();
            Console.Write("Informe o Codigo Curto do produto: ");
            var CodigoCurto = Console.ReadLine();

            var produto = _produtoAppService.ObterPorCodigoCurto(CodigoCurto);

            Console.Write("Quantidade: ");
            var qtdStr = Console.ReadLine();
            if (!int.TryParse(qtdStr, out int qtd) || qtd <= 0)
                throw new Exception("Quantidade inválida!");

            var quantidade = new Quantidade(qtd);

            if (entrada)
                _movimentacaoAppService.RegistrarEntrada(produto.Id, quantidade);
            else
                _movimentacaoAppService.RegistrarSaida(produto.Id, quantidade);

            Console.WriteLine("Movimentação registrada com sucesso!");
        }

        public void ListarMovimentacoes()
        {
            ListarProdutos();
            Console.Write("Informe o Codigo Curto do produto: ");
            var CodigoCurto = Console.ReadLine();

            var produto = _produtoAppService.ObterPorCodigoCurto(CodigoCurto);

            var movimentacoes = _movimentacaoAppService.ListarPorProduto(produto.Id);
            Console.WriteLine("\nMovimentações:");
            foreach (var m in movimentacoes)
            {
                Console.WriteLine($"{m.Data:dd/MM/yyyy HH:mm} | {m.Tipo} | Quantidade: {m.Quantidade.Valor}");
            }
        }

        public void BuscarProdutosAvancado()
        {
            Console.Write("Digite parte do nome do produto (ou deixe vazio): ");
            var nome = Console.ReadLine();

            Console.Write("Digite parte da categoria (ou deixe vazio): ");
            var categoria = Console.ReadLine();

            var produtos = _buscaAvancadaProdutoService.Buscar(nome, categoria);

            Console.WriteLine("\nResultados da busca:");
            foreach (var p in produtos)
            {
                Console.WriteLine($"- [{p.CodigoCurto}] {p.Nome.Valor} | Categoria: {p.Categoria.Nome} | Estoque: {p.Estoque.Valor}");
            }
        }
    }
}
