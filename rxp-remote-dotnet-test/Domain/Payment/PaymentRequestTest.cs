using Microsoft.VisualStudio.TestTools.UnitTesting;
using sx = RealexPayments.Remote.SDK.Utils.SampleXmlValidationUtils;

namespace RealexPayments.Remote.SDK.Domain.Payment {
    [TestClass]
    public class PaymentRequestTest {

        [TestMethod]
        public void AddAddressVerificationServiceDetailsTest() {
            //test variations of address and postcode with TSS Info field null
            var addressLine = "123 Fake St";
            var postcode = "WB1 A42";
            var expectedBillingCode = "142|123";

            PaymentRequest request = new PaymentRequest();
            request.AddAddressVerificationServiceDetails(addressLine, postcode);

            Assert.AreEqual(expectedBillingCode, request.TssInfo.Addresses[0].Code);
            Assert.AreEqual(AddressType.BILLING, request.TssInfo.Addresses[0].Type);

            //test 2
            addressLine = "123 5 Fake St";
            postcode = "1WB 5A2";
            expectedBillingCode = "152|1235";

            request = new PaymentRequest();
            request.AddAddressVerificationServiceDetails(addressLine, postcode);

            Assert.AreEqual(expectedBillingCode, request.TssInfo.Addresses[0].Code);
            Assert.AreEqual(AddressType.BILLING, request.TssInfo.Addresses[0].Type);

            //test 3
            addressLine = "Apt 15, 123 Fake St";
            postcode = "ABC 5A2";
            expectedBillingCode = "52|15123";

            request = new PaymentRequest();
            request.AddAddressVerificationServiceDetails(addressLine, postcode);

            Assert.AreEqual(expectedBillingCode, request.TssInfo.Addresses[0].Code);
            Assert.AreEqual(AddressType.BILLING, request.TssInfo.Addresses[0].Type);

            //test 4
            addressLine = "Fake St";
            postcode = "AI10 9AB";
            expectedBillingCode = "109|";

            request = new PaymentRequest();
            request.AddAddressVerificationServiceDetails(addressLine, postcode);

            Assert.AreEqual(expectedBillingCode, request.TssInfo.Addresses[0].Code);
            Assert.AreEqual(AddressType.BILLING, request.TssInfo.Addresses[0].Type);

            //test 5
            addressLine = "30 Fake St";
            postcode = "";
            expectedBillingCode = "|30";

            request = new PaymentRequest();
            request.AddAddressVerificationServiceDetails(addressLine, postcode);

            Assert.AreEqual(expectedBillingCode, request.TssInfo.Addresses[0].Code);
            Assert.AreEqual(AddressType.BILLING, request.TssInfo.Addresses[0].Type);
        }

        /**
         * Tests the population of a billing address for the Address Verification Service when TSS Info already exists.
         */
        [TestMethod]
        public void AddAddressVerificationServiceDetailsWithTssInfoTest() {
            var addressLine = "123 Fake St";
            var postcode = "WB1 A42";
            var expectedBillingCode = "142|123";

            PaymentRequest request = new PaymentRequest();
            request.AddTssInfo(new TssInfo()).AddAddressVerificationServiceDetails(addressLine, postcode);

            Assert.AreEqual(expectedBillingCode, request.TssInfo.Addresses[0].Code);
            Assert.AreEqual(AddressType.BILLING, request.TssInfo.Addresses[0].Type);
        }

        /**
         * Tests the hash calculation for an auth payment.
         */
        [TestMethod]
        public void AuthHashGenerationTest() {
            PaymentRequest request = new PaymentRequest()
                .AddType(PaymentType.AUTH)
                .AddTimestamp(sx.TIMESTAMP)
                .AddMerchantId(sx.MERCHANT_ID)
                .AddOrderId(sx.ORDER_ID)
                .AddAmount(sx.AMOUNT)
                .AddCurrency(sx.CURRENCY)
                .AddCard(new Card().AddNumber(sx.CARD_NUMBER));
            request.GenerateHash(sx.SECRET);

            Assert.AreEqual(sx.REQUEST_HASH, request.Hash);
        }

        /**
         * Tests the hash calculation for an auth-mobile payment.
         */
        [TestMethod]
        public void AuthMobileHashGenerationTest() {
            PaymentRequest request = new PaymentRequest()
                .AddType(PaymentType.AUTH_MOBILE)
                .AddTimestamp(sx.AUTH_MOBILE_TIMESTAMP)
                .AddMerchantId(sx.AUTH_MOBILE_MERCHANT_ID)
                .AddOrderId(sx.AUTH_MOBILE_ORDER_ID)
                .AddToken(sx.AUTH_MOBILE_TOKEN);
            request.GenerateHash(sx.SECRET);

            Assert.AreEqual(sx.AUTH_MOBILE_REQUEST_HASH, request.Hash);
        }

        /**
         * Tests the hash calculation for a settle payment.
         */
        [TestMethod]
        public void SettleHashGenerationTest() {
            PaymentRequest request = new PaymentRequest()
                .AddType(PaymentType.SETTLE)
                .AddTimestamp(sx.SETTLE_TIMESTAMP)
                .AddMerchantId(sx.SETTLE_MERCHANT_ID)
                .AddOrderId(sx.SETTLE_ORDER_ID)
                .AddPaymentsReference(sx.SETTLE_PASREF)
                .AddAuthCode(sx.SETTLE_AUTH_CODE)
                .AddAmount(long.Parse(sx.SETTLE_AMOUNT))
                .AddCurrency(sx.SETTLE_CURRENCY);
            request.GenerateHash(sx.SECRET);

            Assert.AreEqual(sx.SETTLE_REQUEST_HASH, request.Hash);
        }

        /**
         * Tests the hash calculation for a void payment.
         */
        [TestMethod]
        public void VoidHashGenerationTest() {
            PaymentRequest request = new PaymentRequest()
                .AddType(PaymentType.VOID)
                .AddTimestamp(sx.VOID_TIMESTAMP)
                .AddMerchantId(sx.VOID_MERCHANT_ID)
                .AddOrderId(sx.VOID_ORDER_ID)
                .AddPaymentsReference(sx.VOID_PASREF)
                .AddAuthCode(sx.VOID_AUTH_CODE);
            request.GenerateHash(sx.SECRET);

            Assert.AreEqual(sx.VOID_REQUEST_HASH, request.Hash);
        }

        /**
         * Tests the hash calculation for a rebate payment.
         */
        [TestMethod]
        public void RebateHashGenerationTest() {
            PaymentRequest request = new PaymentRequest()
                .AddType(PaymentType.REBATE)
                .AddTimestamp(sx.REBATE_TIMESTAMP)
                .AddMerchantId(sx.REBATE_MERCHANT_ID)
                .AddOrderId(sx.REBATE_ORDER_ID)
                .AddPaymentsReference(sx.REBATE_PASREF)
                .AddAuthCode(sx.REBATE_AUTH_CODE)
                .AddAmount(long.Parse(sx.REBATE_AMOUNT))
                .AddCurrency(sx.REBATE_CURRENCY)
                .AddRefundHash(sx.REBATE_REFUND_HASH);
            request.GenerateHash(sx.SECRET);

            Assert.AreEqual(sx.REBATE_REQUEST_HASH, request.Hash);
        }

        /**
         * Tests the hash calculation for an OTB request.
         */
        [TestMethod]
        public void OtbHashGenerationTest() {
            PaymentRequest request = new PaymentRequest()
                .AddType(PaymentType.OTB)
                .AddTimestamp(sx.OTB_TIMESTAMP)
                .AddMerchantId(sx.OTB_MERCHANT_ID)
                .AddOrderId(sx.OTB_ORDER_ID);
            request.GenerateHash(sx.SECRET);

            Assert.AreEqual(sx.OTB_REQUEST_HASH, request.Hash);
        }

        /**
         * Tests the hash calculation for a credit payment.
         */
        [TestMethod]
        public void CreditHashGenerationTest() {
            PaymentRequest request = new PaymentRequest()
                .AddType(PaymentType.CREDIT)
                .AddTimestamp(sx.CREDIT_TIMESTAMP)
                .AddMerchantId(sx.CREDIT_MERCHANT_ID)
                .AddOrderId(sx.CREDIT_ORDER_ID)
                .AddPaymentsReference(sx.CREDIT_PASREF)
                .AddAuthCode(sx.CREDIT_AUTH_CODE)
                .AddAmount(long.Parse(sx.CREDIT_AMOUNT))
                .AddCurrency(sx.CREDIT_CURRENCY)
                .AddRefundHash(sx.CREDIT_REFUND_HASH);
            request.GenerateHash(sx.SECRET);

            Assert.AreEqual(sx.CREDIT_REQUEST_HASH, request.Hash);
        }

        /**
         * Tests the hash calculation for a hold payment.
         */
        [TestMethod]
        public void HoldHashGenerationTest() {
            PaymentRequest request = new PaymentRequest()
                .AddType(PaymentType.HOLD)
                .AddTimestamp(sx.HOLD_TIMESTAMP)
                .AddMerchantId(sx.HOLD_MERCHANT_ID)
                .AddOrderId(sx.HOLD_ORDER_ID)
                .AddPaymentsReference(sx.HOLD_PASREF);
            request.GenerateHash(sx.SECRET);

            Assert.AreEqual(sx.HOLD_REQUEST_HASH, request.Hash);
        }

        /**
         * Tests the hash calculation for a release payment.
         */
        [TestMethod]
        public void ReleaseHashGenerationTest() {
            PaymentRequest request = new PaymentRequest()
                .AddType(PaymentType.RELEASE)
                .AddTimestamp(sx.RELEASE_TIMESTAMP)
                .AddMerchantId(sx.RELEASE_MERCHANT_ID)
                .AddOrderId(sx.RELEASE_ORDER_ID)
                .AddPaymentsReference(sx.RELEASE_PASREF);
            request.GenerateHash(sx.SECRET);

            Assert.AreEqual(sx.RELEASE_REQUEST_HASH, request.Hash);
        }
    }
}
