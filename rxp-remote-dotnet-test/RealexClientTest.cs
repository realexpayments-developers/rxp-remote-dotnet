using System.Net;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RealexPayments.Remote.SDK.Domain;
using RealexPayments.Remote.SDK.Domain.Payment;
using RealexPayments.Remote.SDK.Domain.ThreeDSecure;
using RealexPayments.Remote.SDK.Http;
using RealexPayments.Remote.SDK.Properties;
using RealexPayments.Remote.SDK.Utils;

namespace RealexPayments.Remote.SDK {
    [TestClass]
    public class RealexClientTest {
        RealexClient _client;
        HttpConfiguration _config;
        FakeResponseHandler _handler;

        [TestInitialize]
        public void Init() {
            _config = new HttpConfiguration {
                Endpoint = "https://test.realexpayments.com/epage-remote.cgi"
            };
            _client = new RealexClient("Po8lRRT67a", _config);
            _handler = new FakeResponseHandler();
        }

        /**
	 * Test sending a payment request and receiving a payment response. 
	 */
        [TestMethod]
        public void SendTest() {
            //get sample response XML
            PaymentResponse fromXmlResponse = new PaymentResponse().FromXml(Resources.payment_response_sample);

            //mock HttpResponse
            _handler.AddFakeResponse(HttpConfiguration.DEFAULT_ENDPOINT, new HttpResponseMessage(HttpStatusCode.OK) {
                Content = new StringContent(fromXmlResponse.ToXml())
            });

            //create empty request 
            PaymentRequest request = new PaymentRequest();

            //create configuration
            HttpConfiguration httpConfiguration = new HttpConfiguration();
            httpConfiguration.OnlyAllowHttps = false;

            //mock HttpClient instance
            HttpClient httpClient = new HttpClient(_handler);

            //execute send on client
            RealexClient realexClient = new RealexClient(SampleXmlValidationUtils.SECRET, httpConfiguration, httpClient);
            PaymentResponse response = realexClient.Send(request);

            //validate response
            SampleXmlValidationUtils.checkUnmarshalledPaymentResponse(response);
        }

        /**
         * Test sending a payment request and receiving a payment response error. 
         */
        [TestMethod]
        public void SendWithShortErrorResponseTest() {
            //get sample response XML
            PaymentResponse fromXmlResponse = new PaymentResponse().FromXml(Resources.payment_response_basic_error_sample);

            //mock HttpResponse
            _handler.AddFakeResponse(HttpConfiguration.DEFAULT_ENDPOINT, new HttpResponseMessage(HttpStatusCode.OK) {
                Content = new StringContent(fromXmlResponse.ToXml())
            });

            //create empty request 
            PaymentRequest request = new PaymentRequest();

            //create configuration
            HttpConfiguration httpConfiguration = new HttpConfiguration();
            httpConfiguration.OnlyAllowHttps = false;

            //mock HttpCLient instance
            HttpClient httpClientMock = new HttpClient(_handler);
            //execute send on client
            RealexClient realexClient = new RealexClient(SampleXmlValidationUtils.SECRET, httpConfiguration, httpClientMock);

            try {
                realexClient.Send(request);
                Assert.Fail("RealexException should have been thrown before this point.");
            }
            catch (RealexServerException ex) {
                //validate error
                SampleXmlValidationUtils.checkBasicResponseError(ex);
            }
        }

        /**
         * Test sending a payment request and receiving a payment response error. 
         */
        [TestMethod]
        public void SendWithLongErrorResponseTest() {
            //get sample response XML
            PaymentResponse fromXmlResponse = new PaymentResponse().FromXml(Resources.payment_response_full_error_sample);

            //mock HttpResponse
            _handler.AddFakeResponse(HttpConfiguration.DEFAULT_ENDPOINT, new HttpResponseMessage(HttpStatusCode.OK) {
                Content = new StringContent(fromXmlResponse.ToXml())
            });

            //create empty request 
            PaymentRequest request = new PaymentRequest();

            //create configuration
            HttpConfiguration httpConfiguration = new HttpConfiguration();
            httpConfiguration.OnlyAllowHttps = false;

            //mock HttpCLient instance
            HttpClient httpClientMock = new HttpClient(_handler);

            //execute send on client
            RealexClient realexClient = new RealexClient(SampleXmlValidationUtils.SECRET, httpConfiguration, httpClientMock);

            PaymentResponse response = realexClient.Send(request);

            SampleXmlValidationUtils.checkFullResponseError(response);
        }

        /**
         * Test sending a payment request and receiving a payment response error. 
         */
        [TestMethod]
        public void SendWithErrorResponseInvalidCodeTest() {
            //get sample response XML
            PaymentResponse fromXmlResponse = new PaymentResponse().FromXml(Resources.payment_response_basic_error_sample);
            fromXmlResponse.Result = "invalid";

            //mock HttpResponse
            _handler.AddFakeResponse(HttpConfiguration.DEFAULT_ENDPOINT, new HttpResponseMessage(HttpStatusCode.OK) {
                Content = new StringContent(fromXmlResponse.ToXml())
            });

            //create empty request 
            PaymentRequest request = new PaymentRequest();

            //create configuration
            HttpConfiguration httpConfiguration = new HttpConfiguration();

            //mock HttpCLient instance
            HttpClient httpClientMock = new HttpClient(_handler);


            //execute send on client
            RealexClient realexClient = new RealexClient(SampleXmlValidationUtils.SECRET, httpConfiguration, httpClientMock);

            bool correctExceptionThrown = false;

            try {
                realexClient.Send(request);
                Assert.Fail("RealexException should have been thrown before this point.");
            }
            catch (RealexServerException) {
                Assert.Fail("Incorrect exception thrown. Expected RealexException as result code is invalid.");
            }
            catch (RealexException) {
                correctExceptionThrown = true;
            }

            Assert.IsTrue(correctExceptionThrown, "Incorrect exception thrown.");
        }

        /**
         * Test receiving a response which has an invalid hash. 
         */
        [TestMethod, ExpectedException(typeof(RealexException))]
        public void SendInvalidResponseHashTest() {
            //get sample response XML and add invlid hash
            PaymentResponse fromXmlResponse = new PaymentResponse().FromXml(Resources.payment_response_sample);
            fromXmlResponse.Hash = "invalid hash";

            //mock HttpResponse
            _handler.AddFakeResponse(HttpConfiguration.DEFAULT_ENDPOINT, new HttpResponseMessage(HttpStatusCode.OK) {
                Content = new StringContent(fromXmlResponse.ToXml())
            });

            //create empty request 
            PaymentRequest request = new PaymentRequest();

            //create configuration
            HttpConfiguration httpConfiguration = new HttpConfiguration();

            //mock HttpCLient instance
            HttpClient httpClientMock = new HttpClient(_handler);


            //execute send on client
            RealexClient realexClient = new RealexClient(SampleXmlValidationUtils.SECRET, httpConfiguration, httpClientMock);
            realexClient.Send(request);

            //shouldn't get this far
            Assert.Fail("RealexException should have been thrown before this point.");
        }

        /**
         * Test sending a ThreeDSecure Verify Enrolled request and receiving a ThreeDSecure Verify Enrolled response. 
         */
        [TestMethod]
        public void SendThreeDSecureVerifyEnrolledTest() {
            //get sample response XML
            ThreeDSecureResponse fromXmlResponse = new ThreeDSecureResponse().FromXml(Resources._3ds_verify_enrolled_response_sample);

            //mock HttpResponse
            _handler.AddFakeResponse(HttpConfiguration.DEFAULT_ENDPOINT, new HttpResponseMessage(HttpStatusCode.OK) {
                Content = new StringContent(fromXmlResponse.ToXml())
            });

            //create empty request 
            ThreeDSecureRequest request = new ThreeDSecureRequest();

            //create configuration
            HttpConfiguration httpConfiguration = new HttpConfiguration();
            httpConfiguration.OnlyAllowHttps = false;

            //mock HttpClient instance
            HttpClient httpClientMock = new HttpClient(_handler);


            //execute send on client
            RealexClient realexClient = new RealexClient(SampleXmlValidationUtils.SECRET, httpConfiguration, httpClientMock);
            ThreeDSecureResponse response = realexClient.Send(request);

            //validate response
            SampleXmlValidationUtils.checkUnmarshalledThreeDSecureEnrolledResponse(response);
        }

        /**
         * Test receiving a response which has an invalid hash. 
         */
        [TestMethod, ExpectedException(typeof(RealexException))]
        public void SendThreeDSecureInvalidResponseHashTest() {
            //get sample response XML
            ThreeDSecureResponse fromXmlResponse = new ThreeDSecureResponse().FromXml(Resources._3ds_verify_enrolled_response_sample);
            fromXmlResponse.Hash = "invalid hash";

            //mock HttpResponse
            _handler.AddFakeResponse(HttpConfiguration.DEFAULT_ENDPOINT, new HttpResponseMessage(HttpStatusCode.OK) {
                Content = new StringContent(fromXmlResponse.ToXml())
            });

            //create empty request 
            ThreeDSecureRequest request = new ThreeDSecureRequest();

            //create configuration
            HttpConfiguration httpConfiguration = new HttpConfiguration();
            httpConfiguration.OnlyAllowHttps = false;

            //mock HttpClient instance
            HttpClient httpClientMock = new HttpClient(_handler);
            
            //execute send on client
            RealexClient realexClient = new RealexClient(SampleXmlValidationUtils.SECRET, httpConfiguration, httpClientMock);
            realexClient.Send(request);

            //shouldn't get this far
            Assert.Fail("RealexException should have been thrown before this point.");
        }

        //[TestMethod]
        //public void AuthSuccessTest() {
        //    var request = new PaymentRequest()
        //        .AddAccount("internet")
        //        .AddMerchantId("realexsandbox")
        //        .AddType(PaymentType.AUTH)
        //        .AddAmount(100)
        //        .AddCurrency("GBP")
        //        .AddCard(new Card() {
        //            Number = "4263970000005262",
        //            ExpiryDate = "0119",
        //            Type = CardType.VISA,
        //            CardHolderName = "Joe Smith",
        //            Cvn = new Cvn {
        //                Number = "123",
        //                PresenceIndicator = PresenceIndicator.CVN_PRESENT
        //            }
        //        })
        //        .AddAutoSettle(AutoSettleFlag.TRUE);

        //    var response = _client.Send(request);
        //    Assert.IsNotNull(response);
        //    Assert.IsTrue(response.IsSuccess());
        //}

        //[TestMethod]
        //public void OtbSuccessTest() {
        //    var request = new PaymentRequest()
        //        .AddAccount("internet")
        //        .AddMerchantId("realexsandbox")
        //        .AddType(PaymentType.OTB)
        //        .AddCard(new Card {
        //            Number = "4263970000005262",
        //            ExpiryDate = "0119",
        //            Type = CardType.VISA,
        //            CardHolderName = "Joe Smith",
        //            Cvn = new Cvn {
        //                Number = "123",
        //                PresenceIndicator = PresenceIndicator.CVN_PRESENT
        //            }
        //        })
        //        .AddComment("Mobile Channel")
        //        .AddComment("Validation Transaction");

        //    var response = _client.Send(request);
        //    Assert.IsNotNull(response);
        //    Assert.IsTrue(response.IsSuccess());
        //}

        //[TestMethod, Ignore]
        //public void ApplePaySuccessTest() {
        //    var request = new PaymentRequest()
        //        .AddType(PaymentType.AUTH_MOBILE)
        //        .AddMerchantId("realexsandbox")
        //        .AddAccount("internet")
        //        .AddMobile("apple-pay")
        //        .AddToken("{'version':'EC_v1','data':'Ft+dvMNzlcy6WNB+zerKtkh/RWW4RWW4yXIRgmM3WC/FYEC6Z+OJEzir2sDyzDkjIUJ0TFCQd/QAAAAAAAA==','header':{'ephemeralPublicKey':'MFkwEwYHKoZIzj0CAQYIKoZIzj0DAQcDQgAEWdNhNAHy9kO2Kol33kIh7k6wh6E/lxriM46MR1FUrn7SHugprkaeFmWKZPgGpWgZ+telY/G1+YSoaCbR5YSoaCbR57bdGA==','transactionId':'fd88874954acdb299c285f95a3202ad1f330d3fd4ebc22a864398684198644c3','publicKeyHash':'h7WnNVz2gmpTSkHqETOWsskFPLSj31e3sPTS2cBxgrk='}}")
        //        .AddAutoSettle(AutoSettleFlag.TRUE)
        //        .AddComment("Mobile Channel")
        //        .AddComment("Down Transaction");

        //    var response = _client.Send(request);
        //    Assert.IsNotNull(response);
        //    Assert.IsTrue(response.IsSuccess());
        //}

        //[TestMethod, Ignore]
        //public void RefundSuccessTest() {
        //    var request = new PaymentRequest()
        //        .AddMerchantId("realexsandbox")
        //        .AddAccount("inertnet")
        //        .AddType(PaymentType.CREDIT)
        //        .AddAmount(1001)
        //        .AddCurrency("EUR")
        //        .AddCard(new Card {
        //            Type = CardType.VISA,
        //            CardHolderName = "James Mason",
        //            ExpiryDate = "0519",
        //            Number = "4263970000005262"
        //        })
        //        .AddComment("Returned Item")
        //        .AddComment("Break in transit");

        //    _client = new RealexClient("refund", _config);
        //    var response = _client.Send(request);
        //    Assert.IsNotNull(response);
        //    Assert.IsTrue(response.IsSuccess());
        //}

        //[TestMethod, Ignore]
        //public void ManualSuccessTest() {
        //    var request = new PaymentRequest()
        //        .AddType(PaymentType.MANUAL)
        //        .AddMerchantId("realexsandbox")
        //        .AddAccount("internet")
        //        .AddChannel("MOTO")
        //        .AddAuthCode("12345")
        //        .AddAmount(1001)
        //        .AddCurrency("EUR")
        //        .AddCard(new Card() {
        //            Number = "4263970000005262",
        //            ExpiryDate = "0519",
        //            CardHolderName = "Philip Marlowe",
        //            Type = CardType.VISA
        //        })
        //        .AddAutoSettle(AutoSettleFlag.TRUE)
        //        .AddComment("Auth Centre")
        //        .AddComment("Down Payment");

        //    var response = _client.Send(request);
        //    Assert.IsNotNull(response);
        //    Assert.IsTrue(response.IsSuccess());
        //}
    }
}
