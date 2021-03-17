using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Midterm.Core.CustomValidations
{
    public class DoBValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var date = (DateTime)value;

            if (DateTime.Now.Year - date.Year < 16)
                return false;

            return true;
            
        }
    }
}
