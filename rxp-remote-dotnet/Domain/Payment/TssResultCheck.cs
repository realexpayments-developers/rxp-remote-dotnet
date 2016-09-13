using System.Xml.Serialization;

namespace RealexPayments.Remote.SDK.Domain.Payment {
    public class TssResultCheck {
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlText]
        public string Value { get; set; }
    }
}
