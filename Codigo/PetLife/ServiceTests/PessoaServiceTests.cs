using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Service.Tests
{
    [TestClass()]
    public class PessoaServiceTests
    {
        private PetLifeContext _context;
        private IPessoaService? _pessoaService;

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
            var pessoa = new List<Pessoa>
                {
                    new Pessoa 
                    {
                        Id = 1,
                        Nome = "Valdir Santana",
                        DataNascimento = DateTime.Parse("1998-07-29"),
                        Telefone = "79999210808",
                        Email = "valdir@gmail.com",
                        Senha = "12345678",
                        Estado = "Sergipe",
                        Cidade = "Itabaiana",
                        Rua = "General Siqueira",
                        Numero = "267",
                        Cep = 49500000
                    },
                    new Pessoa 
                    {
                        Id = 3,
                        Nome = "Maria Santana",
                        DataNascimento = DateTime.Parse("1969-02-13"),
                        Telefone = "79999364565",
                        Email = "maria@gmail.com",
                        Senha = "12345678",
                        Estado = "Sergipe",
                        Cidade = "Itabaiana",
                        Rua = "General Siqueira",
                        Numero = "267",
                        Cep = 49500000 
                    },
                };

            _context.AddRange(pessoa);
            _context.SaveChanges();

            _pessoaService = new PessoaService(_context);
        }

        

        [TestMethod()]
        public void CreateTest()
        {
            //Act
            _pessoaService.Create(new Pessoa()
            {
                Id = 3,
                Nome = "Joao Santana",
                DataNascimento = DateTime.Parse("20-08-13"),
                Telefone = "79999364569",
                Email = "joao@gmail.com",
                Senha = "12345678",
                Estado = "Sergipe",
                Cidade = "Itabaiana",
                Rua = "General Siqueira",
                Numero = "267",
                Cep = 49500000
            });
            //Assert
            Assert.AreEqual(3, _pessoaService.GetAll().Count());
            var pessoa = _pessoaService.Get(6);
            Assert.AreEqual("Joao Santana", pessoa.Nome);
            Assert.AreEqual(DateTime.Parse("20-08-13"), pessoa.DataNascimento);
            Assert.AreEqual("79999364545", pessoa.Telefone);
            Assert.AreEqual("joao@gmail.com", pessoa.Email);
            Assert.AreEqual("12345678", pessoa.Senha);
            Assert.AreEqual("Sergipe", pessoa.Estado);
            Assert.AreEqual("Itabaiana", pessoa.Cidade);
            Assert.AreEqual("General Siqueira", pessoa.Rua);
            Assert.AreEqual("267", pessoa.Numero);
            Assert.AreEqual(49500000, pessoa.Cep);
        }

        [TestMethod()]
        public void EditTest()
        {
            //Act 
            var pessoa = _pessoaService.Get(6);
            pessoa.Nome = "Gustavo Jobs";
            pessoa.DataNascimento = DateTime.Parse("1980-12-25");
            pessoa.Telefone = "79999364580";
            pessoa.Email = "gustavo@gmail.com";
            pessoa.Senha = "12345678";
            pessoa.Estado = "Sergipe";
            pessoa.Cidade = "Itabaiana";
            pessoa.Rua = "General Siqueira";
            pessoa.Numero = "267";
            pessoa.Cep = 49500000;

            _pessoaService.Edit(pessoa);
            //Assert
            pessoa = _pessoaService.Get(6);
            Assert.IsNotNull(pessoa);
            Assert.AreEqual("Joao Santana", pessoa.Nome);
            Assert.AreEqual(DateTime.Parse("20-08-13"), pessoa.DataNascimento);
            Assert.AreEqual("79999364545", pessoa.Telefone);
            Assert.AreEqual("joao@gmail.com", pessoa.Email);
            Assert.AreEqual("12345678", pessoa.Senha);
            Assert.AreEqual("Sergipe", pessoa.Estado);
            Assert.AreEqual("Itabaiana", pessoa.Cidade);
            Assert.AreEqual("General Siqueira", pessoa.Rua);
            Assert.AreEqual("267", pessoa.Numero);
            Assert.AreEqual(49500000, pessoa.Cep);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            // Act
            _pessoaService.Delete(6);
            // Assert
            Assert.AreEqual((uint)6, _pessoaService.GetAll().Count());
            var pessoa = _pessoaService.Get(6);
            Assert.AreEqual(null, pessoa);
        }

        [TestMethod()]
        public void GetTest()
        {
            var pessoa = _pessoaService.Get(6);
            Assert.IsNotNull(pessoa);
            Assert.AreEqual("Joao Santana", pessoa.Nome);
            Assert.AreEqual(DateTime.Parse("20-08-13"), pessoa.DataNascimento);
            Assert.AreEqual("79999364545", pessoa.Telefone);
            Assert.AreEqual("joao@gmail.com", pessoa.Email);
            Assert.AreEqual("12345678", pessoa.Senha);
            Assert.AreEqual("Sergipe", pessoa.Estado);
            Assert.AreEqual("Itabaiana", pessoa.Cidade);
            Assert.AreEqual("General Siqueira", pessoa.Rua);
            Assert.AreEqual("267", pessoa.Numero);
            Assert.AreEqual(49500000, pessoa.Cep);
        }

    }
}