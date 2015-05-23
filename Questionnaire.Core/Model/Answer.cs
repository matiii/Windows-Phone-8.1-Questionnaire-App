using System;

namespace Questionnaire.Core.Model
{
    public class Answer : IIdentifiable
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }
}
