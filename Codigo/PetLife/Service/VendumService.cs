using Core.DTO;
using Core.Service;
using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class VendumService : IVendumService
    {
        private readonly PetLifeContext _context;

        public VendumService(PetLifeContext context)
        {
            _context = context;
        }
        public int Create(Vendum vendum)
        {
            _context.Add(vendum);
            _context.SaveChanges();
            return (int)vendum.Id;
        }

        public void Delete(int id)
        {
            var vendum = _context.Venda.Find(id);
            _context.Venda.Remove(vendum);
            _context.SaveChanges();
        }

        public void Edit(Vendum vendum)
        {
            _context.Update(vendum);
            _context.SaveChanges();
        }

        public Vendum Get(int id)
        {
            return _context.Venda.Find(id);
        }

        public IEnumerable<VendumDTO> GetAll()
        {
            return _context.Venda.AsNoTracking();
        }

        public IEnumerable<VendumDTO> GetAll(int id)
        {
            return (IEnumerable<VendumDTO>)_context.Venda.Where(
                Vendum => Vendum.Id==id);
        }
    }
}
