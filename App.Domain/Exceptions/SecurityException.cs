using System;

namespace App.Domain.Exceptions
{
    public class SecurityException : AppException
    {
        public SecurityException(Error error, Exception innerException = null) : base(error, innerException)
        {
        }
    }
}
