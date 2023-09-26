using Core;
using AutoMapper;
using PetLifeWEB.Models;

namespace PetLifeWEB.Mappers
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            CreateMap<ProdutoModel, Produto>().ReverseMap();
        }
    }
}
