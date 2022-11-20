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
    public class StatusDescriptionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || !(value is Status status))
                return DependencyProperty.UnsetValue;

            switch (status)
            {
                case Status.UpToDate:
                    return Resources.EverithingIsUpToDate;
                case Status.Updating:
                    return Resources.Updating;
                case Status.Error:
                    return DependencyProperty.UnsetValue;//TODO
            }
            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
