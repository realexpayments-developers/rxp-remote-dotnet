using System.Xml.Serialization;

namespace RealexPayments.Remote.SDK.Domain.Payment
{
    public class PayerAddress
    {
        [XmlElement(ElementName = "line1")]
        public string Line1 { get; set; }

        [XmlElement(ElementName = "line2")]
        public string Line2 { get; set; }

        [XmlElement(ElementName = "line3")]
        public string Line3 { get; set; }

        [XmlElement(ElementName = "city")]
        public string City { get; set; }

        [XmlElement(ElementName = "county")]
        public string County { get; set; }

        [XmlElement(ElementName = "postcode")]
        public string Postcode { get; set; }

        [XmlElement(ElementName = "country")]
        public Country Country { get; set; }

        public PayerAddress AddLine1(string line1)
        {
            Line1 = line1;
            return this;
        }

        public PayerAddress AddLine2(string line2)
        {
            Line2 = line2;
            return this;
        }

        public PayerAddress AddLine3(string line3)
        {
            Line3 = line3;
            return this;
        }

        public PayerAddress AddCity(string city)
        {
            City = city;
            return this;
        }

        public PayerAddress AddCounty(string county)
        {
            County = county;
            return this;
        }

        public PayerAddress AddPostcode(string postcode)
        {
            Postcode = postcode;
            return this;
        }

        public PayerAddress AddCountryCode(string countryCode)
        {
            if (Country == null)
            {
                Country = new Country();
            }
            Country.Code = countryCode;
            return this;
        }

        public PayerAddress AddCountryName(string countryName)
        {
            if (Country == null)
            {
                Country = new Country();
            }
            Country.Name = countryName;
            return this;
        }
    }
}