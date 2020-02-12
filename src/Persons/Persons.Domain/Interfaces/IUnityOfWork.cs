using System;

namespace Persons.Domain.Interfaces
{
    public interface IUnitOfWork 
    {
        IUserRepository userRepository { get; }
        IAccountRepository accountRepository { get; }
        bool Commit();

        IUserLoginValidation userLoginValidate { get; }
    }
}
