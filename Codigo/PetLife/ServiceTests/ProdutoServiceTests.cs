using Core.Service;
using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Tests
{
    [TestClass()]
    public class ProdutoServiceTests
    {
        private PetLifeContext _context;
        private IProdutoService _produtoService;

        [TestInitialize]
        public void Initialize()
        {
            //Arrange
            var builder = new DbContextOptionsBuilder<PetLifeContext>();
            builder.UseInMemoryDatabase("PetLife");
            var options = builder.Options;

            _context = new PetLifeContext(options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            var produtos = new List<Produto>
                {
                    new Produto { Id = 1, Nome = "Ração Petgrilo", Codigo = 1234, Ativo = 1, Quantidade = 50,
                                  Preco = 15.90, IdPetshop = 1},
                    new Produto { Id = 2, Nome = "Ração Whisky", Codigo = 666, Ativo = 1, Quantidade = 24,
                                  Preco = 51.00, IdPetshop = 1},
                    new Produto { Id = 3, Nome = "Ossinho", Codigo = 4002, Ativo = 0, Quantidade = 10,
                                  Preco = 12.99, IdPetshop = 1},
                };

            _context.AddRange(produtos);
            _context.SaveChanges();

            _produtoService = new ProdutoService(_context);
        }

        [TestMethod()]
        public void CreateTest()
        {
            // Act
            _produtoService.Create(new Produto() { Id = 4, Nome = "Shampoo ClearDog", Codigo = 0007, Ativo = 1, 
                                                   Quantidade = 7, Preco = 7.77 });
            // Assert
            Assert.AreEqual(4, _produtoService.GetAll().Count());
            var produto = _produtoService.Get(4);
            Assert.AreEqual("Shampoo ClearDog", produto.Nome);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            // Act
            _produtoService.Delete(2);
            // Assert
            Assert.AreEqual(2, _produtoService.GetAll().Count());
            var produto = _produtoService.Get(2);
            Assert.AreEqual(null, produto);
        }

        [TestMethod()]
        public void EditTest()
        {
            //Act 
            var produto = _produtoService.Get(3);
            produto.Nome = "Chocalho";
            produto.Codigo = 8922;
            produto.Ativo = 1;
            produto.Quantidade = 13;
            produto.Preco = 8.50;
            _produtoService.Edit(produto);
            //Assert
            produto = _produtoService.Get(3);
            Assert.IsNotNull(produto);
            Assert.AreEqual("Chocalho", produto.Nome);
            Assert.AreEqual((uint)8922, produto.Codigo);
        }

        [TestMethod()]
        public void GetTest()
        {
            var produto = _produtoService.Get(1);
            Assert.IsNotNull(produto);
            Assert.AreEqual("Ração Petgrilo", produto.Nome);
            Assert.AreEqual((uint)1234, produto.Codigo);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            // Act
            var listaProduto = _produtoService.GetAll();
            // Assert
            Assert.IsInstanceOfType(listaProduto, typeof(IEnumerable<Produto>));
            Assert.IsNotNull(listaProduto);
            Assert.AreEqual(3, listaProduto.Count());
            Assert.AreEqual((uint)1, listaProduto.First().Id);
            Assert.AreEqual("Ração Petgrilo", listaProduto.First().Nome);
        }

        [TestMethod()]
        public void GetByNomeTest()
        {
            //Act
            var produtos = _produtoService.GetByNome("Ração Petgrilo");
            //Assert
            Assert.IsNotNull(produtos);
            Assert.AreEqual(1, produtos.Count());
            Assert.AreEqual("Ração Petgrilo", produtos.First().Nome);
        }
    }
}
