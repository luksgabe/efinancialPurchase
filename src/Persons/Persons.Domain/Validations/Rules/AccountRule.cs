using Persons.Domain.Entities;
using Persons.Domain.Interfaces;
using System.Threading.Tasks;

namespace Persons.Domain.Validations.Rules
{
    public class AccountRule : BaseRule<IAccountRepository>
    {
        public override IAccountRepository _repository { get; set; }
        public AccountRule(IAccountRepository repository) : base(repository)
        {
        }

        public async Task<bool> UserLoginAccountExist(Account account)
        {
            return await _repository.SearchAccountAsync(account);
        }
    
    }
}
