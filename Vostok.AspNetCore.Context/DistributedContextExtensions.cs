using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Vostok.Context;

namespace Vostok.AspNetCore.Context
{
    /// <summary>
    /// Extension methods for configuring an application to
    /// restore distributed <see cref="FlowingContext.Properties"/>
    /// and <see cref="FlowingContext.Globals"/> from <see cref="HttpContext"/>
    /// </summary>
    public static class DistributedContextExtensions
    {
        /// <summary>
        /// Enables restoring of distributed <see cref="FlowingContext.Properties"/>
        /// and <see cref="FlowingContext.Globals"/> from <see cref="HttpContext"/>
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static void UseDistributedContext(this IApplicationBuilder app)
        {
            app.UseMiddleware<DistributedContextMiddleware>();
        }
    }
}