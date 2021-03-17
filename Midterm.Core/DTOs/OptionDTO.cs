using AutoMapper;
using midTerm.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Midterm.Core.DTOs
{
    public class OptionDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int? Order { get; set; }
        public int QuestionId { get; set; }
        public virtual QuestionDTO Question { get; set; }

        public class Profiler : Profile
        {
            public Profiler()
            {
                CreateMap<OptionDTO, Option>()
                    .ForMember(x => x.Id, opt => opt.Ignore());
                CreateMap<Option, OptionDTO>();
            }
        }
    }
}
