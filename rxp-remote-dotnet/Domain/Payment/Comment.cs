using System.Xml.Serialization;

namespace RealexPayments.Remote.SDK.Domain.Payment {
    public class RxpComment {
        [XmlText]
        public string Comment { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public int Id { get; set; }

        public RxpComment AddComment(string value) { this.Comment = value; return this; }
        public RxpComment AddId(int value) { this.Id = value; return this; }
    }
}
