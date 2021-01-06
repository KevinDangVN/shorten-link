using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace ShortenLinkApi.Ultil
{
    public class BadRequestResponse : IHttpActionResult
    {
        private string message;
        public BadRequestResponse(string message)
        {
            this.message = message;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new StringContent(message)
            };
            return Task.FromResult(response);
        }
    }
}
