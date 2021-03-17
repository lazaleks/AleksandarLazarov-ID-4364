using midTerm.Data.Enums;
using Midterm.Core.CustomValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Midterm.Core.Requests.UserRequests
{
    public class EditUserRequest
    {
        [Required(ErrorMessage = "First Name is required.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required.")]
        public string LastName { get; set; }

        [DoBValidation(ErrorMessage = "Must be at least 16 years old.")]
        public DateTime? DoB { get; set; }
        [Required(ErrorMessage = "Gender is required.")]
        public Gender Gender { get; set; }
        [Required(ErrorMessage = "Country is required.")]
        public string Country { get; set; }
    }
}
