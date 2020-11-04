using FluentValidation.Attributes;
using Models.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Validator(typeof(EducatorValidator))]
    public class Educator : Person
    {
        public int EducatorId { get; set; }
        public string Specialization { get; set; }

        public override int Id => EducatorId;
    }
}
