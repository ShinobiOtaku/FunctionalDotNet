using System.Threading.Tasks;

namespace FunctionalDotNet.Tests.Helpers
{
    public static class Text
    {
        public static string ToUpper(string s) => s.ToUpper();
        public static async Task<string> ToUpperAsync(string s) => s.ToUpper();
    }
}