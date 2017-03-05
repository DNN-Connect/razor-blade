namespace Connect.Razor
{
    public static class Blades
    {
        public static bool HasText(object valToTest)
        {
            // try to cast to string, it will be null if invalid
            return !string.IsNullOrWhiteSpace(valToTest as string);
        }
        
        // 2017-03-05 2dm: for now commented out, I think this isn't a very common request, as HasText seems more important
        //public static bool IsNoE(object valToTest)
        //{
        //    // try to cast to string, it will be null if invalid
        //    return string.IsNullOrEmpty(valToTest as string);
        //}

        public static string Fallback(string valToShow, string fallback)
        {
            return HasText(valToShow) ? valToShow : fallback;
        }
    }
}
