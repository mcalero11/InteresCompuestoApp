﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace InteresCompuestoApp.Forms.Converters
{
    public class OpacityLabelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is bool)
            {
                if ((bool)value)
                {
                    return 1;
                }
                else
                {
                    return 0.2;
                }
            }
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
