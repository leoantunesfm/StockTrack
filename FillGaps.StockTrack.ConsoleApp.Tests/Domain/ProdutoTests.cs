using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FillGaps.StockTrack.ConsoleApp.Domain.Entities;
using FillGaps.StockTrack.ConsoleApp.Domain.Exceptions;
using FillGaps.StockTrack.ConsoleApp.Domain.ValueObjects;

namespace FillGaps.StockTrack.ConsoleApp.Tests.Domain
{
    [TestClass]
    public class ProdutoTests
    {
        private Categoria CriarCategoria() => new Categoria("Informática");
        private NomeProduto CriarNomeProduto(string nome = "Notebook") => new NomeProduto(nome);

        [TestMethod]
        public void Deve_Criar_Eletronico_Valido()
        {
            var categoria = CriarCategoria();
            var nome = CriarNomeProduto();
            var estoque = new Quantidade(10);

            var produto = new Eletronico(Guid.NewGuid(), "COD123", nome, categoria, estoque, "220V");

            Assert.AreEqual(nome, produto.Nome);
            Assert.AreEqual(categoria, produto.Categoria);
            Assert.AreEqual(estoque, produto.Estoque);
            Assert.AreEqual("220V", produto.Voltagem);
        }

        [TestMethod]
        [ExpectedException(typeof(QuantidadeCaracteresException))]
        public void Deve_Lancar_Excecao_Se_Nome_Produto_Maior_Que_100_Caracteres()
        {
            var nomeLongo = new string('A', 101);
            var nome = CriarNomeProduto(nomeLongo);
        }

        [TestMethod]
        [ExpectedException(typeof(ValorInvalidoException))]
        public void Deve_Lancar_Excecao_Se_Estoque_Inicial_Negativo()
        {
            var categoria = CriarCategoria();
            var nome = CriarNomeProduto();
            var estoque = new Quantidade(-1);
            var produto = new Eletronico(Guid.NewGuid(), "COD123", nome, categoria, estoque, "220V");
        }

        [TestMethod]
        [ExpectedException(typeof(ValorInvalidoException))]
        public void Deve_Lancar_Excecao_Se_Estoque_Inicial_Zero()
        {
            var categoria = CriarCategoria();
            var nome = CriarNomeProduto();
            var estoque = new Quantidade(0);
            var produto = new Eletronico(Guid.NewGuid(), "COD123", nome, categoria, estoque, "220V");
            Assert.AreEqual(0, produto.Estoque.Valor);
        }
    }
}
