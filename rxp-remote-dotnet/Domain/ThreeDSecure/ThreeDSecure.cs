using System.Xml.Serialization;

namespace RealexPayments.Remote.SDK.Domain.ThreeDSecure {
    public class ThreeDSecure {
        [XmlElement(ElementName = "status")]
        public string Status { get; set; }
        [XmlElement(ElementName = "eci")]
        public string Eci { get; set; }
        [XmlElement(ElementName = "xid")]
        public string Xid { get; set; }
        [XmlElement(ElementName = "cavv")]
        public string Cavv { get; set; }
        [XmlElement(ElementName = "algorithm")]
        public string Algorithm { get; set; }

        public ThreeDSecure AddStatus(string value) { this.Status = value; return this; }
        public ThreeDSecure AddEci(string value) {this.Eci = value; return this; }
        public ThreeDSecure AddXid(string value) {this.Xid = value; return this; }
        public ThreeDSecure AddCavv(string value) {this.Cavv = value; return this; }
        public ThreeDSecure AddAlgorithm(string value) {this.Algorithm = value; return this; }
    }
}
