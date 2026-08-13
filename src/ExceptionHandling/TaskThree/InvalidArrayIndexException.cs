using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling.TaskThree
{
    public class InvalidArrayIndexException : Exception
    {
        public InvalidArrayIndexException()
            : base()
        {
        }

        public InvalidArrayIndexException(string? message)
            : base(message)
        {
        }

        public InvalidArrayIndexException(string? message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected InvalidArrayIndexException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
