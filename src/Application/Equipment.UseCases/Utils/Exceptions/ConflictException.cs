using System;

namespace Equipment.UseCases.Utils.Exceptions
{
    public class ConflictException : Exception
    {
        public ConflictException(string message)
            : base(message)
        {

        }
    }
}
