using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RealexPayments.Remote.SDK.Domain.Payment {
    [TestClass]
    public class CardTest {
        [TestMethod]
        public void TestDisplayFirstSixLastFour() {
            Card card = new Card {
                Number = "1234567890ABCDEF"
            };

            var expectedResult = "123456******CDEF";
            var result = card.DisplayFirstSixLastFour();

            Assert.AreEqual(expectedResult, result, "Results are not as expected.");
        }
    }
}
