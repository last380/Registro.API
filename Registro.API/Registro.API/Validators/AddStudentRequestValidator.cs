using FluentValidation;
using Registro.API.DomainModels;
using Registro.API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registro.API.Validators
{
    public class AddStudentRequestValidator: AbstractValidator<AddStudentRequest>
    {
        public AddStudentRequestValidator(IStudentRepository studentRepository)
        {
            RuleFor(x=>x.FirstName).NotEmpty();
            RuleFor(x=>x.LastName).NotEmpty();
            RuleFor(x=>x.DateOfBirth).NotEmpty();
            RuleFor(x=>x.Email).NotEmpty();
            RuleFor(x=>x.Mobile).GreaterThan(999999).LessThan(1000000000000);
            RuleFor(x => x.GenderId).NotEmpty().Must(id =>
            {
                var gender = studentRepository.GetGendersAsync().Result.ToList().FirstOrDefault(x=>x.Id==id);

                if (gender != null) {
                    return true;
                }
                return false;
            }).WithMessage("Please select a valid Gender");
            RuleFor(x => x.PhysicalAddress).NotEmpty();
            RuleFor(x => x.PostalAddress).NotEmpty();
        }
    }
}
