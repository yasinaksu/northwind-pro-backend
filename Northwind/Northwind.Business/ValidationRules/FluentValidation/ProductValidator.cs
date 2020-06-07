using FluentValidation;
using Northwind.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.CategoryId).NotEmpty().WithMessage("Kategori alanı boş geçilemez");
            RuleFor(p => p.ProductName).NotEmpty().Length(2,50);
            RuleFor(p => p.UnitPrice).NotEmpty().GreaterThan(0);
            RuleFor(p => p.QuantityPerUnit).NotEmpty();
        }
    }
}
