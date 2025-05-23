﻿using FillGaps.StockTrack.ConsoleApp.Infrastructure;
using FillGaps.StockTrack.ConsoleApp.Infrastructure.Repositories;
using FillGaps.StockTrack.ConsoleApp.Domain.Services;
using FillGaps.StockTrack.ConsoleApp.Application.Services;
using FillGaps.StockTrack.ConsoleApp.Application;

using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main(string[] args)
    {
        var options = new DbContextOptionsBuilder<StockTrackDbContext>()
            .UseSqlite("Data Source=stocktrack.db")
            .Options;

        using var context = new StockTrackDbContext(options);
        context.Database.Migrate();

        var produtoRepository = new ProdutoRepository(context);
        var movimentacaoRepository = new MovimentacaoRepository(context);
        var categoriaRepository = new CategoriaRepository(context);
        var movimentacaoService = new MovimentacaoService(produtoRepository, movimentacaoRepository);
        var buscaAvancadaProdutoService = new BuscaAvancadaProdutoService(produtoRepository);

        var produtoAppService = new ProdutoAppService(produtoRepository);
        var movimentacaoAppService = new MovimentacaoAppService(movimentacaoService, movimentacaoRepository);
        var categoriaAppService = new CategoriaAppService(categoriaRepository);

        var app = new StockTrackApp(
            produtoAppService,
            movimentacaoAppService,
            context,
            buscaAvancadaProdutoService,
            categoriaAppService
        );

        while (true)
        {
            Console.WriteLine("\n=== StockTrack Console ===");
            Console.WriteLine("1. Listar produtos");
            Console.WriteLine("2. Adicionar produto");
            Console.WriteLine("3. Registrar entrada (estoque)");
            Console.WriteLine("4. Registrar saída (estoque)");
            Console.WriteLine("5. Listar movimentações de produto");
            Console.WriteLine("6. Busca avançada de produtos");
            Console.WriteLine("0. Sair");
            Console.Write("Opção: ");

            var opcao = Console.ReadLine();

            if (opcao == "0") break;

            try
            {
                switch (opcao)
                {
                    case "1":
                        app.ListarProdutos();
                        break;
                    case "2":
                        app.AdicionarProduto();
                        break;
                    case "3":
                        app.RegistrarMovimentacao(true);
                        break;
                    case "4":
                        app.RegistrarMovimentacao(false);
                        break;
                    case "5":
                        app.ListarMovimentacoes();
                        break;
                    case "6":
                        app.BuscarProdutosAvancado();
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Erro: {ex.Message}");
                Console.ResetColor();
            }
        }
    }
}