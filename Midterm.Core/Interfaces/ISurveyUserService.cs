using Midterm.Core.DTOs;
using Midterm.Core.Requests.UserRequests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Midterm.Core.Interfaces
{
    public interface ISurveyUserService
    {
        Task<bool> CreateUser(CreateUserRequest request);
        Task<bool> DeleteUser(int userId);
        Task<SurveyUserDTO> GetSurveyUser(int userId);
        Task<List<SurveyUserDTO>> GetSurveyUsers();
        Task<SurveyUserDTO> UpdateUser(EditUserRequest request, int userId);
    }
}
