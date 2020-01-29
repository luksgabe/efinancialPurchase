using EFinancialPurchase.AspNet.Common.FluentValidation;
using FluentValidation;
using Persons.Domain.Entities;
using Persons.Domain.Interfaces;
using Persons.Domain.Validations.Rules;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Persons.Domain.Validations
{
    public class UserLoginValidation : Validator<User>, IUserLoginValidation
    {
        public UserLoginValidation(UserRule rule)
        {
            RuleFor(e => e.Login).NotNull();
            RuleFor(e => e.Password).NotNull();
            RuleFor(e => e).MustAsync((e, cancelation) => rule.UserLoginAccountExist(e))
                .WithMessage($"Usuario ou senha não encontrados").WithErrorCode("401");
        }
    }
}
