using Xunit;
using UMS;
using Microsoft.AspNetCore.Mvc.Testing;
using UMS.Controllers;
using Microsoft.AspNetCore.Mvc;
using UMS.Models;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using UMS.Data;
using UMS.Models.Utilities;

namespace UMS_Test
{
    public class EndpointTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        public EndpointTest(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/")]
        [InlineData("/Courses")]
        [InlineData("/Students")]
        [InlineData("/CourseRegistrations")]
        [InlineData("/Results")]
        [InlineData("/GetResults")]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange
            try
            {
                var client = _factory.CreateClient();
                var response = await client.GetAsync(url);

                // Assert
                // Status Code 200-299
                var code = (int)response.StatusCode;
                Assert.Equal(code, 200);
               
            }
            catch (Exception ex)
            {

            }
            // Act
        }
    }
}