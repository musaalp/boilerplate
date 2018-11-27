using System;

namespace App.Domain.Exceptions
{
    public class SecurityException : ExceptionBase
    {
        public SecurityException(Error error, Exception innerException = null) : base(error, innerException)
        {
        }
    }
}
