using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class GuideValidator : AbstractValidator<Guides>
    {
        public GuideValidator()
        {
            RuleFor(x=>x.GuideName).NotEmpty().WithMessage("Please enter the Guide name");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Please enter the description");
            RuleFor(x => x.GuideName).MinimumLength(6).WithMessage("Please enter a name of more than 6 characters");
            RuleFor(x => x.GuideName).MaximumLength(35).WithMessage("Please enter a name shorter than 35 characters");

        }
    }
}
