using FluentValidation.Results;

namespace EFinancialPurchase.AspNet.Common.CommandResult
{
    public class AppResult<TEntity>
    {
        public ValidationResult ValidationResult { get; private set; }
        public TEntity Data { get; private set; }

        public bool IsValid { get; private set; }

        public static AppResult<TEntity> Error(ValidationResult result)
        {
            return new AppResult<TEntity>(result);
        }

        public static AppResult<TEntity> Succeed(TEntity entity)
        {
            return new AppResult<TEntity>(new ValidationResult(), entity);
        }

        protected AppResult(ValidationResult validation)
        {
            IsValid = false;
            ValidationResult = validation;
        }

        protected AppResult(ValidationResult validation, TEntity entity)
        {
            Data = entity;
            IsValid = true;
            ValidationResult = validation;
        }
        public AppResult()
        {
            IsValid = true;
        }

    }
}
