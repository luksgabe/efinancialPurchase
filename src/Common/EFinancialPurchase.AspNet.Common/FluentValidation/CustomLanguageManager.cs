using FluentValidation.Resources;
using FluentValidation.Validators;

namespace EFinancialPurchase.AspNet.Common.FluentValidation
{
    public class CustomLanguageManager : LanguageManager
    {
        /// <summary>
        /// Código da linguagem.
        /// </summary>
        public const string Language = "pt";

        /// <summary>
        /// Construtor que configura as mensagens para linguagem pt-br.
        /// </summary>
        public CustomLanguageManager()
        {
            Translate<EmailValidator>("{PropertyName} não é um endereço de email válido.");
            Translate<GreaterThanOrEqualValidator>("{PropertyName} deve ser maior ou igual a {ComparisonValue}.");
            Translate<GreaterThanValidator>("{PropertyName} deve ser maior que {ComparisonValue}.");
            Translate<LengthValidator>("{PropertyName} deve ter de {MinLength} a {MaxLength} caracteres. Há {TotalLength} caracteres.");
            Translate<MinimumLengthValidator>("{PropertyName} deve ter no mínimo {MinLength} caracteres. Há apenas {TotalLength} caracteres.");
            Translate<MaximumLengthValidator>("{PropertyName} deve ter no máximo {MaxLength} caracteres. Há {TotalLength} caracteres.");
            Translate<LessThanOrEqualValidator>("{PropertyName} deve ser menor ou igual a {ComparisonValue}.");
            Translate<LessThanValidator>("{PropertyName} deve ser menor que {ComparisonValue}.");
            Translate<NotEmptyValidator>("{PropertyName} deve ser informado(a).");
            Translate<NotEqualValidator>("{PropertyName} deve ser diferente de {ComparisonValue}.");
            Translate<NotNullValidator>("{PropertyName} deve ser informado(a).");
            Translate<PredicateValidator>("{PropertyName} não verifica a condição definida.");
            Translate<AsyncPredicateValidator>("{PropertyName} não verifica a condição definida.");
            Translate<RegularExpressionValidator>("{PropertyName} não se encontra no formato correcto.");
            Translate<EqualValidator>("{PropertyName} deve ser igual a {ComparisonValue}.");
            Translate<ExactLengthValidator>("{PropertyName} deve ter exatamente {MaxLength} caracteres. Há {TotalLength} caracteres.");
            Translate<ExclusiveBetweenValidator>("{PropertyName} deve estar entre {From} e {To} (exclusivo). Foi informado {Value}.");
            Translate<InclusiveBetweenValidator>("{PropertyName} deve estar entre {From} e {To}. Foi informado {Value}.");
            Translate<CreditCardValidator>("{PropertyName} não é um número de cartão de crédito válido.");
            Translate<ScalePrecisionValidator>("{PropertyName} não pode ter mais do que {expectedPrecision} dígitos, com precisão de {expectedScale} decimais. Há {digits} dígitos e {actualScale} decimais.");
            Translate<EmptyValidator>("{PropertyName} deve estar vazio.");
            Translate<NullValidator>("{PropertyName} deve estar vazio.");
            Translate<EnumValidator>("{PropertyName} possui um intervalo de valores que não inclui {PropertyValue}.");
        }

        void Translate<T>(string message)
        {
            AddTranslation(Language, typeof(T).Name, message);
        }
    }
}
