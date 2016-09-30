using System;
using System.Runtime.Serialization;

namespace PhoneBook
{
    [Serializable]
    internal class DuplicateIndexException : Exception
    {
        public DuplicateIndexException()
        {
        }

        public DuplicateIndexException(string message) : base(message)
        {
        }

        public DuplicateIndexException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DuplicateIndexException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}