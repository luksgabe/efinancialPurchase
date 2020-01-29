using System;

namespace Persons.Domain.Interfaces
{
    public interface IUnitOfWork 
    {
        IUserRepository userRepository { get; }
        bool Commit();

        IUserLoginValidation userLoginValidate { get; }
    }
}
