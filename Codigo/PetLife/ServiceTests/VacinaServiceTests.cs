using Core.Service;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;

namespace Service.Tests
{
    [TestClass()]
    public class VacinaServiceTests
    {
        private PetLifeContext _context;
        private IVacinaService _vacinaService;

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
            var vacinas = new List<Vacina>
                {
                    new Vacina { Id = 1, Nome = "Raiva", Periodo = 24},
                    new Vacina { Id = 2, Nome = "Hepatite", Periodo = 10},
                    new Vacina { Id = 3, Nome = "Bronquite", Periodo = 2},
                };

            _context.AddRange(vacinas);
            _context.SaveChanges();

            _vacinaService = new VacinaService(_context);
        }

        [TestMethod()]
        public void CreateTest()
        {
            _vacinaService.Create(new Vacina() { Id = 4, Nome = "Parvovirose", Periodo = 3 });
            Assert.AreEqual(4, _vacinaService.GetAll().Count());
            var vacina = _vacinaService.Get(4);
            Assert.AreEqual("Parvovirose", vacina.Nome);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            // Act
            _vacinaService.Delete(2);
            // Assert
            Assert.AreEqual(2, _vacinaService.GetAll().Count());
            var vacina = _vacinaService.Get(2);
            Assert.AreEqual(null, vacina);
        }

        [TestMethod()]
        public void EditTest()
        {
            //Act 
            var vacina = _vacinaService.Get(3);
            vacina.Nome = "Febre";
            vacina.Periodo = 1;
            _vacinaService.Edit(vacina);
            //Assert
            vacina = _vacinaService.Get(3);
            Assert.IsNotNull(vacina);
            Assert.AreEqual("Febre", vacina.Nome);
            Assert.AreEqual(1, vacina.Periodo);
        }

        [TestMethod()]
        public void GetTest()
        {
            var vacina = _vacinaService.Get(1);
            Assert.IsNotNull(vacina);
            Assert.AreEqual("Raiva", vacina.Nome);
            Assert.AreEqual(24, vacina.Periodo);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            // Act
            var listaVacina = _vacinaService.GetAll();
            // Assert
            Assert.IsInstanceOfType(listaVacina, typeof(IEnumerable<Vacina>));
            Assert.IsNotNull(listaVacina);
            Assert.AreEqual(3, listaVacina.Count());
            Assert.AreEqual((uint)1, listaVacina.First().Id);
            Assert.AreEqual("Raiva", listaVacina.First().Nome);
        }

        [TestMethod()]
        public void GetByNomeTest()
        {
            //Act
            var vacinas = _vacinaService.GetByNome("Raiva");
            //Assert
            Assert.IsNotNull(vacinas);
            Assert.AreEqual(1, vacinas.Count());
            Assert.AreEqual("Raiva", vacinas.First().Nome);
        }
    }
}