using Core.DTO;
using Core.Service;
using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class VendumService : IVendumService
    {
        private readonly PetLifeContext context;

        public VendumService(PetLifeContext context)
        {
            this.context = context;
        }
        public int Create(Vendum vendum)
        {
            context.Add(vendum);
            context.SaveChanges();
            return (int)vendum.Id;
        }

        public void Delete(int id)
        {
            var vendum = context.Venda.Find(id);
            if (vendum != null)
            {
                context.Venda.Remove(vendum);
                context.SaveChanges();
            }
        }

        public void Edit(Vendum vendum)
        {
            context.Update(vendum);
            context.SaveChanges();
        }

        public Vendum Get(int id)
        {
            return context.Venda.Find(id);
        }

        public IEnumerable<Vendum> GetAll()
        {
            return (IEnumerable<Vendum>)context.Venda.AsNoTracking();
        }

        public IEnumerable<Vendum> GetAll(uint id)
        {
            return (IEnumerable<Vendum>)context.Venda.Where(
                Vendum => Vendum.Id == id);
        }
    }
}
