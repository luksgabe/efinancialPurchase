using Persons.Domain.Entities;
using Persons.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace Persons.Domain.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<string> Authenticate(User user)
        {
            User userLogged = await  _unitOfWork.userRepository.SearchUserAsync(user);

            //lembrar de estudar fluentValidation nativo do asp.net core
            if (userLogged == null)
            {
                throw new Exception("Usuario não encontrado");
            }

            return "gera nova chave aqui";
        }
    }
}
