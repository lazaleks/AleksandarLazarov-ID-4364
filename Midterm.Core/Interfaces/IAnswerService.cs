using Midterm.Core.DTOs;
using Midterm.Core.Requests.AnswerRequests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Midterm.Core.Interfaces
{
    public interface IAnswerService
    {
        Task<bool> CreateAnswer(CreateAnswerRequest request);
        Task<bool> DeleteAnswer(int answerId);
        Task<List<AnswerDTO>> GetAllAnswers();
        Task<List<AnswerDTO>> GetAllAnswersForUser(int userId);
        Task<AnswerDTO> GetAnswerById(int answerId);
        Task<AnswerDTO> UpdateAnswer(EditAnswerRequest request, int answerId);
    }
}
