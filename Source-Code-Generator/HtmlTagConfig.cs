namespace Source_Code_Generator
{
    public class HtmlTagConfig
    {
        public string TagName { get; }
        public string ClassName { get; }

        public bool Standalone { get; }

        public HtmlTagConfig(string tagName, bool standalone = false)
        {
            TagName = tagName;
            ClassName = FirstCharToUpper(tagName);
            Standalone = standalone;
        }

        private static string FirstCharToUpper(string s)
        {
            // Check for empty string.  
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.  
            return char.ToUpper(s[0]) + s.Substring(1);
        }
    }
}
