using Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service {
    public interface IVacinaService {
        public int Create(Vacina vacina);
        public void Edit(Vacina vacina);
        public void Delete(int id);
        public Vacina Get(int id);
        public IEnumerable<VacinaDTO> GetAll();
        public IEnumerable<VacinaDTO> GetAll(String nome);
    }
}
