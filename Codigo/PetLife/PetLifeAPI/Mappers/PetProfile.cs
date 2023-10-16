using Core;
using AutoMapper;
using PetLifeAPI.Models;

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
