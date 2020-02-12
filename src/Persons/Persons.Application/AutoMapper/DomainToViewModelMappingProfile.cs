using AutoMapper;
using Persons.Application.ViewModels;
using Persons.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Persons.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Account, LoginViewModel>()
                .ForMember(v => v.Login, d => d.MapFrom(t => t.Login))
                .ForMember(v => v.Password, d => d.MapFrom(t => t.Password));

            CreateMap<User, UserViewModel>()
                .ForMember(v => v.Name, d => d.MapFrom(t => t.Name))
                .ForMember(v => v.LastName, d => d.MapFrom(t => t.LastName))
                .ForMember(v => v.Cpf, d => d.MapFrom(t => t.Cpf))
                .ForMember(v => v.Email, d => d.MapFrom(t => t.Email))
                .ForMember(v => v.Roles, d => d.MapFrom(t => t.Roles))
                .ForMember(v => v.Status, d => d.MapFrom(t => t.Status));

            CreateMap<List<User>, List<UserViewModel>>();
        }
    }
}
