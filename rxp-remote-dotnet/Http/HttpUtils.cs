using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace RealexPayments.Remote.SDK.Http {
    /// <summary>
    /// HTTP Utils class for dealing with HTTP and actual message sending.
    /// </summary>
    /// <author>russelleverett</author>
    public class HttpUtils {
        private const string HTTPS_PROTOCOL = "https";

        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Get a default HttpClient based on the HttpConfiguration object. If required the defaults can 
        /// be altered to meet the requirements of the SDK user.The default client does not use connection
        /// pooling and does not reuse connections.Timeouts for connection and socket are taken from the
        /// { @link HttpConfiguration} object.
        /// </summary>
        /// <param name="httpConfiguration"></param>
        /// <returns>CloseableHttpClient</returns>
        public static HttpClient GetDefaultClient(HttpConfiguration httpConfiguration) {
            var client = new HttpClient() {
                Timeout = TimeSpan.FromMilliseconds(httpConfiguration.Timeout)
            };
            return client;
        }

        /// <summary>
        /// Perform the actual send of the message, according to the HttpConfiguration, and get the response. 
        /// This will also check if only HTTPS is allowed, based on the {@link HttpConfiguration}, and will
        /// throw a {@link RealexException} if HTTP is used when only HTTPS is allowed.A {@link RealexException} 
        /// is also thrown if the response from Realex is not success(ie. if it's not 200 status code). 
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="httpClient"></param>
        /// <param name="httpConfiguration"></param>
        /// <returns>string</returns>
        public static string SendMessage(string xml, HttpClient httpClient, HttpConfiguration httpConfiguration) {
            logger.Debug("Setting endpoint of: " + httpConfiguration.Endpoint);
            HttpRequestMessage httpPost = new HttpRequestMessage(HttpMethod.Post, httpConfiguration.Endpoint);

            HttpResponseMessage response = null;

            if (httpConfiguration.OnlyAllowHttps) {
                string scheme = httpPost.RequestUri.Scheme;
                if (scheme.ToLower() != HTTPS_PROTOCOL) {
                    logger.Error("Protocol must be " + HTTPS_PROTOCOL);
                    throw new RealexException("Protocol must be " + HTTPS_PROTOCOL);
                }
            }
            else {
                logger.Warn("Allowed send message over HTTP. This should NEVER be allowed in a production environment.");
            }

            try {
                logger.Debug("Setting entity in POST message.");
                httpPost.Content = new StringContent(xml, Encoding.UTF8, "application/xml");

                logger.Debug("Executing HTTP Post message to: " + httpPost.RequestUri);
                response = httpClient.SendAsync(httpPost).Result;

                logger.Debug("Checking the HTTP response status code.");
                var statusCode = response.StatusCode;
                if (statusCode != HttpStatusCode.OK){
                    throw new RealexException("Unexpected http status code [" + statusCode + "]");
                }

                logger.Debug("Converting HTTP entity (the xml response) back into a string.");
                string xmlResponse = response.Content.ReadAsStringAsync().Result;
                return xmlResponse;
            }
            catch (Exception exc) {
                // Also catches ClientProtocolException (from httpClient.execute()) and UnsupportedEncodingException (from response.getEntity()
                logger.Error(exc.Message, "Exception communicating with Realex.");
                throw new RealexException("Exception communicating with Realex.", exc);
            }
            finally {
            }
        }
    }
}
