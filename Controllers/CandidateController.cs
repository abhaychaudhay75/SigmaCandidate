using JobCandidate.Helpers;
using JobCandidate.Models;
using JobCandidate.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace JobCandidate.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidateController : Controller
    {
        private readonly ICandidate _candidateService;

        public CandidateController(ICandidate CandidateService)
        {
            _candidateService = CandidateService;
        }

        [HttpPost("AddUpdateCandidate")]
        public async Task<IActionResult> AddUpdateCandidateAsync([FromBody] CandidateModel model)
        {
            try
            {
                var result = await _candidateService.AddUpdateCandidateAsync(model);
                return Ok(new ResponseResult
                {
                    Status = "success",
                    Message = "Candidate created/updated successfully",
                    StatusCode = (int)HttpStatusCode.OK,

                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseResult
                {
                    Status = "error",
                    Message = ex.Message,
                    StatusCode = (int)HttpStatusCode.BadRequest
                });
            }
           
        }
    }
}
