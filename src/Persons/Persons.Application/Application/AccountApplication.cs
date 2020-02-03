using AutoMapper;
using EFinancialPurchase.AspNet.Common.CommandResult;
using Persons.Application.Interface;
using Persons.Application.ViewModels;
using Persons.CrossCutting.Security.Hash;
using Persons.Domain.Entities;
using Persons.Domain.Interfaces;
using System.Threading.Tasks;

namespace Persons.Application.Application
{
    public class AccountApplication : IAccountApplication
    {
        private readonly IMapper _mapper;
        private readonly IAccountService _accountService;
        private readonly IHash _hash;

        public AccountApplication(IAccountService accountService, IMapper mapper, IHash hash)
        {
            _accountService = accountService;
            _mapper = mapper;
            _hash = hash;
        }
        public async Task<AppResult<LoginViewModel>> Login(LoginViewModel login)
        {
            AppResult<LoginViewModel> result;
            var user = _mapper.Map<LoginViewModel, User>(login);

            CreateHash(user);

            var retorno = await _accountService.Authenticate(user);
            if (!retorno.ValidationResult.IsValid)
                result = AppResult<LoginViewModel>.Error(retorno.ValidationResult);
            else
                result = AppResult<LoginViewModel>.Succeed(login);

            return result;
        }

        private void CreateHash(User user)
        {
            user.Login = _hash.Create(user.Login);
            user.Password = _hash.Create(user.Password);
        }
    }
}
