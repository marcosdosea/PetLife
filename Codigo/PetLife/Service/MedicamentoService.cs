using Core;
using Core.DTO;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class MedicamentoService : IMedicamentoService
    {
        private readonly PetLifeContext _context;

        public MedicamentoService(PetLifeContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Insere medicamento na base de dados
        /// </summary>
        /// <param name="medicamento"></param>
        /// <returns>Id do medicamento criado</returns>
        public int Create(Medicamento medicamento)
        {
            _context.Add(medicamento);
            _context.SaveChanges();
            return (int)medicamento.Id;
        }

        /// <summary>
        /// Remove medicamento na base de dados
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            var medicamento = _context.Medicamentos.Find(id);
            _context.Medicamentos.Remove(medicamento);
            _context.SaveChanges();
        }

        /// <summary>
        /// Edita medicamento na base de dados
        /// </summary>
        /// <param name="medicamento"></param>
        public void Edit(Medicamento medicamento)
        {
            _context.Update(medicamento);
            _context.SaveChanges();
        }

        /// <summary>
        /// Obtém medicamento da base de dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Medicamento</returns>
        public Medicamento Get(int id)
        {
            return _context.Medicamentos.Find(id);
        }

        /// <summary>
        /// Obtém todos medicamentos da base de dados
        /// </summary>
        /// <returns>Todos os Medicamentos</returns>
        public IEnumerable<MedicamentoDTO> GetAll()
        {
            return _context.Medicamentos.AsNoTracking();
        }

        /// <summary>
        /// Obtém medicamentos listados por nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns>Medicamentos retornados pelo nome</returns>
        public IEnumerable<MedicamentoDTO> GetByNome(string nome)
        {
            return (IEnumerable<MedicamentoDTO>)_context.Medicamentos.Where(
                medicamento => medicamento.Nome.StartsWith(nome)).AsNoTracking();
        }
    }
}
