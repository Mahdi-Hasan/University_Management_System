namespace UMS.Models.Utilities
{
    public static class Calculate
    {
        public static decimal CalculateCGPA(List<Result> results)
        {
            return results.Average(g => g.GPA);
        }
        public static Result BestGpa(List<Result> results)
        {
            return results.OrderByDescending(r => r.GPA).ToList().FirstOrDefault();
        }
    }
}
