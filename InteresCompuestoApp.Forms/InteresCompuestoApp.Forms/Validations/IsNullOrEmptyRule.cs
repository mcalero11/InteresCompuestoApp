using InteresCompuestoApp.Forms.Validations.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace InteresCompuestoApp.Forms.Validations
{
    public class IsNullOrEmptyRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }

        public bool Check(T value)
        {
            if (value == null) return false;

            var str = value as string;
            return !string.IsNullOrWhiteSpace(str);
        }

        public IsNullOrEmptyRule(string message = "")
        {
            ValidationMessage = message;
        }
    }
}
