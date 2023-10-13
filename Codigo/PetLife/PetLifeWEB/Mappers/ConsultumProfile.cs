using Core;
using AutoMapper;
using PetLifeWEB.Models;

namespace PetLifeWEB.Mappers
{
    public class ConsultumProfile : Profile
    {
        public ConsultumProfile()
        {
            CreateMap<ConsultumModel, Consultum>().ReverseMap();
        }
    }
}
