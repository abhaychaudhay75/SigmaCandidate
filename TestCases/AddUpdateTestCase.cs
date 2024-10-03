using System;
using System.Net;
using System.Threading.Tasks;
using JobCandidate.Controllers;
using JobCandidate.Helpers;
using JobCandidate.Models;
using JobCandidate.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace JobCandidate.TestCases
{
    public class AddUpdateTestCase
    {
        private readonly Mock<ICandidate> _mockCandidateService;
        private readonly CandidateController _controller;

        public AddUpdateTestCase()
        {
            _mockCandidateService = new Mock<ICandidate>();
            _controller = new CandidateController(_mockCandidateService.Object);
        }

        [Fact]
        public async Task AddUpdateCandidateAsync_ShouldReturnOk_WhenSuccessful()
        {
            var candidateModel = new CandidateModel
            {
                FirstName = "John",
                LastName = "Doe",
                PhoneNumber = "1234567890",
                Email = "john.doe@example.com",
                TimeInterval = "Morning",
                LinkedInURL = "https://linkedin.com/in/johndoe",
                GitHubURL = "https://github.com/johndoe",
                Comment = "Test candidate"
            };

            _mockCandidateService.Setup(service => service.AddUpdateCandidateAsync(candidateModel))
                .ReturnsAsync(candidateModel);

            var result = await _controller.AddUpdateCandidateAsync(candidateModel);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var responseResult = Assert.IsType<ResponseResult>(okResult.Value);

            Assert.Equal("success", responseResult.Status);
            Assert.Equal("Candidate created/updated successfully", responseResult.Message);
            Assert.Equal((int)HttpStatusCode.OK, responseResult.StatusCode);
        }
    }
}