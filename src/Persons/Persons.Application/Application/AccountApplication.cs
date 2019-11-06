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
        public async Task<string> Login(LoginViewModel login)
        {
            //lembrar de adicionar o mapper aqui
            var user = new User
            {
                Login = login.Username,
                Password = login.Password
            };
            string token = await _accountService.Authenticate(user);
            //string token = "chave";
            return token;
        }
    }
}
