using Core.DTO;
using Core.Service;
using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service {
    public class VacinaService : IVacinaService {
        private readonly PetLifeContext _context;

        public VacinaService(PetLifeContext context) {
            _context = context;
        }
        public int Create(Vacina vacina) {
            _context.Add(vacina);
            _context.SaveChanges();
            return (int)vacina.Id;
        }

        public void Delete(int id) {
            var vacina = _context.Vacinas.Find(id);
            _context.Vacinas.Remove(vacina);
            _context.SaveChanges();
        }

        public void Edit(Vacina vacina) {
            _context.Update(vacina);
            _context.SaveChanges();
        }

        public Vacina Get(int id) {
            return _context.Vacinas.Find(id);
        }

        public IEnumerable<VacinaDTO> GetAll() {
            return _context.Vacinas.AsNoTracking();
        }

        public IEnumerable<VacinaDTO> GetAll(string nome) {
            return (IEnumerable<VacinaDTO>)_context.Vacinas.Where(
                Vacina => Vacina.Nome.StartsWith(nome)).AsNoTracking();
        }
    }
}
