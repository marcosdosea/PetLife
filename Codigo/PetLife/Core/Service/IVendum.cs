using Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IVendumService {
        public int Create(Vendum vendum);
        public void Edit(Vendum vendum);
        public void Delete(int id);
        public Vendum Get(int id);
        public IEnumerable<VendumDTO> GetAll();
        public IEnumerable<VendumDTO> GetAll(String nome);
    }
}
