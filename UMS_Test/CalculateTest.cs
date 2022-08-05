using UMS.Models;
using UMS.Models.Utilities;

namespace UMS_Test
{
    public class CalculateTest
    {
        [Fact]
        public void CheckCalculator()
        {
            var gpaList = new List<Result>();
            var result1 = new Result()
            {
                Id = 1,
                CourseId = 1,
                StudentId = 1,
                GPA = 4.0M
            };
            gpaList.Add(result1);
            gpaList.Add(new Result()
            {
                Id = 2,
                CourseId = 2,
                GPA = 3.5M,
                StudentId = 2
            });
            Assert.Equal(3.75M, Calculate.CalculateCGPA(gpaList));
        }
        [Fact]
        public void CheckBestGpa()
        {
            var gpaList = new List<Result>();
            var result1 = new Result()
            {
                Id = 1,
                CourseId = 1,
                StudentId = 1,
                GPA = 2.0M
            };
            gpaList.Add(result1);
            gpaList.Add(new Result()
            {
                Id = 2,
                CourseId = 2,
                GPA = 3.5M,
                StudentId = 2
            });
            Assert.Equal(result1, Calculate.BestGpa(gpaList));
        }
    }
}
