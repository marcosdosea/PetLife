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
    public class PessoaControllerTests
    {
        private static PessoaController controller;
        

        [TestInitialize]
        public void Initialize()
        {
            var mockService = new Mock<IPessoaService>();
            IMapper mapper = new MapperConfiguration(cfg => 
                cfg.AddProfile(new PessoaProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll()).Returns(GetTestPessoa());
            mockService.Setup(service => service.Get(1)).Returns(GetTargetPessoa());
            mockService.Setup(service => service.Create(It.IsAny<Pessoa>())).Verifiable();
            mockService.Setup(service => service.Edit(It.IsAny<Pessoa>())).Verifiable();
            
            controller = new PessoaController(mockService.Object, mapper);
        }
        
        

        [TestMethod()]
        public void IndexTest()
        {

            //Act
            var result = controller.Index();
            //Asserrt
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<PessoaModel>));

            List<PessoaModel>? lista = (List<PessoaModel>)viewResult.ViewData.Model;
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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(PessoaModel));
            PessoaModel pessoaModel = (PessoaModel)viewResult.ViewData.Model;

            Assert.AreEqual((uint)1, pessoaModel.Id);
            Assert.AreEqual("Fabio Santana", pessoaModel.Nome);
            Assert.AreEqual(DateTime.Parse("1969-03-17"), pessoaModel.DataNascimento);
            Assert.AreEqual("79999364545", pessoaModel.Telefone);
            Assert.AreEqual("fabio@gmail.com", pessoaModel.Email);
            Assert.AreEqual("12345678", pessoaModel.Senha);
            Assert.AreEqual("Sergipe", pessoaModel.Estado);
            Assert.AreEqual("Itabaiana", pessoaModel.Cidade);
            Assert.AreEqual("General Siqueira", pessoaModel.Rua);
            Assert.AreEqual("267", pessoaModel.Numero);
            Assert.AreEqual(49500000, pessoaModel.Cep);
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
            var result = controller.Create(GetNewPessoa());

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
            var result = controller.Create(GetNewPessoa());

            // Assert
            Assert.AreEqual(1, controller.ModelState.ErrorCount);
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        [TestMethod()]
        public void EditTest_Get()
        {
            var result = controller.Edit(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(PessoaModel));
            PessoaModel pessoaModel = (PessoaModel)viewResult.ViewData.Model;
            
            Assert.AreEqual((uint)1, pessoaModel.Id);
            Assert.AreEqual("Fabio Santana", pessoaModel.Nome);
            Assert.AreEqual(DateTime.Parse("1969-03-17"), pessoaModel.DataNascimento);
            Assert.AreEqual("79999364545", pessoaModel.Telefone);
            Assert.AreEqual("fabio@gmail.com", pessoaModel.Email);
            Assert.AreEqual("12345678", pessoaModel.Senha);
            Assert.AreEqual("Sergipe", pessoaModel.Estado);
            Assert.AreEqual("Itabaiana", pessoaModel.Cidade);
            Assert.AreEqual("General Siqueira", pessoaModel.Rua);
            Assert.AreEqual("267", pessoaModel.Numero);
            Assert.AreEqual(49500000, pessoaModel.Cep);
        }

        [TestMethod()]
        public void EditTest_Post()
        {
            // Act
            var result = controller.Edit(GetTargetPessoaModel().Id, GetTargetPessoaModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        [TestMethod()]
        public void DeleteTest_Post()
        {
            //Act
            var result = controller.Delete(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(PessoaModel));
            PessoaModel pessoaModel = (PessoaModel)viewResult.ViewData.Model;

            Assert.AreEqual((uint)1, pessoaModel.Id);
            Assert.AreEqual("Fabio Santana", pessoaModel.Nome);
            Assert.AreEqual(DateTime.Parse("1969-03-17"), pessoaModel.DataNascimento);
            Assert.AreEqual("79999364545", pessoaModel.Telefone);
            Assert.AreEqual("fabio@gmail.com", pessoaModel.Email);
            Assert.AreEqual("12345678", pessoaModel.Senha);
            Assert.AreEqual("Sergipe", pessoaModel.Estado);
            Assert.AreEqual("Itabaiana", pessoaModel.Cidade);
            Assert.AreEqual("General Siqueira", pessoaModel.Rua);
            Assert.AreEqual("267", pessoaModel.Numero);
            Assert.AreEqual(49500000, pessoaModel.Cep);

        }

        [TestMethod()]
        public void DeleteTest_Get()
        {
            // Act
            var result = controller.Delete(GetTargetPessoaModel().Id, GetTargetPessoaModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private PessoaModel GetNewPessoa()
        {
            return new PessoaModel
            {
                Id = 3,
                Nome = "Fabio Santana",
                DataNascimento = DateTime.Parse("1969-03-17"),
                Telefone = "79999364545",
                Email = "fabio@gmail.com",
                Senha = "12345678",
                Estado = "Sergipe",
                Cidade = "Itabaiana",
                Rua = "General Siqueira",
                Numero = "267",
                Cep = 49500000
            };
        }

        private PessoaModel GetTargetPessoaModel() 
        {
            return new PessoaModel 
            {
                Id = 2,
                Nome = "Fabio Santana",
                DataNascimento = DateTime.Parse("1969-03-17"),
                Telefone = "79999364545",
                Email = "fabio@gmail.com",
                Senha = "12345678",
                Estado = "Sergipe",
                Cidade = "Itabaiana",
                Rua = "General Siqueira",
                Numero = "267",
                Cep = 49500000
            };
        }

        private Pessoa GetTargetPessoa() 
        {
            return new Pessoa
            {
                Id = 1,
                Nome = "Fabio Santana",
                DataNascimento = DateTime.Parse("1969-03-17"),
                Telefone = "79999364545",
                Email = "fabio@gmail.com",
                Senha = "12345678",
                Estado = "Sergipe",
                Cidade = "Itabaiana",
                Rua = "General Siqueira",
                Numero = "267",
                Cep = 49500000
            };
        }

        private IEnumerable<Pessoa> GetTestPessoa() 
        {
            return new List<Pessoa>
            {
                new Pessoa
                {
                    Id = 1,
                    Nome = "Fabio Santana",
                    DataNascimento = DateTime.Parse("1969-03-17"),
                    Telefone = "79999364545",
                    Email = "fabio@gmail.com",
                    Senha = "12345678",
                    Estado = "Sergipe",
                    Cidade = "Itabaiana",
                    Rua = "General Siqueira",
                    Numero = "267",
                    Cep = 49500000
                },
                new Pessoa
                {
                    Id = 2,
                    Nome = "Fabio Santana",
                    DataNascimento = DateTime.Parse("1969-03-17"),
                    Telefone = "79999364545",
                    Email = "fabio@gmail.com",
                    Senha = "12345678",
                    Estado = "Sergipe",
                    Cidade = "Itabaiana",
                    Rua = "General Siqueira",
                    Numero = "267",
                    Cep = 49500000
                },
            };
        }
    }
}