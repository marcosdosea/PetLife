using Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IPetService
    {
        public uint Create(Pet pet);
        public void Edit(Pet pet);
        public void Delete(uint id);
        public Pet Get(uint id);
        public IEnumerable<Pet> GetAll();
        public IEnumerable<Pet> GetAll(string nome);
    }
}
