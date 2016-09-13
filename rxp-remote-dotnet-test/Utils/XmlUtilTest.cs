using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RealexPayments.Remote.SDK.Domain;
using RealexPayments.Remote.SDK.Domain.Payment;
using RealexPayments.Remote.SDK.Domain.ThreeDSecure;
using RealexPayments.Remote.SDK.Properties;
using static RealexPayments.Remote.SDK.Utils.XmlUtils;
using sx = RealexPayments.Remote.SDK.Utils.SampleXmlValidationUtils;

namespace RealexPayments.Remote.SDK.Utils {
    [TestClass]
    public class XmlUtilTest {
        [TestMethod]
        public void PaymentRequestXmlHelpersTest() {
            var cvn = new Cvn()
                .AddNumber(sx.CARD_CVN_NUMBER)
                .AddPresenceIndicator(sx.CARD_CVN_PRESENCE);

            var card = new Card()
                .AddExpiryDate(sx.CARD_EXPIRY_DATE)
                .AddNumber(sx.CARD_NUMBER)
                .AddType(CardType.VISA)
                .AddCardHolderName(sx.CARD_HOLDER_NAME)
                .AddIssueNumber(sx.CARD_ISSUE_NUMBER);
            card.Cvn = cvn;

            var tssInfo = new TssInfo()
                .AddCustomerNumber(sx.CUSTOMER_NUMBER)
                .AddProductId(sx.PRODUCT_ID)
                .AddVariableReference(sx.VARIABLE_REFERENCE)
                .AddCustomerIpAddress(sx.CUSTOMER_IP)
                .AddAddress(new Address()
                        .AddType(sx.ADDRESS_TYPE_BUSINESS)
                        .AddCode(sx.ADDRESS_CODE_BUSINESS)
                        .AddCountry(sx.ADDRESS_COUNTRY_BUSINESS))
                .AddAddress(new Address()
                        .AddType(sx.ADDRESS_TYPE_SHIPPING)
                        .AddCode(sx.ADDRESS_CODE_SHIPPING)
                        .AddCountry(sx.ADDRESS_COUNTRY_SHIPPING));

            var request = new PaymentRequest()
                .AddAccount(sx.ACCOUNT)
                .AddMerchantId(sx.MERCHANT_ID)
                .AddType(PaymentType.AUTH)
                .AddAmount(sx.AMOUNT)
                .AddCurrency(sx.CURRENCY)
                .AddCard(card)
                .AddAutoSettle(sx.AUTO_SETTLE_FLAG)
                .AddTimestamp(sx.TIMESTAMP)
                .AddChannel(sx.CHANNEL)
                .AddOrderId(sx.ORDER_ID)
                .AddHash(sx.REQUEST_HASH)
                .AddComment(sx.COMMENT1)
                .AddComment(sx.COMMENT2)
                .AddPaymentsReference(sx.PASREF)
                .AddAuthCode(sx.AUTH_CODE)
                .AddRefundHash(sx.REFUND_HASH)
                .AddFraudFilter(sx.FRAUD_FILTER)
                .AddRecurring(new Recurring()
                        .AddFlag(sx.RECURRING_FLAG)
                        .AddSequence(sx.RECURRING_SEQUENCE)
                        .AddType(sx.RECURRING_TYPE))
                .AddTssInfo(tssInfo)
                .AddMpi(new Mpi()
                        .AddCavv(sx.THREE_D_SECURE_CAVV)
                        .AddXid(sx.THREE_D_SECURE_XID)
                        .AddEci(sx.THREE_D_SECURE_ECI));


            string xml = request.ToXml();

            PaymentRequest fromXmlRequest = new PaymentRequest().FromXml(xml);
            sx.checkUnmarshalledPaymentRequest(fromXmlRequest);
        }

        /**
	 * Tests conversion of {@link PaymentRequest} to and from XML using the helper methods with no enums.
	 */
        [TestMethod]
        public void PaymentRequestXmlHelpersNoEnumsTest() {
            Card card = new Card()
                    .AddExpiryDate(sx.CARD_EXPIRY_DATE)
                    .AddNumber(sx.CARD_NUMBER)
                    .AddType(CardType.VISA)
                    .AddCardHolderName(sx.CARD_HOLDER_NAME)
                    .AddCvn(sx.CARD_CVN_NUMBER)
                    .AddCvnPresenceIndicator(sx.CARD_CVN_PRESENCE)
                    .AddIssueNumber(sx.CARD_ISSUE_NUMBER);

            TssInfo tssInfo = new TssInfo()
                    .AddCustomerNumber(sx.CUSTOMER_NUMBER)
                    .AddProductId(sx.PRODUCT_ID)
                    .AddVariableReference(sx.VARIABLE_REFERENCE)
                    .AddCustomerIpAddress(sx.CUSTOMER_IP)
                    .AddAddress(new Address()
                            .AddType(sx.ADDRESS_TYPE_BUSINESS)
                            .AddCode(sx.ADDRESS_CODE_BUSINESS)
                            .AddCountry(sx.ADDRESS_COUNTRY_BUSINESS))
                    .AddAddress(new Address()
                            .AddType(sx.ADDRESS_TYPE_SHIPPING)
                            .AddCode(sx.ADDRESS_CODE_SHIPPING)
                            .AddCountry(sx.ADDRESS_COUNTRY_SHIPPING));

            PaymentRequest request = new PaymentRequest()
                    .AddAccount(sx.ACCOUNT)
                    .AddMerchantId(sx.MERCHANT_ID)
                    .AddType(PaymentType.AUTH)
                    .AddAmount(sx.AMOUNT)
                    .AddCurrency(sx.CURRENCY)
                    .AddCard(card)
                    .AddAutoSettle(sx.AUTO_SETTLE_FLAG)
                    .AddTimestamp(sx.TIMESTAMP)
                    .AddChannel(sx.CHANNEL)
                    .AddOrderId(sx.ORDER_ID)
                    .AddHash(sx.REQUEST_HASH)
                    .AddComment(sx.COMMENT1)
                    .AddComment(sx.COMMENT2)
                    .AddPaymentsReference(sx.PASREF)
                    .AddAuthCode(sx.AUTH_CODE)
                    .AddRefundHash(sx.REFUND_HASH)
                    .AddFraudFilter(sx.FRAUD_FILTER)
                    .AddRecurring(new Recurring()
                            .AddFlag(sx.RECURRING_FLAG)
                            .AddSequence(sx.RECURRING_SEQUENCE)
                            .AddType(sx.RECURRING_TYPE))
                    .AddTssInfo(tssInfo)
                    .AddMpi(new Mpi()
                            .AddCavv(sx.THREE_D_SECURE_CAVV)
                            .AddXid(sx.THREE_D_SECURE_XID)
                            .AddEci(sx.THREE_D_SECURE_ECI));

            //convert to XML
            string xml = request.ToXml();

            //Convert from XML back to PaymentRequest
            PaymentRequest fromXmlRequest = new PaymentRequest().FromXml(xml);
            sx.checkUnmarshalledPaymentRequest(fromXmlRequest);
        }

        /**
         * Tests conversion of {@link PaymentRequest} to and from XML using setters.
         */
        [TestMethod]
        public void PaymentRequestXmlSettersTest() {
            Card card = new Card();
            card.ExpiryDate = sx.CARD_EXPIRY_DATE;
            card.Number = sx.CARD_NUMBER;
            card.Type = CardType.VISA;
            card.CardHolderName = sx.CARD_HOLDER_NAME;
            card.IssueNumber = sx.CARD_ISSUE_NUMBER;

            Cvn cvn = new Cvn();
            cvn.Number = sx.CARD_CVN_NUMBER;
            cvn.PresenceIndicator = sx.CARD_CVN_PRESENCE;
            card.Cvn = cvn;

            PaymentRequest request = new PaymentRequest();
            request.Account = sx.ACCOUNT;
            request.MerchantId = sx.MERCHANT_ID;
            request.Type = PaymentType.AUTH;

            RxpAmount amount = new RxpAmount();
            amount.Amount = sx.AMOUNT;
            amount.Currency = sx.CURRENCY;
            request.Amount = amount;

            AutoSettle autoSettle = new AutoSettle();
            autoSettle.Flag = sx.AUTO_SETTLE_FLAG;

            request.AutoSettle = autoSettle;
            request.Card = card;
            request.Timestamp = sx.TIMESTAMP;
            request.Channel = sx.CHANNEL;
            request.OrderId = sx.ORDER_ID;
            request.Hash = sx.REQUEST_HASH;

            List<RxpComment> comments = new List<RxpComment>();
            RxpComment comment = new RxpComment();
            comment.Id = 1;
            comment.Comment = sx.COMMENT1;
            comments.Add(comment);
            comment = new RxpComment();
            comment.Id = 2;
            comment.Comment = sx.COMMENT2;
            comments.Add(comment);
            request.Comments = comments;

            request.PaymentsReference = sx.PASREF;
            request.AuthCode = sx.AUTH_CODE;
            request.RefundHash = sx.REFUND_HASH;
            request.FraudFilter = sx.FRAUD_FILTER;

            Recurring recurring = new Recurring();
            recurring.Flag = sx.RECURRING_FLAG;
            recurring.Sequence = sx.RECURRING_SEQUENCE;
            recurring.Type = sx.RECURRING_TYPE;
            request.Recurring = recurring;

            TssInfo tssInfo = new TssInfo();
            tssInfo.CustomerNumber = sx.CUSTOMER_NUMBER;
            tssInfo.ProductId = sx.PRODUCT_ID;
            tssInfo.VariableReference = sx.VARIABLE_REFERENCE;
            tssInfo.CustomerIpAddress = sx.CUSTOMER_IP;

            List<Address> addresses = new List<Address>();
            Address address = new Address();
            address.Type = sx.ADDRESS_TYPE_BUSINESS;
            address.Code = sx.ADDRESS_CODE_BUSINESS;
            address.Country = sx.ADDRESS_COUNTRY_BUSINESS;
            addresses.Add(address);

            address = new Address();
            address.Type = sx.ADDRESS_TYPE_SHIPPING;
            address.Code = sx.ADDRESS_CODE_SHIPPING;
            address.Country = sx.ADDRESS_COUNTRY_SHIPPING;
            addresses.Add(address);

            tssInfo.Addresses = addresses;
            request.TssInfo = tssInfo;

            Mpi mpi = new Mpi();
            mpi.Cavv = sx.THREE_D_SECURE_CAVV;
            mpi.Xid = sx.THREE_D_SECURE_XID;
            mpi.Eci = sx.THREE_D_SECURE_ECI;
            request.Mpi = mpi;

            //convert to XML
            string xml = request.ToXml();

            //Convert from XML back to PaymentRequest
            PaymentRequest fromXmlRequest = new PaymentRequest().FromXml(xml);
            sx.checkUnmarshalledPaymentRequest(fromXmlRequest);

        }

        /**
         * Tests conversion of {@link PaymentResponse} to and from XML.
         */
        [TestMethod]
        public void PaymentResponseXmlTest() {
            PaymentResponse response = new PaymentResponse();

            response.Account = sx.ACCOUNT;
            response.AcquirerResponse = sx.ACQUIRER_RESPONSE;
            response.AuthCode = sx.AUTH_CODE;
            response.AuthTimeTaken = sx.AUTH_TIME_TAKEN;
            response.BatchId = sx.BATCH_ID;

            CardIssuer cardIssuer = new CardIssuer();
            cardIssuer.Bank = sx.BANK;
            cardIssuer.Country = sx.COUNTRY;
            cardIssuer.CountryCode = sx.COUNTRY_CODE;
            cardIssuer.Region = sx.REGION;
            response.CardIssuer = cardIssuer;

            response.CvnResult = sx.CVN_RESULT;
            response.MerchantId = sx.MERCHANT_ID;
            response.Message = sx.MESSAGE;
            response.OrderId = sx.ORDER_ID;
            response.PaymentsReference = sx.PASREF;
            response.Result = sx.RESULT_SUCCESS;
            response.Hash = sx.RESPONSE_HASH;
            response.Timestamp = sx.TIMESTAMP_RESPONSE;
            response.TimeTaken = sx.TIME_TAKEN;

            TssResult tssResult = new TssResult();
            tssResult.Result = sx.TSS_RESULT;

            List<TssResultCheck> checks = new List<TssResultCheck>();
            TssResultCheck check = new TssResultCheck();
            check.Id = sx.TSS_RESULT_CHECK1_ID;
            check.Value = sx.TSS_RESULT_CHECK1_VALUE;
            checks.Add(check);
            check = new TssResultCheck();
            check.Id = sx.TSS_RESULT_CHECK2_ID;
            check.Value = sx.TSS_RESULT_CHECK2_VALUE;
            checks.Add(check);

            tssResult.Checks = checks;
            response.TssResult = tssResult;

            response.AvsAddressResponse = sx.AVS_ADDRESS;
            response.AvsPostcodeResponse = sx.AVS_POSTCODE;

            //marshal to XML
            string xml = response.ToXml();

            //unmarshal back to response
            PaymentResponse fromXmlResponse = new PaymentResponse().FromXml(xml);
            sx.checkUnmarshalledPaymentResponse(fromXmlResponse);
        }

        /**
         * Tests conversion of {@link PaymentResponse} from XML file 
         */
        [TestMethod]
        public void PaymentResponseXmlFromFileTest() {
            PaymentResponse fromXmlResponse = new PaymentResponse().FromXml(Resources.payment_response_sample);
            sx.checkUnmarshalledPaymentResponse(fromXmlResponse);
        }

        /**
         * Tests conversion of {@link PaymentRequest} from XML file.
         */
        [TestMethod]
        public void PaymentRequestXmlFromFileTest() {
            //Convert from XML back to PaymentRequest
            PaymentRequest fromXmlRequest = new PaymentRequest().FromXml(Resources.payment_request_sample);
            sx.checkUnmarshalledPaymentRequest(fromXmlRequest);
        }

        /**
         * Tests conversion of {@link PaymentResponse} from XML file with unknown element.
         */
        [TestMethod]
        public void PaymentResponseXmlFromFileUnknownElementTest() {
            //Convert from XML back to PaymentRequest
            PaymentResponse fromXmlResponse = new PaymentResponse().FromXml(Resources.payment_response_sample_unknown_element);
            sx.checkUnmarshalledPaymentResponse(fromXmlResponse);
        }

        /**
         * Test expected {@link RealexException} when unmarshalling invalid xml.
         */
        [TestMethod, ExpectedException(typeof(RealexException))]
        public void fromXmlErrorTest() {
            //Try to unmarshal invalid XML
            XmlUtils.FromXml<PaymentRequest>("<xml>test</xml>");
        }

        /**
         * Tests conversion of {@link ThreeDSecureRequest} to and from XML using the helper methods.
         */
        [TestMethod]
        public void ThreeDSecureRequestXmlHelpersTest() {

            Card card = new Card()
                    .AddExpiryDate(sx.CARD_EXPIRY_DATE)
                    .AddNumber(sx.CARD_NUMBER)
                    .AddType(CardType.VISA)
                    .AddCardHolderName(sx.CARD_HOLDER_NAME)
                    .AddIssueNumber(sx.CARD_ISSUE_NUMBER)
                    .AddCvn(sx.CARD_CVN_NUMBER)
                    .AddCvnPresenceIndicator(sx.CARD_CVN_PRESENCE);

            ThreeDSecureRequest request = new ThreeDSecureRequest()
                    .AddAccount(sx.ACCOUNT)
                    .AddMerchantId(sx.MERCHANT_ID)
                    .AddType(ThreeDSecureType.VERIFY_ENROLLED)
                    .AddAmount(sx.AMOUNT)
                    .AddCurrency(sx.CURRENCY)
                    .AddCard(card)
                    .AddTimestamp(sx.TIMESTAMP)
                    .AddOrderId(sx.ORDER_ID)
                    .AddHash(sx.THREE_D_SECURE_VERIFY_ENROLLED_REQUEST_HASH);

            //convert to XML
            string xml = request.ToXml();

            //Convert from XML back to PaymentRequest
            ThreeDSecureRequest fromXmlRequest = new ThreeDSecureRequest().FromXml(xml);
            sx.checkUnmarshalledVerifyEnrolledRequest(fromXmlRequest);
        }

        /**
         * Tests conversion of {@link ThreeDSecureRequest} to and from XML using the helper methods with no enums.
         */
        [TestMethod]
        public void ThreeDSecureRequestXmlHelpersNoEnumsTest() {

            Card card = new Card()
                    .AddExpiryDate(sx.CARD_EXPIRY_DATE)
                    .AddNumber(sx.CARD_NUMBER)
                    .AddType(CardType.VISA)
                    .AddCardHolderName(sx.CARD_HOLDER_NAME)
                    .AddIssueNumber(sx.CARD_ISSUE_NUMBER)
                    .AddCvn(sx.CARD_CVN_NUMBER)
                    .AddCvnPresenceIndicator(sx.CARD_CVN_PRESENCE);

            ThreeDSecureRequest request = new ThreeDSecureRequest()
                    .AddAccount(sx.ACCOUNT)
                    .AddMerchantId(sx.MERCHANT_ID)
                    .AddType(ThreeDSecureType.VERIFY_ENROLLED)
                    .AddAmount(sx.AMOUNT)
                    .AddCurrency(sx.CURRENCY)
                    .AddCard(card)
                    .AddTimestamp(sx.TIMESTAMP)
                    .AddOrderId(sx.ORDER_ID)
                    .AddHash(sx.THREE_D_SECURE_VERIFY_ENROLLED_REQUEST_HASH);

            //convert to XML
            string xml = request.ToXml();

            //Convert from XML back to PaymentRequest
            ThreeDSecureRequest fromXmlRequest = new ThreeDSecureRequest().FromXml(xml);
            sx.checkUnmarshalledVerifyEnrolledRequest(fromXmlRequest);
        }

        /**
         * Tests conversion of {@link ThreeDSecureRequest} verify enrolled to and from XML using setters.
         */
        [TestMethod]
        public void ThreeDSecureEnrolledRequestXmlWithSettersTest() {

            Card card = new Card();
            card.ExpiryDate = sx.CARD_EXPIRY_DATE;
            card.Number = sx.CARD_NUMBER;
            card.Type = CardType.VISA;
            card.CardHolderName = sx.CARD_HOLDER_NAME;
            card.IssueNumber = sx.CARD_ISSUE_NUMBER;

            Cvn cvn = new Cvn();
            cvn.Number = sx.CARD_CVN_NUMBER;
            cvn.PresenceIndicator = sx.CARD_CVN_PRESENCE;
            card.Cvn = cvn;

            ThreeDSecureRequest request = new ThreeDSecureRequest();
            request.Account = sx.ACCOUNT;
            request.MerchantId = sx.MERCHANT_ID;

            RxpAmount amount = new RxpAmount();
            amount.Amount = sx.AMOUNT;
            amount.Currency = sx.CURRENCY;
            request.Amount = amount;

            request.Card = card;
            request.Timestamp = sx.TIMESTAMP;
            request.OrderId = sx.ORDER_ID;
            request.Hash = sx.THREE_D_SECURE_VERIFY_ENROLLED_REQUEST_HASH;
            request.Type = ThreeDSecureType.VERIFY_ENROLLED;

            //convert to XML
            string xml = request.ToXml();

            //Convert from XML back to PaymentRequest
            ThreeDSecureRequest fromXmlRequest = new ThreeDSecureRequest().FromXml(xml);
            sx.checkUnmarshalledVerifyEnrolledRequest(fromXmlRequest);
        }

        /**
         * Tests conversion of {@link ThreeDSecureRequest} verify sig to and from XML using setters.
         */
        [TestMethod]
        public void ThreeDSecureSigRequestXmlWithSettersTest() {

            Card card = new Card();
            card.ExpiryDate = sx.CARD_EXPIRY_DATE;
            card.Number = sx.CARD_NUMBER;
            card.Type = CardType.VISA;
            card.CardHolderName = sx.CARD_HOLDER_NAME;
            card.IssueNumber = sx.CARD_ISSUE_NUMBER;

            Cvn cvn = new Cvn();
            cvn.Number = sx.CARD_CVN_NUMBER;
            cvn.PresenceIndicator = sx.CARD_CVN_PRESENCE;
            card.Cvn = cvn;

            ThreeDSecureRequest request = new ThreeDSecureRequest();
            request.Account = sx.ACCOUNT;
            request.MerchantId = sx.MERCHANT_ID;

            RxpAmount amount = new RxpAmount();
            amount.Amount = sx.AMOUNT;
            amount.Currency = sx.CURRENCY;
            request.Amount = amount;

            request.Card = card;
            request.Timestamp = sx.TIMESTAMP;
            request.OrderId = sx.ORDER_ID;
            request.Pares = sx.THREE_D_SECURE_PARES;
            request.Hash = sx.THREE_D_SECURE_VERIFY_SIG_REQUEST_HASH;
            request.Type = ThreeDSecureType.VERIFY_SIG;

            //convert to XML
            string xml = request.ToXml();

            //Convert from XML back to PaymentRequest
            ThreeDSecureRequest fromXmlRequest = new ThreeDSecureRequest().FromXml(xml);
            sx.checkUnmarshalledVerifySigRequest(fromXmlRequest);
        }

        /**
         * Tests conversion of {@link ThreeDSecureResponse} from XML file for verify enrolled
         */
        [TestMethod]
        public void ThreeDSecureEnrolledResponseXmlFromFileTest() {
            //unmarshal back to re
            ThreeDSecureResponse fromXmlResponse = new ThreeDSecureResponse().FromXml(Resources._3ds_verify_enrolled_response_sample);
            sx.checkUnmarshalledThreeDSecureEnrolledResponse(fromXmlResponse);
        }

        /**
         * Tests conversion of {@link ThreeDSecureResponse} from XML file for verify sig 
         */
        [TestMethod]
        public void ThreeDSecureSigResponseXmlFromFileTest() {
            //unmarshal back to response
            ThreeDSecureResponse fromXmlResponse = new ThreeDSecureResponse().FromXml(Resources._3ds_verify_sig_response_sample);
            sx.checkUnmarshalledThreeDSecureSigResponse(fromXmlResponse);
        }

        /**
         * Tests conversion of {@link ThreeDSecureRequest} from XML file for verify enrolled.
         */
        [TestMethod]
        public void ThreeDSecureRequestEnrolledXmlFromFileTest() {
            //Convert from XML back to PaymentRequest
            ThreeDSecureRequest fromXmlRequest = new ThreeDSecureRequest().FromXml(Resources._3ds_verify_enrolled_request_sample);
            sx.checkUnmarshalledVerifyEnrolledRequest(fromXmlRequest);
        }

        /**
         * Tests conversion of {@link ThreeDSecureRequest} from XML file for verify sig.
         */
        [TestMethod]
        public void ThreeDSecureRequestSigXmlFromFileTest() {
            //Convert from XML back to PaymentRequest
            ThreeDSecureRequest fromXmlRequest = new ThreeDSecureRequest().FromXml(Resources._3ds_verify_sig_request_sample);
            sx.checkUnmarshalledVerifySigRequest(fromXmlRequest);
        }

        /**
         * Test expected {@link RealexException} when unmarshalling invalid xml.
         */
        [TestMethod, ExpectedException(typeof(RealexException))]
        public void ThreeDSecureFromXmlErrorTest() {
            //Try to unmarshal invalid XML
            XmlUtils.FromXml<ThreeDSecureRequest>("<xml>test</xml>");
        }

        /**
         * Tests conversion of {@link PaymentRequest} from XML file for mobile-auth payment types.
         */
        [TestMethod]
        public void PaymentRequestXmlFromFileMobileAuthTest() {
            //Convert from XML back to PaymentRequest
            PaymentRequest fromXmlRequest = new PaymentRequest().FromXml(Resources.auth_mobile_payment_request_sample);
            sx.checkUnmarshalledMobileAuthPaymentRequest(fromXmlRequest);
        }

        /**
         * Tests conversion of {@link PaymentRequest} from XML file for settle payment types.
         */
        [TestMethod]
        public void PaymentRequestXmlFromFileSettleTest() {
            //Convert from XML back to PaymentRequest
            PaymentRequest fromXmlRequest = new PaymentRequest().FromXml(Resources.settle_payment_request_sample);
            sx.checkUnmarshalledSettlePaymentRequest(fromXmlRequest);
        }

        /**
         * Tests conversion of {@link PaymentRequest} from XML file for void Payment types.
         */
        [TestMethod]
        public void PaymentRequestXmlFromFileVoidTest() {
            //Convert from XML back to PaymentRequest
            PaymentRequest fromXmlRequest = new PaymentRequest().FromXml(Resources.void_payment_request_sample);
            sx.checkUnmarshalledVoidPaymentRequest(fromXmlRequest);
        }

        /**
         * Tests conversion of {@link PaymentRequest} from XML file for rebate payment types.
         */
        [TestMethod]
        public void PaymentRequestXmlFromFileRebateTest() {
            //Convert from XML back to PaymentRequest
            PaymentRequest fromXmlRequest = new PaymentRequest().FromXml(Resources.rebate_payment_request_sample);
            sx.checkUnmarshalledRebatePaymentRequest(fromXmlRequest);
        }

        /**
         * Tests conversion of {@link PaymentRequest} from XML file for OTB payment types.
         */
        [TestMethod]
        public void PaymentRequestXmlFromFileOtbTest() {
            //Convert from XML back to PaymentRequest
            PaymentRequest fromXmlRequest = new PaymentRequest().FromXml(Resources.otb_payment_request_sample);
            sx.checkUnmarshalledOtbPaymentRequest(fromXmlRequest);
        }

        /**
         * Tests conversion of {@link PaymentRequest} from XML file for credit payment types.
         */
        [TestMethod]
        public void PaymentRequestXmlFromFileCreditTest() {
            //Convert from XML back to PaymentRequest
            PaymentRequest fromXmlRequest = new PaymentRequest().FromXml(Resources.credit_payment_request_sample);
            sx.checkUnmarshalledCreditPaymentRequest(fromXmlRequest);
        }

        /**
         * Tests conversion of {@link PaymentRequest} from XML file for hold payment types.
         */
        [TestMethod]
        public void PaymentRequestXmlFromFileHoldTest() {
            //Convert from XML back to PaymentRequest
            PaymentRequest fromXmlRequest = new PaymentRequest().FromXml(Resources.hold_payment_request_sample);
            sx.checkUnmarshalledHoldPaymentRequest(fromXmlRequest);
        }

        /**
         * Tests conversion of {@link PaymentRequest} from XML file for release payment types.
         */
        [TestMethod]
        public void PaymentRequestXmlFromFileReleaseTest() {
            //Convert from XML back to PaymentRequest
            PaymentRequest fromXmlRequest = new PaymentRequest().FromXml(Resources.release_payment_request_sample);
            sx.checkUnmarshalledReleasePaymentRequest(fromXmlRequest);
        }
    }
}
