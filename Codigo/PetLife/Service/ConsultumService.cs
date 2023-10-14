using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class ConsultumService : IConsultumService
    {
        private readonly PetLifeContext _context;

        public ConsultumService(PetLifeContext context)
        {
            this._context = context;
        }
        public uint Create(Consultum consultum)
        {
            _context.Add(consultum);
            _context.SaveChanges();
            return (uint)consultum.Id;
        }

        public void Delete(uint id)
        {
            var consultum = _context.Consulta.Find(id);
            if (consultum != null)
            {
                _context.Consulta.Remove(consultum);
                _context.SaveChanges();
            }

        }

        public void Edit(Consultum consultum)
        {
            _context.Update(consultum);
            _context.SaveChanges();
        }

        public Consultum Get(uint id)
        {
            return _context.Consulta.Find(id);
        }

        public IEnumerable<Consultum> GetAll()
        {
            return (IEnumerable<Consultum>)_context.Consulta.AsNoTracking();
        }

        public IEnumerable<Consultum> GetByStatus(string status)
        {
            return (IEnumerable<Consultum>)_context.Consulta.Where(
                Consultum => Consultum.Status.StartsWith(status)).AsNoTracking();
        }
    }
}
