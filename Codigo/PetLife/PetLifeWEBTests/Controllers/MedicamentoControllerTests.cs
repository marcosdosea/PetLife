using AutoMapper;
using Core;
using Core.Service;
using PetLifeWEB.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetLifeWEB.Models;
using Moq;

namespace PetLifeWEB.Controllers.Tests
{
    [TestClass]
    public class MedicamentoControllerTests
    {
        private static MedicamentoController controller;

        [TestInitialize]
        public void Initialize()
        {
            // Arrange
            var mockService = new Mock<IMedicamentoService>();

            IMapper mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile(new MedicamentoProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll())
                .Returns(GetTestMedicamentos());
            mockService.Setup(service => service.Get(1))
                .Returns(GetTargetMedicamento());
            mockService.Setup(service => service.Edit(It.IsAny<Medicamento>()))
                .Verifiable();
            mockService.Setup(service => service.Create(It.IsAny<Medicamento>()))
                .Verifiable();
            controller = new MedicamentoController(mockService.Object, mapper);
        }

        [TestMethod()]
        public void IndexTest_Valido()
        {
            // Act
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<MedicamentoModel>));

            List<MedicamentoModel>? lista = (List<MedicamentoModel>)viewResult.ViewData.Model;
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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(MedicamentoModel));
            MedicamentoModel medicamentoModel = (MedicamentoModel)viewResult.ViewData.Model;
            Assert.AreEqual("Dipirona", medicamentoModel.Nome);
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
            var result = controller.Create(GetNewMedicamento());

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
            var result = controller.Create(GetNewMedicamento());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(MedicamentoModel));
            MedicamentoModel medicamentoModel = (MedicamentoModel)viewResult.ViewData.Model;
            Assert.AreEqual("Dipirona", medicamentoModel.Nome);
        }

        [TestMethod()]
        public void EditTest_Post_Valid()
        {
            // Act
            var result = controller.Edit(GetTargetMedicamentoModel().Id, GetTargetMedicamentoModel());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(MedicamentoModel));
            MedicamentoModel medicamentoModel = (MedicamentoModel)viewResult.ViewData.Model;
            Assert.AreEqual("Dipirona", medicamentoModel.Nome);
        }

        [TestMethod()]
        public void DeleteTest_Get_Valid()
        {
            // Act
            var result = controller.Delete(GetTargetMedicamentoModel().Id, (Microsoft.AspNetCore.Http.IFormCollection)GetTargetMedicamentoModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private MedicamentoModel GetNewMedicamento()
        {
            return new MedicamentoModel
            {
                Id = 4,
                Nome = "Tylenol"
            };

        }
        private static Medicamento GetTargetMedicamento()
        {
            return new Medicamento
            {
                Id = 1,
                Nome = "Dipirona",
            };
        }

        private MedicamentoModel GetTargetMedicamentoModel()
        {
            return new MedicamentoModel
            {
                Id = 2,
                Nome = "Dipirona",
            };
        }

        private IEnumerable<Medicamento> GetTestMedicamentos()
        {
            return new List<Medicamento>
            {
                new Medicamento
                {
                    Id = 1,
                    Nome = "Escabin"
                },
                new Medicamento
                {
                    Id = 2,
                    Nome = "Dipirona"
                },
                new Medicamento
                {
                    Id = 3,
                    Nome = "Ibuprofeno"
                },
            };
        }
    }
}