using DTOLayer.DataTrabsferObjects.AppUserDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AppUserEgisterValidator : AbstractValidator<AppUserRegisterDTO>
    {
        public AppUserEgisterValidator()
        {
            //NotEmpty alanı
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Name field cannot be empty !!!");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Surname field cannot be empty !!!");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail field cannot be empty !!!");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username field cannot be empty !!!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password field cannot be empty !!!");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("ConfirmPassword field cannot be empty !!!");

            //Minimum-Maximum Length Alanı
            RuleFor(x => x.Username).MinimumLength(5).WithMessage("Please enter a minimum of 5 characters for the Username");
            RuleFor(x => x.Username).MinimumLength(25).WithMessage("Please enter a maximum of 25 characters for the Username");

            //Password eşleştirmek için
            RuleFor(x => x.Password).Equal(y => y.ConfirmPassword).WithMessage("Passwords are not compatible please check");
        }
    }
}
