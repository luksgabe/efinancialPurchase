using Persons.Domain.Entities;
using Persons.Domain.Interfaces;

namespace Persons.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        void Autenticar(User user);
    }
}
