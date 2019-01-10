using Connect.Razor.Internals;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Connect.Razor.Blade;


namespace Razor_Blades_Tests
{
    [TestClass]
    public class Test_Blades_Ellipsis
    {

        [TestMethod]
        public void Test_Ellipsis_Basic()
        {
            var message = "This is a teaser for something";
            Assert.AreEqual(message, Text.Ellipsis(message, 100), "message is short, shouldn't change");
            Assert.AreEqual("This" + Defaults.HtmlEllipsisCharacter, Text.Ellipsis(message, 5), "message is longer, should be truncated");
            Assert.AreEqual("This", Text.Ellipsis(message, 5, ""), "blank Text.Ellipsis char should just trunc");
            Assert.AreEqual(4 + Defaults.HtmlEllipsisCharacter.Length, Text.Ellipsis(message, 5).Length, "should trunc and add ell");
        }

        [TestMethod]
        public void Test_Ellipsis_DontSplitWords()
        {
            var message = "This is a teaser for something";
            var messageLess12 = "This is a";
            Assert.AreEqual(Text.Ellipsis(message, 12), messageLess12 + Defaults.HtmlEllipsisCharacter, "should be truncated at previous word");
        }

        [TestMethod]
        public void Test_Ellipsis_With_Umlauts()
        {
            var message = "Visit M&uuml;nchen &amp; Z&uuml;rich";
            var msg5 = "Visit" + Defaults.HtmlEllipsisCharacter;
            var msg13 = "Visit M&uuml;nchen" + Defaults.HtmlEllipsisCharacter;
            Assert.AreEqual(msg5, Text.Ellipsis(message, 5), "very short");
            Assert.AreEqual(msg5, Text.Ellipsis(message, 10), "very short");
            Assert.AreEqual(msg5, Text.Ellipsis(message, 12), "just too short");
            Assert.AreEqual(msg13, Text.Ellipsis(message, 13), "just right");
            Assert.AreEqual(msg13, Text.Ellipsis(message, 14), "bit longer, ok");
            Assert.AreNotEqual(msg13, Text.Ellipsis(message, 15), "now has an html-and, so must be different ok");
            //Assert.AreNotEqual(message, Text.Ellipsis(message, 5), "message is longer, should be truncated");
            //Assert.AreEqual(Ellipsis(message, 5, ""), "This ", "blank Text.Ellipsis char should just trunc");
            //Assert.AreEqual(Ellipsis(message, 5).Length, 5 + Defaults.HtmlEllipsisCharacter.Length, "should trunc and add ell");
        }


        [TestMethod]
        public void Truncate_CutOffPoint_Basic()
        {
            var basicTests = "Some normal text without specials";
            Assert.AreEqual(Truncator.FindCutPosition(basicTests, 5), 5);
            Assert.AreEqual(Truncator.FindCutPosition(basicTests, 10), 10);
        }

        private readonly string citiesUmlauts = "Zürich and München".Replace("ü", "&uml;");

        [TestMethod]
        public void Truncate_CutOffPoint_Umlauts()
        {
            Assert.AreEqual(9, Truncator.FindCutPosition(citiesUmlauts, 5));
            Assert.AreEqual(14, Truncator.FindCutPosition(citiesUmlauts, 10));
            Assert.AreEqual(23, Truncator.FindCutPosition(citiesUmlauts, 15));
            Assert.AreEqual(citiesUmlauts.Length - 1, Truncator.FindCutPosition(citiesUmlauts, 50));
        }

        [TestMethod]
        public void Truncate_CutOffPoint_Nbsp()
        {
            var basicTests = "Dont-Split-Me".Replace("-", "&nbsp;");
            Assert.AreEqual(10, Truncator.FindCutPosition(basicTests, 5));
            Assert.AreEqual(15, Truncator.FindCutPosition(basicTests, 10));
            Assert.AreEqual(21, Truncator.FindCutPosition(basicTests, 11));
            Assert.AreEqual(basicTests.Length -1, Truncator.FindCutPosition(basicTests, basicTests.Length));
        }

        private string simpleTruncates = "This is a teaser for something";
        [TestMethod]
        public void Truncate_Basic()
        {
            Assert.AreEqual(simpleTruncates, Truncator.SafeTruncate(simpleTruncates, 100), "message is short, shouldn't change");

            Assert.AreEqual("This", Truncator.SafeTruncate(simpleTruncates, 4), "truncate till end of word");
            Assert.AreEqual("This", Truncator.SafeTruncate(simpleTruncates, 5), "truncate till end of word");
        }


        [TestMethod]
        public void Truncate_Chars15To19()
        {
            var partBefore16 = simpleTruncates.Substring(0, 16); // should be "This is a teaser"
            Assert.AreNotEqual(partBefore16, Truncator.SafeTruncate(simpleTruncates, 15), "15 chars should be shorter");
            Assert.AreEqual(partBefore16, Truncator.SafeTruncate(simpleTruncates, 16), "truncate till end of word");
            Assert.AreEqual(partBefore16, Truncator.SafeTruncate(simpleTruncates, 17), "truncate till end of word");
            Assert.AreEqual(partBefore16, Truncator.SafeTruncate(simpleTruncates, 18), "truncate till end of word");
            Assert.AreEqual(partBefore16, Truncator.SafeTruncate(simpleTruncates, 19), "truncate till end of word");
            Assert.AreNotEqual(partBefore16, Truncator.SafeTruncate(simpleTruncates, 20), "20 should get next length end of word");
        }

        [TestMethod]
        public void Truncate_DontBacktrackIfNoSpace()
        {
            var withoutSpace = simpleTruncates.Replace(" ", "-");
            
            Assert.AreEqual(withoutSpace.Substring(0, 15), Truncator.SafeTruncate(withoutSpace, 15), "truncate till end of word");
            Assert.AreEqual(withoutSpace.Substring(0, 16), Truncator.SafeTruncate(withoutSpace, 16), "truncate till end of word");
            Assert.AreEqual(withoutSpace.Substring(0, 17), Truncator.SafeTruncate(withoutSpace, 17), "truncate till end of word");
            Assert.AreEqual(withoutSpace.Substring(0, 18), Truncator.SafeTruncate(withoutSpace, 18), "truncate till end of word");
        }

        [TestMethod]
        public void Truncate_CitiesUmlauts()
        {
            Assert.AreEqual("Z&uml;ric", Truncator.SafeTruncate(citiesUmlauts, 5), "Zürich has 6/5 chars");
            Assert.AreEqual("Z&uml;rich", Truncator.SafeTruncate(citiesUmlauts, 6), "Zürich has 6/6 chars");
            Assert.AreEqual("Z&uml;rich", Truncator.SafeTruncate(citiesUmlauts, 8), "Zürich has 6/8 chars");
            Assert.AreEqual("Z&uml;rich and", Truncator.SafeTruncate(citiesUmlauts, 10), "Zürich-and has 10/10 chars");
            Assert.AreEqual("Z&uml;rich and", Truncator.SafeTruncate(citiesUmlauts, 11), "Zürich-and has 10/11 chars");
        }

    }
}
