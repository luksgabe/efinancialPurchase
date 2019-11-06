using Persons.Domain.Entities;
using Persons.Domain.Interfaces;
using System.Threading.Tasks;

namespace Persons.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<bool> SearchUserAsync(User user);
    }
}
