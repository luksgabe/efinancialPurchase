using EFinancialPurchase.AspNet.Common.Interfaces;
using FluentValidation;
using FluentValidation.Results;

namespace EFinancialPurchase.AspNet.Common.FluentValidation
{
    public class Validator<TModel> : AbstractValidator<TModel>, IValidatorApp<TModel>
    {
        protected internal string AdditionErrorMessage { get; set; }

        ValidationResult IValidatorApp<TModel>.ValidateObject(TModel model)
        {
            return Validate(model).ToAppResult(AdditionErrorMessage);
        }
    }
}
