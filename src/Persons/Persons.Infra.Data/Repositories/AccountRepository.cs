using System.Linq;
using System.Threading.Tasks;
using Persons.Domain.Entities;
using Persons.Domain.Interfaces;
using Persons.Infra.Data.Context;

namespace Persons.Infra.Data.Repositories
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<bool> SearchAccountAsync(Account account)
        {
            IQueryable<Account> listUser = await GetAllAsync();
            return await Task.Run(() => listUser.Any(p => p.Login == account.Login && p.Password == account.Password));
        }
    }
}
