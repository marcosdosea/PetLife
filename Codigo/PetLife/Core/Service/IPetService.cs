using Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public internal interface IPetService
    {
        public int Create(Pet pet);
        public void Edit(Pet pet);
        public void Delete(int id);
        public Pet Get(int id);
        public IEnumerable<PetDTO> GetAll();
        public IEnumerable<PetDTO> GetAll(string nome);
    }
}
