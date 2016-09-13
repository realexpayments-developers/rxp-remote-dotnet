namespace RealexPayments.Remote.SDK {
    public class RealexServerException : RealexException {
        private const long serialVersionUID = -298850091427275465L;
        public string ErrorCode { get; private set; }
        public string OrderId { get; private set; }
        public string Timestamp { get; private set; }

        public RealexServerException(string timestamp, string orderId, string errorCode, string message) : base(message) {
            this.Timestamp = timestamp;
            this.OrderId = orderId;
            this.ErrorCode = errorCode;
        }
    }
}
