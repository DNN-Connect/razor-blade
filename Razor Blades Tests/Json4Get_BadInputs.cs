using System;
using Connect.Razor.Json4Get;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Razor_Blades_Tests
{
    [TestClass]
    public class Json4Get_BadInputs
    {

        [TestMethod]
        public void BadInput_Encode_Null()
            => Assert.IsNull(Json4Get.Encode(null));

        [TestMethod]
        public void BadInput_Decode_Null()
            => Assert.IsNull(Json4Get.Encode(null));

        [TestMethod]
        public void BadInput_Encode_EmptyOrWhiteSpace()
        {
            Assert.AreEqual(string.Empty, Json4Get.Encode(string.Empty));
            Assert.AreEqual(" ", Json4Get.Encode(" "));
            Assert.AreEqual("\n \t ", Json4Get.Encode("\n \t "));
        }
        [TestMethod]
        public void BadInput_Decode_EmptyOrWhiteSpace()
        {
            Assert.AreEqual(string.Empty, Json4Get.Decode(string.Empty));
            Assert.AreEqual(" ", Json4Get.Decode(" "));
            Assert.AreEqual("\n \t ", Json4Get.Decode("\n \t "));
        }

        [TestMethod]
        public void BadInput_Encode_LeadingSpaces() => Assert.AreEqual("()", Json4Get.Encode("  {}"));

        [TestMethod]
        public void BadInput_Decode_LeadingSpaces() => Assert.AreEqual("  {}", Json4Get.Decode("  ()"));

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void BadInput_Encode_LeadingSpacesBadValue() => Json4Get.Encode("  bad-json");

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void BadInput_Decode_LeadingSpacesBadValue() => Json4Get.Decode("  bad-json");

        [TestMethod]
        public void BadInput_Encode_BadOpenCloseCount()
        {
            var badVariations = new []{ "{", "}", "{ { }", "\"value\":\"forgot-to-close" };
            foreach (var test in badVariations)
            {
                try
                {
                    // this line should throw an error
                    Json4Get.Encode(test);

                    // if it didn't throw yet, it's not ok - so throw special
                    Assert.Fail("not-ok-should-throw-before");
                }
                catch (Exception exception)
                {
                    if (exception.Message == "not-ok-should-throw-before") throw;
                }
            }
        }

    }
}
