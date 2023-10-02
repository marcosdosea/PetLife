using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IConsultumService
    {
        public uint Create(Consultum consultum);
        public void Edit(Consultum consultum);
        public void Delete(uint id);
        public Consultum Get(uint id);
        public IEnumerable<Consultum> GetAll();
        public IEnumerable<Consultum> GetByName(string descricao);
    }
}
