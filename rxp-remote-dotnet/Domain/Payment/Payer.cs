using System.Xml.Serialization;

namespace RealexPayments.Remote.SDK.Domain.Payment
{
    public class PayerType
    {
        public const string Business = "Business";
        public const string Retail = "Retail";
    }

    public class Payer
    {
        [XmlAttribute(AttributeName = "ref")]
        public string Ref { get; set; }

        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }

        [XmlElement(ElementName = "title")]
        public string Title { get; set; }

        [XmlElement(ElementName = "firstname")]
        public string FirstName { get; set; }

        [XmlElement(ElementName = "surname")]
        public string Surname { get; set; }

        [XmlElement(ElementName = "company")]
        public string Company { get; set; }

        [XmlElement(ElementName = "address")]
        public PayerAddress Address { get; set; }

        [XmlElement(ElementName = "email")]
        public string Email { get; set; }

        public Payer AddRef(string reference)
        {
            Ref = reference;
            return this;
        }

        public Payer AddTitle(string title)
        {
            Title = title;
            return this;
        }

        public Payer AddFirstName(string firstName)
        {
            FirstName = firstName;
            return this;
        }

        public Payer AddSurname(string surname)
        {
            Surname = surname;
            return this;
        }

        public Payer AddCompany(string company)
        {
            Company = company;
            return this;
        }

        public Payer AddPayerAddress(PayerAddress address)
        {
            Address = address;
            return this;
        }

        public Payer AddType(string type)
        {
            Type = type;
            return this;
        }

        public Payer AddEmail(string email)
        {
            Email = email;
            return this;
        }
    }
}
