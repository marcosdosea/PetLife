using Core;
using AutoMapper;
using PetLifeWEB.Models;

namespace PetLifeWEB.Mappers
{
    public class PetProfile : Profile
    {
        public PetProfile()
        { 
            CreateMap<PetModel, Pet>().ReverseMap();
        }
    }
}
