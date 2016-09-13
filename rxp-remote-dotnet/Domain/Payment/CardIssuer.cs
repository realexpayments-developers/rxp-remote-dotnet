using System.Xml.Serialization;

namespace RealexPayments.Remote.SDK.Domain.Payment {
    public class CardIssuer {
        [XmlElement(ElementName = "bank")]
        public string Bank { get; set; }
        [XmlElement(ElementName = "country")]
        public string Country { get; set; }
        [XmlElement(ElementName = "countrycode")]
        public string CountryCode { get; set; }
        [XmlElement(ElementName = "region")]
        public string Region { get; set; }
    }
}
