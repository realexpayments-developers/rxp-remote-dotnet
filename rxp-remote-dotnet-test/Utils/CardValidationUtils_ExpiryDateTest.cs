using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTestHacks;

namespace RealexPayments.Remote.SDK.Utils {
    [TestClass]
    public class CardValidationUtils_ExpiryDateTest : TestBase {
        private IEnumerable<TestData> DataSource {
            get {
                return new List<TestData>() {
                    new TestData ("Correct format MMYY", "1220", true ),
                    new TestData ("Correct format MM-YY", "12-20", false ),
                    new TestData ("Correct format MM/YY", "12/20", false ),
                    new TestData ("Correct format MM YY", "12 20", false ),
                    new TestData ("Incorrect format MM\\YY", "12\\20", false ),
                    new TestData ("Incorrect format AABB", "AABB", false ),
                    new TestData ("Correct future date MMYY", "1221", true ),
                    new TestData ("Correct date MMYY", "1221", true ),
                    new TestData ("Incorrect date MMYY", "1321", false ),
                    new TestData ("Incorrect date MMYY", "1212", false ),
                    new TestData ("Incorrect date MMYY", "0015", false ),
                    new TestData ("Incorrect date MMYY", "0415", false ),
                    new TestData ("Correct date MMYY", "1217", true ),
                    new TestData ("Incorrect date MMYY", "0021", false )
                };
            }
        }

        public class TestData {
            public string Message { get; set; }
            public string ExpiryDate { get; set; }
            public bool ExpectedResult { get; set; }

            public TestData(string message, string expiryDate, bool expectedResult) {
                this.Message = message;
                this.ExpiryDate = expiryDate;
                this.ExpectedResult = expectedResult;
            }
        }

        [TestMethod]
        [DataSource("RealexPayments.Remote.SDK.Utils.CardValidationUtils_ExpiryDateTest.DataSource")]
        public void TestExpiryDateFormats() {
            var testData = this.TestContext.GetRuntimeDataSourceObject<TestData>();

            bool result = CardValidationUtils.PerformExpiryDateCheck(testData.ExpiryDate);
            Assert.AreEqual(testData.ExpectedResult, result, testData.Message + " : " + testData.ExpiryDate);
        }
    }
}
