using BikeStores.Contracts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BikeStores.Services.Validators
{
    public class PagingRequestValidator<T> : AbstractValidator<PagingRequest<T>>, IValidator<PagingRequest<T>> where T : class
    {
        public PagingRequestValidator()
        {
            RuleFor(x => x.PageIndex).GreaterThanOrEqualTo(1); //.WithMessage("Indeks strony PageIndex musi być większy lub równy 1");
            RuleFor(x => x.PageSize).GreaterThanOrEqualTo(5).LessThanOrEqualTo(100); //.WithMessage("Rozmiar strony PageSize musi być w przedziale <5,100>");

            RuleFor(x => x.OrderField).Custom(ValidateOrderField);
        }

        private void ValidateOrderField(string orderField, ValidationContext<PagingRequest<T>> context)
        {
            var sourceProperties = typeof(T).GetProperties();
            if (!sourceProperties.Any(p => string.Compare(p.Name, orderField, StringComparison.CurrentCulture) == 0))
            {
                context.AddFailure(nameof(PagingRequest<T>.OrderField), $"Pole {nameof(PagingRequest<T>.OrderField)} ma niepoprawną wartość '{orderField}'");
            }
        }
    }
}
