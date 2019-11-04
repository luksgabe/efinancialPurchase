
using Persons.Domain.Entities;
using System.Threading.Tasks;

namespace Persons.Domain.Interfaces
{
    public interface IAccountService
    {
        Task<string> Authenticate(User user);
    }
}
