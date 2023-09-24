using Core;
using AutoMapper;
using PetLifeWEB.Models;

namespace PetLifeWEB.Mappers
{
    public class PetshopProfile : Profile
    {
        public PetshopProfile() 
        { 
            CreateMap<PetshopModel, Petshop>().ReverseMap();
        }
    }
}
