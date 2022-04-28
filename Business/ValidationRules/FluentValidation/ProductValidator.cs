using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty().WithMessage("Kullanıcı Adı Boş Olamaz");
            RuleFor(p => p.ProductName).MinimumLength(2).WithMessage("En az 2 karakter olmalı.");
            RuleFor(p => p.UnitPrice).NotEmpty().WithMessage("UnitePrice boş olamaz");
            RuleFor(p => p.UnitPrice).GreaterThan(0).WithMessage("0'dan büyük tutar olamalı.");
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("İsim A ile başlamalı.");
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
