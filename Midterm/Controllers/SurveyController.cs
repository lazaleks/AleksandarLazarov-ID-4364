using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Midterm.Core.DTOs;
using Midterm.Core.Interfaces;
using Midterm.Core.Requests.UserRequests;

namespace Midterm.Controllers
{
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly ISurveyUserService _userService;

        public SurveyController(ISurveyUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("api/users")]
        public async Task<IActionResult> GetUsers()
        {
            var result = await _userService.GetSurveyUsers();
            return Ok(result);
        }

        [HttpGet]
        [Route("api/users/{userId}")]
        public async Task<IActionResult> GetUserById([FromRoute] int userId)
        {
            var result = await _userService.GetSurveyUser(userId);
            return Ok(result);
        }

        [HttpPost]
        [Route("api/users")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            var result = await _userService.CreateUser(request);
            return Ok(result);

        }

        [HttpPut]
        [Route("api/users/{userId}")]
        public async Task<IActionResult> EditUser([FromRoute] int userId, [FromBody] EditUserRequest request)
        {
            var result = await _userService.UpdateUser(request, userId);
            return Ok(result);
        }

        [HttpDelete]
        [Route("api/users/{userId}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int userId)
        {
            var result = await _userService.DeleteUser(userId);
            return Ok(result);
        }
    }
}
