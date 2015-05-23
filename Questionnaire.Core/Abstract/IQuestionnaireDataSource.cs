using System.Collections.Generic;
using System.Globalization;
using Questionnaire.Core.Model;

namespace Questionnaire.Core.Abstract
{
    public interface IQuestionnaireDataSource
    {
        List<Question> GetAllQuestions(Event e, CultureInfo culture);
    }
}
