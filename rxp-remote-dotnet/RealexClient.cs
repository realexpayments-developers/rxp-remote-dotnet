using System.Net.Http;
using RealexPayments.Remote.SDK.Http;
using RealexPayments.Remote.SDK.Domain;
using NLog;
using RealexPayments.Remote.SDK.Utils;

namespace RealexPayments.Remote.SDK {
    public class RealexClient {
        public string Secret { get; set; }
        public HttpClient HttpClient { get; set; }
        public HttpConfiguration HttpConfiguration { get; set; }

        // TODO: Logging Implementation
        private readonly Logger LOGGER = LogManager.GetCurrentClassLogger();

        public RealexClient(string secret, HttpConfiguration httpConfiguration = null, HttpClient httpClient = null) {
            Secret = secret;
            HttpConfiguration = httpConfiguration ?? new HttpConfiguration();
            HttpClient = httpClient ?? HttpUtils.GetDefaultClient(httpConfiguration);
        }

        public U Send<T, U>(IRequest<T, U> request) where U : IResponse<U> {
            LOGGER.Info("Sending XML request to Realex.");

            //generate any required defaults e.g. order ID, time stamp, hash
            request.GenerateDefaults(Secret);

            //convert request to XML
            LOGGER.Debug("Marshalling request object to XML.");
            string xmlRequest = request.ToXml();

            //send request to Realex.
            string xmlResult = HttpUtils.SendMessage(xmlRequest, HttpClient, HttpConfiguration);

            //log the response
            LOGGER.Trace("Response XML from server: {}", xmlResult);

            //convert XML to response object
            LOGGER.Debug("Unmarshalling XML to response object.");
            U response = request.ResponseFromXml(xmlResult);

            //throw exception if short response returned (indicating request could not be processed).
            if (ResponseUtils.IsBasicResponse(response.Result)) {
                LOGGER.Error("Error response received from Realex with code {0} and message {1}.", response.Result, response.Message);
                throw new RealexServerException(response.Timestamp, response.OrderId, response.Result, response.Message);
            }

            //validate response hash
            LOGGER.Debug("Verifying response hash.");
            if (!response.IsHashValid(Secret)) {
                //Hash invalid. Throw exception.
                LOGGER.Error("Response hash is invalid. This response's validity cannot be verified.");
                throw new RealexException("Response hash is invalid. This response's validity cannot be verified.");
            }

            return response;
        }
    }
}
