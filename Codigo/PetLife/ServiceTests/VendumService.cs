using Core.Service;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;

namespace Service.Tests
{
    [TestClass()]
    public class VendumServiceTests
    {
        private PetLifeContext _context;
        private IVendumService _vendumService;

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
            var vendum = GetVendum();

            _context.AddRange(vendum);
            _context.SaveChanges();

            _vendumService = new VendumService(_context);
        }

        private static List<Vendum> GetVendum()
        {
            return new List<Vendum>
                {
                    new Vendum { Id = 1, FormaPagamento = "Dinheiro", Parcelas = 0, Pago = 0},
                    new Vendum { Id = 2, FormaPagamento = "Cartão", Parcelas = 10, Pago = 0},
                    new Vendum { Id = 4, FormaPagamento = "Cartão", Parcelas = 5, Pago = 1},
                };
        }

        [TestMethod()]
        public void CreateTest()
        {
            Vendum vendum1 = new Vendum { Id = 1, FormaPagamento = "Dinheiro", Parcelas = 0, Pago = 0 };
            _vendumService.Create(vendum1);
            Assert.AreEqual(1, _vendumService.GetAll().Count());
            var vendum = _vendumService.Get(1);
            Assert.AreEqual((uint)1, vendum.Id);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            // Act
            _vendumService.Delete(2);
            // Assert
            Assert.AreEqual(2, _vendumService.GetAll().Count());
            var vendum = _vendumService.Get(2);
            Assert.AreEqual(null, vendum);
        }

        [TestMethod()]
        public void EditTest()
        {
            //Act 
            var vendum = _vendumService.Get(4);
            vendum.Id = 4;
            vendum.FormaPagamento = "Cartão";
            vendum.Parcelas = 10;
            vendum.Pago = 1;
            _vendumService.Edit(vendum);
            //Assert
            vendum = _vendumService.Get(4);
            Assert.IsNotNull(vendum);
            Assert.AreEqual(4, vendum.Id);
            Assert.AreEqual("Cartão", vendum.FormaPagamento);
            Assert.AreEqual(10, vendum.Parcelas);
            Assert.AreEqual(1, vendum.Pago);
        }

        [TestMethod()]
        public void GetTest()
        {
            var vendum = _vendumService.Get(1);
            Assert.IsNotNull(vendum);
            Assert.AreEqual((uint)1, vendum.Id);
            Assert.AreEqual("Cartão", vendum.FormaPagamento);
            Assert.AreEqual(10, vendum.Parcelas);
            Assert.AreEqual(1, vendum.Pago);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            // Act
            var listaVendum = _vendumService.GetAll();
            // Assert
            Assert.IsInstanceOfType(listaVendum, typeof(IEnumerable<Vendum>));
            Assert.IsNotNull(listaVendum);
            Assert.AreEqual(3, listaVendum.Count());
            Assert.AreEqual((uint)1, listaVendum.First().Id);
            Assert.AreEqual(3, listaVendum.First().Id);
        }
    }
}