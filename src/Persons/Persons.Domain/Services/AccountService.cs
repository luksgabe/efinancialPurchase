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
        private readonly IValidatorApp<User> _validator;

        public AccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _validator = _unitOfWork.userLoginValidate;
        }

        public async Task<AppResult<User>> Authenticate(User user)
        {
            var result = await Task.Run(() => _validator.ValidateObject(user));

            if (!result.IsValid)
                return AppResult<User>.Error(result);

            return AppResult<User>.Succeed(user);
        }
    }
}
