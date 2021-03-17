using AutoMapper;
using midTerm.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Midterm.Core.DTOs
{
    public class AnswerDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OptionId { get; set; }
        public virtual OptionDTO Option { get; set; }
        public virtual SurveyUserDTO User { get; set; }

        public class Profiler : Profile
        {
            public Profiler()
            {
                CreateMap<AnswerDTO, Answers>()
                    .ForMember(x => x.Id, opt => opt.Ignore());
                CreateMap<Answers, AnswerDTO>();
            }
        }
    }
}
