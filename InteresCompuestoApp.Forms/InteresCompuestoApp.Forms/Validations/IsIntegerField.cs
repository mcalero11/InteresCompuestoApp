using InteresCompuestoApp.Forms.Validations.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace InteresCompuestoApp.Forms.Validations
{
    class IsIntegerField<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }

        public bool Check(T value)
        {
            if (value == null) return false;

            var str = value as string;
            decimal number = 0;


            var flag =  decimal.TryParse(str, out number);
            if (!flag) return false;
            if (number < 0) return false;

            return flag;
        }

        public IsIntegerField(string message = "")
        {
            ValidationMessage = message;
        }
    }
}
