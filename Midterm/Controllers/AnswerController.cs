using Microsoft.AspNetCore.Mvc;
using Midterm.Core.DTOs;
using Midterm.Core.Interfaces;
using Midterm.Core.Requests.AnswerRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Midterm.Controllers
{
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerService _answerService;

        public AnswerController(IAnswerService answerService)
        {
            _answerService = answerService;
        }

        [HttpGet]
        [Route("api/answers")]
        public async Task<IActionResult> GetAllAnswers()
        {
            var result = await _answerService.GetAllAnswers();
            return Ok(result);
        }

        [HttpGet]
        [Route("api/answers/{answerId}")]
        public async Task<IActionResult> GetAnswerById([FromRoute] int answerId)
        {
            var result = await _answerService.GetAnswerById(answerId);
            return Ok(result);
        }

        [HttpGet]
        [Route("api/answers/user/{userId}")]
        public async Task<IActionResult> GetAnswersForUser([FromRoute] int userId)
        {
            var result = await _answerService.GetAllAnswersForUser(userId);
            return Ok(result);
        }

        [HttpPost]
        [Route("api/answers")]
        public async Task<IActionResult> CreateAnswer([FromBody] CreateAnswerRequest request)
        {
            var result = await _answerService.CreateAnswer(request);
            return Ok(result);
        }

        [HttpPatch]
        [Route("api/answers/{answerId}")]
        public async Task<IActionResult> UpdateAnswer([FromRoute] int answerId, [FromBody] EditAnswerRequest request)
        {
            var result = await _answerService.UpdateAnswer(request, answerId);
            return Ok(result);
        }

        [HttpDelete]
        [Route("api/answers/{answerId}")]
        public async Task<IActionResult> DeleteAnswer([FromRoute] int answerId)
        {
            var result = await _answerService.DeleteAnswer(answerId);
            return Ok(result);
        }
    }
}
