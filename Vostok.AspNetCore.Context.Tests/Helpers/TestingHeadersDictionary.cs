using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace Vostok.AspNetCore.Context.Tests.Helpers
{
    public class TestingHeadersDictionary : Dictionary<string, StringValues>, IHeaderDictionary
    {
        public long? ContentLength { get; set; }
    }
}