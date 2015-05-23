using Questionnaire.Core.Commands;
using Questionnaire.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace Questionnaire.Core.ViewModel
{
    public class AnswerViewModel : ViewModel
    {
        private string _openOrScaleAnswer;
        private Answer _radioAnswer;
        private readonly List<Answer> _multiAnswers = new List<Answer>();

        public Question Question { get; set; }
        private double _actualWidth;

        public double ActualWidth
        {
            get { return _actualWidth; }
            set
            {
                if (_actualWidth != value)
                {
                    _actualWidth = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public int Number { get; set; }
        public int MaxNumber { get; set; }


        private ICommand _pressedButton;


        public string OpenOrScale
        {
            get { return _openOrScaleAnswer; }
            set
            {
                if (_openOrScaleAnswer != value)
                {
                    _openOrScaleAnswer = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public Answer RadioAnswer
        {
            get { return _radioAnswer; }
            set { _radioAnswer = value; }
        }


        public List<Answer> MultiAnswers
        {
            get { return _multiAnswers; }
        } 

        public ICommand PressedButtonCommand
        {
            get
            {
                return _pressedButton ?? (_pressedButton = new PressedAnswerButtonCommand(a =>
                    {

                        switch (Question.QuestionType)
                        {
                            case QuestionType.Open:
                                _openOrScaleAnswer = (string)a;
                                break;
                            case QuestionType.CloseMulti:
                                var answer = (Answer)a;
                                if (_multiAnswers.Any(ans => ans.Equals(answer)))
                                    _multiAnswers.Remove(answer);
                                else
                                    _multiAnswers.Add(answer);
                                break;
                            case QuestionType.CloseOne:
                                _radioAnswer = (Answer)a;
                                break;
                            case QuestionType.CloseScale:
                                _openOrScaleAnswer = a.ToString();
                                break;
                        }

                    }));
            }
        }

        public override string ToString()
        {
            return String.Format("{0}/{1}", Number, MaxNumber);
        }
    }
}
