namespace Connect.Razor.V1
{
    public static partial class Blade
    {

        public static string If(bool condition, string result, string otherwise = null)
        {
            return condition ? result : otherwise;
        }

    }
}
