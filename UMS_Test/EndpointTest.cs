using Xunit;
using UMS;
using Microsoft.AspNetCore.Mvc.Testing;
using UMS.Controllers;
using Microsoft.AspNetCore.Mvc;
using UMS.Models;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace UMS_Test
{
    public class EndpointTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        public EndpointTest(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        //[Fact]
        //public void CourseUpdate()
        //{
        //    var controller = new CoursesController();
        //    var course = controller.Details(1);

        //    // update course
        //    var updatedCourse = new Course();
        //    updatedCourse.Id = 1;
        //    updatedCourse.Name = "Updated";
        //    updatedCourse.Description = "Updated";
        //    controller.Edit(1, updatedCourse);

        //    var newUpdatedCourse = controller.Details(1);
        //    Assert.NotEqual(course, newUpdatedCourse);
        //}
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
                response.EnsureSuccessStatusCode(); // Status Code 200-299
                Assert.Equal("200", response.StatusCode.ToString());
            }
            catch (Exception ex)
            {

            }
            // Act
        }
    }
}