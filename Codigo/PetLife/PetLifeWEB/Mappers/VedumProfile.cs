using AutoMapper;
using Core;
using PetLifeWEB.Models;

namespace PetLifeWEB.Mappers
{
    public class VendumProfile : Profile
    {
        public VendumProfile()
        {
            CreateMap<VendumModel, Pet>().ReverseMap();
        }
    }

}
