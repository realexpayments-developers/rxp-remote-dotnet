using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using RealexPayments.Remote.SDK.Utils;

namespace RealexPayments.Remote.SDK.Domain.Payment {
    public class PaymentType {
        public const string AUTH = "auth";
        public const string AUTH_MOBILE = "auth-mobile";
        public const string SETTLE = "settle";
        public const string VOID = "void";
        public const string REBATE = "rebate";
        public const string OTB = "otb";
        public const string CREDIT = "credit";
        public const string HOLD = "hold";
        public const string RELEASE = "release";
        public const string MANUAL = "manual";
    }

    [XmlRoot("request", IsNullable = false)]
    public class PaymentRequest : IRequest<PaymentRequest, PaymentResponse> {
        [XmlAttribute(AttributeName = "timestamp")]
        public string Timestamp { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlElement(ElementName = "merchantid")]
        public string MerchantId { get; set; }
        [XmlElement(ElementName = "account")]
        public string Account { get; set; }
        [XmlElement(ElementName = "channel")]
        public string Channel { get; set; }
        [XmlElement(ElementName = "orderid")]
        public string OrderId { get; set; }
        [XmlElement(ElementName = "amount")]
        public RxpAmount Amount { get; set; }
        [XmlElement(ElementName = "card")]
        public Card Card { get; set; }
        [XmlElement(ElementName = "autosettle")]
        public AutoSettle AutoSettle { get; set; }
        [XmlElement(ElementName = "sha1hash")]
        public string Hash { get; set; }
        [XmlArray(ElementName = "comments")]
        [XmlArrayItem(ElementName = "comment", Type = typeof(RxpComment))]
        public List<RxpComment> Comments { get; set; }
        [XmlElement(ElementName = "pasref")]
        public string PaymentsReference { get; set; }
        [XmlElement(ElementName = "authcode")]
        public string AuthCode { get; set; }
        [XmlElement(ElementName = "refundhash")]
        public string RefundHash { get; set; }
        [XmlElement(ElementName = "fraudfilter")]
        public string FraudFilter { get; set; }
        [XmlElement(ElementName = "recurring")]
        public Recurring Recurring { get; set; }
        [XmlElement(ElementName = "tssinfo")]
        public TssInfo TssInfo { get; set; }
        [XmlElement(ElementName = "mpi")]
        public Mpi Mpi { get; set; }
        [XmlElement(ElementName = "mobile")]
        public string Mobile { get; set; }
        [XmlElement(ElementName = "token")]
        public string Token { get; set; }

        public PaymentRequest AddMerchantId(string value) { this.MerchantId = value; return this; }
        public PaymentRequest AddAccount(string value) { this.Account = value; return this; }
        public PaymentRequest AddTimestamp(string value) { this.Timestamp = value; return this; }
        public PaymentRequest AddOrderId(string value) { this.OrderId = value; return this; }
        public PaymentRequest AddAmount(long value) {
            if (this.Amount == null)
                this.Amount = new RxpAmount().AddAmount(value);
            else this.Amount.AddAmount(value);
            return this;
        }
        public PaymentRequest AddCurrency(string value) {
            if (this.Amount == null)
                this.Amount = new RxpAmount().AddCurrency(value);
            else this.Amount.AddCurrency(value);
            return this;
        }
        public PaymentRequest AddCard(Card value) { this.Card = value; return this; }
        public PaymentRequest AddAutoSettle(string value) {
            if (this.AutoSettle == null)
                this.AutoSettle = new AutoSettle();
            this.AutoSettle.AddFlag(value);
            return this;
        }
        public PaymentRequest AddType(string value) { this.Type = value; return this; }
        public PaymentRequest AddComment(string value) {
            if (this.Comments == null)
                this.Comments = new List<RxpComment>();
            int size = this.Comments.Count;
            this.Comments.Add(new RxpComment().AddComment(value).AddId(++size));
            return this;
        }
        public PaymentRequest AddPaymentsReference(string value) { this.PaymentsReference = value; return this; }
        public PaymentRequest AddAuthCode(string value) { this.AuthCode = value; return this; }
        public PaymentRequest AddRefundHash(string value) { this.RefundHash = value; return this; }
        public PaymentRequest AddHash(string value) { this.Hash = value; return this; }
        public PaymentRequest AddChannel(string value) { this.Channel = value; return this; }
        public PaymentRequest AddFraudFilter(string value) { this.FraudFilter = value; return this; }
        public PaymentRequest AddRecurring(Recurring value) { this.Recurring = value; return this; }
        public PaymentRequest AddTssInfo(TssInfo value) { this.TssInfo = value; return this; }
        public PaymentRequest AddMpi(Mpi value) { this.Mpi = value; return this; }
        public PaymentRequest AddMobile(string value) { this.Mobile = value;  return this; }
        public PaymentRequest AddToken(string value) { this.Token = value; return this; }
        public PaymentRequest AddAddressVerificationServiceDetails(string addressLine, string postCode) {
            var rgx = new Regex("[^0-9]");
            var code = new StringBuilder()
                .Append(rgx.Replace(postCode, ""))
                .Append("|")
                .Append(rgx.Replace(addressLine, ""));

            var address = new Address().AddCode(code.ToString()).AddType(AddressType.BILLING);
            if (this.TssInfo == null)
                this.TssInfo = new TssInfo();
            this.TssInfo.AddAddress(address);
            return this;
        }

        public string ToXml() {
            return XmlUtils.ToXml(this);
        }

        public PaymentRequest FromXml(string xml) {
            return XmlUtils.FromXml<PaymentRequest>(xml);
        }

        public PaymentRequest GenerateDefaults(string secret) {
            if (this.Timestamp == null)
                this.Timestamp = GenerationUtils.GenerateTimestamp();

            if (this.OrderId == null)
                this.OrderId = GenerationUtils.GenerateOrderId();

            GenerateHash(secret);

            return this;
        }

        public PaymentResponse ResponseFromXml(string xml) {
            return new PaymentResponse().FromXml(xml);
        }

        public PaymentRequest GenerateHash(string secret) {
            string timestamp = this.Timestamp ?? string.Empty;
            string merchantId = this.MerchantId ?? string.Empty;
            string orderId = this.OrderId ?? string.Empty;
            string amount = string.Empty;
            string currency = string.Empty;
            string token = this.Token ?? string.Empty;

            if(this.Amount != null) {
                amount = this.Amount.Amount == default(long) ? string.Empty : this.Amount.Amount.ToString();
                currency = this.Amount.Currency ?? string.Empty;
            }

            string cardNumber = string.Empty;
            if (this.Card != null)
                cardNumber = this.Card.Number ?? string.Empty;

            string toHash = string.Empty;
            if (this.Type == PaymentType.AUTH_MOBILE) {
                toHash = new StringBuilder()
                    .Append(timestamp).Append(".")
                    .Append(merchantId).Append(".")
                    .Append(orderId).Append("...")
                    .Append(token).ToString();
            }
            else if (this.Type == PaymentType.OTB) {
                toHash = new StringBuilder()
                    .Append(timestamp).Append(".")
                    .Append(merchantId).Append(".")
                    .Append(orderId).Append(".")
                    .Append(cardNumber).ToString();
            }
            else {
                toHash = new StringBuilder()
                    .Append(timestamp).Append(".")
                    .Append(merchantId).Append(".")
                    .Append(orderId).Append(".")
                    .Append(amount).Append(".")
                    .Append(currency).Append(".")
                    .Append(cardNumber).ToString();
            }

            this.Hash = GenerationUtils.GenerateHash(toHash, secret);
            return this;
        }
    }
}
