namespace CSharpExercises
{
    public static class ExtensionMethods
    {
        public static string Head(this string input)
        {
            return input.Substring(0, 1);
        }

        public static string Tail(this string input)
        {
            return input.Substring(1);
        }
    }
}