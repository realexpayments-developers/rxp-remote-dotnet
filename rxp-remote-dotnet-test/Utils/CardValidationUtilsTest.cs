using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RealexPayments.Remote.SDK.Utils {
    [TestClass]
    public class CardValidationUtilsTest {
        private const string VALID_CARD_NUM = "4242424242424242";
        private const string INVALID_CARD_NUM = "1234567890123456";
        private const string VALID_CARD_NUM_WITH_SPACES = "4242 4242 4242 4242";
        private const string INVALID_CARD_NUM_WITH_SPACES = "1234 5678 9012 3456";
        private const string ALPHA_STRING = "abcdefghijklmop";
        private const string EMPTY_STRING = "";

        [TestMethod]
        public void TestValidCardNumber() {
            bool cardIsValid = CardValidationUtils.PerformLuhnCheck(VALID_CARD_NUM);
            Assert.IsTrue(cardIsValid, "Test Valid Card Number " + VALID_CARD_NUM);
        }

        [TestMethod]
        public void TestInvalidCardNumber() {
            bool cardIsValid = CardValidationUtils.PerformLuhnCheck(INVALID_CARD_NUM);
            Assert.IsFalse(cardIsValid, "Test Invalid Card Number " + INVALID_CARD_NUM);
        }

        [TestMethod]
        public void TestValidCardNumberWithSpaces() {
            bool cardIsValid = CardValidationUtils.PerformLuhnCheck(VALID_CARD_NUM_WITH_SPACES);
            Assert.IsFalse(cardIsValid, "Test Valid Card Number " + VALID_CARD_NUM_WITH_SPACES);
        }

        [TestMethod]
        public void TestInvalidCardNumberWithSpaces() {
            bool cardIsValid = CardValidationUtils.PerformLuhnCheck(INVALID_CARD_NUM_WITH_SPACES);
            Assert.IsFalse(cardIsValid, "Test Invalid Card Number " + INVALID_CARD_NUM_WITH_SPACES);
        }

        [TestMethod]
        public void TestAlphastringAsCardNumber() {
            bool cardIsValid = CardValidationUtils.PerformLuhnCheck(ALPHA_STRING);
            Assert.IsFalse(cardIsValid, "Test Invalid Card Number " + ALPHA_STRING);
        }

        [TestMethod]
        public void TestEmptystringAsCardNumber() {
            bool cardIsValid = CardValidationUtils.PerformLuhnCheck(EMPTY_STRING);
            Assert.IsFalse(cardIsValid, "Test Invalid Card Number " + EMPTY_STRING);
        }

        [TestMethod]
        public void TestValidAmexCvv() {
            string cvvNumber = "1234";
            string cardType = "AMEX";

            bool cvvIsValid = CardValidationUtils.PerformCvvCheck(cvvNumber, cardType);
            Assert.IsTrue(cvvIsValid, "Testing valid " + cardType + " card type with CVV number " + cvvNumber + EMPTY_STRING);
        }

        [TestMethod]
        public void TestValidAmexLowerCaseCvv() {
            string cvvNumber = "1234";
            string cardType = "amex";

            bool cvvIsValid = CardValidationUtils.PerformCvvCheck(cvvNumber, cardType);
            Assert.IsTrue(cvvIsValid, "Testing valid " + cardType + " card type with CVV number " + cvvNumber + EMPTY_STRING);
        }

        [TestMethod]
        public void TestInvalidAmexCvv() {
            string cvvNumber = "12345";
            string cardType = "AMEX";

            bool cvvIsValid = CardValidationUtils.PerformCvvCheck(cvvNumber, cardType);
            Assert.IsFalse(cvvIsValid, "Testing invalid " + cardType + " card type with CVV number " + cvvNumber + EMPTY_STRING);
        }

        [TestMethod]
        public void TestValidVisaCvv() {
            string cvvNumber = "123";
            string cardType = "VISA";

            bool cvvIsValid = CardValidationUtils.PerformCvvCheck(cvvNumber, cardType);
            Assert.IsTrue(cvvIsValid, "Testing valid " + cardType + " card type with CVV number " + cvvNumber + EMPTY_STRING);
        }

        [TestMethod]
        public void TestInvalidVisaCvv() {
            string cvvNumber = "1234";
            string cardType = "VISA";

            bool cvvIsValid = CardValidationUtils.PerformCvvCheck(cvvNumber, cardType);
            Assert.IsFalse(cvvIsValid, "Testing valid " + cardType + " card type with CVV number " + cvvNumber + EMPTY_STRING);
        }

        [TestMethod]
        public void TestValidExpiryDateCurrentMonthThisYear() {
            string message = "Correct date MMYY - this month";
            string expiryDate = GetExpiry();
            bool expectedResult = true;

            bool result = CardValidationUtils.PerformExpiryDateCheck(expiryDate);
            Assert.AreEqual(expectedResult, result, message + " : " + expiryDate);
        }

        [TestMethod]
        public void TestValidExpiryDateFutureMonthThisYear() {

            string message = "Correct date MMYY - this month";
            string expiryDate = GetExpiry(1);
            bool expectedResult = true;

            bool result = CardValidationUtils.PerformExpiryDateCheck(expiryDate);
            Assert.AreEqual(expectedResult, result, message + " : " + expiryDate);
        }

        [TestMethod]
        public void TestInvalidExpiryDatePastMonthThisYear() {

            string message = "Correct date MMYY - this month";
            string expiryDate = GetExpiry(-1);
            bool expectedResult = false;

            bool result = CardValidationUtils.PerformExpiryDateCheck(expiryDate);
            Assert.AreEqual(expectedResult, result, message + " : " + expiryDate);
        }

        private string GetExpiry(int additionalMonths = 0) {
            var now = DateTime.Now.AddMonths(additionalMonths);
            return now.ToString("MMyy");
        }
    }
}
