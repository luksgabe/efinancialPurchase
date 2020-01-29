using DotNetCore.Objects;
using FluentValidation;
using FluentValidation.Results;

namespace EFinancialPurchase.AspNet.Common.Interfaces
{
    public interface IValidatorApp<TEntity> : IValidator<TEntity>
    {

        ValidationResult ValidateObject(TEntity model);
    }
}
