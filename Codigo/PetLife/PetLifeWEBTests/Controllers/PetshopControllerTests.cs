using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PetLifeWEB.Mappers;
using PetLifeWEB.Models;
using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace PetLifeWEB.Controllers.Tests
{
    [TestClass()]
    public class PetshopControllerTests
    {
        private static PetshopController controller;

        [TestInitialize]
        public void Initialize()
        {
            var mockService = new Mock<IPetshopService>();
            IMapper mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile(new PetshopProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll()).Returns(GetTestPetshop());
            mockService.Setup(service => service.Get(1)).Returns(GetTargetPetshop());
            mockService.Setup(service => service.Create(It.IsAny<Petshop>())).Verifiable();
            mockService.Setup(service => service.Edit(It.IsAny<Petshop>())).Verifiable();

            controller = new PetshopController(mockService.Object, mapper);
        }

        [TestMethod()]
        public void IndexTest()
        {
            //Act
            var result = controller.Index();
            //Asserrt
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<PetshopModel>));

            List<PetshopModel>? lista = (List<PetshopModel>)viewResult.ViewData.Model;
            Assert.AreEqual(2, lista.Count);
        }

        [TestMethod()]
        public void DetailsTest()
        {
            //Act
            var result = controller.Details(1);
            //Asserrt
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(PetshopModel));
            PetshopModel petshopModel = (PetshopModel)viewResult.ViewData.Model;

            Assert.AreEqual((uint)1, petshopModel.Id);
            Assert.AreEqual("PetLife", petshopModel.Nome);
            Assert.AreEqual("XXXXXXXX0001XX", petshopModel.Cnpj);
            Assert.AreEqual("fabio@gmail.com", petshopModel.Email);
            Assert.AreEqual("12345678", petshopModel.Senha);
            Assert.AreEqual("79999364545", petshopModel.Telefone);
            Assert.AreEqual("Itabaiana", petshopModel.Cidade);
            Assert.AreEqual("Sergipe", petshopModel.Estado);
            Assert.AreEqual("General Siqueira", petshopModel.Rua);
            Assert.AreEqual("267", petshopModel.Numero);
            Assert.AreEqual("49500000", petshopModel.Cep);
        }

        [TestMethod()]
        public void CreateTest()
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
            var result = controller.Create(GetNewPetshop());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        [TestMethod()]
        public void CreateTest_Invalid()
        {
            //Arrage
            controller.ModelState.AddModelError("Nome", "Nome é um campo obrigatório");

            // Act
            var result = controller.Create(GetNewPetshop());

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
            var result = controller.Edit(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(PetshopModel));
            PetshopModel petshopModel = (PetshopModel)viewResult.ViewData.Model;

            Assert.AreEqual((uint)1, petshopModel.Id);
            Assert.AreEqual("PetLife", petshopModel.Nome);
            Assert.AreEqual("XXXXXXXX0001XX", petshopModel.Cnpj);
            Assert.AreEqual("fabio@gmail.com", petshopModel.Email);
            Assert.AreEqual("12345678", petshopModel.Senha);
            Assert.AreEqual("79999364545", petshopModel.Telefone);
            Assert.AreEqual("Itabaiana", petshopModel.Cidade);
            Assert.AreEqual("Sergipe", petshopModel.Estado);
            Assert.AreEqual("General Siqueira", petshopModel.Rua);
            Assert.AreEqual("267", petshopModel.Numero);
            Assert.AreEqual("49500000", petshopModel.Cep);
        }

        [TestMethod()]
        public void EditTest_Post()
        {
            // Act
            var result = controller.Edit(GetTargetPetshopModel().Id, GetTargetPetshopModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        [TestMethod()]
        public void DeleteTest_Get_Valid()
        {
            var result = controller.Delete(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(PetshopModel));
            PetshopModel petshopModel = (PetshopModel)viewResult.ViewData.Model;

            Assert.AreEqual((uint)1, petshopModel.Id);
            Assert.AreEqual("PetLife", petshopModel.Nome);
            Assert.AreEqual("XXXXXXXX0001XX", petshopModel.Cnpj);
            Assert.AreEqual("fabio@gmail.com", petshopModel.Email);
            Assert.AreEqual("12345678", petshopModel.Senha);
            Assert.AreEqual("79999364545", petshopModel.Telefone);
            Assert.AreEqual("Itabaiana", petshopModel.Cidade);
            Assert.AreEqual("Sergipe", petshopModel.Estado);
            Assert.AreEqual("General Siqueira", petshopModel.Rua);
            Assert.AreEqual("267", petshopModel.Numero);
            Assert.AreEqual("49500000", petshopModel.Cep);
        }

        [TestMethod()]
        public void DeleteTest_Post_Valid()
        {
            // Act
            var result = controller.Edit(GetTargetPetshopModel().Id, GetTargetPetshopModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private PetshopModel GetNewPetshop()
        {
            return new PetshopModel
            {
                Id = 3,
                Nome = "PetLife",
                Cnpj = "XXXXXXXX0003XX",
                Telefone = "79999364545",
                Email = "fabio@gmail.com",
                Senha = "12345678",
                Estado = "Sergipe",
                Cidade = "Itabaiana",
                Rua = "General Siqueira",
                Numero = "267",
                Cep = "49500000"
            };
        }

        private PetshopModel GetTargetPetshopModel()
        {
            return new PetshopModel
            {
                Id = 2,
                Nome = "PetLife",
                Cnpj = "XXXXXXXX0002XX",
                Telefone = "79999364545",
                Email = "fabio@gmail.com",
                Senha = "12345678",
                Estado = "Sergipe",
                Cidade = "Itabaiana",
                Rua = "General Siqueira",
                Numero = "267",
                Cep = "49500000"
            };
        }

        private Petshop GetTargetPetshop()
        {
            return new Petshop
            {
                Id = 1,
                Nome = "PetLife",
                Cnpj = "XXXXXXXX0001XX",
                Telefone = "79999364545",
                Email = "fabio@gmail.com",
                Senha = "12345678",
                Estado = "Sergipe",
                Cidade = "Itabaiana",
                Rua = "General Siqueira",
                Numero = "267",
                Cep = "49500000"
            };
        }

        private IEnumerable<Petshop> GetTestPetshop()
        {
            return new List<Petshop>
            {
                new Petshop
                {
                    Id = 1,
                    Nome = "PetLife",
                    Cnpj = "XXXXXXXX0001XX",
                    Telefone = "79999364545",
                    Email = "fabio@gmail.com",
                    Senha = "12345678",
                    Estado = "Sergipe",
                    Cidade = "Itabaiana",
                    Rua = "General Siqueira",
                    Numero = "267",
                    Cep = "49500000"
                },
                new Petshop
                {
                    Id = 2,
                    Nome = "PetLife",
                    Cnpj = "XXXXXXXX0002XX",
                    Telefone = "79999364545",
                    Email = "fabio@gmail.com",
                    Senha = "12345678",
                    Estado = "Sergipe",
                    Cidade = "Itabaiana",
                    Rua = "General Siqueira",
                    Numero = "267",
                    Cep = "49500000"
                },
            };
        }
    }
}