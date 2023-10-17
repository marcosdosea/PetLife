﻿using AutoMapper;
using Core;
using Core.Service;
using PetLifeWEB.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetLifeWEB.Models;
using Moq;
using PetLifeWEB.Controllers;

namespace PetLifeWEB.Controllers.Tests
{
    [TestClass]
    public class VendumControllerTests
    {
        private static VendumController controller;

        [TestInitialize]
        public void Initialize()
        {
            // Arrange
            var mockService = new Mock<IVendumService>();

            IMapper mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile(new VendumProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll())
                .Returns(GetTestVendum());
            mockService.Setup(service => service.Get(1))
                .Returns(GetTargetVendum());
            mockService.Setup(service => service.Edit(It.IsAny<Vendum>()))
                .Verifiable();
            mockService.Setup(service => service.Create(It.IsAny<Vendum>()))
                .Verifiable();
            controller = new VendumController(mockService.Object, mapper);
        }

        [TestMethod()]
        public void IndexTest_Valido()
        {
            // Act
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<VendumModel>));

            List<VendumModel>? lista = (List<VendumModel>)viewResult.ViewData.Model;
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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(VendumModel));
            VendumModel vendumModel = (VendumModel)viewResult.ViewData.Model;
            Assert.AreEqual((uint)1, vendumModel.Id);
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
            var result = controller.Create(GetNewVendum());

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
            var result = controller.Create(GetNewVendum());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(VendumModel));
            VendumModel vendumModel = (VendumModel)viewResult.ViewData.Model;
            Assert.AreEqual((uint)1, vendumModel.Id);
        }

        [TestMethod()]
        public void EditTest_Post_Valid()
        {
            // Act
            var result = controller.Edit(GetTargetVendumModel().Id, GetTargetVendumModel());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(VendumModel));
            VendumModel vendumModel = (VendumModel)viewResult.ViewData.Model;
            Assert.AreEqual((uint)1, vendumModel.Id);
        }

        [TestMethod()]
        public void DeleteTest_Get_Valid()
        {
            // Act
            var result = controller.Delete(GetTargetVendumModel().Id, GetTargetVendumModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private VendumModel GetNewVendum()
        {
            return new VendumModel
            {
                Id = 1,
                DataVenda = DateTime.Parse("2023-02-01"),
                FormaPagamento = "Cartão",
                Parcelas = 5,
                Pago = 1
            };

        }
        private static Vendum GetTargetVendum()
        {
            return new Vendum
            {
                Id = 1,
                DataVenda = DateTime.Parse("2023-02-15"),
                FormaPagamento = "Cartão",
                Parcelas = 10,
                Pago = 0
            };
        }

        private VendumModel GetTargetVendumModel()
        {
            return new VendumModel
            {
                Id = 1,
                DataVenda = DateTime.Parse("2023-08-01"),
                FormaPagamento = "Dinheiro",
                Parcelas = 0,
                Pago = 1
            };
        }

        private IEnumerable<Vendum> GetTestVendum()
        {
            return new List<Vendum>
            {
                new Vendum
                {
                    Id = 1,
                    DataVenda = DateTime.Parse("2023-02-01"),
                    FormaPagamento = "Cartão",
                    Parcelas = 5,
                    Pago = 1
                },
                new Vendum
                {
                    Id = 2,
                    DataVenda = DateTime.Parse("2023-02-15"),
                    FormaPagamento = "Cartão",
                    Parcelas = 10,
                    Pago = 0
                },
                new Vendum
                {
                    Id = 3,
                    DataVenda = DateTime.Parse("2023-08-01"),
                    FormaPagamento = "Dinheiro",
                    Parcelas = 0,
                    Pago = 1
                },
            };
        }
    }
}