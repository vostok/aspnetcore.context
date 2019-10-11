using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Vostok.Context;

namespace Vostok.AspNetCore.Context
{
    /// <summary>
    /// Middleware that restores distributed <see cref="FlowingContext.Properties"/>
    /// and <see cref="FlowingContext.Globals"/> from <see cref="HttpContext"/>
    /// </summary>
    internal class DistributedContextMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            FlowingContext.RestoreDistributedProperties(context.Request.Headers[HeaderNames.ContextProperties]);
            FlowingContext.RestoreDistributedGlobals(context.Request.Headers[HeaderNames.ContextGlobals]);
            await next(context);
        }
    }
}