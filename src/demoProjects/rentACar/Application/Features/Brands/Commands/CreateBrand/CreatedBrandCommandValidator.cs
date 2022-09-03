using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.CreateBrand
{
    public class CreatedBrandCommandValidator : AbstractValidator<CreateBrandCommand>
    {
        public CreatedBrandCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Name).MinimumLength(2);
            //validasyon verinin iş kurallarına uygunluguyla yani formatı ile alakalı (ornegin karakter uzunlugu vs)
            //ornegin aynı markayı iki kere ekleme gibi bir durum ise business rule
        }
    }
}
