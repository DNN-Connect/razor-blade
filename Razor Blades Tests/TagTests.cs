using System.Linq;
using System.Web;
using Connect.Razor.Blade;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Razor_Blades_Tests
{
    public class TagTestBase

    {
        public void Is(string expected, Tag result, string message = null)
        {
            Is(expected, result.ToString(), message);
            //Assert.AreEqual(expected, result.ToString(), message);
        }

        public void Is(string expected, IHtmlString result, string message = null)
        {
            //var resultStr = result.ToString();
            //int index = expected.Zip(resultStr, (c1, c2) => c1 == c2).TakeWhile(b => b).Count() + 1;

            //Assert.AreEqual(expected, resultStr, message + $"(pos: {index}");
            Is(expected, result.ToString(), message);
        }

        private void Is(string expected, string result, string message = null)
        {
            var resultStr = result;
            var index = expected.Zip(resultStr, (c1, c2) => c1 == c2).TakeWhile(b => b).Count() + 1;

            // if we found a deviation, include that in the message
            if (index <= resultStr.Length)
            {
                var startErrorText = index - 25;
                if (startErrorText < 0) startErrorText = 0;
                var before = expected.Substring(startErrorText, index - startErrorText);

                message = message + $"(pos: {index}, before: '{before}')";
            }

            Assert.AreEqual(expected, resultStr, message);

        }
    }
}
