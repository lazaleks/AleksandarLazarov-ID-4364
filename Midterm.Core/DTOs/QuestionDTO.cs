using AutoMapper;
using midTerm.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Midterm.Core.DTOs
{
    public class QuestionDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public virtual ICollection<OptionDTO> Options { get; set; }

        public class Profiler : Profile
        {
            public Profiler()
            {
                CreateMap<QuestionDTO, Question>()
                    .ForMember(x => x.Id, opt => opt.Ignore());
                CreateMap<Question, QuestionDTO>();
            }
        }
    }
}
