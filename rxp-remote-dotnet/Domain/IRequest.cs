using System.IO;

namespace RealexPayments.Remote.SDK.Domain {
    public interface IRequest<T, U> where U : IResponse<U> {
        /// <summary>
        /// Method returns an XML representation of the interface implementation.
        /// </summary>
        /// <returns>string</returns>
        string ToXml();

        T FromXml(string xml);

        /// <summary>
        /// Generates default values for fields such as hash, timestamp and order ID.
        /// </summary>
        /// <param name="secret"></param>
        /// <returns>T</returns>
        T GenerateDefaults(string secret);

        U ResponseFromXml(string xml);
    }
}
