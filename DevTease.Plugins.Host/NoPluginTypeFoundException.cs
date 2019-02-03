using System;
using System.Runtime.Serialization;

namespace DevTease.Plugins.Host
{
    [Serializable]
    internal class NoPluginTypeFoundException : Exception
    {
        public NoPluginTypeFoundException()
        {
        }

        public NoPluginTypeFoundException(string message) : base(message)
        {
        }

        public NoPluginTypeFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoPluginTypeFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}