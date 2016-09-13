using System.Text;
using System.Xml.Serialization;

namespace RealexPayments.Remote.SDK.Domain {
    public class CardType {
        public const string VISA = "VISA";
        public const string MASTERCARD = "MC";
        public const string AMEX = "AMEX";
        public const string CB = "CB";
        public const string DINERS = "DINERS";
        public const string JCB = "JCB";
    }

    public class Card {
        private const string SHORT_MASK = "******";

        [XmlElement(ElementName = "number")]
        public string Number { get; set; }
        [XmlElement(ElementName = "expdate")]
        public string ExpiryDate { get; set; }
        [XmlElement(ElementName = "chname")]
        public string CardHolderName { get; set; }
        [XmlElement(ElementName = "type")]
        public string Type { get; set; }
        [XmlElement(ElementName = "issueno")]
        public int IssueNumber { get; set; }
        [XmlElement(ElementName = "cvn", Type = typeof(Cvn))]
        public Cvn Cvn { get; set; }

        public Card AddNumber(string value) { this.Number = value; return this; }
        public Card AddExpiryDate(string value) { this.ExpiryDate = value; return this; }
        public Card AddCardHolderName(string value) { this.CardHolderName = value; return this; }
        public Card AddType(string value) { this.Type = value; return this; }
        public Card AddIssueNumber(int value) { this.IssueNumber = value; return this; }
        public Card AddCvn(string value) {
            if (this.Cvn == null)
                this.Cvn = new Cvn().AddNumber(value);
            else this.Cvn.AddNumber(value);
            return this;
        }
        public Card AddCvnPresenceIndicator(string value) {
            if (this.Cvn == null)
                this.Cvn = new Cvn().AddPresenceIndicator(value);
            else this.Cvn.AddPresenceIndicator(value);
            return this;
        }

        public string DisplayFirstSixLastFour() {
            var sb = new StringBuilder(this.Number.Substring(0, 6));
            sb.Append(SHORT_MASK);
            sb.Append(this.Number.Substring(this.Number.Length - 4));
            return sb.ToString();
        }
    }
}
