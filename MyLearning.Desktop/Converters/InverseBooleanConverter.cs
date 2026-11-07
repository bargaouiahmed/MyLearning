using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Data.Converters;

namespace MyLearning.Desktop.Converters
{
    public sealed class InverseBooleanConverter : IValueConverter
    { 
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo cultureInfo)

        {
            return value is bool boolean && !boolean;
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo cultureInfo)
        {
            return value is bool boolean && !boolean;
        }
    }

}