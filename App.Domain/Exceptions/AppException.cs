using System;

namespace App.Domain.Exceptions
{
    public abstract class ExceptionBase : Exception
    {
        public ExceptionBase(Error error, Exception innerException = null)
            : base(error.Message, innerException)
        {

        }
    }
}
