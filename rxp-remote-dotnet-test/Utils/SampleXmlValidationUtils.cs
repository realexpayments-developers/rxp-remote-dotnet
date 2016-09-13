using Microsoft.VisualStudio.TestTools.UnitTesting;
using RealexPayments.Remote.SDK.Domain;
using RealexPayments.Remote.SDK.Domain.Payment;
using RealexPayments.Remote.SDK.Domain.ThreeDSecure;

namespace RealexPayments.Remote.SDK.Utils {
    public class SampleXmlValidationUtils {
        public static string SECRET = "mysecret";

        //payment sample XML
        public static string PAYMENT_REQUEST_XML_PATH = "payment-request-sample";
        public static string PAYMENT_RESPONSE_XML_PATH = "payment-response-sample";
        public static string PAYMENT_RESPONSE_BASIC_ERROR_XML_PATH = "payment-response-basic-error-sample";
        public static string PAYMENT_RESPONSE_FULL_ERROR_XML_PATH = "payment-response-full-error-sample";
        public static string PAYMENT_RESPONSE_XML_PATH_UNKNOWN_ELEMENT = "payment-response-sample-unknown-element";

        //3DSecure sample XML
        public static string THREE_D_SECURE_VERIFY_ENROLLED_REQUEST_XML_PATH = "_3ds-verify-enrolled-request-sample";
        public static string THREE_D_SECURE_VERIFY_ENROLLED_RESPONSE_XML_PATH = "_3ds-verify-enrolled-response-sample";
        public static string THREE_D_SECURE_VERIFY_ENROLLED_NOT_ENROLLED_RESPONSE_XML_PATH = "_3ds-verify-enrolled-response-sample-not-enrolled";
        public static string THREE_D_SECURE_VERIFY_SIG_REQUEST_XML_PATH = "_3ds-verify-sig-request-sample";
        public static string THREE_D_SECURE_VERIFY_SIG_RESPONSE_XML_PATH = "_3ds-verify-sig-response-sample";

        //other request types sample XML
        public static string MOBILE_AUTH_PAYMENT_REQUEST_XML_PATH = "/sample-xml/auth-mobile-payment-request-sample.xml";
        public static string SETTLE_PAYMENT_REQUEST_XML_PATH = "/sample-xml/settle-payment-request-sample.xml";
        public static string VOID_PAYMENT_REQUEST_XML_PATH = "/sample-xml/void-payment-request-sample.xml";
        public static string REBATE_PAYMENT_REQUEST_XML_PATH = "/sample-xml/rebate-payment-request-sample.xml";
        public static string OTB_PAYMENT_REQUEST_XML_PATH = "/sample-xml/otb-payment-request-sample.xml";
        public static string CREDIT_PAYMENT_REQUEST_XML_PATH = "credit-payment-request-sample.xml";
        public static string HOLD_PAYMENT_REQUEST_XML_PATH = "/sample-xml/hold-payment-request-sample.xml";
        public static string RELEASE_PAYMENT_REQUEST_XML_PATH = "/sample-xml/release-payment-request-sample.xml";

        //Card
        public static string CARD_NUMBER = "420000000000000000";
        public static string CARD_TYPE = CardType.VISA;
        public static string CARD_HOLDER_NAME = "Joe Smith";
        public static string CARD_CVN_NUMBER = "123";
        public static string CARD_CVN_PRESENCE = PresenceIndicator.CVN_PRESENT;
        public static string CARD_EXPIRY_DATE = "0119";
        public static int CARD_ISSUE_NUMBER = 1;

        //PaymentRequest
        public static string ACCOUNT = "internet";
        public static string MERCHANT_ID = "thestore";
        public static long AMOUNT = 29900L;
        public static string CURRENCY = "EUR";
        public static string AUTO_SETTLE_FLAG = AutoSettleFlag.MULTI;
        public static string TIMESTAMP = "20151201094345";
        public static string CHANNEL = "yourChannel";
        public static string ORDER_ID = "ORD453-11";
        public static string REQUEST_HASH = "085f09727da50c2392b64894f962e7eb5050f762";
        public static string COMMENT1 = "comment 1";
        public static string COMMENT2 = "comment 2";
        public static string REFUND_HASH = "hjfdg78h34tyvklasjr89t";
        public static string FRAUD_FILTER = "fraud filter";
        public static string CUSTOMER_NUMBER = "cust num";
        public static string PRODUCT_ID = "prod ID";
        public static string VARIABLE_REFERENCE = "variable ref 1234";
        public static string CUSTOMER_IP = "127.0.0.1";

        //Recurring
        public static string RECURRING_TYPE = RecurringType.FIXED;
        public static string RECURRING_FLAG = RecurringFlag.ONE;
        public static string RECURRING_SEQUENCE = RecurringSequence.FIRST;

        //Address
        public static string ADDRESS_TYPE_BUSINESS = AddressType.BILLING;
        public static string ADDRESS_CODE_BUSINESS = "21|578";
        public static string ADDRESS_COUNTRY_BUSINESS = "IE";

        public static string ADDRESS_TYPE_SHIPPING = AddressType.SHIPPING;
        public static string ADDRESS_CODE_SHIPPING = "77|9876";
        public static string ADDRESS_COUNTRY_SHIPPING = "GB";

        //response fields
        public static string ACQUIRER_RESPONSE = "<response>test acquirer response</response>";
        public static long AUTH_TIME_TAKEN = 1001l;
        public static long BATCH_ID = -1L;
        public static string BANK = "bank";
        public static string COUNTRY = "Ireland";
        public static string COUNTRY_CODE = "IE";
        public static string REGION = "Dublin";
        public static string CVN_RESULT = "M";
        public static string MESSAGE = "Successful";
        public static string RESULT_SUCCESS = "00";
        public static long TIME_TAKEN = 54564L;
        public static string TSS_RESULT = "67";
        public static string TSS_RESULT_CHECK1_ID = "1";
        public static string TSS_RESULT_CHECK2_ID = "2";
        public static string TSS_RESULT_CHECK1_VALUE = "99";
        public static string TSS_RESULT_CHECK2_VALUE = "199";
        public static string RESPONSE_HASH = "368df010076481d47a21e777871012b62b976339";
        public static string PASREF = "3737468273643";
        public static string AUTH_CODE = "79347";
        public static string AVS_POSTCODE = "M";
        public static string AVS_ADDRESS = "P";
        public static string MOBILE = "apple-pay";
        public static string TIMESTAMP_RESPONSE = "20120926112654";

        //basic response error fields
        public static string MESSAGE_BASIC_ERROR = "error message returned from system";
        public static string RESULT_BASIC_ERROR = "508";
        public static string TIMESTAMP_BASIC_ERROR = "20120926112654";
        public static string ORDER_ID_BASIC_ERROR = "ORD453-11";

        //basic response error fields
        public static string RESULT_FULL_ERROR = "101";
        public static string MESSAGE_FULL_ERROR = "Bank Error";
        public static string RESPONSE_FULL_ERROR_HASH = "0ad8a9f121c4041b4b832ae8069e80674269e22f";

        //3DS request fields
        public static string THREE_D_SECURE_VERIFY_ENROLLED_REQUEST_HASH = "085f09727da50c2392b64894f962e7eb5050f762";
        public static string THREE_D_SECURE_VERIFY_SIG_REQUEST_HASH = "085f09727da50c2392b64894f962e7eb5050f762";

        //3DS response fields
        public static string THREE_D_SECURE_ENROLLED_RESULT = "00";
        public static string THREE_D_SECURE_SIG_RESULT = "00";
        public static string THREE_D_SECURE_NOT_ENROLLED_RESULT = "110";
        public static string THREE_D_SECURE_ENROLLED_MESSAGE = "Enrolled";
        public static string THREE_D_SECURE_SIG_MESSAGE = "Authentication Successful";
        public static string THREE_D_SECURE_NOT_ENROLLED_MESSAGE = "Not Enrolled";
        public static string THREE_D_SECURE_PAREQ = "eJxVUttygkAM/ZUdnitZFlBw4na02tE6bR0vD+0bLlHpFFDASv++u6i1";
        public static string THREE_D_SECURE_PARES = "eJxVUttygkAM/ZUdnitZFlBw4na02tE6bR0vD+0bLlHpFFDASv++u6i1";
        public static string THREE_D_SECURE_URL = "http://myurl.com";
        public static string THREE_D_SECURE_ENROLLED_NO = "N";
        public static string THREE_D_SECURE_ENROLLED_YES = "Y";
        public static string THREE_D_SECURE_STATUS = "Y";
        public static string THREE_D_SECURE_ECI = "5";
        public static string THREE_D_SECURE_XID = "e9dafe706f7142469c45d4877aaf5984";
        public static string THREE_D_SECURE_CAVV = "AAABASY3QHgwUVdEBTdAAAAAAAA=";
        public static string THREE_D_SECURE_ALGORITHM = "1";
        public static string THREE_D_SECURE_NOT_ENROLLED_RESPONSE_HASH = "e553ff2510dec9bfee79bb0303af337d871c02ad";
        public static string THREE_D_SECURE_ENROLLED_RESPONSE_HASH = "728cdbef90ff535ed818748f329ed8b1df6b8f5a";
        public static string THREE_D_SECURE_SIG_RESPONSE_HASH = "e5a7745da5dc32d234c3f52860132c482107e9ac";

        //auth-mobile fields
        public static string AUTH_MOBILE_TIMESTAMP = "20150820154047";
        public static string AUTH_MOBILE_MERCHANT_ID = "thestore";
        public static string AUTH_MOBILE_ACCOUNT = "internet";
        public static string AUTH_MOBILE_ORDER_ID = "8cdbf036-73e2-44ff-bf11-eba8cab33a14";
        public static string AUTH_MOBILE_MOBILE = "apple-pay";
        public static string AUTH_MOBILE_AUTOSETTLE_FLAG = AutoSettleFlag.TRUE;
        public static string AUTH_MOBILE_TOKEN = "{\"version\":\"EC_v1\",\"data\":\"Ft+dvmdfgnsdfnbg+zerKtkh/RWWjdfgdjhHGFHGFlkjdfgkljlkfs78678hEPnsbXZnMDy3o7qDg+iDHB0JVEjDHxjQIAPcNN1Cqdtq63nX4+VRU3eXzdo1QGqSptH6D5KW5SxZLAdnMEmCxG9vkVEdHTTlhVPddxiovAkFTBWBFTJ2uf5f2grXC/VnK0X/efAowXrhJIX1ngsGfAk3/EVRzADGHJFGHJKH78hjkhdfgih80UU05zSluzATidvvBoHBz/WpytSYyrUx1QI9nyH/Nbv8f8lOUjPzBFb+EFOzJaIf+fr0swKU6EB2/2Sm0Y20mD0IvyomtKQ7Tf3VHKA7zhFrDvZUdtX808oHnrqDFRAQZHWAppGUVstqkOyibA0C4suxnOQlsQNZT0r70Tz84=\",\"signature\":\"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\",\"header\":{\"ephemeralPublicKey\":\"MFkwEwYHKoZIzj0CAQYIKoZIzj0DAQcDQgAEWdNhNAHy9kO2Kol33kIh7k6wh6E/lxriM46MR1FUrn7SHugprkaeFmWKZPgGpWgZ+telY/G1+YSoaCbR57bdGA==\",\"transactionId\":\"fd88874954acdb29976gfnjd784ng8ern8BDF8gT7G3fd4ebc22a864398684198644c3\",\"publicKeyHash\":\"h7njghUJVz2gmpTSkHqETOWsskhsdfjj4mgf3sPTS2cBxgrk=\"}}";
        public static string AUTH_MOBILE_REQUEST_HASH = "b13f183cd3ea2a0b63033fb53bdeb4894c684643";

        //settle fields
        public static string SETTLE_TIMESTAMP = "20151204133035";
        public static string SETTLE_MERCHANT_ID = "thestore";
        public static string SETTLE_ACCOUNT = "internet";
        public static string SETTLE_PASREF = "13276780809850";
        public static string SETTLE_AUTH_CODE = "AP1234";
        public static string SETTLE_AMOUNT = "1000";
        public static string SETTLE_CURRENCY = "EUR";
        public static string SETTLE_ORDER_ID = "e3cf94c6-f674-4f99-b4db-7541254a8767";
        public static string SETTLE_REQUEST_HASH = "b2e110f78803ccb377e8f3f12730e41d0cb0ed66";

        //void fields
        public static string VOID_TIMESTAMP = "20151204142728";
        public static string VOID_MERCHANT_ID = "thestore";
        public static string VOID_ACCOUNT = "internet";
        public static string VOID_PASREF = "13276780809851";
        public static string VOID_AUTH_CODE = "AP12345";
        public static string VOID_ORDER_ID = "012bf34b-3ec9-4c9b-b3a5-700f2f28e67f";
        public static string VOID_REQUEST_HASH = "9f61456cce6c90dcc13281e6b95734f5b91e628f";

        //rebate fields
        public static string REBATE_TIMESTAMP = "20151204145825";
        public static string REBATE_MERCHANT_ID = "thestore";
        public static string REBATE_ACCOUNT = "internet";
        public static string REBATE_PASREF = "13276780809852";
        public static string REBATE_AUTH_CODE = "AP12346";
        public static string REBATE_AMOUNT = "3000";
        public static string REBATE_CURRENCY = "EUR";
        public static string REBATE_ORDER_ID = "6df026a7-15d6-4b92-86e1-9f7b2b1d97c5";
        public static string REBATE_REFUND_HASH = "52ed08590ab0bb6c2e5e4c9584aca0f6e9635a3a";
        public static string REBATE_REQUEST_HASH = "c1319b2999608fcfa3e71d583627affaeb25d961";

        //OTB fields
        public static string OTB_ACCOUNT = "internet";
        public static string OTB_MERCHANT_ID = "thestore";
        public static string OTB_AUTO_SETTLE_FLAG = AutoSettleFlag.TRUE;
        public static string OTB_TIMESTAMP = "20151204152333";
        public static string OTB_ORDER_ID = "3be87fe9-db95-470f-ab04-b82f965f5b17";
        public static string OTB_REQUEST_HASH = "c05460fa3d195c1ee6ac97d3594e8cace4449cb2";

        //credit fields
        public static string CREDIT_TIMESTAMP = "20151204145825";
        public static string CREDIT_MERCHANT_ID = "thestore";
        public static string CREDIT_ACCOUNT = "internet";
        public static string CREDIT_PASREF = "13276780809852";
        public static string CREDIT_AUTH_CODE = "AP12346";
        public static string CREDIT_AMOUNT = "3000";
        public static string CREDIT_CURRENCY = "EUR";
        public static string CREDIT_ORDER_ID = "6df026a7-15d6-4b92-86e1-9f7b2b1d97c5";
        public static string CREDIT_REFUND_HASH = "52ed08590ab0bb6c2e5e4c9584aca0f6e9635a3a";
        public static string CREDIT_REQUEST_HASH = "c1319b2999608fcfa3e71d583627affaeb25d961";

        //hold fields
        public static string HOLD_TIMESTAMP = "20151204161419";
        public static string HOLD_MERCHANT_ID = "thestore";
        public static string HOLD_ACCOUNT = "internet";
        public static string HOLD_PASREF = "ABC123456";
        public static string HOLD_ORDER_ID = "292af5fa-6cbc-43d5-b2f0-7fd134d78d95";
        public static string HOLD_REQUEST_HASH = "eec6d1f5dcc51a6a2d2b59af5d2cdb965806d96c";

        //release fields
        public static string RELEASE_TIMESTAMP = "20151204161419";
        public static string RELEASE_MERCHANT_ID = "thestore";
        public static string RELEASE_ACCOUNT = "internet";
        public static string RELEASE_PASREF = "ABC123456";
        public static string RELEASE_ORDER_ID = "292af5fa-6cbc-43d5-b2f0-7fd134d78d95";
        public static string RELEASE_REQUEST_HASH = "eec6d1f5dcc51a6a2d2b59af5d2cdb965806d96c";

        /**
         * Check all fields match expected values.
         * 
         * @param fromXmlRequest
         */
        public static void checkUnmarshalledPaymentRequest(PaymentRequest fromXmlRequest) {
            Assert.IsNotNull(fromXmlRequest);
            Assert.AreEqual(PaymentType.AUTH, fromXmlRequest.Type);
            Assert.AreEqual(CARD_NUMBER, fromXmlRequest.Card.Number);
            Assert.AreEqual(CARD_TYPE, fromXmlRequest.Card.Type);
            Assert.AreEqual(CARD_HOLDER_NAME, fromXmlRequest.Card.CardHolderName);
            Assert.AreEqual(CARD_CVN_NUMBER, fromXmlRequest.Card.Cvn.Number);
            Assert.AreEqual(CARD_CVN_PRESENCE, fromXmlRequest.Card.Cvn.PresenceIndicator);
            Assert.AreEqual(CARD_ISSUE_NUMBER, fromXmlRequest.Card.IssueNumber);
            Assert.AreEqual(CARD_EXPIRY_DATE, fromXmlRequest.Card.ExpiryDate);
            Assert.AreEqual(ACCOUNT, fromXmlRequest.Account);
            Assert.AreEqual(MERCHANT_ID, fromXmlRequest.MerchantId);
            Assert.AreEqual(AMOUNT, fromXmlRequest.Amount.Amount);
            Assert.AreEqual(CURRENCY, fromXmlRequest.Amount.Currency);
            Assert.AreEqual(AUTO_SETTLE_FLAG, fromXmlRequest.AutoSettle.Flag);
            Assert.AreEqual(TIMESTAMP, fromXmlRequest.Timestamp);
            Assert.AreEqual(CHANNEL, fromXmlRequest.Channel);
            Assert.AreEqual(ORDER_ID, fromXmlRequest.OrderId);
            Assert.AreEqual(REQUEST_HASH, fromXmlRequest.Hash);
            Assert.AreEqual(COMMENT1, fromXmlRequest.Comments[0].Comment);
            Assert.AreEqual("1", fromXmlRequest.Comments[0].Id.ToString());
            Assert.AreEqual(COMMENT2, fromXmlRequest.Comments[1].Comment);
            Assert.AreEqual("2", fromXmlRequest.Comments[1].Id.ToString());
            Assert.AreEqual(PASREF, fromXmlRequest.PaymentsReference);
            Assert.AreEqual(AUTH_CODE, fromXmlRequest.AuthCode);
            Assert.AreEqual(REFUND_HASH, fromXmlRequest.RefundHash);
            Assert.AreEqual(FRAUD_FILTER, fromXmlRequest.FraudFilter);
            Assert.AreEqual(RECURRING_FLAG, fromXmlRequest.Recurring.Flag);
            Assert.AreEqual(RECURRING_TYPE, fromXmlRequest.Recurring.Type);
            Assert.AreEqual(RECURRING_SEQUENCE, fromXmlRequest.Recurring.Sequence);
            Assert.AreEqual(CUSTOMER_NUMBER, fromXmlRequest.TssInfo.CustomerNumber);
            Assert.AreEqual(PRODUCT_ID, fromXmlRequest.TssInfo.ProductId);
            Assert.AreEqual(VARIABLE_REFERENCE, fromXmlRequest.TssInfo.VariableReference);
            Assert.AreEqual(CUSTOMER_IP, fromXmlRequest.TssInfo.CustomerIpAddress);
            Assert.AreEqual(ADDRESS_TYPE_BUSINESS, fromXmlRequest.TssInfo.Addresses[0].Type);
            Assert.AreEqual(ADDRESS_CODE_BUSINESS, fromXmlRequest.TssInfo.Addresses[0].Code);
            Assert.AreEqual(ADDRESS_COUNTRY_BUSINESS, fromXmlRequest.TssInfo.Addresses[0].Country);
            Assert.AreEqual(ADDRESS_TYPE_SHIPPING, fromXmlRequest.TssInfo.Addresses[1].Type);
            Assert.AreEqual(ADDRESS_CODE_SHIPPING, fromXmlRequest.TssInfo.Addresses[1].Code);
            Assert.AreEqual(ADDRESS_COUNTRY_SHIPPING, fromXmlRequest.TssInfo.Addresses[1].Country);
            Assert.AreEqual(THREE_D_SECURE_CAVV, fromXmlRequest.Mpi.Cavv);
            Assert.AreEqual(THREE_D_SECURE_XID, fromXmlRequest.Mpi.Xid);
            Assert.AreEqual(THREE_D_SECURE_ECI, fromXmlRequest.Mpi.Eci);
        }

        /**
         * Check all fields match expected values.
         * 
         * @param fromXmlRequest
         */
        public static void checkUnmarshalledMobileAuthPaymentRequest(PaymentRequest fromXmlRequest) {
            Assert.IsNotNull(fromXmlRequest);
            Assert.AreEqual(PaymentType.AUTH_MOBILE, fromXmlRequest.Type);
            Assert.AreEqual(AUTH_MOBILE_ACCOUNT, fromXmlRequest.Account);
            Assert.AreEqual(AUTH_MOBILE_MERCHANT_ID, fromXmlRequest.MerchantId);
            Assert.AreEqual(AUTH_MOBILE_AUTOSETTLE_FLAG, fromXmlRequest.AutoSettle.Flag);
            Assert.AreEqual(AUTH_MOBILE_TIMESTAMP, fromXmlRequest.Timestamp);
            Assert.AreEqual(AUTH_MOBILE_ORDER_ID, fromXmlRequest.OrderId);
            Assert.AreEqual(AUTH_MOBILE_MOBILE, fromXmlRequest.Mobile);
            Assert.AreEqual(AUTH_MOBILE_TOKEN, fromXmlRequest.Token);
            Assert.AreEqual(AUTH_MOBILE_REQUEST_HASH, fromXmlRequest.Hash);
        }

        /**
         * Check all fields match expected values.
         * 
         * @param fromXmlRequest
         */
        public static void checkUnmarshalledSettlePaymentRequest(PaymentRequest fromXmlRequest) {
            Assert.IsNotNull(fromXmlRequest);
            Assert.AreEqual(PaymentType.SETTLE, fromXmlRequest.Type);
            Assert.AreEqual(SETTLE_ACCOUNT, fromXmlRequest.Account);
            Assert.AreEqual(SETTLE_MERCHANT_ID, fromXmlRequest.MerchantId);
            Assert.AreEqual(SETTLE_TIMESTAMP, fromXmlRequest.Timestamp);
            Assert.AreEqual(SETTLE_ORDER_ID, fromXmlRequest.OrderId);
            Assert.AreEqual(SETTLE_REQUEST_HASH, fromXmlRequest.Hash);
            Assert.AreEqual(SETTLE_AMOUNT, fromXmlRequest.Amount.Amount.ToString());
            Assert.AreEqual(SETTLE_CURRENCY, fromXmlRequest.Amount.Currency);
            Assert.AreEqual(SETTLE_PASREF, fromXmlRequest.PaymentsReference);
            Assert.AreEqual(SETTLE_AUTH_CODE, fromXmlRequest.AuthCode);
        }

        /**
         * Check all fields match expected values.
         * 
         * @param fromXmlRequest
         */
        public static void checkUnmarshalledVoidPaymentRequest(PaymentRequest fromXmlRequest) {
            Assert.IsNotNull(fromXmlRequest);
            Assert.AreEqual(PaymentType.VOID, fromXmlRequest.Type);
            Assert.AreEqual(VOID_ACCOUNT, fromXmlRequest.Account);
            Assert.AreEqual(VOID_MERCHANT_ID, fromXmlRequest.MerchantId);
            Assert.AreEqual(VOID_TIMESTAMP, fromXmlRequest.Timestamp);
            Assert.AreEqual(VOID_ORDER_ID, fromXmlRequest.OrderId);
            Assert.AreEqual(VOID_REQUEST_HASH, fromXmlRequest.Hash);
            Assert.AreEqual(VOID_PASREF, fromXmlRequest.PaymentsReference);
            Assert.AreEqual(VOID_AUTH_CODE, fromXmlRequest.AuthCode);
        }

        /**
         * Check all fields match expected values.
         * 
         * @param fromXmlRequest
         */
        public static void checkUnmarshalledRebatePaymentRequest(PaymentRequest fromXmlRequest) {
            Assert.IsNotNull(fromXmlRequest);
            Assert.AreEqual(PaymentType.REBATE, fromXmlRequest.Type);
            Assert.AreEqual(REBATE_ACCOUNT, fromXmlRequest.Account);
            Assert.AreEqual(REBATE_MERCHANT_ID, fromXmlRequest.MerchantId);
            Assert.AreEqual(REBATE_TIMESTAMP, fromXmlRequest.Timestamp);
            Assert.AreEqual(REBATE_ORDER_ID, fromXmlRequest.OrderId);
            Assert.AreEqual(REBATE_REQUEST_HASH, fromXmlRequest.Hash);
            Assert.AreEqual(REBATE_AMOUNT, fromXmlRequest.Amount.Amount.ToString());
            Assert.AreEqual(REBATE_CURRENCY, fromXmlRequest.Amount.Currency);
            Assert.AreEqual(REBATE_PASREF, fromXmlRequest.PaymentsReference);
            Assert.AreEqual(REBATE_AUTH_CODE, fromXmlRequest.AuthCode);
            Assert.AreEqual(REBATE_REFUND_HASH, fromXmlRequest.RefundHash);
        }

        /**
         * Check all fields match expected values.
         * 
         * @param fromXmlRequest
         */
        public static void checkUnmarshalledOtbPaymentRequest(PaymentRequest fromXmlRequest) {
            Assert.IsNotNull(fromXmlRequest);
            Assert.AreEqual(PaymentType.OTB, fromXmlRequest.Type);
            Assert.AreEqual(CARD_NUMBER, fromXmlRequest.Card.Number);
            Assert.AreEqual(CARD_TYPE, fromXmlRequest.Card.Type);
            Assert.AreEqual(CARD_HOLDER_NAME, fromXmlRequest.Card.CardHolderName);
            Assert.AreEqual(CARD_CVN_NUMBER, fromXmlRequest.Card.Cvn.Number);
            Assert.AreEqual(CARD_CVN_PRESENCE, fromXmlRequest.Card.Cvn.PresenceIndicator);
            Assert.AreEqual(CARD_ISSUE_NUMBER, fromXmlRequest.Card.IssueNumber);
            Assert.AreEqual(CARD_EXPIRY_DATE, fromXmlRequest.Card.ExpiryDate);
            Assert.AreEqual(OTB_ACCOUNT, fromXmlRequest.Account);
            Assert.AreEqual(OTB_MERCHANT_ID, fromXmlRequest.MerchantId);
            Assert.AreEqual(OTB_AUTO_SETTLE_FLAG, fromXmlRequest.AutoSettle.Flag);
            Assert.AreEqual(OTB_TIMESTAMP, fromXmlRequest.Timestamp);
            Assert.AreEqual(OTB_ORDER_ID, fromXmlRequest.OrderId);
            Assert.AreEqual(OTB_REQUEST_HASH, fromXmlRequest.Hash);
        }

        /**
         * Check all fields match expected values.
         * 
         * @param fromXmlRequest
         */
        public static void checkUnmarshalledCreditPaymentRequest(PaymentRequest fromXmlRequest) {
            Assert.IsNotNull(fromXmlRequest);
            Assert.AreEqual(PaymentType.CREDIT, fromXmlRequest.Type);
            Assert.AreEqual(CREDIT_ACCOUNT, fromXmlRequest.Account);
            Assert.AreEqual(CREDIT_MERCHANT_ID, fromXmlRequest.MerchantId);
            Assert.AreEqual(CREDIT_TIMESTAMP, fromXmlRequest.Timestamp);
            Assert.AreEqual(CREDIT_ORDER_ID, fromXmlRequest.OrderId);
            Assert.AreEqual(CREDIT_REQUEST_HASH, fromXmlRequest.Hash);
            Assert.AreEqual(CREDIT_AMOUNT, fromXmlRequest.Amount.Amount.ToString());
            Assert.AreEqual(CREDIT_CURRENCY, fromXmlRequest.Amount.Currency);
            Assert.AreEqual(CREDIT_PASREF, fromXmlRequest.PaymentsReference);
            Assert.AreEqual(CREDIT_AUTH_CODE, fromXmlRequest.AuthCode);
            Assert.AreEqual(CREDIT_REFUND_HASH, fromXmlRequest.RefundHash);
        }

        /**
         * Check all fields match expected values.
         * 
         * @param fromXmlRequest
         */
        public static void checkUnmarshalledHoldPaymentRequest(PaymentRequest fromXmlRequest) {
            Assert.IsNotNull(fromXmlRequest);
            Assert.AreEqual(PaymentType.HOLD, fromXmlRequest.Type);
            Assert.AreEqual(HOLD_ACCOUNT, fromXmlRequest.Account);
            Assert.AreEqual(HOLD_MERCHANT_ID, fromXmlRequest.MerchantId);
            Assert.AreEqual(HOLD_TIMESTAMP, fromXmlRequest.Timestamp);
            Assert.AreEqual(HOLD_ORDER_ID, fromXmlRequest.OrderId);
            Assert.AreEqual(HOLD_REQUEST_HASH, fromXmlRequest.Hash);
            Assert.AreEqual(HOLD_PASREF, fromXmlRequest.PaymentsReference);
        }

        /**
         * Check all fields match expected values.
         * 
         * @param fromXmlRequest
         */
        public static void checkUnmarshalledReleasePaymentRequest(PaymentRequest fromXmlRequest) {
            Assert.IsNotNull(fromXmlRequest);
            Assert.AreEqual(PaymentType.RELEASE, fromXmlRequest.Type);
            Assert.AreEqual(RELEASE_ACCOUNT, fromXmlRequest.Account);
            Assert.AreEqual(RELEASE_MERCHANT_ID, fromXmlRequest.MerchantId);
            Assert.AreEqual(RELEASE_TIMESTAMP, fromXmlRequest.Timestamp);
            Assert.AreEqual(RELEASE_ORDER_ID, fromXmlRequest.OrderId);
            Assert.AreEqual(RELEASE_REQUEST_HASH, fromXmlRequest.Hash);
            Assert.AreEqual(RELEASE_PASREF, fromXmlRequest.PaymentsReference);
        }

        /**
         * Check all fields match expected values.
         * 
         * @param fromXmlResponse
         */
        public static void checkUnmarshalledPaymentResponse(PaymentResponse fromXmlResponse) {
            Assert.AreEqual(ACCOUNT, fromXmlResponse.Account);
            Assert.AreEqual(ACQUIRER_RESPONSE, fromXmlResponse.AcquirerResponse);
            Assert.AreEqual(AUTH_CODE, fromXmlResponse.AuthCode);
            Assert.AreEqual(AUTH_TIME_TAKEN.ToString(), fromXmlResponse.AuthTimeTaken.ToString());
            Assert.AreEqual(BATCH_ID.ToString(), fromXmlResponse.BatchId.ToString());
            Assert.AreEqual(BANK, fromXmlResponse.CardIssuer.Bank);
            Assert.AreEqual(COUNTRY, fromXmlResponse.CardIssuer.Country);
            Assert.AreEqual(COUNTRY_CODE, fromXmlResponse.CardIssuer.CountryCode);
            Assert.AreEqual(REGION, fromXmlResponse.CardIssuer.Region);
            Assert.AreEqual(CVN_RESULT, fromXmlResponse.CvnResult);
            Assert.AreEqual(MERCHANT_ID, fromXmlResponse.MerchantId);
            Assert.AreEqual(MESSAGE, fromXmlResponse.Message);
            Assert.AreEqual(ORDER_ID, fromXmlResponse.OrderId);
            Assert.AreEqual(PASREF, fromXmlResponse.PaymentsReference);
            Assert.AreEqual(RESULT_SUCCESS, fromXmlResponse.Result);
            Assert.AreEqual(RESPONSE_HASH, fromXmlResponse.Hash);
            Assert.AreEqual(TIMESTAMP_RESPONSE, fromXmlResponse.Timestamp);
            Assert.AreEqual(TIME_TAKEN.ToString(), fromXmlResponse.TimeTaken.ToString());
            Assert.AreEqual(TSS_RESULT, fromXmlResponse.TssResult.Result);
            Assert.AreEqual(TSS_RESULT_CHECK1_ID, fromXmlResponse.TssResult.Checks[0].Id);
            Assert.AreEqual(TSS_RESULT_CHECK1_VALUE, fromXmlResponse.TssResult.Checks[0].Value);
            Assert.AreEqual(TSS_RESULT_CHECK2_ID, fromXmlResponse.TssResult.Checks[1].Id);
            Assert.AreEqual(TSS_RESULT_CHECK2_VALUE, fromXmlResponse.TssResult.Checks[1].Value);
            Assert.AreEqual(AVS_ADDRESS, fromXmlResponse.AvsAddressResponse);
            Assert.AreEqual(AVS_POSTCODE, fromXmlResponse.AvsPostcodeResponse);
            Assert.IsTrue(fromXmlResponse.IsSuccess());
        }

        /**
         * Check all fields match expected values.
         * 
         * @param fromXmlResponse
         */
        public static void checkBasicResponseError(RealexServerException ex) {
            Assert.AreEqual(RESULT_BASIC_ERROR, ex.ErrorCode);
            Assert.AreEqual(MESSAGE_BASIC_ERROR, ex.Message);
            Assert.AreEqual(TIMESTAMP_BASIC_ERROR, ex.Timestamp);
            Assert.AreEqual(ORDER_ID_BASIC_ERROR, ex.OrderId);
        }

        /**
         * Check all fields match expected values.
         * 
         * @param fromXmlResponse
         */
        public static void checkFullResponseError(PaymentResponse fromXmlResponse) {
            Assert.AreEqual(ACCOUNT, fromXmlResponse.Account);
            Assert.AreEqual(ACQUIRER_RESPONSE, fromXmlResponse.AcquirerResponse);
            Assert.AreEqual(AUTH_CODE, fromXmlResponse.AuthCode);
            Assert.AreEqual(AUTH_TIME_TAKEN.ToString(), fromXmlResponse.AuthTimeTaken.ToString());
            Assert.AreEqual(BATCH_ID.ToString(), fromXmlResponse.BatchId.ToString());
            Assert.AreEqual(BANK, fromXmlResponse.CardIssuer.Bank);
            Assert.AreEqual(COUNTRY, fromXmlResponse.CardIssuer.Country);
            Assert.AreEqual(COUNTRY_CODE, fromXmlResponse.CardIssuer.CountryCode);
            Assert.AreEqual(REGION, fromXmlResponse.CardIssuer.Region);
            Assert.AreEqual(CVN_RESULT, fromXmlResponse.CvnResult);
            Assert.AreEqual(MERCHANT_ID, fromXmlResponse.MerchantId);
            Assert.AreEqual(MESSAGE_FULL_ERROR, fromXmlResponse.Message);
            Assert.AreEqual(ORDER_ID, fromXmlResponse.OrderId);
            Assert.AreEqual(PASREF, fromXmlResponse.PaymentsReference);
            Assert.AreEqual(RESULT_FULL_ERROR, fromXmlResponse.Result);
            Assert.AreEqual(RESPONSE_FULL_ERROR_HASH, fromXmlResponse.Hash);
            Assert.AreEqual(TIMESTAMP_RESPONSE, fromXmlResponse.Timestamp);
            Assert.AreEqual(TIME_TAKEN.ToString(), fromXmlResponse.TimeTaken.ToString());
            Assert.AreEqual(TSS_RESULT, fromXmlResponse.TssResult.Result);
            Assert.AreEqual(TSS_RESULT_CHECK1_ID, fromXmlResponse.TssResult.Checks[0].Id);
            Assert.AreEqual(TSS_RESULT_CHECK1_VALUE, fromXmlResponse.TssResult.Checks[0].Value);
            Assert.AreEqual(TSS_RESULT_CHECK2_ID, fromXmlResponse.TssResult.Checks[1].Id);
            Assert.AreEqual(TSS_RESULT_CHECK2_VALUE, fromXmlResponse.TssResult.Checks[1].Value);
            Assert.IsFalse(fromXmlResponse.IsSuccess());
        }

        /**
         * Check all fields match expected values.
         * 
         * @param fromXmlResponse
         */
        public static void checkUnmarshalledThreeDSecureNotEnrolledResponse(ThreeDSecureResponse fromXmlResponse) {
            Assert.AreEqual(ACCOUNT, fromXmlResponse.Account);
            Assert.AreEqual(AUTH_CODE, fromXmlResponse.AuthCode);
            Assert.AreEqual(AUTH_TIME_TAKEN.ToString(), fromXmlResponse.AuthTimeTaken.ToString());
            Assert.AreEqual(MERCHANT_ID, fromXmlResponse.MerchantId);
            Assert.AreEqual(THREE_D_SECURE_NOT_ENROLLED_MESSAGE, fromXmlResponse.Message);
            Assert.AreEqual(ORDER_ID, fromXmlResponse.OrderId);
            Assert.AreEqual(PASREF, fromXmlResponse.PaymentsReference);
            Assert.AreEqual(THREE_D_SECURE_NOT_ENROLLED_RESULT, fromXmlResponse.Result);
            Assert.AreEqual(THREE_D_SECURE_NOT_ENROLLED_RESPONSE_HASH, fromXmlResponse.Hash);
            Assert.AreEqual(TIMESTAMP, fromXmlResponse.Timestamp);
            Assert.AreEqual(TIME_TAKEN.ToString(), fromXmlResponse.TimeTaken.ToString());
            Assert.AreEqual(THREE_D_SECURE_URL, fromXmlResponse.Url);
            Assert.AreEqual(THREE_D_SECURE_PAREQ, fromXmlResponse.Pareq);
            Assert.AreEqual(THREE_D_SECURE_ENROLLED_NO, fromXmlResponse.Enrolled);
            Assert.AreEqual(THREE_D_SECURE_XID, fromXmlResponse.Xid);
            Assert.IsFalse(fromXmlResponse.IsSuccess());
        }

        /**
         * Check all fields match expected values.
         * 
         * @param fromXmlResponse
         */
        public static void checkUnmarshalledThreeDSecureEnrolledResponse(ThreeDSecureResponse fromXmlResponse) {
            Assert.AreEqual(ACCOUNT, fromXmlResponse.Account);
            Assert.AreEqual(AUTH_CODE, fromXmlResponse.AuthCode);
            Assert.AreEqual(AUTH_TIME_TAKEN.ToString(), fromXmlResponse.AuthTimeTaken.ToString());
            Assert.AreEqual(MERCHANT_ID, fromXmlResponse.MerchantId);
            Assert.AreEqual(THREE_D_SECURE_ENROLLED_MESSAGE, fromXmlResponse.Message);
            Assert.AreEqual(ORDER_ID, fromXmlResponse.OrderId);
            Assert.AreEqual(PASREF, fromXmlResponse.PaymentsReference);
            Assert.AreEqual(THREE_D_SECURE_ENROLLED_RESULT, fromXmlResponse.Result);
            Assert.AreEqual(THREE_D_SECURE_ENROLLED_RESPONSE_HASH, fromXmlResponse.Hash);
            Assert.AreEqual(TIMESTAMP_RESPONSE, fromXmlResponse.Timestamp);
            Assert.AreEqual(TIME_TAKEN.ToString(), fromXmlResponse.TimeTaken.ToString());
            Assert.AreEqual(THREE_D_SECURE_URL, fromXmlResponse.Url);
            Assert.AreEqual(THREE_D_SECURE_PAREQ, fromXmlResponse.Pareq);
            Assert.AreEqual(THREE_D_SECURE_ENROLLED_YES, fromXmlResponse.Enrolled);
            Assert.AreEqual(THREE_D_SECURE_XID, fromXmlResponse.Xid);
            Assert.IsTrue(fromXmlResponse.IsSuccess());
        }

        /**
         * Check all fields match expected values.
         * 
         * @param fromXmlResponse
         */
        public static void checkUnmarshalledThreeDSecureSigResponse(ThreeDSecureResponse fromXmlResponse) {
            Assert.AreEqual(ACCOUNT, fromXmlResponse.Account);
            Assert.AreEqual(MERCHANT_ID, fromXmlResponse.MerchantId);
            Assert.AreEqual(THREE_D_SECURE_SIG_MESSAGE, fromXmlResponse.Message);
            Assert.AreEqual(ORDER_ID, fromXmlResponse.OrderId);
            Assert.AreEqual(THREE_D_SECURE_SIG_RESULT, fromXmlResponse.Result);
            Assert.AreEqual(THREE_D_SECURE_SIG_RESPONSE_HASH, fromXmlResponse.Hash);
            Assert.AreEqual(TIMESTAMP_RESPONSE, fromXmlResponse.Timestamp);
            Assert.AreEqual(THREE_D_SECURE_STATUS, fromXmlResponse.ThreeDSecure.Status);
            Assert.AreEqual(THREE_D_SECURE_ECI, fromXmlResponse.ThreeDSecure.Eci);
            Assert.AreEqual(THREE_D_SECURE_XID, fromXmlResponse.ThreeDSecure.Xid);
            Assert.AreEqual(THREE_D_SECURE_CAVV, fromXmlResponse.ThreeDSecure.Cavv);
            Assert.AreEqual(THREE_D_SECURE_ALGORITHM, fromXmlResponse.ThreeDSecure.Algorithm);
            Assert.IsTrue(fromXmlResponse.IsSuccess());
        }

        /**
         * Check all fields match expected values.
         * 
         * @param fromXmlRequest
         */
        public static void checkUnmarshalledVerifyEnrolledRequest(ThreeDSecureRequest fromXmlRequest) {
            Assert.IsNotNull(fromXmlRequest);
            Assert.AreEqual(CARD_NUMBER, fromXmlRequest.Card.Number);
            Assert.AreEqual(CARD_TYPE, fromXmlRequest.Card.Type);
            Assert.AreEqual(CARD_HOLDER_NAME, fromXmlRequest.Card.CardHolderName);
            Assert.AreEqual(CARD_EXPIRY_DATE, fromXmlRequest.Card.ExpiryDate);

            Assert.AreEqual(ACCOUNT, fromXmlRequest.Account);
            Assert.AreEqual(MERCHANT_ID, fromXmlRequest.MerchantId);
            Assert.AreEqual(ThreeDSecureType.VERIFY_ENROLLED, fromXmlRequest.Type);
            Assert.AreEqual(AMOUNT, fromXmlRequest.Amount.Amount);
            Assert.AreEqual(CURRENCY, fromXmlRequest.Amount.Currency);
            Assert.AreEqual(TIMESTAMP, fromXmlRequest.Timestamp);
            Assert.AreEqual(ORDER_ID, fromXmlRequest.OrderId);
            Assert.AreEqual(THREE_D_SECURE_VERIFY_ENROLLED_REQUEST_HASH, fromXmlRequest.Hash);
        }

        /**
         * Check all fields match expected values.
         * 
         * @param fromXmlRequest
         */
        public static void checkUnmarshalledVerifySigRequest(ThreeDSecureRequest fromXmlRequest) {
            Assert.IsNotNull(fromXmlRequest);
            Assert.AreEqual(CARD_NUMBER, fromXmlRequest.Card.Number);
            Assert.AreEqual(CARD_TYPE, fromXmlRequest.Card.Type);
            Assert.AreEqual(CARD_HOLDER_NAME, fromXmlRequest.Card.CardHolderName);
            Assert.AreEqual(CARD_EXPIRY_DATE, fromXmlRequest.Card.ExpiryDate);

            Assert.AreEqual(ACCOUNT, fromXmlRequest.Account);
            Assert.AreEqual(MERCHANT_ID, fromXmlRequest.MerchantId);
            Assert.AreEqual(ThreeDSecureType.VERIFY_SIG, fromXmlRequest.Type);
            Assert.AreEqual(AMOUNT, fromXmlRequest.Amount.Amount);
            Assert.AreEqual(CURRENCY, fromXmlRequest.Amount.Currency);
            Assert.AreEqual(TIMESTAMP, fromXmlRequest.Timestamp);
            Assert.AreEqual(ORDER_ID, fromXmlRequest.OrderId);
            Assert.AreEqual(THREE_D_SECURE_PARES, fromXmlRequest.Pares);
            Assert.AreEqual(THREE_D_SECURE_VERIFY_SIG_REQUEST_HASH, fromXmlRequest.Hash);
        }
    }
}
