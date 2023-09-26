using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Service.Tests
{
    [TestClass()]
    public class MedicamentoServiceTests
    {
        private PetLifeContext _context;
        private IMedicamentoService _medicamentoService;

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
            var medicamentos = new List<Medicamento>
                {
                    new Medicamento { Id = 1, Nome = "Dipirona", Importado = "Sim"},
                    new Medicamento { Id = 2, Nome = "Escabin", Importado = "Não"},
                    new Medicamento { Id = 3, Nome = "Ibuprofeno", Importado = "Sim"},
                };

            _context.AddRange(medicamentos);
            _context.SaveChanges();

            _medicamentoService = new MedicamentoService(_context);
        }

        [TestMethod()]
        public void CreateTest()
        {
            // Act
            _medicamentoService.Create(new Medicamento() { Id = 4, Nome = "Tylenol", Importado = "Sim"});
            // Assert
            Assert.AreEqual(4, _medicamentoService.GetAll().Count());
            var medicamento = _medicamentoService.Get(4);
            Assert.AreEqual("Tylenol", medicamento.Nome);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            // Act
            _medicamentoService.Delete(2);
            // Assert
            Assert.AreEqual(2, _medicamentoService.GetAll().Count());
            var medicamento = _medicamentoService.Get(2);
            Assert.AreEqual(null, medicamento);
        }

        [TestMethod()]
        public void EditTest()
        {
            //Act 
            var medicamento = _medicamentoService.Get(3);
            medicamento.Nome = "Paracetamol";
            medicamento.Importado = "Não";
            _medicamentoService.Edit(medicamento);
            //Assert
            medicamento = _medicamentoService.Get(3);
            Assert.IsNotNull(medicamento);
            Assert.AreEqual("Paracetamol", medicamento.Nome);
            Assert.AreEqual("Não", medicamento.Importado);
        }

        [TestMethod()]
        public void GetTest()
        {
            var medicamento = _medicamentoService.Get(1);
            Assert.IsNotNull(medicamento);
            Assert.AreEqual("Dipirona", medicamento.Nome);
            Assert.AreEqual("Sim", medicamento.Importado);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            // Act
            var listaMedicamento = _medicamentoService.GetAll();
            // Assert
            Assert.IsInstanceOfType(listaMedicamento, typeof(IEnumerable<Medicamento>));
            Assert.IsNotNull(listaMedicamento);
            Assert.AreEqual(3, listaMedicamento.Count());
            Assert.AreEqual((uint)1, listaMedicamento.First().Id);
            Assert.AreEqual("Dipirona", listaMedicamento.First().Nome);
        }

        [TestMethod()]
        public void GetByNomeTest()
        {
            //Act
            var medicamentos = _medicamentoService.GetByNome("Dipirona");
            //Assert
            Assert.IsNotNull(medicamentos);
            Assert.AreEqual(1, medicamentos.Count());
            Assert.AreEqual("Dipirona", medicamentos.First().Nome);
        }
    }
}