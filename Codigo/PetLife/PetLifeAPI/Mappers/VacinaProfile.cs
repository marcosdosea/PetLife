using Core;
using AutoMapper;
using PetLifeAPI.Models;

namespace PetLifeAPI.Mappers
{
    public class VacinaProfile : Profile
    {
        public VacinaProfile()
        {
            CreateMap<VacinaModel, Vacina>().ReverseMap();
        }
    }
}

