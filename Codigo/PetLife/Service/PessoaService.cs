using Core.DTO;
using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class PessoaService :IPessoaService
    {
        private readonly PetLifeContext context;

        public PessoaService(PetLifeContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Insere pessoa na base de dados
        /// </summary>
        /// <param name="pessoa"></param>
        /// <returns>Id do pessoa criado</returns>
        public int Create(Pessoa pessoa)
        {
            context.Add(pessoa);
            context.SaveChanges();
            return (int)pessoa.Id;
        }
        /// <summary>
        /// Edita pessoa na base de dados
        /// </summary>
        /// <param name="pessoa"></param>
        public void Edit(Pessoa pessoa)
        {
            context.Update(pessoa);
            context.SaveChanges();
        }
        /// <summary>
        /// Remove pessoa na base de dados
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            var pessoa = context.Pessoas.Find(id);
            if(pessoa != null) {
                context.Pessoas.Remove(pessoa);
                context.SaveChanges();
            }
            
        }

        /// <summary>
        /// Obtém Pessoa da base de dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Pessoa</returns>
        public Pessoa Get(int id)
        {
            return context.Pessoas.Find(id);
        }
        /// <summary>
        /// Obtém todos Pessoas da base de dados
        /// </summary>
        /// <returns>Todos os Pessoas</returns>
        public IEnumerable<Pessoa> GetAll()
        {
            return context.Pessoas.AsNoTracking();
        }

        /// <summary>
        /// Obtém pessoas listados por nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns>Pessoas retornados pelo nome</returns>
        public IEnumerable<Pessoa> GetByNome(string nome)
        {
            
           return context.Pessoas.Where(
                pessoa => pessoa.Nome.StartsWith(nome)).AsNoTracking();
        }
    }
}
