using Core;
using AutoMapper;
using PetLifeWEB.Models;

namespace PetLifeAPI.Mappers
{
    public class MedicamentoProfile : Profile
    {
        public MedicamentoProfile()
        {
            CreateMap<MedicamentoModel, Medicamento>().ReverseMap();
        }
    }
}
