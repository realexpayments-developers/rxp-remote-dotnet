using System.Xml.Serialization;

namespace RealexPayments.Remote.SDK.Domain.Payment {
    public class AutoSettleFlag {
        public const string TRUE = "1";
        public const string FALSE = "0";
        public const string MULTI = "MULTI";
    }

    public class AutoSettle {
        [XmlAttribute(AttributeName = "flag")]
        public string Flag { get; set; }

        public AutoSettle AddFlag(string autoSettleFlag) {
            this.Flag = autoSettleFlag;
            return this;
        }
    }
}
