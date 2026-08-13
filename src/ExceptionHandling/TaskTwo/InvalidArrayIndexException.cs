using System.Runtime.Serialization;

namespace ExceptionHandling.TaskTwo
{
    /// <summary>
    /// Represents an exception that is thrown when an invalid array index
    /// is used to access an array element.
    /// </summary>
    public class InvalidArrayIndexException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidArrayIndexException"/> class.
        /// </summary>
        public InvalidArrayIndexException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidArrayIndexException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message that describes the error.
        /// </param>
        public InvalidArrayIndexException(string? message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidArrayIndexException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message that describes the error.
        /// </param>
        /// <param name="innerException">
        /// The exception that caused the current exception.
        /// </param>
        public InvalidArrayIndexException(string? message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidArrayIndexException"/> class.
        /// </summary>
        /// <param name="info">
        /// The <see cref="SerializationInfo"/> that holds the serialized object data.
        /// </param>
        /// <param name="context">
        /// The <see cref="StreamingContext"/> that contains contextual information
        /// about the source or destination.
        /// </param>
        protected InvalidArrayIndexException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
