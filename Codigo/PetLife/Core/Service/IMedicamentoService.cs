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
        public uint Create(Medicamento medicamento);
        public void Edit(Medicamento medicamento);
        public void Delete(uint id);
        public Medicamento Get(uint id);
        public IEnumerable<Medicamento> GetAll();
        public IEnumerable<Medicamento> GetByNome(string nome);
    }
}
