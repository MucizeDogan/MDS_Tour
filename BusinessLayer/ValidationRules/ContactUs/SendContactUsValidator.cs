using DTOLayer.DataTrabsferObjects.ContactDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.ContactUs
{
    public class SendContactUsValidator : AbstractValidator<SendMessageDto>
    {
        public SendContactUsValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Please enter the name");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Please enter the Subject");
            RuleFor(x => x.MessageBody).NotEmpty().WithMessage("Please enter your Message");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Please enter the mail");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Please enter a Subject shorter than 50 characters");
            RuleFor(x => x.Subject).MinimumLength(5).WithMessage("Please enter a Subject more than 5 characters");
        }
    }
}
