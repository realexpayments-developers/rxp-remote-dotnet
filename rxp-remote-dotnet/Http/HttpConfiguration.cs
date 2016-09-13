namespace RealexPayments.Remote.SDK.Http {
    public class HttpConfiguration {
        public const string DEFAULT_ENDPOINT = "https://epage.payandshop.com/epage-remote.cgi";
        public const int DEFAULT_TIMEOUT = 65000;

        public string Endpoint { get; set; }
        public int Timeout { get; set; }
        public bool OnlyAllowHttps { get; set; }

        public HttpConfiguration() {
            this.Endpoint = DEFAULT_ENDPOINT;
            this.Timeout = DEFAULT_TIMEOUT;
            this.OnlyAllowHttps = true;
        }
    }
}
