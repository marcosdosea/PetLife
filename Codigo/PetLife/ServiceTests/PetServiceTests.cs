using Core.Service;
using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Service.Tests
{
    [TestClass()]
    public class PetServiceTests
    {
        private PetLifeContext _context;
        private IPetService _petService;

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
            var pets = new List<Pet>
                {
                    new Pet { Id = 1, Nome = "Ariel", Especie = "Cachorro", Raca = "Pinscher", Sexo = "F"},
                    new Pet { Id = 2, Nome = "Pipoca", Especie = "Cachorro", Raca = "SRN", Sexo = "F"},
                    new Pet { Id = 3, Nome = "Bob", Especie = "Cachorro", Raca = "SRN", Sexo = "M"},
                };

            _context.AddRange(pets);
            _context.SaveChanges();

            _petService = new PetService(_context);
        }

        [TestMethod()]
        public void CreateTest()
        {
            // Act
            _petService.Create(new Pet() { Id = 4, Nome = "Odin", Especie = "Gato", Raca = "SRN", Sexo = "M" });
            // Assert
            Assert.AreEqual(4, _petService.GetAll().Count());
            var pet = _petService.Get(4);
            Assert.AreEqual("Odin", pet.Nome);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            // Act
            _petService.Delete(2);
            // Assert
            Assert.AreEqual(2, _petService.GetAll().Count());
            var pet = _petService.Get(2);
            Assert.AreEqual(null, pet);
        }

        [TestMethod()]
        public void EditTest()
        {
            //Act 
            var pet = _petService.Get(3);
            pet.Nome = "Ariel";
            pet.Especie = "Cachorro";
            _petService.Edit(pet);
            //Assert
            pet = _petService.Get(3);
            Assert.IsNotNull(pet);
            Assert.AreEqual("Ariel", pet.Nome);
            Assert.AreEqual("Cachorro", pet.Especie);
        }

        [TestMethod()]
        public void GetTest()
        {
            var pet = _petService.Get(1);
            Assert.IsNotNull(pet);
            Assert.AreEqual("Ariel", pet.Nome);
            Assert.AreEqual("Cachorro", pet.Especie);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            // Act
            var listaPet = _petService.GetAll();
            // Assert
            Assert.IsInstanceOfType(listaPet, typeof(IEnumerable<Pet>));
            Assert.IsNotNull(listaPet);
            Assert.AreEqual(3, listaPet.Count());
            Assert.AreEqual((uint)1, listaPet.First().Id);
            Assert.AreEqual("Ariel", listaPet.First().Nome);
        }

        [TestMethod()]
        public void GetByNomeTest()
        {
            //Act
            var pet = _petService.GetByName("Pipoca");
            //Assert
            Assert.IsNotNull(pet);
            Assert.AreEqual(1, pet.Count());
            Assert.AreEqual("Pipoca", pet.First().Nome);
        }
    }
}