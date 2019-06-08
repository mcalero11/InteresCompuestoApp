﻿using System;
using System.Collections.Generic;
using System.Text;

namespace InteresCompuestoApp.Forms.Validations.Base
{
    public interface IValidationRule<T>
    {
        string ValidationMessage { get; set; }
        bool Check(T value);
    }
}
