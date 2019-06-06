using System;
using System.Collections.Generic;
using System.Text;

namespace InteresCompuestoApp.Forms.Helpers
{
    public static class DecimalExtension
    {
        public static double ToDouble(this decimal num)
        {
            return decimal.ToDouble(num);
        }
    }
}
