using AutoMapper;
using EFinancialPurchase.AspNet.Common.CommandResult;
using Persons.Application.Interface;
using Persons.Application.ViewModels;
using Persons.Domain.Entities;
using Persons.Domain.Interfaces;
using System.Threading.Tasks;

namespace Persons.Application.Application
{
    public class AccountApplication : IAccountApplication
    {
        private readonly IMapper _mapper;
        private readonly IAccountService _accountService;

        public AccountApplication(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }
        public async Task<AppResult<LoginViewModel>> Login(LoginViewModel login)
        {
            AppResult<LoginViewModel> result;
            var user = _mapper.Map<LoginViewModel, User>(login);

            var retorno = await _accountService.Authenticate(user);
            if (!retorno.ValidationResult.IsValid)
                result = AppResult<LoginViewModel>.Error(retorno.ValidationResult);
            else
                result = AppResult<LoginViewModel>.Succeed(login);

            return result;
        }
    }
}
