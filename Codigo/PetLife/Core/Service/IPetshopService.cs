using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IPetshopService
    {
        public uint Create(Petshop petshop);
        public void Edit(Petshop petshop);
        public void Delete(uint id);
        public Petshop Get(uint id);
        public IEnumerable<Petshop> GetAll();
        public IEnumerable<Petshop> GetbyNome(string nome);
    }
}
