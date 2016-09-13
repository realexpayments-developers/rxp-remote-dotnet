using System.Xml.Serialization;
using System.Collections.Generic;
using System.Text;

namespace RealexPayments.Remote.SDK.Domain.Payment {
    public class TssResult {
        [XmlElement(ElementName = "result")]
        public string Result { get; set; }
        [XmlElement(ElementName = "check")]
        public List<TssResultCheck> Checks { get; set; }

        public override string ToString() {
            var result = new StringBuilder(this.Result);
            result.Append(":");
            foreach (TssResultCheck check in this.Checks) {
                result.Append(check.Id);
                result.Append("-");
                result.Append(check.Value);
                result.Append(";");
            }
            return result.ToString();
        }
    }
}
