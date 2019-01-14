using System;
using System.Collections.Generic;
using System.Linq;
using Connect.Razor.Internals;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Connect.Razor.Blade;


namespace Razor_Blades_Tests
{
    [TestClass]
    public class Text_Crop
    {

        [TestMethod]
        public void Crop_Basic()
        {
            var message = "This is a teaser for something";
            Assert.AreEqual("T", Text.Crop(message, 1), "message is short, shouldn't change");
            Assert.AreEqual("Th", Text.Crop(message, 2));
            Assert.AreEqual("Thi", Text.Crop(message, 3));
            Assert.AreEqual("This", Text.Crop(message, 4));
            Assert.AreEqual("This", Text.Crop(message, 5));
            Assert.AreEqual("This", Text.Crop(message, 6));
            Assert.AreEqual("This is", Text.Crop(message, 7));
            Assert.AreEqual("This is", Text.Crop(message, 8));
        }

        [TestMethod]
        public void Truncate_CutOffPoint_Basic()
        {
            var basicTests = "Some normal text without specials";
            Assert.AreEqual(Truncator.FindCutLength(basicTests, 5), 5);
            Assert.AreEqual(Truncator.FindCutLength(basicTests, 10), 10);
        }

        // for reference char numbers     "12345678901234567890"
        private const string citiesUtf8 = "Zürich & München";
        private const string entityUuml = "&uuml;";
        private const string entityEt = "&amp;";
        private readonly string citiesUmlauts = citiesUtf8.Replace("&", entityEt).Replace("ü", entityUuml);
        private readonly int[] entityPositions = {2, 8, 11};

        private void AssertLastCityChar(int length)
        {
            var cutLength = Truncator.FindCutLength(citiesUmlauts, length);

            // special case: length 0 means nothing should come back
            if (length == 0)
            {
                Assert.AreEqual(0, cutLength, "on 0 should be 0");
                return;
            }

            var foundChar = citiesUmlauts[cutLength - 1];
            var expected = citiesUtf8[length - 1];
            // if it's one of the special characters, the real value will be a ; ending the entity
            if(entityPositions.Contains(length)) expected = ';';
            Assert.AreEqual(expected, foundChar, $"tried on index {length}");
        }

        [TestMethod]
        public void Truncate_CutOffPoint_Umlauts()
        {
            for(var i = 0; i < citiesUtf8.Length; i++)
                AssertLastCityChar(i);

            // test each character to ensure the length jumps correctly each time
            var tests = new List<int[]>
            {
                new[] {1, 1}, // Z
                new[] {2, 7}, // Z&uuml;
                new[] {3, 8},
                new[] {7, 12},
                new[] {8, 17}, // an &uuml; and &amp;
                new[] {9, 18},
                new[] {10, 19},
                new[] {11, 25}, // two &uuml; and one &amp;
                new[] {12, 26},
                new[] {13, 27},
                new[] {15, 29},
                new[] {16, 30},
                new[] {17, 30}, // it doesn't get longer
                new[] {18, 30}, // it doesn't get longer
                new[] {19, 30}, // it doesn't get longer
            };

            foreach (var test in tests)
                Assert.AreEqual(test[1], Truncator.FindCutLength(citiesUmlauts, test[0]),
                    $"looking at length {test[0]}");
        }

        [TestMethod]
        public void Truncate_CutOffPoint_Nbsp()
        {
            var basicTests = "Dont-Split-Me".Replace("-", "&nbsp;");
            Assert.AreEqual(10, Truncator.FindCutLength(basicTests, 5));
            Assert.AreEqual(15, Truncator.FindCutLength(basicTests, 10));
            Assert.AreEqual(21, Truncator.FindCutLength(basicTests, 11));
            Assert.AreEqual(basicTests.Length, Truncator.FindCutLength(basicTests, basicTests.Length));
        }

        private string simpleTruncates = "This is a teaser for something";
        [TestMethod]
        public void Truncate_Basic()
        {
            Assert.AreEqual(simpleTruncates, Text.Crop(simpleTruncates, 100), "message is short, shouldn't change");

            Assert.AreEqual("This", Text.Crop(simpleTruncates, 4), "truncate till end of word");
            Assert.AreEqual("This", Text.Crop(simpleTruncates, 5), "truncate till end of word");
        }


        [TestMethod]
        public void Truncate_Chars15To19()
        {
            var testStr = simpleTruncates;
            var partBefore16 = simpleTruncates.Substring(0, 16); // should be "This is a teaser"
            TestChars15To20(partBefore16, testStr);
        }

        [TestMethod]
        public void Truncate_Chars15To19Hyphen()
        {
            var testStr = simpleTruncates.Replace(' ', '-');
            var partBefore16 = testStr.Substring(0, 16); // should be "This is a teaser"
            TestChars15To20(partBefore16, testStr);
        }

        private static void TestChars15To20(string partBefore16, string testStr)
        {
            Assert.AreNotEqual(partBefore16, Truncator.SafeTruncate(testStr, 15), "15 chars should be shorter");
            for(var i= 16; i < 20; i++)
                Assert.AreEqual(partBefore16, Truncator.SafeTruncate(testStr, i), $"truncate till end of word count: {i}");
            Assert.AreNotEqual(partBefore16, Truncator.SafeTruncate(testStr, 20), "20 should get next length end of word");
        }

        [TestMethod]
        public void Truncate_DontBacktrackIfNoSpace()
        {
            var withoutSpace = simpleTruncates.Replace(" ", "x"); // remove all white-spaces
            
            Assert.AreEqual(withoutSpace.Substring(0, 15), Truncator.SafeTruncate(withoutSpace, 15), "truncate till end of word");
            Assert.AreEqual(withoutSpace.Substring(0, 16), Truncator.SafeTruncate(withoutSpace, 16), "truncate till end of word");
            Assert.AreEqual(withoutSpace.Substring(0, 17), Truncator.SafeTruncate(withoutSpace, 17), "truncate till end of word");
            Assert.AreEqual(withoutSpace.Substring(0, 18), Truncator.SafeTruncate(withoutSpace, 18), "truncate till end of word");
        }

        [TestMethod]
        public void Truncate_CitiesUmlauts()
        {
            Assert.AreEqual("Z&uuml;ric", Truncator.SafeTruncate(citiesUmlauts, 5), "Zürich has 6/5 chars");
            Assert.AreEqual("Z&uuml;rich", Truncator.SafeTruncate(citiesUmlauts, 6), "Zürich has 6/6 chars");
            Assert.AreEqual("Z&uuml;rich", Truncator.SafeTruncate(citiesUmlauts, 7), "Zürich has 6/8 chars");
            Assert.AreEqual("Z&uuml;rich &amp;", Truncator.SafeTruncate(citiesUmlauts, 8), "Zürich has 6/8 chars");
            Assert.AreEqual("Z&uuml;rich &amp;", Truncator.SafeTruncate(citiesUmlauts, 10), "Zürich-and has 10/10 chars");
            Assert.AreEqual("Z&uuml;rich &amp;", Truncator.SafeTruncate(citiesUmlauts, 11), "Zürich-and has 10/11 chars");
            Assert.AreEqual("Z&uuml;rich &amp; M&uuml;nchen", Truncator.SafeTruncate(citiesUmlauts, 16), "Zürich-and has M.. 16 chars");
        }

    }
}
