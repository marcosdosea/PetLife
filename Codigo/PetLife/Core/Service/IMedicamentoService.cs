using Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IMedicamentoService
    {
        public int Create(Medicamento medicamento);
        public void Edit(Medicamento medicamento);
        public void Delete(int id);
        public Medicamento Get(int id);
        public IEnumerable<Medicamento> GetAll();
        public IEnumerable<Medicamento> GetByNome(string nome);
    }
}
