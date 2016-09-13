using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RealexPayments.Remote.SDK.Utils {
    [TestClass]
    public class GenerationUtilsTest {
        [TestMethod]
        public void TestGenerateHash() {
            var testString = "20120926112654.thestore.ORD453-11.00.Successful.3737468273643.79347";
            var secret = "mysecret";
            var expectedResult = "368df010076481d47a21e777871012b62b976339";

            string result = GenerationUtils.GenerateHash(testString, secret);
            Assert.AreEqual(expectedResult, result, "Expected and resultant Hash do not match. expected: " + expectedResult + " result: " + result);
        }

        [TestMethod]
        public void TestGenerateTimestamp() {
            var result = GenerationUtils.GenerateTimestamp();
            Assert.IsTrue(new Regex("[0-9]{14}").IsMatch(result), "Timestamp should be 14 digits: " + result);
        }

        [TestMethod]
        public void TestGenerateOrderId() {
            var result = GenerationUtils.GenerateOrderId();
            Assert.IsTrue(result.Length == 22, "OrderId " + result + " should be 22 characters, is " + result.Length + " characters: " + result);
        }
    }
}
