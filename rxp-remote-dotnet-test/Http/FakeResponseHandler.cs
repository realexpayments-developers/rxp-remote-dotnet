using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

internal class FakeResponseHandler : DelegatingHandler {
    private readonly Dictionary<Uri, HttpResponseMessage> _responses = new Dictionary<Uri, HttpResponseMessage>();

    public void AddFakeResponse(string url, HttpResponseMessage response) {
        AddFakeResponse(new Uri(url), response);
    }
    public void AddFakeResponse(Uri uri, HttpResponseMessage response) {
        _responses.Add(uri, response);
    }

    protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) {
        if (_responses.ContainsKey(request.RequestUri))
            return _responses[request.RequestUri];
        else return new HttpResponseMessage(System.Net.HttpStatusCode.NotFound) { RequestMessage = request };
    }
}