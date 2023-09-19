using Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IPessoaService
    {
        public int Create(Pessoa pessoa);
        public void Edit(Pessoa pessoa);
        public void Delete(int id);

        public Pessoa Get(int id);

        public IEnumerable<Pessoa> GetAll();

        public IEnumerable<Pessoa> GetByNome(string nome);
    }
}
