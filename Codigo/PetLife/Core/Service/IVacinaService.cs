using Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service {
    public interface IVacinaService {
        public uint Create(Vacina vacina);
        public void Edit(Vacina vacina);
        public void Delete(uint id);
        public Vacina Get(uint id);
        public IEnumerable<Vacina> GetAll();
        public IEnumerable<Vacina> GetByNome(String nome);
    }
}
