using Core.DTO;
using Core;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class PetService : IPetService
    {
        private readonly PetLifeContext _context;

        public PetService(PetLifeContext context)
        {
            _context = context;
        }
        public int Create(Pet pet)
        {
            _context.Add(pet);
            _context.SaveChanges();
            return (int)pet.Id;
        }

        public void Delete(int id)
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

        public Pet Get(int id)
        {
            return _context.Pets.Find(id);
        }

        public IEnumerable<PetDTO> GetAll()
        {
            return (IEnumerable<PetDTO>)_context.Pets.AsNoTracking();
        }

        public IEnumerable<PetDTO> GetAll(string nome)
        {
            return (IEnumerable<PetDTO>)_context.Pets.Where(
                Pet => Pet.Nome.StartsWith(nome)).AsNoTracking();
        }
    }
}
