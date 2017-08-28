using System.Xml.Serialization;

namespace RealexPayments.Remote.SDK.Domain.Payment
{
    public class Country
    {

        [XmlAttribute(AttributeName = "code")]
        public string Code { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

    }
}
