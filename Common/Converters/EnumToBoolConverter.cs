using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace Common.Converters
{
    [ValueConversion(typeof(Enum), typeof(bool))]
    public class EnumToBoolConverter : IValueConverter
    {
        public bool IsInverted { get; set; }
        public object Convert(object value, Type targetType, object parameter,
            CultureInfo culture)
        {
            if (value == null || parameter == null || (value.GetType() !=
                    typeof(Enum) && value.GetType().BaseType != typeof(Enum)))
                return DependencyProperty.UnsetValue;
            string enumValue = value.ToString();
            string targetValue = parameter.ToString();
            bool boolValue = enumValue.Equals(targetValue,
                StringComparison.InvariantCultureIgnoreCase);
            return IsInverted ? !boolValue : boolValue;
        }
        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null)
                return DependencyProperty.UnsetValue;
            bool boolValue = (bool)value;
            string targetValue = parameter.ToString();
            if ((boolValue && !IsInverted) || (!boolValue && IsInverted))
                return Enum.Parse(targetType, targetValue);
            return DependencyProperty.UnsetValue;
        }
    }

}
