using Persons.Domain.Entities;
using Persons.Domain.Interfaces;
using System.Threading.Tasks;

namespace Persons.Domain.Validations.Rules
{
    public class UserRule : BaseRule<IUserRepository>
    {
        public override IUserRepository _repository { get; set; }
        public UserRule(IUserRepository repository) : base(repository)
        {
        }

    }
}
