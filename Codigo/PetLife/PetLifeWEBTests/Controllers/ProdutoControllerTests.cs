using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PetLifeWEB.Controllers;
using PetLifeWEB.Mappers;
using PetLifeWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetLifeWEB.Controllers.Tests
{
    [TestClass]
    public class ProdutoControllerTests
    {
        private static ProdutoController controller;

        [TestInitialize]
        public void Initialize()
        {
            // Arrange
            var mockService = new Mock<IProdutoService>();

            IMapper mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile(new ProdutoProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll())
                .Returns(GetTestProdutos());
            mockService.Setup(service => service.Get(1))
                .Returns(GetTargetProduto());
            mockService.Setup(service => service.Edit(It.IsAny<Produto>()))
                .Verifiable();
            mockService.Setup(service => service.Create(It.IsAny<Produto>()))
                .Verifiable();
            controller = new ProdutoController(mockService.Object, mapper);
        }

        [TestMethod()]
        public void IndexTest_Valido()
        {
            // Act
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<ProdutoModel>));

            List<ProdutoModel>? lista = (List<ProdutoModel>)viewResult.ViewData.Model;
            Assert.AreEqual(3, lista.Count);
        }

        [TestMethod()]
        public void DetailsTest_Valido()
        {
            // Act
            var result = controller.Details(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(ProdutoModel));
            ProdutoModel produtoModel = (ProdutoModel)viewResult.ViewData.Model;
            Assert.AreEqual("Ração Petgrilo", produtoModel.Nome);
        }

        [TestMethod()]
        public void CreateTest_Get_Valido()
        {
            // Act
            var result = controller.Create();
            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod()]
        public void CreateTest_Valid()
        {
            // Act
            var result = controller.Create(GetNewProduto());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        [TestMethod()]
        public void CreateTest_Post_Invalid()
        {
            // Arrange
            controller.ModelState.AddModelError("Nome", "Campo requerido");

            // Act
            var result = controller.Create(GetNewProduto());

            // Assert
            Assert.AreEqual(1, controller.ModelState.ErrorCount);
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        [TestMethod()]
        public void EditTest_Get_Valid()
        {
            // Act
            var result = controller.Edit(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(ProdutoModel));
            ProdutoModel produtoModel = (ProdutoModel)viewResult.ViewData.Model;
            Assert.AreEqual("Ração Petgrilo", produtoModel.Nome);
        }

        [TestMethod()]
        public void EditTest_Post_Valid()
        {
            // Act
            var result = controller.Edit(GetTargetProdutoModel().Id, GetTargetProdutoModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        [TestMethod()]
        public void DeleteTest_Post_Valid()
        {
            // Act
            var result = controller.Delete(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(ProdutoModel));
            ProdutoModel produtoModel = (ProdutoModel)viewResult.ViewData.Model;
            Assert.AreEqual("Ração Petgrilo", produtoModel.Nome);
        }

        [TestMethod()]
        public void DeleteTest_Get_Valid()
        {
            // Act
            var result = controller.Delete(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(ProdutoModel));
            ProdutoModel produtoModel = (ProdutoModel)viewResult.ViewData.Model;
            Assert.AreEqual("Ração Petgrilo", produtoModel.Nome);
        }

        private ProdutoModel GetNewProduto()
        {
            return new ProdutoModel
            {
                Id = 4,
                Nome = "Chocalho",
                Codigo = 2234,
                Ativo = 1,
                Quantidade = 47,
                Preco = 24.00,
                IdPetshop = 1,
            };

        }
        private static Produto GetTargetProduto()
        {
            return new Produto
            {
                Id = 1,
                Nome = "Ração Petgrilo",
                Codigo = 1234,
                Ativo = 1,
                Quantidade = 50,
                Preco = 15.90,
                IdPetshop = 1,
            };
        }

        private ProdutoModel GetTargetProdutoModel()
        {
            return new ProdutoModel
            {
                Id = 2,
                Nome = "Ração Petgrilo",
                Codigo = 1234,
                Ativo = 1,
                Quantidade = 50,
                Preco = 15.90,
                IdPetshop = 1,
            };
        }

        private IEnumerable<Produto> GetTestProdutos()
        {
            return new List<Produto>
            {
                new Produto
                {
                    Id = 1,
                    Nome = "Ração Petgrilo",
                    Codigo = 1234,
                    Ativo = 1,
                    Quantidade = 50,
                    Preco = 15.90,
                    IdPetshop = 1
                },
                new Produto
                {
                    Id = 1,
                    Nome = "Ração Whisky",
                    Codigo = 666,
                    Ativo = 1,
                    Quantidade = 24,
                    Preco = 51.00,
                    IdPetshop = 1
                },
                new Produto
                {
                    Id = 3,
                    Nome = "Ossinho",
                    Codigo = 4002,
                    Ativo = 0,
                    Quantidade = 10,
                    Preco = 12.99,
                    IdPetshop = 1
                },
            };
        }
    }
}
