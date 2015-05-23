using System.Collections.Generic;

namespace Questionnaire.Core.Model
{
    public class CachedAnswer
    {
        public QuestionType QuestionType { get; set; }
        public int RadioAnswerId { get; set; }
        public List<int> MultiAnswer { get; set; }
        public string OpenOrScale { get; set; }
    }
}
