using Core;
using AutoMapper;
using PetLifeWEB.Models;

namespace PetLifeWEB.Mappers
{
    public class MedicamentoProfile : Profile
    {
        public MedicamentoProfile()
        {
            CreateMap<MedicamentoModel, Medicamento>().ReverseMap();
        }
    }
}
