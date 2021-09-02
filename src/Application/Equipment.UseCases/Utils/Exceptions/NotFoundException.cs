using System;

namespace Equipment.UseCases.Utils.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, object key)
            : base($"Entity '{name}' ({key}) was not found!")
        {
        }
    }
}
