using FluentValidation;
using FluentValidation.Attributes;
using FluentValidation.Internal;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public abstract class DataErrorInfo : IDataErrorInfo
    {
        private IValidator Validator => new AttributedValidatorFactory().GetValidator(GetType());

        public string this[string columnName]
        {
            get
            {
                if (Validator == null)
                    return string.Empty;

                var result = Validator.Validate(new ValidationContext(this, new PropertyChain(), new MemberNameValidatorSelector(new List<string> { columnName })));
                return GetErrors(result);
            }
        }

        public string Error => Validator == null ? string.Empty : GetErrors(Validator.Validate(this));

        private string GetErrors(ValidationResult validationResult)
        {
            if(validationResult == null || !validationResult.Errors.Any())
            {
                return string.Empty;
            }
            return string.Join(Environment.NewLine, validationResult.Errors.Select(x => x.ErrorMessage));
        }
    }
}
