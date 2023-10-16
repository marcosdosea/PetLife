using Core;
using AutoMapper;
using PetLifeAPI.Models;

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
