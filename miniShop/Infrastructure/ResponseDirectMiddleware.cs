using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace miniShop.Infrastructure
{
    public class ResponseDirectMiddleware
    {
        private RequestDelegate next;

        public ResponseDirectMiddleware(RequestDelegate next)
        {
            this.next = next; 
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path.Value.ToLower() =="/error")
            {
                await httpContext.Response.WriteAsync("Hata....");
            }
            await next.Invoke(httpContext);
        }
    }
}
