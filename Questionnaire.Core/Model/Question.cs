using System;
using System.Collections.Generic;

//TODO: implement nationalisation

namespace Questionnaire.Core.Model
{
    public class Question : IIdentifiable
    {
        public int Id { get; set; }
        public bool IsRequire { get; set; }
        public QuestionType QuestionType { get; set; }
        public string Value { get; set; }
        public IList<Answer> Answers { get; set; }
        
    }
}
