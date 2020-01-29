using FluentValidation.Results;

namespace EFinancialPurchase.AspNet.Common.FluentValidation
{
    public static class FluentValidationExtensions
    {
        public static ValidationResult ToAppResult(this ValidationResult result, string AdditionErrorMessage)
        {
            if (!string.IsNullOrEmpty(AdditionErrorMessage))
                result.Errors.Add(new ValidationFailure(string.Empty, AdditionErrorMessage));
            
            return result;
        }
    }
}
