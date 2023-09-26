using Core.Service;
using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;


namespace Service.Tests
{
    [TestClass()]
    public class PessoaServiceTests
    {
        private PetLifeContext _context;
        private IPessoaService _pessoaService;

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
                    new Pessoa { Id = 1, 
                        Nome = "Valdir", 
                        DataNascimento = DateTime.Parse("1998-07-29"),
                        Telefone = "79999210808", 
                        Email = "valdirms@academico.ufs.br", 
                        Senha = "12345678",
                        Estado = "Sergipe", 
                        Cidade = "Itabaiana", 
                        Rua = "Eleandro do Nascimento Silva",
                        Numero = "1071", 
                        Cep = 49504337},
                    new Pessoa { Id = 2, 
                        Nome = "João", 
                        DataNascimento = DateTime.Parse("1998-07-30"),
                        Telefone = "79999210809", 
                        Email = "joaoms@academico.ufs.br", 
                        Senha = "12345678",
                        Estado = "Sergipe", 
                        Cidade = "Itabaiana", 
                        Rua = "Eleandro do Nascimento Silva",
                        Numero = "1075", 
                        Cep = 49504337},
                    new Pessoa { Id = 3,
                        Nome = "Wang",
                        DataNascimento = DateTime.Parse("1998-08-29"),
                        Telefone = "79999210810",
                        Email = "wangms@academico.ufs.br",
                        Senha = "12345678",
                        Estado = "Sergipe",
                        Cidade = "Itabaiana",
                        Rua = "Eleandro do Nascimento Silva",
                        Numero = "1073",
                        Cep = 49504337
                    },
                };

            _context.AddRange(pessoa);
            _context.SaveChanges();

            _pessoaService = new PessoaService(_context);
        }

        [TestMethod()]
        public void CreateTest()
        {
            // Act
            _pessoaService.Create(new Pessoa()
            {
                Id = 4,
                Nome = "Joana",
                DataNascimento = DateTime.Parse("1998-08-30"),
                Telefone = "79999210811",
                Email = "joanams@academico.ufs.br",
                Senha = "12345678",
                Estado = "Sergipe",
                Cidade = "Itabaiana",
                Rua = "Eleandro do Nascimento Silva",
                Numero = "1077",
                Cep = 49504337
            });
            // Assert
            Assert.AreEqual(4, _pessoaService.GetAll().Count());
            var pessoa = _pessoaService.Get(4);
            Assert.AreEqual("Joana", pessoa.Nome);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            // Act
            _pessoaService.Delete(2);
            // Assert
            Assert.AreEqual(2, _pessoaService.GetAll().Count());
            var pessoa = _pessoaService.Get(2);
            Assert.AreEqual(null, pessoa);
        }

        [TestMethod()]
        public void EditTest()
        {
            //Act 
            var pessoa = _pessoaService.Get(3);
            pessoa.Nome = "Lilica";
            pessoa.Email = "lilica@academico.ufs.br";
            pessoa.Senha = "123456789";
            pessoa.Rua = "General Siqueira";
            pessoa.Numero = "267";
            pessoa.Cep = 49500000;
            _pessoaService.Edit(pessoa);
            //Assert
            pessoa = _pessoaService.Get(3);
            Assert.IsNotNull(pessoa);
            Assert.AreEqual("Lilica", pessoa.Nome);
            Assert.AreEqual("lilica@academico.ufs.br", pessoa.Email);
            Assert.AreEqual("123456789", pessoa.Senha);
            Assert.AreEqual("General Siqueira", pessoa.Rua);
            Assert.AreEqual("267", pessoa.Numero);
            Assert.AreEqual(49500000, pessoa.Cep);
        }

        [TestMethod()]
        public void GetTest()
        {
            var pessoa = _pessoaService.Get(1);
            Assert.IsNotNull(pessoa);
            Assert.AreEqual("Valdir", pessoa.Nome);
            Assert.AreEqual(DateTime.Parse("1998-07-29"), pessoa.DataNascimento);
            Assert.AreEqual("79999210808", pessoa.Telefone);
            Assert.AreEqual("valdirms@academico.ufs.br", pessoa.Email);
            Assert.AreEqual("12345678", pessoa.Senha);
            Assert.AreEqual("Sergipe", pessoa.Estado);
            Assert.AreEqual("Itabaiana", pessoa.Cidade);
            Assert.AreEqual("Eleandro do Nascimento Silva", pessoa.Rua);
            Assert.AreEqual("1071", pessoa.Numero);
            Assert.AreEqual(49504337, pessoa.Cep);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            // Act
            var listaPessoa = _pessoaService.GetAll();
            // Assert
            Assert.IsInstanceOfType(listaPessoa, typeof(IEnumerable<Pessoa>));
            Assert.IsNotNull(listaPessoa);
            Assert.AreEqual(3, listaPessoa.Count());
            Assert.AreEqual((uint)1, listaPessoa.First().Id);
            Assert.AreEqual("Valdir", listaPessoa.First().Nome);
        }

        [TestMethod()]
        public void GetByNomeTest()
        {
            //Act
            var pessoa = _pessoaService.GetByNome("Valdir");
            //Assert
            Assert.IsNotNull(pessoa);
            Assert.AreEqual(1, pessoa.Count());
            Assert.AreEqual("Valdir", pessoa.First().Nome);
        }
    }
}