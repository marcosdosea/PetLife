using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Service.Tests
{
    [TestClass()]
    public class ConsultumServiceTests
    {
        private PetLifeContext _context;
        private IConsultumService _consultumService;

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
            var consulta = new List<Consultum>
                {
                    new Consultum { Id = 1, Status = "A", Descricao = "Consulta"},
                    new Consultum { Id = 2, Status = "R", Descricao = "Cirurgia"},
                    new Consultum { Id = 3, Status = "C", Descricao = "Retorno"},
                };

            _context.AddRange(consulta);
            _context.SaveChanges();

            _consultumService = new ConsultumService(_context);
        }

        [TestMethod()]
        public void CreateTest()
        {
            // Act
            _consultumService.Create(new Consultum() { Id = 4, Status = "C", Descricao = "Cirurgia"});
            // Assert
            Assert.AreEqual(4, _consultumService.GetAll().Count());
            var consultum = _consultumService.Get(4);
            Assert.AreEqual("C", consultum.Status);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            // Act
            _consultumService.Delete(2);
            // Assert
            Assert.AreEqual(2, _consultumService.GetAll().Count());
            var consultum = _consultumService.Get(2);
            Assert.AreEqual(null, consultum);
        }

        [TestMethod()]
        public void EditTest()
        {
            //Act 
            var consultum = _consultumService.Get(3);
            consultum.Status = "R";
            _consultumService.Edit(consultum);
            //Assert
            consultum = _consultumService.Get(3);
            Assert.IsNotNull(consultum);
            Assert.AreEqual("R", consultum.Status);
        }

        [TestMethod()]
        public void GetTest()
        {
            var consultum = _consultumService.Get(1);
            Assert.IsNotNull(consultum);
            Assert.AreEqual("A", consultum.Status);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            // Act
            var listaConsulta = _consultumService.GetAll();
            // Assert
            Assert.IsInstanceOfType(listaConsulta, typeof(IEnumerable<Consultum>));
            Assert.IsNotNull(listaConsulta);
            Assert.AreEqual(3, listaConsulta.Count());
            Assert.AreEqual((uint)1, listaConsulta.First().Id);
            Assert.AreEqual("A", listaConsulta.First().Status);
        }

        [TestMethod()]
        public void GetByNomeTest()
        {
            //Act
            var consultum = _consultumService.GetByStatus("A");
            //Assert
            Assert.IsNotNull(consultum);
            Assert.AreEqual(1, consultum.Count());
            Assert.AreEqual("A", consultum.First().Status);
        }
    }
}