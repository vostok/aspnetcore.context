using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
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
        /// <param name="app">The <see cref="IApplicationBuilder" />.</param>
        /// <returns></returns>
        public static void UseDistributedContext(this IApplicationBuilder app)
        {
            app.UseMiddleware<DistributedContextMiddleware>();
        }
        
        /// <summary>
        /// Registers an <see cref="DistributedContextMiddleware" /> service that can restore
        /// distributed <see cref="FlowingContext.Properties"/>
        /// and <see cref="FlowingContext.Globals"/> from <see cref="HttpContext"/>
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        public static void AddDistributedContext(this IServiceCollection services)
        {
            services.AddSingleton<DistributedContextMiddleware>();
        }
    }
}