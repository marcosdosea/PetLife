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
    public class ConsultumControllerTests
    {
        private static ConsultumController controller;

        [TestInitialize]
        public void Initialize()
        {
            // Arrange
            var mockService = new Mock<IConsultumService>();

            IMapper mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile(new ConsultumProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll())
                .Returns(GetTestConsultum());
            mockService.Setup(service => service.Get(1))
                .Returns(GetTargetConsultum());
            mockService.Setup(service => service.Edit(It.IsAny<Consultum>()))
                .Verifiable();
            mockService.Setup(service => service.Create(It.IsAny<Consultum>()))
                .Verifiable();
            controller = new ConsultumController(mockService.Object, mapper);
        }

        [TestMethod()]
        public void IndexTest_Valido()
        {
            // Act
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<ConsultumModel>));

            List<ConsultumModel>? lista = (List<ConsultumModel>)viewResult.ViewData.Model;
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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(ConsultumModel));
            ConsultumModel consultumModel = (ConsultumModel)viewResult.ViewData.Model;
            Assert.AreEqual("A", consultumModel.Status);
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
            var result = controller.Create(GetNewConsultum());

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
            controller.ModelState.AddModelError("Status", "Campo requerido");

            // Act
            var result = controller.Create(GetNewConsultum());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(ConsultumModel));
            ConsultumModel consultumModel = (ConsultumModel)viewResult.ViewData.Model;
            Assert.AreEqual("A", consultumModel.Status);
        }

        [TestMethod()]
        public void EditTest_Post_Valid()
        {
            // Act
            var result = controller.Edit(GetTargetConsultumModel().Id, GetTargetConsultumModel());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(ConsultumModel));
            ConsultumModel consultumModel = (ConsultumModel)viewResult.ViewData.Model;
            Assert.AreEqual("A", consultumModel.Status);
        }

        [TestMethod()]
        public void DeleteTest_Get_Valid()
        {
            // Act
            var result = controller.Delete(GetTargetConsultumModel().Id, GetTargetConsultumModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private ConsultumModel GetNewConsultum()
        {
            return new ConsultumModel
            {
                Id = 2,
                Status = "R"
            };

        }
        private static Consultum GetTargetConsultum()
        {
            return new Consultum
            {
                Id = 1,
                Status = "A",
            };
        }

        private ConsultumModel GetTargetConsultumModel()
        {
            return new ConsultumModel
            {
                Id = 2,
                Status = "A",
            };
        }

        private IEnumerable<Consultum> GetTestConsultum()
        {
            return new List<Consultum>
            {
                new Consultum
                {
                    Id = 1,
                    Status = "C"
                },
                new Consultum
                {
                    Id = 2,
                    Status = "A"
                },
                new Consultum
                {
                    Id = 3,
                    Status = "R"
                },
            };
        }
    }
}