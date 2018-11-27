using System;

namespace App.Domain.Exceptions
{
    public abstract class AppException : Exception
    {
        public AppException(Error error, Exception innerException = null)
            : base(error.Message, innerException)
        {

        }
    }
}
