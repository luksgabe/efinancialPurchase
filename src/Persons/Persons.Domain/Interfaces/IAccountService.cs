using EFinancialPurchase.AspNet.Common.CommandResult;
using Persons.Domain.Entities;
using System.Threading.Tasks;

namespace Persons.Domain.Interfaces
{
    public interface IAccountService
    {
        Task<AppResult<User>> Authenticate(User user);
    }
}
