using System.Xml.Serialization;

namespace RealexPayments.Remote.SDK.Domain.Payment {
    public class AddressType {
        public const string NONE = "";
        public const string SHIPPING = "shipping";
        public const string BILLING = "billing";
    }

    public class Address {
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }

        [XmlElement(ElementName = "code")]
        public string Code { get; set; }

        [XmlElement(ElementName = "country")]
        public string Country { get; set; }

        public Address AddType(string type) {
            this.Type = type;
            return this;
        }

        public Address AddCode(string code) {
            this.Code = code;
            return this;
        }

        public Address AddCountry(string country) {
            this.Country = country;
            return this;
        }
    }
}
