using Core;
using AutoMapper;
using PetLifeAPI.Models;

namespace PetLifeAPI.Mappers
{
    public class PetshopProfile : Profile
    {
        public PetshopProfile() 
        { 
            CreateMap<PetshopModel, Petshop>().ReverseMap();
        }
    }
}
