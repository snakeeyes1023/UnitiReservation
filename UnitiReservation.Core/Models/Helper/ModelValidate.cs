using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitiReservation.Core.Models.Helper
{
    public class ModelValidate<T>
    {
        public Tuple<bool, List<ValidationResult>> Validate()
        {
            var context = new ValidationContext(this, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();

            return new Tuple<bool, List<ValidationResult>>(Validator.TryValidateObject(this, context, validationResults, true), validationResults);
        }
    }
}
