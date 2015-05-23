using System;
using Windows.UI.Xaml.Data;

namespace Questionnaire.Core.Converters
{
    public class DoubleToStringConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value == null ? value : value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value == null ? value : value.ToString();
        }
    }
}
