using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Automation.Provider;
using System.Windows.Data;
using System.Windows.Media;

namespace Common.Converters
{
    public class IntToSolidBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || !(value is Int32 intColor)) 
                return DependencyProperty.UnsetValue;

            byte[] buffer = BitConverter.GetBytes(intColor);
            return new SolidColorBrush(Color.FromRgb(buffer[0], buffer[1], buffer[2]));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
