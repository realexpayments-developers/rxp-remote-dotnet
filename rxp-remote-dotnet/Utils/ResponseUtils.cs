using System;
using NLog;
using RealexPayments.Remote.SDK.Domain;

namespace RealexPayments.Remote.SDK.Utils {
    public class ResponseUtils {
        public const string RESULT_CODE_SUCCESS = "00";
        public const int RESULT_CODE_PREFIX_ERROR_RESPONSE_START = 3;
        private static readonly Logger LOGGER = LogManager.GetCurrentClassLogger();

        public static bool IsBasicResponse(string result) {
            var inErrorRange = false;
            try {
                int initialNumber = int.Parse(result.Substring(0, 1));
                inErrorRange = initialNumber >= RESULT_CODE_PREFIX_ERROR_RESPONSE_START;
            }
            catch (Exception exc) {
                LOGGER.Error("Error parsing result {}", result, exc);
                throw new RealexException("Error parsing result.", exc);
            }

            return inErrorRange;
        }

        public static bool IsSuccess<T>(IResponse<T> response) {
            return response.Result == RESULT_CODE_SUCCESS;
        }
    }
}
