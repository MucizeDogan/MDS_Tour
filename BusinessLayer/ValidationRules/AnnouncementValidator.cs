using DTOLayer.DataTrabsferObjects.AnnouncementDTOs;
using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AnnouncementValidator : AbstractValidator<AnnouncementAddDto>
    {
        public AnnouncementValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Please do not leave the title empty");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Please do not leave the Announcement Content empty");
        }
    }
}
