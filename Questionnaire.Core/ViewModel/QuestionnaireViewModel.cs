using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Questionnaire.Core.Abstract;
using Questionnaire.Core.Dal;
using Questionnaire.Core.Model;
using Windows.UI.Xaml;
using Questionnaire.Core.Commands;
using Questionnaire.Core.Controls;
using System;

namespace Questionnaire.Core.ViewModel
{
    public class QuestionnaireViewModel : ViewModel
    {
        private readonly IQuestionnaireDataSource dataSource = new QuestionnaireDataSource();
        private readonly ItemsHub hub;
        private readonly Action<bool> callback;

        private List<AnswerViewModel> _questions;


        public QuestionnaireViewModel(ItemsHub hub, Action<bool> callbackSave)
        {
            this.hub = hub;
            callback = callbackSave;
        }

        public ItemsHub Hub
        {
            get { return hub; }
        }

        public List<AnswerViewModel> Questions
        {
            get
            {
                if (_questions == null)
                {
                    _questions = new List<AnswerViewModel>();
                    List<Question> _q = dataSource.GetAllQuestions(null, null);

                    for (int i = 1; i <= _q.Count; i++)
                    {
                        _questions.Add(new AnswerViewModel
                        {
                            ActualWidth = Window.Current.Bounds.Width,
                            MaxNumber = _q.Count,
                            Number = i,
                            Question = _q[i - 1]
                        });
                    }
                }

                return _questions;
            }
        }

        public bool AllRequiredQuestionsiSAnswered()
        {
            foreach (var answer in Questions)
            {
                if (answer.Question.IsRequire)
                {
                    switch (answer.Question.QuestionType)
                    {
                        case QuestionType.Open:
                            if (String.IsNullOrEmpty(answer.OpenOrScale))
                                return false;
                            break;
                        case QuestionType.CloseMulti:
                            if (answer.MultiAnswers == null || !answer.MultiAnswers.Any())
                                return false;
                            break;
                        case QuestionType.CloseOne:
                            if (answer.RadioAnswer == null)
                                return false;
                            break;
                        case QuestionType.CloseScale:
                            if (String.IsNullOrEmpty(answer.OpenOrScale))
                                return false;
                            break;
                    } 
                }
            }

            return true;
        }

        private ICommand _changeSizeCommand;

        public ICommand ChangeSizeCommand
        {
            get { return _changeSizeCommand ?? (_changeSizeCommand = new QuestionnaireSizeChangedCommand()); }
        }

        private ICommand _saveCommand;

        public ICommand SaveCommand
        {
            get { return _saveCommand ?? (_saveCommand = new SaveQuestionnaireCommand(callback)); }
        }

    }
}
