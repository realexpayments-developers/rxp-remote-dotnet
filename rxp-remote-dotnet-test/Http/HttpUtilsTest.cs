using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Net;
using System.IO;

namespace RealexPayments.Remote.SDK.Http {
    [TestClass]
    public class HttpUtilsTest {
        FakeResponseHandler _handler;

        [TestInitialize]
        public void Init() {
            _handler = new FakeResponseHandler();
        }

        [TestMethod]
        public void SendMessageSuccessTest() {
            string endpoint = "https://some-test-endpoint";
            string xml = "<element>test response xml</element>";
            bool onlyAllowHttps = true;

            _handler.AddFakeResponse(endpoint, new HttpResponseMessage(HttpStatusCode.OK) {
                Content = new StringContent(xml),
                ReasonPhrase = string.Empty
            });

            var httpConfiguration = new HttpConfiguration { Endpoint = endpoint, OnlyAllowHttps = onlyAllowHttps };
            var httpClient = new HttpClient(_handler);

            var response = HttpUtils.SendMessage(xml, httpClient, httpConfiguration);
            Assert.AreEqual(xml, response);
        }

        [TestMethod, ExpectedException(typeof(RealexException), "Unexpected HTTP Status Code []")]
        public void SendMessageFailureTest() {
            string endpoint = "https://some-test-endpoint";
            string xml = "<element>test response xml</element>";
            bool onlyAllowHttps = true;

            _handler.AddFakeResponse(endpoint, new HttpResponseMessage(HttpStatusCode.BadRequest) {
                ReasonPhrase = string.Empty
            });

            try {
                var httpConfiguration = new HttpConfiguration { Endpoint = endpoint, OnlyAllowHttps = onlyAllowHttps };
                var httpClient = new HttpClient(_handler);

                var response = HttpUtils.SendMessage(xml, httpClient, httpConfiguration);
                Assert.AreEqual(xml, response);
            }
            catch (IOException exc) {
                Assert.Fail("Unexpected exception: " + exc.Message);
            }
        }

        [TestMethod, ExpectedException(typeof(RealexException), "Protocol must be https")]
        public void SendMessageFailureHttpNotAllowedTest() {
            string endpoint = "http://some-test-endpoint";
            string xml = "<element>test response xml</element>";
            bool onlyAllowHttps = true;

            _handler.AddFakeResponse(endpoint, new HttpResponseMessage(HttpStatusCode.OK) {
                Content = new StringContent(xml),
                ReasonPhrase = string.Empty
            });

            try {
                var httpConfiguration = new HttpConfiguration { Endpoint = endpoint, OnlyAllowHttps = onlyAllowHttps };
                var httpClient = new HttpClient(_handler);

                var response = HttpUtils.SendMessage(xml, httpClient, httpConfiguration);
            }
            catch (IOException exc) {
                Assert.Fail("Unexpected exception: " + exc.Message);
            }
        }
    }
}
