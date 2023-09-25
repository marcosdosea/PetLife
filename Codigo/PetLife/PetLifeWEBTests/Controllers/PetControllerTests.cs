using AutoMapper;
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
    public class PetControllerTests
    {
        private static PetController controller;

        [TestInitialize]
        public void Initialize()
        {
            // Arrange
            var mockService = new Mock<IPetService>();

            IMapper mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile(new PetProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll())
                .Returns(GetTestPets());
            mockService.Setup(service => service.Get(1))
                .Returns(GetTargetPet());
            mockService.Setup(service => service.Edit(It.IsAny<Pet>()))
                .Verifiable();
            mockService.Setup(service => service.Create(It.IsAny<Pet>()))
                .Verifiable();
            controller = new PetController(mockService.Object, mapper);
        }

        [TestMethod()]
        public void IndexTest_Valido()
        {
            // Act
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<PetModel>));

            List<PetModel>? lista = (List<PetModel>)viewResult.ViewData.Model;
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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(PetModel));
            PetModel petModel = (PetModel)viewResult.ViewData.Model;
            Assert.AreEqual("Narigol", petModel.Nome);
            Assert.AreEqual(DateTime.Parse("2017-02-23"), petModel.DataNascimento);
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
            var result = controller.Create(GetNewPet());

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
            var result = controller.Create(GetNewPet());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(PetModel));
            PetModel petModel = (PetModel)viewResult.ViewData.Model;
            Assert.AreEqual("Narigol", petModel.Nome);
            Assert.AreEqual(DateTime.Parse("2017-02-23"), petModel.DataNascimento);
        }

        [TestMethod()]
        public void EditTest_Post_Valid()
        {
            // Act
            var result = controller.Edit(GetTargetPetModel().Id, GetTargetPetModel());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(PetModel));
            PetModel petModel = (PetModel)viewResult.ViewData.Model;
            Assert.AreEqual("Narigol", petModel.Nome);
            Assert.AreEqual(DateTime.Parse("2017-02-23"), petModel.DataNascimento);
        }

        [TestMethod()]
        public void DeleteTest_Get_Valid()
        {
            // Act
            var result = controller.Delete(GetTargetPetModel().Id, GetTargetPetModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private PetModel GetNewPet()
        {
            return new PetModel
            {
                Id = 4,
                Nome = "Narigol",
                DataNascimento = DateTime.Parse("2017-02-23"),
                Especie = "Cachorro",
                Raca = "Pitbull",
                Sexo = "M",
                Peso = 15,
                IdTutor = 1
            };

        }
        private static Pet GetTargetPet()
        {
            return new Pet
            {
                Id = 1,
                Nome = "Narigol",
                DataNascimento = DateTime.Parse("2017-02-23"),
                Especie = "Cachorro",
                Raca = "Pitbull",
                Sexo = "M",
                Peso = 15,
                IdTutor = 1
            };
        }

        private PetModel GetTargetPetModel()
        {
            return new PetModel
            {
                Id = 2,
                Nome = "Narigol",
                DataNascimento = DateTime.Parse("2017-02-23"),
                Especie = "Cachorro",
                Raca = "Pitbull",
                Sexo = "M",
                Peso = 15,
                IdTutor = 1
            };
        }

        private IEnumerable<Pet> GetTestPets()
        {
            return new List<Pet>
            {
                new Pet
                {
                    Id = 1,
                    Nome = "Narigol",
                    DataNascimento = DateTime.Parse("2017-02-23"),
                    Especie = "Cachorro",
                    Raca = "Pitbull",
                    Sexo = "M",
                    Peso = 15,
                    IdTutor = 1
                },
                new Pet
                {
                    Id = 2,
                    Nome = "Rodrigo Cheiro",
                    DataNascimento = DateTime.Parse("2015-05-23"),
                    Especie = "Cachorro",
                    Raca = "Chiuaua",
                    Sexo = "M",
                    Peso = 2,
                    IdTutor = 1
                },
                new Pet
                {
                    Id = 3,
                    Nome = "Gabibunda",
                    DataNascimento = DateTime.Parse("2019-11-23"),
                    Especie = "Cachorro",
                    Raca = "Pinscher",
                    Sexo = "M",
                    Peso = 4,
                    IdTutor = 1
                },
            };
        }
    }
}