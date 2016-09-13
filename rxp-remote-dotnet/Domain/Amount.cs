using System.Xml.Serialization;

namespace RealexPayments.Remote.SDK.Domain {
    public class RxpAmount {
        [XmlText(Type = typeof(long))]
        public long Amount { get; set; }
        [XmlAttribute(AttributeName = "currency")]
        public string Currency { get; set; }

        public RxpAmount AddAmount(long value) { this.Amount = value; return this; }
        public RxpAmount AddCurrency(string value) { this.Currency = value; return this; }
    }
}
