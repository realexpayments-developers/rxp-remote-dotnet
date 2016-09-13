using Microsoft.VisualStudio.TestTools.UnitTesting;
using sx = RealexPayments.Remote.SDK.Utils.SampleXmlValidationUtils;

namespace RealexPayments.Remote.SDK.Domain.ThreeDSecure {
    [TestClass]
    public class ThreeDSecureRequestTest {
        [TestMethod]
        public void VerifyEnrolledHashGenerationTest() {
            ThreeDSecureRequest request = new ThreeDSecureRequest()
                .AddType(ThreeDSecureType.VERIFY_ENROLLED)
                .AddTimestamp(sx.TIMESTAMP)
                .AddMerchantId(sx.MERCHANT_ID)
                .AddOrderId(sx.ORDER_ID)
                .AddAmount(sx.AMOUNT)
                .AddCurrency(sx.CURRENCY)
                .AddCard(new Card()
                .AddNumber(sx.CARD_NUMBER));
            request.GenerateHash(sx.SECRET);

            Assert.AreEqual(sx.REQUEST_HASH, request.Hash);
        }

        /**
         * Test hash calculation for 3DSecure Verify Sig.
         */
        [TestMethod]
        public void VerifySigHashGenerationTest() {
            ThreeDSecureRequest request = new ThreeDSecureRequest()
                .AddType(ThreeDSecureType.VERIFY_SIG)
                .AddTimestamp(sx.TIMESTAMP)
                .AddMerchantId(sx.MERCHANT_ID)
                .AddOrderId(sx.ORDER_ID)
                .AddAmount(sx.AMOUNT)
                .AddCurrency(sx.CURRENCY)
                .AddCard(new Card().AddNumber(sx.CARD_NUMBER));
            request.GenerateHash(sx.SECRET);

            Assert.AreEqual(sx.REQUEST_HASH, request.Hash);
        }
    }
}
