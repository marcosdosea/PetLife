using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Core;

namespace Service
{
    public class PetshopService :IPetshopService
    {
        private readonly PetLifeContext context;

        public PetshopService(PetLifeContext context)
        {
            this.context = context;
        }

        public uint Create(Petshop petshop)
        {
            context.Add(petshop);
            context.SaveChanges();
            return (uint)petshop.Id;
        }

        public void Edit(Petshop petshop) 
        { 
            context.Update(petshop);
            context.SaveChanges();
        }

        public void Delete(uint id) 
        {
            var petshop = context.Petshops.Find(id);
            if(petshop != null ) 
            {
                context.Petshops.Remove(petshop);
                context.SaveChanges();
            }
        }

        public Petshop Get(uint id)
        {
            return context.Petshops.Find(id);
        }

        public IEnumerable<Petshop> GetAll()
        {
            return context.Petshops.AsNoTracking();
        }

        public IEnumerable<Petshop> GetbyNome(string nome)
        {
            return context.Petshops.Where(
                petshop => petshop.Nome.StartsWith(nome)).AsNoTracking();
        }
    }
}
