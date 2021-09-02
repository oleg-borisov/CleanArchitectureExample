using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Equipment.UseCases.Utils.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(List<ValidationFailure> validationFailures) 
            : base("Validation failures have occurred.")
        {
            ValidationFailures = validationFailures
                .Select(x => x.ToString())
                .ToList();
        }

        public List<string> ValidationFailures { get; private set; }
    }
}
