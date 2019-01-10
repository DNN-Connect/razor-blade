namespace Connect.Razor
{
    public static partial class Temporary
    {

        public static string If(bool condition, string result, string otherwise = null)
        {
            return condition ? result : otherwise;
        }

    }
}
