using Core.DTO;
using Core.Service;
using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Service {
    public class VacinaService : IVacinaService {
        private readonly PetLifeContext context;

        public VacinaService(PetLifeContext context) {
            this.context = context;
        }
        public int Create(Vacina vacina) {
            context.Add(vacina);
            context.SaveChanges();
            return (int)vacina.Id;
        }

        public void Delete(int id) {
            var vacina = context.Vacinas.Find(id);
            if(vacina != null)
            {
                context.Vacinas.Remove(vacina);
                context.SaveChanges();
            }
            
        }

        public void Edit(Vacina vacina) {
            context.Update(vacina);
            context.SaveChanges();
        }

        public Vacina Get(int id) {
            return context.Vacinas.Find(id);
        }

        public IEnumerable<Vacina> GetAll() {
            return context.Vacinas.AsNoTracking();
        }

        public IEnumerable<Vacina> GetByNome(string nome) {
            return context.Vacinas.Where(
                Vacina => Vacina.Nome.StartsWith(nome)).AsNoTracking();
        }
    }
}
