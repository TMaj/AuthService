namespace AuthService.Infrastructure.Helpers
{
    public static class Extensions
    {
        public static bool IsNullOrEmpty(this string value)
        {
            return value.Length == 0 || value == null;
        }
    }
}
