using Core;
using AutoMapper;
using PetLifeWEB.Models;

namespace PetLifeWEB.Mappers
{
    public class PessoaProfile : Profile
    {
        public PessoaProfile()
        {
            CreateMap<PessoaModel, Pessoa>().ReverseMap();
        }
    }
}
