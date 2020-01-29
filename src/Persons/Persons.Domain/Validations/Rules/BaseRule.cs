using System;

namespace Persons.Domain.Validations.Rules
{
    public abstract class BaseRule<TEntityRepo> where TEntityRepo : class
    {
        public abstract TEntityRepo _repository { get; set; }

        public BaseRule(TEntityRepo repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
    }
}
