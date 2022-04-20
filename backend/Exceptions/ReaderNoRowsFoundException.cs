using System.Runtime.Serialization;

namespace backend.Exceptions
{
    [Serializable]
    internal class ReaderNoRowsFoundException : Exception
    {
        private readonly string? message;
        private readonly Exception? innerException;
        private readonly SerializationInfo info;
        private readonly StreamingContext context;

        public ReaderNoRowsFoundException()
        {
        }

        public ReaderNoRowsFoundException(string? message) : base(message)
        {
            this.message = message;
        }

        public ReaderNoRowsFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
            this.message = message;
            this.innerException = innerException;
        }

        protected ReaderNoRowsFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            this.info = info;
            this.context = context;
        }
    }
}