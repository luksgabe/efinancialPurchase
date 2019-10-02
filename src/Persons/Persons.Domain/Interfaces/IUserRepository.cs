using Persons.Domain.Entities;

namespace Persons.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        void Autenticar(User user);
    }
}
