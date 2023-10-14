using Core.Service;
using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Service.Tests
{
    [TestClass()]
    public class PetshopServiceTests
    {
        private PetLifeContext _context;
        private IPetshopService _petshopService;

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

            var petshop = new List<Petshop>
            {
                new Petshop
                {
                    Id = 1,
                    Nome = "PetLife",
                    Cnpj = "XXXXXXXX0001XX",
                    Telefone = "79999364545",
                    Email = "petlife@gmail.com",
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
                    Nome = "Pet",
                    Cnpj = "XXXXXXXX0002XX",
                    Telefone = "79999364546",
                    Email = "pet@gmail.com",
                    Senha = "12345678",
                    Estado = "Sergipe",
                    Cidade = "Itabaiana",
                    Rua = "General Siqueira",
                    Numero = "271",
                    Cep = "49500000"
                },
                new Petshop
                {
                    Id = 3,
                    Nome = "Life",
                    Cnpj = "XXXXXXXX0003XX",
                    Telefone = "79999364547",
                    Email = "life@gmail.com",
                    Senha = "12345678",
                    Estado = "Sergipe",
                    Cidade = "Itabaiana",
                    Rua = "General Siqueira",
                    Numero = "269",
                    Cep = "49500000"
                },
            };

            _context.AddRange(petshop);
            _context.SaveChanges();

            _petshopService = new PetshopService(_context);

        }

        [TestMethod()]
        public void CreateTest()
        {
            _petshopService.Create(new Petshop()
            {
                Id = 4,
                Nome = "Pet_Life",
                Cnpj = "XXXXXXXX0004XX",
                Telefone = "79999364548",
                Email = "pet_life@gmail.com",
                Senha = "12345678",
                Estado = "Sergipe",
                Cidade = "Itabaiana",
                Rua = "General Siqueira",
                Numero = "273",
                Cep = "49500000"
            });

            //Assert
            Assert.AreEqual(4, _petshopService.GetAll().Count());
            var pessoa = _petshopService.Get(4);
            Assert.AreEqual("Pet_Life", pessoa.Nome);
        }

        [TestMethod()]
        public void EditTest()
        {
            //Act
            var petshop = _petshopService.Get(3);
            _petshopService.Edit(petshop);
            petshop.Nome = "Life";
            petshop.Email = "life@gmail.com";
            petshop.Senha = "12345678";
            petshop.Rua = "General Siqueira";
            petshop.Numero = "269";
            petshop.Cep = "49500000";

            //Assert
            petshop = _petshopService.Get(3);
            Assert.IsNotNull(petshop);
            Assert.AreEqual("Life", petshop.Nome);
            Assert.AreEqual("life@gmail.com", petshop.Email);
            Assert.AreEqual("12345678", petshop.Senha);
            Assert.AreEqual("General Siqueira", petshop.Rua);
            Assert.AreEqual("269", petshop.Numero);
            Assert.AreEqual("49500000", petshop.Cep);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            // Act
            _petshopService.Delete(2);
            // Assert
            Assert.AreEqual(2, _petshopService.GetAll().Count());
            var petshop = _petshopService.Get(2);
            Assert.AreEqual(null, petshop);
        }

        [TestMethod()]
        public void GetTest()
        {
            var petshop = _petshopService.Get(1);
            Assert.IsNotNull(petshop);
            Assert.AreEqual("PetLife", petshop.Nome);
            Assert.AreEqual("XXXXXXXX0001XX", petshop.Cnpj);
            Assert.AreEqual("petlife@gmail.com", petshop.Email);
            Assert.AreEqual("12345678", petshop.Senha);
            Assert.AreEqual("79999364545", petshop.Telefone);
            Assert.AreEqual("Itabaiana", petshop.Cidade);
            Assert.AreEqual("Sergipe", petshop.Estado);
            Assert.AreEqual("General Siqueira", petshop.Rua);
            Assert.AreEqual("267", petshop.Numero);
            Assert.AreEqual("49500000", petshop.Cep);

        }

        [TestMethod()]
        public void GetAllTest()
        {
            var listaPetshop = _petshopService.GetAll();
            // Assert
            Assert.IsInstanceOfType(listaPetshop, typeof(IEnumerable<Petshop>));
            Assert.IsNotNull(listaPetshop);
            Assert.AreEqual(3, listaPetshop.Count());
            Assert.AreEqual((uint)1, listaPetshop.First().Id);
            Assert.AreEqual("PetLife", listaPetshop.First().Nome);
        }

        [TestMethod()]
        public void GetbyNomeTest()
        {
            //Act
            var petshop = _petshopService.GetbyNome("PetLife");
            //Assert
            Assert.IsNotNull(petshop);
            Assert.AreEqual(1, petshop.Count());
            Assert.AreEqual("PetLife", petshop.First().Nome);
        }
    }
}