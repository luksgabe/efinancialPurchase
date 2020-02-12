using Persons.Domain.Entities;
using System.Threading.Tasks;

namespace Persons.Domain.Interfaces
{
    public interface IAccountRepository : IRepository<Account>
    {
        Task<bool> SearchAccountAsync(Account account);
    }
}
