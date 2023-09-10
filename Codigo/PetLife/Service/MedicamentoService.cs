using Core;
using Core.DTO;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class MedicamentoService : IMedicamentoService
    {
        private readonly PetLifeContext context;

        public MedicamentoService(PetLifeContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Insere medicamento na base de dados
        /// </summary>
        /// <param name="medicamento"></param>
        /// <returns>Id do medicamento criado</returns>
        public int Create(Medicamento medicamento)
        {
            context.Add(medicamento);
            context.SaveChanges();
            return (int)medicamento.Id;
        }

        /// <summary>
        /// Remove medicamento na base de dados
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            var medicamento = context.Medicamentos.Find(id);
            if(medicamento != null)
            {
                context.Medicamentos.Remove(medicamento);
                context.SaveChanges();
            }
            
        }

        /// <summary>
        /// Edita medicamento na base de dados
        /// </summary>
        /// <param name="medicamento"></param>
        public void Edit(Medicamento medicamento)
        {
            context.Update(medicamento);
            context.SaveChanges();
        }

        /// <summary>
        /// Obtém medicamento da base de dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Medicamento</returns>
        public Medicamento Get(int id)
        {
            return context.Medicamentos.Find(id);
        }

        /// <summary>
        /// Obtém todos medicamentos da base de dados
        /// </summary>
        /// <returns>Todos os Medicamentos</returns>
        public IEnumerable<Medicamento> GetAll()
        {
            return context.Medicamentos.AsNoTracking();
        }

        /// <summary>
        /// Obtém medicamentos listados por nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns>Medicamentos retornados pelo nome</returns>
        public IEnumerable<Medicamento> GetByNome(string nome)
        {
            return context.Medicamentos.Where(
                medicamento => medicamento.Nome.StartsWith(nome)).AsNoTracking();
        }
    }
}
