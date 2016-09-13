using System.IO;

namespace RealexPayments.Remote.SDK.Domain {
    public interface IResponse<T> {
        T FromXml(string xml);
        string ToXml();
        bool IsHashValid(string secret);
        string Result { get; set; }
        string Message { get; set; }
        string OrderId { get; set; }
        string Timestamp { get; set; }
        bool IsSuccess();
    }
}
