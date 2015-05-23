using System;
using Windows.UI.Xaml.Data;
using Questionnaire.Core.Model;
using Windows.UI.Xaml;

namespace Questionnaire.Core.Converters
{
    public class AnswerVisibilityConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var arg = (string) parameter;
            var data = (Question) value;

            switch (arg)
            {
                case "radio":
                    if (data.QuestionType == QuestionType.CloseOne)
                        return Visibility.Visible;
                    break;
                case "check":
                    if (data.QuestionType == QuestionType.CloseMulti)
                        return Visibility.Visible;
                    break;
                case "open":
                    if (data.QuestionType == QuestionType.Open)
                        return Visibility.Visible;
                    break;
                case "scale":
                    if (data.QuestionType == QuestionType.CloseScale)
                        return Visibility.Visible;
                    break;
            }

            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return null;
        }
    }
}
