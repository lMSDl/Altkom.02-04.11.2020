using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Validators
{
    public class EducatorValidator : AbstractValidator<Educator>
    {
        public EducatorValidator()
        {
            RuleFor(x => x.FirstName).Length(0, 15);
            RuleFor(x => x.LastName).MaximumLength(15).NotNull();
            RuleFor(x => x.BirthDate).LessThan(DateTime.Now).GreaterThanOrEqualTo(new DateTime(1900, 1, 1));
        }
    }
}
