using System;
using System.Runtime.Serialization;

namespace iTest.Services.Data.Admin.Implementations
{
    [Serializable]
    internal class InvalidTestException : Exception
    {
        public InvalidTestException()
        {
        }

        public InvalidTestException(string message) : base(message)
        {
        }

        public InvalidTestException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidTestException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}