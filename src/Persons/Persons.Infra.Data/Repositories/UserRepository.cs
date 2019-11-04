using Persons.Domain.Entities;
using Persons.Domain.Interfaces;
using Persons.Infra.Data.Context;
using System.Linq;
using System.Threading.Tasks;

namespace Persons.Infra.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<User> SearchUserAsync(User user)
        {
            IQueryable<User> listUser = await GetAllAsync();
            return await Task.Run(() => listUser.FirstOrDefault(p => p.Login == user.Login && p.Password == user.Password));
        }
    }
}
