using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace WebApplicationUsers.Util
{
    public class HttpActionResult : IHttpActionResult
    {
        public HttpActionResult(HttpRequestMessage request) : this(request, HttpStatusCode.OK)
        {
        }

        public HttpActionResult(HttpRequestMessage request, HttpStatusCode code) : this(request, code, null)
        {
        }

        public HttpActionResult(HttpRequestMessage request, HttpStatusCode code, object result)
        {
            Request = request;
            Code = code;
            Result = result;
        }

        public HttpRequestMessage Request { get; }
        public HttpStatusCode Code { get; }
        public object Result { get; }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(Request.CreateResponse(Code, Result));
        }
    }
}