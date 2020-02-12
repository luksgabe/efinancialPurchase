using EFinancialPurchase.AspNet.Common.FluentValidation;
using FluentValidation;
using Persons.Domain.Entities;
using Persons.Domain.Interfaces;
using Persons.Domain.Validations.Rules;

namespace Persons.Domain.Validations
{
    public class UserLoginValidation : Validator<Account>, IUserLoginValidation
    {
        public UserLoginValidation(AccountRule rule)
        {
            RuleFor(e => e.Login).NotNull();
            RuleFor(e => e.Password).NotNull();
            RuleFor(e => e).MustAsync((e, cancelation) => rule.UserLoginAccountExist(e))
                .WithMessage($"Usuario ou senha não encontrados").WithErrorCode("401");
        }
    }
}
