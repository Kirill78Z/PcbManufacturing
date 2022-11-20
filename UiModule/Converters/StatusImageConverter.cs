using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using BusinessLogic;

namespace UiModule.Converters
{
    public class StatusImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || !(value is Status status))
                return DependencyProperty.UnsetValue;

            switch (status)
            {
                case Status.UpToDate:
                    return new BitmapImage(new Uri("pack://application:,,,/Common;component/Images/icons8-done-30.png"));
                case Status.Updating:
                    return new BitmapImage(new Uri("pack://application:,,,/Common;component/Images/icons8-refresh-30.png"));
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
