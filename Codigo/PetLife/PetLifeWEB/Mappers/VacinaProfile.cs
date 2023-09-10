using Core;
using AutoMapper;
using PetLifeWEB.Models;

namespace PetLifeWEB.Mappers {
    public class VacinaProfile : Profile {
        public VacinaProfile() {
            CreateMap<VacinaModel, Vacina>().ReverseMap();
        }
    }
}
