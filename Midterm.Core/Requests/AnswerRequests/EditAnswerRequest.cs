using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Midterm.Core.Requests.AnswerRequests
{
    public class EditAnswerRequest
    {
        [Required]
        public int OptionId { get; set; }
    }
}
