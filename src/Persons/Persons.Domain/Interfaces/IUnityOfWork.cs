using System;

namespace Persons.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository userRepository { get; }

        bool Commit();
    }
}
