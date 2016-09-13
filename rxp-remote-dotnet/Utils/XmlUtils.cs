using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using NLog;
using RealexPayments.Remote.SDK.Domain.Payment;
using RealexPayments.Remote.SDK.Domain.ThreeDSecure;

namespace RealexPayments.Remote.SDK.Utils {
    public class XmlUtils {
        private static Dictionary<string, XmlSerializer> CONTEXT_MAP = new Dictionary<string, XmlSerializer>();
        private static XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();

        private static readonly Logger LOGGER = LogManager.GetCurrentClassLogger();

        static XmlUtils() {
            try {
                var paymentReqest = new XmlSerializer(typeof(PaymentRequest));
                var paymentResponse = new XmlSerializer(typeof(PaymentResponse));
                var threeDSecureRequest = new XmlSerializer(typeof(ThreeDSecureRequest));
                var threeDSecureResponse = new XmlSerializer(typeof(ThreeDSecureResponse));

                CONTEXT_MAP.Add(typeof(PaymentRequest).Name, paymentReqest);
                CONTEXT_MAP.Add(typeof(ThreeDSecureRequest).Name, threeDSecureRequest);
                CONTEXT_MAP.Add(typeof(PaymentResponse).Name, paymentResponse);
                CONTEXT_MAP.Add(typeof(ThreeDSecureResponse).Name, threeDSecureResponse);

                namespaces.Add(string.Empty, string.Empty);
            }
            catch (Exception exc) {
                LOGGER.Error(exc, "Error initialising XmlSerializers");
                throw new RealexException("Error initialising XmlSerializers", exc);
            }
        }

        public static string ToXml<T>(T obj) {
            LOGGER.Debug("Marshalling domain object to XML.");

            StringWriter result = new Utf8StringWriter();
            try {
                var marshaller = CONTEXT_MAP[typeof(T).Name];
                marshaller.Serialize(result, obj, namespaces);
            }
            catch (Exception exc) {
                LOGGER.Error(exc, "Error marshalling to XML");
                throw new RealexException("Error marshalling to XML", exc);
            }

            return result.ToString();
        }

        public static T FromXml<T>(string xml) {
            LOGGER.Debug("Unmarshalling XML to domain object.");

            object response = null;

            try {
                var  marshaller = CONTEXT_MAP[typeof(T).Name];
                response = marshaller.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xml)));
            }
            catch (Exception exc) {
                LOGGER.Error(exc, "Error unmarshalling from XML");
                throw new RealexException("Error unmarshalling from XML", exc);
            }

            return (T)response;
        }
    }

    internal class Utf8StringWriter : StringWriter {
        public override Encoding Encoding {
            get {
                return Encoding.UTF8;
            }
        }
    }
}
