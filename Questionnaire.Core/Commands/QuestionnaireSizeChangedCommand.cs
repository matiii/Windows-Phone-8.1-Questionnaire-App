using System;
using System.Windows.Input;
using Questionnaire.Core.ViewModel;
using Windows.UI.Xaml;

namespace Questionnaire.Core.Commands
{
    class QuestionnaireSizeChangedCommand: ICommand
    {
        public bool CanExecute(object parameter)
        {
            return parameter is QuestionnaireViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            var obj = (QuestionnaireViewModel) parameter;
            double currentWidth = Window.Current.Bounds.Width;


            foreach (var answerViewModel in obj.Questions)
            {
                answerViewModel.ActualWidth = currentWidth;
            }

            foreach (var hubSection in obj.Hub.Sections)
            {
                hubSection.Width = currentWidth;
            }
        }
    }
}
