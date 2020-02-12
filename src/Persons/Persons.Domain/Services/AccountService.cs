using Persons.Domain.Entities;
using Persons.Domain.Interfaces;
using System.Threading.Tasks;
using EFinancialPurchase.AspNet.Common.Interfaces;
using EFinancialPurchase.AspNet.Common.CommandResult;

namespace Persons.Domain.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidatorApp<Account> _validator;

        public AccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _validator = _unitOfWork.userLoginValidate;
        }

        public async Task<AppResult<Account>> Authenticate(Account account)
        {
            var result = await Task.Run(() => _validator.ValidateObject(account));

            if (!result.IsValid)
                return AppResult<Account>.Error(result);

            return AppResult<Account>.Succeed(account);
        }
    }
}
