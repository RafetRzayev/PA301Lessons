namespace CSharpSyntaxsis
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }

    static class ExtensionMethods
    {
        public static string Capitalize(this string original)
        {
            var firstLetter = original[0].ToString().ToUpper();
            var restOfOriginal = original.Substring(1).ToLower();

            return firstLetter + restOfOriginal;
        }

        public static string ToDisplayTime(this DateTime time)
        {
            var now = DateTime.Now; 

            if (now.Day == time.Day && now.Year ==  time.Year && now.Month == time.Month)
            {
                return $"Bugun {time.ToString("HH:mm")}";
            }
            else
            {
                return time.ToString("dd.MM.yyyy");
            }
        }
    }
}
