using DotNetCore.Objects;
using EFinancialPurchase.AspNet.Common.CommandResult;
using Persons.Application.Interface;
using Persons.Application.ViewModels;
using Persons.Domain.Entities;
using Persons.Domain.Interfaces;
using Persons.Domain.Services;
using System.Threading.Tasks;

namespace Persons.Application.Application
{
    public class AccountApplication : IAccountApplication
    {
        private readonly IAccountService _accountService;
        
        public AccountApplication(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public async Task<AppResult<LoginViewModel>> Login(LoginViewModel login)
        {
            AppResult<LoginViewModel> result;

            //lembrar de adicionar o mapper aqui
            var user = new User
            {
                Login = login.Username,
                Password = login.Password
            };

            var retorno = await _accountService.Authenticate(user);
            if (!retorno.ValidationResult.IsValid)
                result = AppResult<LoginViewModel>.Error(retorno.ValidationResult);
            else
                result = AppResult<LoginViewModel>.Succeed(login);

            return result;
        }
    }
}
