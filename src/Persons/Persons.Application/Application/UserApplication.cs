using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Persons.Application.Interface;
using Persons.Application.ViewModels;
using Persons.Domain.Entities;
using Persons.Domain.Interfaces;

namespace Persons.Application.Application
{
    public class UserApplication : IUserApplication
    {
        private readonly IMapper _mapper;
        public readonly IUserService _userService;

        public UserApplication(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserViewModel>> GetAll()
        {
            var list = await _userService.GetAll();
            var modelList = list.ToList();

            var model = _mapper.Map<List<User>, List<UserViewModel>>(modelList as List<User>);
            return model.ToList();
        }
    }
}
