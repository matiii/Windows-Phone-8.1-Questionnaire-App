using System.Collections.Generic;
using System.Globalization;
using Questionnaire.Core.Model;
using Questionnaire.Core.Abstract;

namespace Questionnaire.Core.Dal
{
    public class QuestionnaireDataSource : IQuestionnaireDataSource
    {
        public List<Question> GetAllQuestions(Event e, CultureInfo culture)
        {
             return new List<Question>
             {
                 new Question
                 {
                     Answers = new List<Answer>
                     {
                         new Answer
                         {
                             Id = 1,
                             Value = "Tak"
                         },
                         new Answer
                         {
                             Id = 2,
                             Value = "Nie"
                         }
                     },
                     Id = 1,
                     IsRequire = true,
                     QuestionType = QuestionType.CloseOne,
                     Value = "Lubisz Matrixa ?"
                 },
                 new Question
                 {
                     Answers = new List<Answer>
                     {
                         new Answer
                         {
                             Id = 3,
                             Value = "Neo"
                         },
                         new Answer
                         {
                             Id = 4,
                             Value = "Morfeusz"
                         },
                         new Answer
                         {
                             Id = 5,
                             Value = "Trinity"
                         }
                     },
                     Id = 2,
                     IsRequire = false,
                     QuestionType = QuestionType.CloseMulti,
                     Value = "Jake są Twoje ulubione postacie ?"
                 },
                 new Question
                 {
                     Answers = new List<Answer> {new Answer()},
                     Id = 3,
                     IsRequire = false,
                     QuestionType = QuestionType.CloseScale,
                     Value = "W skali od 1 do 10 podaj ocene filmu Matrix."
                 },
                 new Question
                 {
                     Answers = new List<Answer>{new Answer()},
                     Id = 4,
                     IsRequire = true,
                     QuestionType = QuestionType.Open,
                     Value = "Która scena najbardziej zapadła Ci w pamięć ?"
                 }
             };
        }
    }
}
