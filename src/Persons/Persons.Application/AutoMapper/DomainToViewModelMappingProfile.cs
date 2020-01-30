using AutoMapper;
using Persons.Application.ViewModels;
using Persons.Domain.Entities;

namespace Persons.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<User, LoginViewModel>()
                .ForMember(v => v.Username, d => d.MapFrom(t => t.Login))
                .ForMember(v => v.Password, d => d.MapFrom(t => t.Password));
        }
    }
}
