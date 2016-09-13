using System;

namespace RealexPayments.Remote.SDK {
    public class RealexException : Exception {
        private const long serialVersionUID = -6404893161440391367L;

        public RealexException(string message, Exception innerException = null) : base(message, innerException) { }
    }
}
