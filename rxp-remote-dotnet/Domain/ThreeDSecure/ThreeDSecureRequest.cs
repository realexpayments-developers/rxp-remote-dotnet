using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using RealexPayments.Remote.SDK.Domain.Payment;
using RealexPayments.Remote.SDK.Utils;

namespace RealexPayments.Remote.SDK.Domain.ThreeDSecure {
    public class ThreeDSecureType {
        public const string VERIFY_ENROLLED = "3ds-verifyenrolled";
        public const string VERIFY_SIG = "3ds-verifysig";
    }

    [XmlRoot(ElementName = "request")]
    public class ThreeDSecureRequest : IRequest<ThreeDSecureRequest, ThreeDSecureResponse> {
        [XmlAttribute(AttributeName = "timestamp")]
        public string Timestamp { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlElement(ElementName = "merchantid")]
        public string MerchantId { get; set; }
        [XmlElement(ElementName = "account")]
        public string Account { get; set; }
        [XmlElement(ElementName = "orderid")]
        public string OrderId { get; set; }
        [XmlElement(ElementName = "amount")]
        public RxpAmount Amount { get; set; }
        [XmlElement(ElementName = "card")]
        public Card Card { get; set; }
        [XmlElement(ElementName = "pares")]
        public string Pares { get; set; }
        [XmlElement(ElementName = "sha1hash")]
        public string Hash { get; set; }
        [XmlArray(ElementName = "comments")]
        [XmlArrayItem(ElementName = "comment", Type = typeof(RxpComment))]
        public List<RxpComment> Comments { get; set; }

        public ThreeDSecureRequest AddTimestamp(string value) { this.Timestamp = value; return this; }
        public ThreeDSecureRequest AddType(string value) { this.Type = value; return this; }
        public ThreeDSecureRequest AddMerchantId(string value) { this.MerchantId = value; return this; }
        public ThreeDSecureRequest AddAccount(string value) { this.Account = value; return this; }
        public ThreeDSecureRequest AddOrderId(string value) { this.OrderId = value; return this; }
        public ThreeDSecureRequest AddAmount(long value) {
            if (this.Amount == null)
                this.Amount = new RxpAmount().AddAmount(value);
            else this.Amount.AddAmount(value);
            return this;
        }
        public ThreeDSecureRequest AddCurrency(string value) {
            if (this.Amount == null)
                this.Amount = new RxpAmount().AddCurrency(value);
            else this.Amount.AddCurrency(value);
            return this;
        }
        public ThreeDSecureRequest AddCard(Card value) { this.Card = value; return this; }
        public ThreeDSecureRequest AddPares(string value) { this.Pares = value; return this; }
        public ThreeDSecureRequest AddHash(string value) { this.Hash = value; return this; }
        public ThreeDSecureRequest AddComment(string value) {
            if (this.Comments == null)
                this.Comments = new List<RxpComment>();
            int size = this.Comments.Count;
            this.Comments.Add(new RxpComment().AddComment(value).AddId(++size));
            return this;
        }

        public string ToXml() { return XmlUtils.ToXml(this); }

        public ThreeDSecureRequest FromXml(string xml) {
            return XmlUtils.FromXml<ThreeDSecureRequest>(xml);
        }

        public ThreeDSecureRequest GenerateDefaults(string secret) {
            if (this.Timestamp == null)
                this.Timestamp = GenerationUtils.GenerateTimestamp();

            if (this.OrderId == null)
                this.OrderId = GenerationUtils.GenerateOrderId();

            GenerateHash(secret);

            return this;
        }

        public ThreeDSecureResponse ResponseFromXml(string xml) {
            return new ThreeDSecureResponse().FromXml(xml);
        }

        public ThreeDSecureRequest GenerateHash(string secret) {
            string timestamp = this.Timestamp ?? string.Empty;
            string merchantId = this.MerchantId ?? string.Empty;
            string orderId = this.OrderId ?? string.Empty;
            string amount = string.Empty;
            string currency = string.Empty;

            if (this.Amount != null) {
                amount = this.Amount.Amount == default(long) ? "" : this.Amount.Amount.ToString();
                currency = this.Amount.Currency ?? string.Empty;
            }

            string cardNumber = string.Empty;
            if (this.Card != null)
                cardNumber = this.Card.Number ?? string.Empty;

            string toHash = new StringBuilder()
                .Append(timestamp).Append(".")
                .Append(merchantId).Append(".")
                .Append(orderId).Append(".")
                .Append(amount).Append(".")
                .Append(currency).Append(".")
                .Append(cardNumber).ToString();

            this.Hash = GenerationUtils.GenerateHash(toHash, secret);
            return this;
        }
    }
}
