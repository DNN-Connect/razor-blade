using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Connect.Razor.Blade;

namespace Razor_Blades_Tests
{
    [TestClass]
    public class Test_Blades_Dynamic
    {
        [TestMethod]
        public void Test_ToDynamic()
        {
            var exp = TestDynamic();

            Assert.AreEqual("Unknown", exp.FullName, "should be the same");
        }

        [TestMethod]
        [ExpectedException(typeof( Microsoft.CSharp.RuntimeBinder.RuntimeBinderException))]

        public void Test_ToDynamic_InvalidPropertyCase()
        {
            var exp = TestDynamic();
            var x = exp.fullname; //wrong casing

        }

        private static dynamic TestDynamic()
        {
            var vls = TestDict();
            var exp = (dynamic)Dic.ToDynamic(vls);
            return exp;
        }


        private static Dictionary<string, object> TestDict()
        {
            return new Dictionary<string, object>()
            {
                { "FullName", "Unknown" },
                { "Image", "unknown.jpg" },
                { "ShortBio", "bio unknown" }
            };
        }
    }
}
