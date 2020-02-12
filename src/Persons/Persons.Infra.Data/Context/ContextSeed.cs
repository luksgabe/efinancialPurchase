using EFinancialPurchase.AspNet.Common.Enums;
using Microsoft.EntityFrameworkCore;
using Persons.Domain.Entities;
using Persons.Domain.Enums;

namespace Persons.Infra.Data.Context
{
    public static class ContextSeed
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.SeedUsers();
            builder.SeedAccounts();
        }

        private static void SeedUsers(this ModelBuilder builder)
        {
            builder.Entity<User>(x =>
            {
                x.HasData(new User
                {
                    Id = 1,
                    Name = "Lucas Gabriel",
                    LastName = "Pereira da Silva",
                    Cpf = "85100790059",
                    Email = "85100790059",
                    Roles = Roles.User | Roles.Admin,
                    Status = Status.Active
                });
            });
        }

        private static void SeedAccounts(this ModelBuilder builder)
        {
            builder.Entity<Account>(x =>
            {
                x.HasData(new Account
                {
                    Id = 1,
                    Login = "vjQeBi/dPnPLFVDwZRJUHEE17h2i7Sjmwh188EcNgt7UuAugafd2c9OkojKw33mf0o/UopfzbeZALFQildtJUg==",
                    Password = "z8uY8pIDZ/SjS6/dQjksAkqzNXqQ2qL+GP8+UV/bZfDCqLZLF9X2QkgMUFZIqwUhX1HLTitxHSU54u23Erz+vA==",
                    Status = Status.Active,
                    IdUser = 1
                });
            });
        }

    }
}
