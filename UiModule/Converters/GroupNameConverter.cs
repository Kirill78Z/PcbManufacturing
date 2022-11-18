using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;
using BusinessLogic;
using Common.Properties;

namespace UiModule.Converters
{
    public class GroupNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || !(value is QuoteElementType type))
                return DependencyProperty.UnsetValue;

            switch (type)
            {
                case QuoteElementType.Fabrication:
                    return Resources.Fabrication;
                case QuoteElementType.Assembly:
                    return Resources.Assembly;
                case QuoteElementType.Components:
                    return Resources.Components;
            }
            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
