using AutoMapper;
using midTerm.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Midterm.Core.Requests.AnswerRequests
{
    public class CreateAnswerRequest
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int OptionId { get; set; }

        public class Profiler : Profile
        {
            public Profiler()
            {
                CreateMap<CreateAnswerRequest, Answers>()
                    .ForMember(x => x.Id, opt => opt.Ignore())
                    .ForMember(x => x.Option, opt => opt.Ignore())
                    .ForMember(x => x.User, opt => opt.Ignore());
            }
        }
    }
}
