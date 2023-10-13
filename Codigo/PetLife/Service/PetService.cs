using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class PetService : IPetService
    {
        private readonly PetLifeContext _context;

        public PetService(PetLifeContext context)
        {
            this._context = context;
        }
        public uint Create(Pet pet)
        {
            _context.Add(pet);
            _context.SaveChanges();
            return (uint)pet.Id;
        }

        public void Delete(uint id)
        {
            var pet = _context.Pets.Find(id);
            if(pet != null)
            {
                _context.Pets.Remove(pet);
                _context.SaveChanges();
            }
            
        }

        public void Edit(Pet pet)
        {
            _context.Update(pet);
            _context.SaveChanges();
        }

        public Pet Get(uint id)
        {
            return _context.Pets.Find(id);
        }

        public IEnumerable<Pet> GetAll()
        {
            return (IEnumerable<Pet>)_context.Pets.AsNoTracking();
        }

        public IEnumerable<Pet> GetByName(string nome)
        {
            return (IEnumerable<Pet>)_context.Pets.Where(
                Pet => Pet.Nome.StartsWith(nome)).AsNoTracking();
        }
    }
}
