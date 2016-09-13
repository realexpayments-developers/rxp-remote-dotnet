using System.Xml.Serialization;

namespace RealexPayments.Remote.SDK.Domain {
    public class PresenceIndicator {
        public const string CVN_PRESENT = "1";
        public const string CVN_ILLEGIBLE = "2";
        public const string CVN_NOT_ON_CARD = "3";
        public const string CVN_NOT_REQUESTED = "4";
    }

    public class Cvn {
        [XmlElement(ElementName = "number")]
        public string Number { get; set; }
        [XmlElement(ElementName = "presind")]
        public string PresenceIndicator { get; set; }

        public Cvn AddNumber(string number) {
            this.Number = number;
            return this;
        }

        public Cvn AddPresenceIndicator(string presenceIndicator) {
            this.PresenceIndicator = presenceIndicator;
            return this;
        }
    }
}
