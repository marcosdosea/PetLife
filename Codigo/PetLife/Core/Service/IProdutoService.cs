using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IProdutoService
    {
        public uint Create(Produto produto);
        public void Edit(Produto produto);
        public void Delete(uint id);
        public Produto Get(uint id);
        public IEnumerable<Produto> GetAll();
        public IEnumerable<Produto> GetByNome(string nome);
    }
}
