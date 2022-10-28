using System.Runtime.Serialization;

namespace Adapter.ModernGrapicsLib
{
    [Serializable]
    internal class GraphicsLogicalException : Exception
    {
        public GraphicsLogicalException()
        {
        }

        public GraphicsLogicalException(string? message) : base(message)
        {
        }

        public GraphicsLogicalException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected GraphicsLogicalException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}