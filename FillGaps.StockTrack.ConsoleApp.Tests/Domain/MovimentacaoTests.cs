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
    public class MovimentacaoTests
    {
        private Produto CriarProdutoComEstoque(int estoque)
        {
            var categoria = new Categoria("Teste");
            var nome = new NomeProduto("Produto Teste");
            return new Eletronico(Guid.NewGuid(), "COD123", nome, categoria, new Quantidade(estoque), "110V");
        }

        [TestMethod]
        public void Deve_Criar_Movimentacao_Entrada_Valida()
        {
            var produto = CriarProdutoComEstoque(10);
            var quantidade = new Quantidade(5);

            var mov = new Movimentacao(produto, quantidade, TipoMovimentacao.Entrada);

            Assert.AreEqual(produto, mov.Produto);
            Assert.AreEqual(quantidade, mov.Quantidade);
            Assert.AreEqual(TipoMovimentacao.Entrada, mov.Tipo);
            Assert.IsTrue(mov.Data <= DateTime.Now);
        }

        [TestMethod]
        [ExpectedException(typeof(ValorInvalidoException))]
        public void Deve_Lancar_Excecao_ValorInvalidoMovimentacao_Se_Quantidade_Menor_Ou_Igual_A_Zero()
        {
            var produto = CriarProdutoComEstoque(10);
            var quantidade = new Quantidade(0);

            new Movimentacao(produto, quantidade, TipoMovimentacao.Entrada);
        }

        [TestMethod]
        [ExpectedException(typeof(QuantidadeInsuficienteException))]
        public void Deve_Lancar_Excecao_QuantidadeInsuficiente_Se_Saida_Maior_Que_Estoque()
        {
            var produto = CriarProdutoComEstoque(2);
            var quantidade = new Quantidade(5);

            new Movimentacao(produto, quantidade, TipoMovimentacao.Saida);
        }

        [TestMethod]
        public void Deve_Criar_Movimentacao_Saida_Valida_Se_Estoque_Suficiente()
        {
            var produto = CriarProdutoComEstoque(10);
            var quantidade = new Quantidade(5);

            var mov = new Movimentacao(produto, quantidade, TipoMovimentacao.Saida);

            Assert.AreEqual(produto, mov.Produto);
            Assert.AreEqual(quantidade, mov.Quantidade);
            Assert.AreEqual(TipoMovimentacao.Saida, mov.Tipo);
        }
    }
}
