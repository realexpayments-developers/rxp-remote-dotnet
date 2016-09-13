using System.Collections.Generic;
using System.Xml.Serialization;

namespace RealexPayments.Remote.SDK.Domain.Payment {
    public class TssInfo {
        [XmlElement(ElementName = "custnum")]
        public string CustomerNumber { get; set; }
        [XmlElement(ElementName = "prodid")]
        public string ProductId { get; set; }
        [XmlElement(ElementName = "varref")]
        public string VariableReference { get; set; }
        [XmlElement(ElementName = "custipaddress")]
        public string CustomerIpAddress { get; set; }
        //[XmlArray(ElementName = "")]
        //[XmlArrayItem(ElementName = "address", Type = typeof(Address))]
        [XmlElement(ElementName = "address")]
        public List<Address> Addresses { get; set; }

        public TssInfo AddCustomerNumber(string value) { this.CustomerNumber = value; return this; }
        public TssInfo AddProductId(string value) { this.ProductId = value; return this; }
        public TssInfo AddVariableReference(string value) { this.VariableReference = value; return this; }
        public TssInfo AddCustomerIpAddress(string value) { this.CustomerIpAddress = value; return this; }
        public TssInfo AddAddress(Address value) {
            if(this.Addresses == null) {
                this.Addresses = new List<Address>();
            }
            this.Addresses.Add(value);
            return this;
        }
    }
}
