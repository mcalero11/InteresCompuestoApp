using InteresCompuestoApp.Forms.Validations.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace InteresCompuestoApp.Forms.Validations
{
    public class IsDecimalField<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }

        public bool Check(T value)
        {
            if (value == null) return false;

            var str = value as string;
            decimal number = 0;
            
            return decimal.TryParse(str, out number);
        }

        public IsDecimalField(string message = "")
        {
            ValidationMessage = message;
        }
    }
}
