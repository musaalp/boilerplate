using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string message) : base(message)
        {
        }
    }
}
