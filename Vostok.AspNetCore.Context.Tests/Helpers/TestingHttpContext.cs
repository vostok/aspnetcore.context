using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Http.Features;

namespace Vostok.AspNetCore.Context.Tests.Helpers
{
    public class TestingHttpContext : HttpContext
    {
        public override void Abort() => throw new NotSupportedException();
        public override IFeatureCollection Features { get; }
        public override HttpRequest Request { get; } = new TestingHttpRequest();
        public override HttpResponse Response { get; }
        public override ConnectionInfo Connection { get; }
        public override WebSocketManager WebSockets { get; }
        public override AuthenticationManager Authentication { get; }
        public override ClaimsPrincipal User { get; set; }
        public override IDictionary<object, object> Items { get; set; }
        public override IServiceProvider RequestServices { get; set; }
        public override CancellationToken RequestAborted { get; set; }
        public override string TraceIdentifier { get; set; }
        public override ISession Session { get; set; }
    }
}