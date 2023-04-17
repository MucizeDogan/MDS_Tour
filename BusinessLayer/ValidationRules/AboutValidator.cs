using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    internal class AboutValidator:AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x => x.Description).NotEmpty().WithMessage("AÇıklama kısmı boş geçilezç..!");
            RuleFor(x => x.Description2).MaximumLength(350).WithMessage("AÇıklama2 kısmına maks 350 girilebilir..!");
        }
    }
}
