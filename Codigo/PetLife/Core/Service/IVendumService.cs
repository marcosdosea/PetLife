using Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IVendumService
    {
        public uint Create(Vendum vendum);
        public void Edit(Vendum vendum);
        public void Delete(uint id);
        public Vendum Get(uint id);
        public IEnumerable<Vendum> GetAll();
        public IEnumerable<Vendum> GetAll(uint id);
    }
}
