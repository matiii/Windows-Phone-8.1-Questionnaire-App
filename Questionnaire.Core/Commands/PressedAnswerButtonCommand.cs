using System;
using System.Windows.Input;
using Questionnaire.Core.Model;

namespace Questionnaire.Core.Commands
{
    public class PressedAnswerButtonCommand: ICommand
    {

        private readonly Action<object> answer;

        public PressedAnswerButtonCommand(Action<object> answer)
        {
            this.answer = answer;
        }


        public bool CanExecute(object parameter)
        {
            return parameter is Answer || parameter is string || parameter is int;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            answer(parameter);
        }
    }
}
