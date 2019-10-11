using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using Vostok.AspNetCore.Context.Tests.Helpers;
using Vostok.Context;

namespace Vostok.AspNetCore.Context.Tests
{
    [TestFixture]
    public class DistributedContextMiddleware_Tests
    {
        [Test]
        public async Task Invoke_SuccessfullyRestoresDistributedProperties()
        {
            FlowingContext.Configuration.RegisterDistributedGlobal("global", ContextSerializers.String);
            FlowingContext.Configuration.RegisterDistributedProperty("property", ContextSerializers.String);
            
            var middleware = new DistributedContextMiddleware();
            var httpContext = new TestingHttpContext();

            using (FlowingContext.Globals.Use("globalValue"))
            using (FlowingContext.Properties.Use("property", "propertyValue"))
            {
                httpContext.Request.Headers.Add(HeaderNames.ContextProperties, FlowingContext.SerializeDistributedProperties());
                httpContext.Request.Headers.Add(HeaderNames.ContextGlobals, FlowingContext.SerializeDistributedGlobals());
            }

            var nextInvoked = false;
            await middleware.InvokeAsync(httpContext, _ =>
            {
                nextInvoked = true;
                FlowingContext.Globals.Get<string>().Should().Be("globalValue");
                FlowingContext.Properties.Get<string>("property").Should().Be("propertyValue");
                return Task.CompletedTask;
            });

            nextInvoked.Should().BeTrue();
        }
    }
}