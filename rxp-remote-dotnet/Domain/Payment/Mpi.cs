using System.Xml.Serialization;

namespace RealexPayments.Remote.SDK.Domain.Payment {
    public class Mpi {
        [XmlElement(ElementName = "cavv")]
        public string Cavv { get; set; }
        [XmlElement(ElementName = "xid")]
        public string Xid { get; set; }
        [XmlElement(ElementName = "eci")]
        public string Eci { get; set; }

        public Mpi AddCavv(string value) { this.Cavv = value; return this; }
        public Mpi AddXid(string value) { this.Xid = value; return this; }
        public Mpi AddEci(string value) { this.Eci = value; return this; }
    }
}
