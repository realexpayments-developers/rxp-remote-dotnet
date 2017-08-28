using System.Collections.Generic;
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
        public const string CARD_NEW = "card-new";
        public const string PAYER_NEW = "payer-new";
        public const string CARD_CANCEL = "card-cancel-card";
        public const string RECEIPT_IN = "receipt-in";
        public const string PAYMENT_OUT = "payment-out";
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

        [XmlElement(ElementName = "payer")]
        public Payer Payer { get; set; }
        
        [XmlElement(ElementName = "sha1hash")]
        public string Hash { get; set; }

        [XmlElement(ElementName = "payerref")]
        public string PayerRef { get; set; }

        [XmlElement(ElementName = "paymentmethod")]
        public string PaymentMethod { get; set; }
       

        public PaymentRequest AddMerchantId(string value) { MerchantId = value; return this; }
        public PaymentRequest AddAccount(string value) { Account = value; return this; }
        public PaymentRequest AddTimestamp(string value) { Timestamp = value; return this; }
        public PaymentRequest AddOrderId(string value) { OrderId = value; return this; }
        public PaymentRequest AddAmount(long value) {
            if (Amount == null)
                Amount = new RxpAmount().AddAmount(value);
            else Amount.AddAmount(value);
            return this;
        }
        public PaymentRequest AddCurrency(string value) {
            if (Amount == null)
                Amount = new RxpAmount().AddCurrency(value);
            else Amount.AddCurrency(value);
            return this;
        }
        public PaymentRequest AddCard(Card value) { Card = value; return this; }
        public PaymentRequest AddAutoSettle(string value) {
            if (AutoSettle == null)
                AutoSettle = new AutoSettle();
            AutoSettle.AddFlag(value);
            return this;
        }
        public PaymentRequest AddType(string value) { Type = value; return this; }
        public PaymentRequest AddComment(string value) {
            if (Comments == null)
                Comments = new List<RxpComment>();
            var size = Comments.Count;
            Comments.Add(new RxpComment().AddComment(value).AddId(++size));
            return this;
        }
        public PaymentRequest AddPaymentsReference(string value) { PaymentsReference = value; return this; }
        public PaymentRequest AddAuthCode(string value) { AuthCode = value; return this; }
        public PaymentRequest AddRefundHash(string value) { RefundHash = value; return this; }
        public PaymentRequest AddHash(string value) { Hash = value; return this; }
        public PaymentRequest AddChannel(string value) { Channel = value; return this; }
        public PaymentRequest AddFraudFilter(string value) { FraudFilter = value; return this; }
        public PaymentRequest AddRecurring(Recurring value) { Recurring = value; return this; }
        public PaymentRequest AddPayer(Payer value) { Payer = value; return this; }
        public PaymentRequest AddTssInfo(TssInfo value) { TssInfo = value; return this; }
        public PaymentRequest AddMpi(Mpi value) { Mpi = value; return this; }
        public PaymentRequest AddMobile(string value) { Mobile = value;  return this; }
        public PaymentRequest AddToken(string value) { Token = value; return this; }
        public PaymentRequest AddPayerRef(string value) { PayerRef = value; return this; }
        public PaymentRequest AddPaymentMethod(string value) { PaymentMethod = value; return this; }
        public PaymentRequest AddAddressVerificationServiceDetails(string addressLine, string postCode) {
            var rgx = new Regex("[^0-9]");
            var code = new StringBuilder()
                .Append(rgx.Replace(postCode, ""))
                .Append("|")
                .Append(rgx.Replace(addressLine, ""));

            var address = new Address().AddCode(code.ToString()).AddType(AddressType.BILLING);
            if (TssInfo == null)
                TssInfo = new TssInfo();
            TssInfo.AddAddress(address);
            return this;
        }

        public string ToXml() {
            return XmlUtils.ToXml(this);
        }

        public PaymentRequest FromXml(string xml) {
            return XmlUtils.FromXml<PaymentRequest>(xml);
        }

        public PaymentRequest GenerateDefaults(string secret) {
            if (Timestamp == null)
                Timestamp = GenerationUtils.GenerateTimestamp();

            if (OrderId == null)
                OrderId = GenerationUtils.GenerateOrderId();

            GenerateHash(secret);

            return this;
        }

        public PaymentResponse ResponseFromXml(string xml) {
            return new PaymentResponse().FromXml(xml);
        }

        public PaymentRequest GenerateHash(string secret) {
            var timestamp = Timestamp ?? string.Empty;
            var merchantId = MerchantId ?? string.Empty;
            var orderId = OrderId ?? string.Empty;
            var amount = string.Empty;
            var currency = string.Empty;
            var token = Token ?? string.Empty;
            var payerRef = Payer != null ? Payer.Ref : PayerRef;
            var paymentMethod = Card != null ? Card.Ref : PaymentMethod;

            if (Amount != null) {
                amount = Amount.Amount == default(long) ? string.Empty : Amount.Amount.ToString();
                currency = Amount.Currency ?? string.Empty;
            }

            var cardNumber = string.Empty;
            if (Card != null)
                cardNumber = Card.Number ?? string.Empty;

            string toHash;
            switch (Type)
            {
                case PaymentType.AUTH_MOBILE:
                    toHash = new StringBuilder()
                        .Append(timestamp).Append(".")
                        .Append(merchantId).Append(".")
                        .Append(orderId).Append("...")
                        .Append(token).ToString();
                    break;
                case PaymentType.OTB:
                    toHash = new StringBuilder()
                        .Append(timestamp).Append(".")
                        .Append(merchantId).Append(".")
                        .Append(orderId).Append(".")
                        .Append(cardNumber).ToString();
                    break;
                case PaymentType.PAYER_NEW:
                    // timestamp.merchantid.orderid.amount.currency.payerref
                    toHash = new StringBuilder()
                        .Append(timestamp).Append(".")
                        .Append(merchantId).Append(".")
                        .Append(orderId).Append(".")
                        .Append(amount).Append(".")
                        .Append(currency).Append(".")
                        .Append(payerRef).ToString();
                    break;
                case PaymentType.CARD_NEW:
                    // timestamp.merchantid.orderid.amount.currency.payerref.chname.cardnumber
                    toHash = new StringBuilder()
                        .Append(timestamp).Append(".")
                        .Append(merchantId).Append(".")
                        .Append(orderId).Append(".")
                        .Append(amount).Append(".")
                        .Append(currency).Append(".")
                        .Append(Card?.PayerRef).Append(".")
                        .Append(Card?.CardHolderName).Append(".")
                        .Append(cardNumber).ToString();
                    break;
                case PaymentType.CARD_CANCEL:
                    // timestamp.merchantid.payerref.cardref
                    toHash = new StringBuilder()
                        .Append(timestamp).Append(".")
                        .Append(merchantId).Append(".")
                        .Append(Card?.PayerRef).Append(".")
                        .Append(Card?.Ref).ToString();
                    break;
                case PaymentType.RECEIPT_IN:
                    // timestamp.merchantid.orderid.amount.currency.payerref
                    toHash = new StringBuilder()
                        .Append(timestamp).Append(".")
                        .Append(merchantId).Append(".")
                        .Append(orderId).Append(".")
                        .Append(amount).Append(".")
                        .Append(currency).Append(".")
                        .Append(payerRef).ToString();
                    break;
                case PaymentType.PAYMENT_OUT:
                    // timestamp.merchantid.orderid.amount.currency.payerref
                    toHash = new StringBuilder()
                        .Append(timestamp).Append(".")
                        .Append(merchantId).Append(".")
                        .Append(orderId).Append(".")
                        .Append(amount).Append(".")
                        .Append(currency).Append(".")
                        .Append(payerRef).ToString();
                    break;
                default:
                    toHash = new StringBuilder()
                        .Append(timestamp).Append(".")
                        .Append(merchantId).Append(".")
                        .Append(orderId).Append(".")
                        .Append(amount).Append(".")
                        .Append(currency).Append(".")
                        .Append(cardNumber).ToString();
                    break;
            }

            Hash = GenerationUtils.GenerateHash(toHash, secret);
            return this;
        }
    }
}
