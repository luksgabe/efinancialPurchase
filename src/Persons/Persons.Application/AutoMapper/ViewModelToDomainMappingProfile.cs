using AutoMapper;
using Persons.Application.ViewModels;
using Persons.Domain.Entities;

namespace Persons.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<LoginViewModel, User>()
                .ForMember(d => d.Login, d => d.MapFrom(v => v.Username))
                .ForMember(d => d.Password, d => d.MapFrom(v => v.Password));
        }
    }
}
