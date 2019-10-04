using Persons.Domain.Entities;
using Persons.Domain.Interfaces;
using Persons.Infra.Data.Context;
using System;

namespace Persons.Infra.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public void Autenticar(User user)
        {
            throw new NotImplementedException();
        }
    }
}
