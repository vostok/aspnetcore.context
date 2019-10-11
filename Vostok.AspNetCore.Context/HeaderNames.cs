namespace Vostok.AspNetCore.Context
{
    /// <summary>
    /// <para>Contains the names of well-known common HTTP headers.</para>
    /// <para>Values are taken from corresponding RFC (https://www.w3.org/Protocols/rfc2616/rfc2616-sec14.html).</para>
    /// </summary>
    internal static class HeaderNames
    {
        /// <summary>
        /// A custom optional request header used for transmitting serialized distributed context properties.
        /// </summary>
        public const string ContextProperties = "Context-Properties";

        /// <summary>
        /// A custom optional request header used for transmitting serialized distributed context globals.
        /// </summary>
        public const string ContextGlobals = "Context-Globals";
    }
}