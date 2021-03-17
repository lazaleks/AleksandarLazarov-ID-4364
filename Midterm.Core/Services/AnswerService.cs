using AutoMapper;
using Microsoft.EntityFrameworkCore;
using midTerm.Data;
using midTerm.Data.Entities;
using Midterm.Core.DTOs;
using Midterm.Core.Interfaces;
using Midterm.Core.Requests.AnswerRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm.Core.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly SurveyContext _context;
        private readonly IMapper _mapper;

        public AnswerService(SurveyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<AnswerDTO>> GetAllAnswers()
        {
            var answers = await _context.Answers
                .Include(x => x.User)
                .Include(x => x.Option)
                .ToListAsync();
            return _mapper.Map<List<AnswerDTO>>(answers);
        }

        public async Task<AnswerDTO> GetAnswerById(int answerId)
        {
            var answer = await _context.Answers.Where(x => x.Id == answerId)
                .Include(x => x.Option)
                .Include(x => x.User)
                .FirstOrDefaultAsync();

            return _mapper.Map<AnswerDTO>(answer);
        }

        public async Task<List<AnswerDTO>> GetAllAnswersForUser(int userId)
        {
            var answers = await _context.Answers
                .Where(x => x.UserId == userId)
                .Include(x => x.Option)
                .ToListAsync();

            return _mapper.Map<List<AnswerDTO>>(answers);
        }

        public async Task<bool> CreateAnswer(CreateAnswerRequest request)
        {
            var answer = _mapper.Map<Answers>(request);

            _context.Answers.Add(answer);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAnswer(int answerId)
        {
            var answer = await _context.Answers
                .Where(x => x.Id == answerId)
                .FirstOrDefaultAsync();

            _context.Answers.Remove(answer);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<AnswerDTO> UpdateAnswer(EditAnswerRequest request, int answerId)
        {
            var answer = await _context.Answers
                .Where(x => x.Id == answerId)
                .FirstOrDefaultAsync();

            answer.OptionId = request.OptionId;

            await _context.SaveChangesAsync();

            return _mapper.Map<AnswerDTO>(answer);
        }
    }
}
