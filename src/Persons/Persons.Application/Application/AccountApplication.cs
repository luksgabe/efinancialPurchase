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
        private readonly IHash _hash;
        private readonly IAccountService _accountService;

        public AccountApplication(IAccountService accountService, IMapper mapper, IHash hash)
        {
            _accountService = accountService;
            _mapper = mapper;
            _hash = hash;
        }
        public async Task<AppResult<LoginViewModel>> Login(LoginViewModel login)
        {
            AppResult<LoginViewModel> result;
            var account = _mapper.Map<LoginViewModel, Account>(login);

            CreateHash(account);

            var retorno = await _accountService.Authenticate(account);
            if (!retorno.ValidationResult.IsValid)
                result = AppResult<LoginViewModel>.Error(retorno.ValidationResult);
            else
                result = AppResult<LoginViewModel>.Succeed(login);

            return result;
        }

        private void CreateHash(Account account)
        {
            account.Login = _hash.Create(account.Login);
            account.Password = _hash.Create(account.Password);
        }
    }
}
