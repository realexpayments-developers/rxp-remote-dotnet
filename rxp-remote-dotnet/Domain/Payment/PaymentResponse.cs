using System.Text;
using System.Xml.Serialization;
using RealexPayments.Remote.SDK.Utils;

namespace RealexPayments.Remote.SDK.Domain.Payment {
    [XmlRoot(ElementName = "response")]
    public class PaymentResponse : IResponse<PaymentResponse> {
        [XmlAttribute(AttributeName = "timestamp")]
        public string Timestamp { get; set; }
        [XmlElement(ElementName = "merchantid")]
        public string MerchantId { get; set; }
        [XmlElement(ElementName = "account")]
        public string Account { get; set; }
        [XmlElement(ElementName = "orderid")]
        public string OrderId { get; set; }
        [XmlElement(ElementName = "result")]
        public string Result { get; set; }
        [XmlElement(ElementName = "authcode")]
        public string AuthCode { get; set; }
        [XmlElement(ElementName = "message")]
        public string Message { get; set; }
        [XmlElement(ElementName = "pasref")]
        public string PaymentsReference { get; set; }
        [XmlElement(ElementName = "cvnresult")]
        public string CvnResult { get; set; }
        [XmlElement(ElementName = "timetaken")]
        public long TimeTaken { get; set; }
        [XmlElement(ElementName = "authtimetaken")]
        public long AuthTimeTaken { get; set; }
        [XmlElement(ElementName = "acquirerresponse")]
        public string AcquirerResponse { get; set; }
        [XmlElement(ElementName = "batchid")]
        public long BatchId { get; set; }
        [XmlElement(ElementName = "cardissuer")]
        public CardIssuer CardIssuer { get; set; }
        [XmlElement(ElementName = "sha1hash")]
        public string Hash { get; set; }
        [XmlElement(ElementName = "tss")]
        public TssResult TssResult { get; set; }
        [XmlElement(ElementName = "avspostcoderesponse")]
        public string AvsPostcodeResponse { get; set; }
        [XmlElement(ElementName = "avsaddressresponse")]
        public string AvsAddressResponse { get; set; }

        public PaymentResponse FromXml(string xml) {
            return XmlUtils.FromXml<PaymentResponse>(xml);
        }

        public string ToXml() {
            return XmlUtils.ToXml(this);
        }

        public bool IsHashValid(string secret) {
            bool hashValid = false;

            //check for any null values and set them to empty string for hashing
            string timeStamp = this.Timestamp ?? string.Empty;
            string merchantId = this.MerchantId ?? string.Empty;
            string orderId = this.OrderId ?? string.Empty;
            string result = this.Result ?? string.Empty;
            string message = this.Message ?? string.Empty;
            string paymentsReference = this.PaymentsReference ?? string.Empty;
            string authCode = this.AuthCode ?? string.Empty;

            //create String to hash
            var toHash = new StringBuilder()
                    .Append(timeStamp).Append(".")
                    .Append(merchantId).Append(".")
                    .Append(orderId).Append(".")
                    .Append(result).Append(".")
                    .Append(message).Append(".")
                    .Append(paymentsReference).Append(".")
                    .Append(authCode).ToString();

            //check if calculated hash matches returned value
            string expectedHash = GenerationUtils.GenerateHash(toHash, secret);
            if (expectedHash == this.Hash) {
                hashValid = true;
            }

            return hashValid;
        }

        public bool IsSuccess() { return ResponseUtils.IsSuccess(this); }
    }
}
