using System.Xml.Serialization;

namespace RealexPayments.Remote.SDK.Domain.Payment {
    public class RecurringType {
        public const string NONE = "";
        public const string VARIABLE = "variable";
        public const string FIXED = "fixed";
    }

    public class RecurringSequence {
        public const string NONE = "";
        public const string FIRST = "first";
        public const string SUBSEQUENT = "subsequent";
        public const string LAST = "last";
    }

    public class RecurringFlag {
        public const string NONE = "";
        public const string ZERO = "0";
        public const string ONE = "1";
        public const string TWO = "2";
    }

    public class Recurring {
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "sequence")]
        public string Sequence { get; set; }
        [XmlAttribute(AttributeName = "flag")]
        public string Flag { get; set; }
        
        public Recurring AddType(string value) { this.Type = value; return this; }
        public Recurring AddSequence(string value) { this.Sequence = value; return this; }
        public Recurring AddFlag(string value) { this.Flag = value; return this; }
    }
}
