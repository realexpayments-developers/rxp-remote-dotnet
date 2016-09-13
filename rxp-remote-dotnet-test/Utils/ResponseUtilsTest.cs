using Microsoft.VisualStudio.TestTools.UnitTesting;
using RealexPayments.Remote.SDK.Domain.Payment;

namespace RealexPayments.Remote.SDK.Utils {
    [TestClass]
    public class ResponseUtilsTest {
        [TestMethod]
        public void IsBasicResponseTest() {
            //test success response
            Assert.IsFalse(ResponseUtils.IsBasicResponse(ResponseUtils.RESULT_CODE_SUCCESS));

            //test 1xx code
            Assert.IsFalse(ResponseUtils.IsBasicResponse("100"));

            //test 2xx code
            Assert.IsFalse(ResponseUtils.IsBasicResponse("200"));

            //test 3xx code
            Assert.IsTrue(ResponseUtils.IsBasicResponse("300"));

            //test 5xx code
            Assert.IsTrue(ResponseUtils.IsBasicResponse("500"));
        }

        [TestMethod]
        public void IsSuccessTest() {
            PaymentResponse response = new PaymentResponse();

            //test success
            response.Result = ResponseUtils.RESULT_CODE_SUCCESS;
            Assert.IsTrue(ResponseUtils.IsSuccess(response));

            //test failure
            response.Result = "101";
            Assert.IsFalse(ResponseUtils.IsSuccess(response));
        }
    }
}
