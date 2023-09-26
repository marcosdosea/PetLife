using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PetLifeWEB.Mappers;
using PetLifeWEB.Models;

namespace PetLifeWEB.Controllers.Tests 
    {
    [TestClass()]
    public class VacinaControllerTests 
    {
        private static VacinaController controller;

        [TestInitialize]
        public void Initialize() 
        {
            // Arrange
            var mockService = new Mock<IVacinaService>();

            IMapper mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile(new VacinaProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll())
                .Returns(GetTestVacinas());
            mockService.Setup(service => service.Get(1))
                .Returns(GetTargetVacina());
            mockService.Setup(service => service.Edit(It.IsAny<Vacina>()))
                .Verifiable();
            mockService.Setup(service => service.Create(It.IsAny<Vacina>()))
                .Verifiable();
            controller = new VacinaController(mockService.Object, mapper);
        }
        [TestMethod()]
        public void IndexTest_Valido() 
        {
            // Act
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<VacinaModel>));

            List<VacinaModel>? lista = (List<VacinaModel>)viewResult.ViewData.Model;
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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(VacinaModel));
            VacinaModel vacinaModel = (VacinaModel)viewResult.ViewData.Model;
            Assert.AreEqual("Raiva", vacinaModel.Nome);
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
            var result = controller.Create(GetNewVacina());

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
            var result = controller.Create(GetNewVacina());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(VacinaModel));
            VacinaModel vacinaModel = (VacinaModel)viewResult.ViewData.Model;
            Assert.AreEqual("Raiva", vacinaModel.Nome);
        }

        [TestMethod()]
        public void EditTest_Post_Valid() 
        {
            // Act
            var result = controller.Edit(GetTargetVacinaModel().Id, GetTargetVacinaModel());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(VacinaModel));
            VacinaModel vacinaModel = (VacinaModel)viewResult.ViewData.Model;
            Assert.AreEqual("Raiva", vacinaModel.Nome);
        }

        [TestMethod()]
        public void DeleteTest_Get_Valid() 
        {
            // Act
            var result = controller.Delete(GetTargetVacinaModel().Id, (Microsoft.AspNetCore.Http.IFormCollection)GetTargetVacinaModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }
        private VacinaModel GetNewVacina() 
        {
            return new VacinaModel {
                Nome = "Parvovirose",
                Periodo = 3
            };
        }
        private static Vacina GetTargetVacina() 
        {
            return new Vacina {
                Id = 4,
                Nome = "Raiva",
            };
        }
        private VacinaModel GetTargetVacinaModel()
        {
            return new VacinaModel
            {
                Nome = "Raiva",
                Periodo = 24
            };
        }
        private IEnumerable<Vacina> GetTestVacinas() 
        {
            return new List<Vacina>
            {
                new Vacina
                {
                    Id = 1,
                    Nome = "Raiva"
                },
                new Vacina
                {
                    Id = 2,
                    Nome = "Hepatite"
                },
                new Vacina
                {
                    Id = 3,
                    Nome = "Bronquite"
                },
            };
        }

    }
}