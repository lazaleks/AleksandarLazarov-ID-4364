using AutoMapper;
using Microsoft.EntityFrameworkCore;
using midTerm.Data;
using midTerm.Data.Entities;
using Midterm.Core.DTOs;
using Midterm.Core.Interfaces;
using Midterm.Core.Requests.UserRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm.Core.Services
{
    public class SurveyUserService : ISurveyUserService
    {
        private readonly SurveyContext _context;
        private readonly IMapper _mapper;

        public SurveyUserService(SurveyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SurveyUserDTO> GetSurveyUser(int userId)
        {
            var user = await _context.SurveyUsers.Where(x => x.Id == userId).FirstOrDefaultAsync();

            return _mapper.Map<SurveyUserDTO>(user);
        }

        public async Task<List<SurveyUserDTO>> GetSurveyUsers()
        {
            var users = await _context.SurveyUsers.ToListAsync();
            return _mapper.Map<List<SurveyUserDTO>>(users);
        }

        public async Task<bool> CreateUser(CreateUserRequest request)
        {
            var newUser = _mapper.Map<SurveyUser>(request);
            _context.SurveyUsers.Add(newUser);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<SurveyUserDTO> UpdateUser(EditUserRequest request, int userId)
        {
            var user = await _context.SurveyUsers.Where(x => x.Id == userId).FirstOrDefaultAsync();
            if (user == null)
                throw new Exception("User not found ! ");

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Gender = request.Gender;
            user.DoB = request.DoB;
            user.Country = request.Country;

            await _context.SaveChangesAsync();

            return _mapper.Map<SurveyUserDTO>(user);
        }

        public async Task<bool> DeleteUser(int userId)
        {
            var user = await _context.SurveyUsers.Where(x => x.Id == userId).FirstOrDefaultAsync();
            if (user == null)
                throw new Exception("User not found ! ");

            _context.SurveyUsers.Remove(user);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
