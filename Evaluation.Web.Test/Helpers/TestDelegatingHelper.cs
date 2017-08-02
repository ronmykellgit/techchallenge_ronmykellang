using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Evaluation.Web.Test.Helpers
{
    // HttpClient doesn’t implement an interface we can’t use most of the 
    // standard mocking frameworks like Moq to replace the HttpClient with a test fake.
    // But you can replace the internal pipeline of the HttpClient instead using a custom
    // HttpMesageHandler class.
    public class TestDelegatingHandler<T> : DelegatingHandler
    {
        public TestDelegatingHandler(T value) : this(HttpStatusCode.OK, value) { }

        public TestDelegatingHandler(HttpStatusCode statusCode) : this(statusCode, default(T)) { }

        public TestDelegatingHandler(HttpStatusCode statusCode, T value)
        {
            _httpResponseMessageFunc = request => request.CreateResponse(statusCode, value);
        }

        private Func<HttpRequestMessage, HttpResponseMessage> _httpResponseMessageFunc;

        public TestDelegatingHandler(Func<HttpRequestMessage, HttpResponseMessage> httpResponseMessageFunc)
        {
            _httpResponseMessageFunc = httpResponseMessageFunc;
        }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.Factory.StartNew(() => _httpResponseMessageFunc(request));
        }
    }
}
