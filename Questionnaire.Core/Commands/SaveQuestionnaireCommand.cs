using System;
using System.Windows.Input;
using Windows.UI.Popups;
using Questionnaire.Core.ViewModel;

namespace Questionnaire.Core.Commands
{
    public class SaveQuestionnaireCommand : ICommand
    {
        private readonly Action<bool> callback;

        public SaveQuestionnaireCommand(Action<bool> callback)
        {
            this.callback = callback;
        }

        public bool CanExecute(object parameter)
        {
            return parameter is QuestionnaireViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public async void Execute(object parameter)
        {
            var data = (QuestionnaireViewModel)parameter;

            bool result = false;

            try
            {
                result = true;

                if (!data.AllRequiredQuestionsiSAnswered())
                {
                    var dialog =
                        new MessageDialog(
                            "You don't answser for all required questions. Are you sure to save questionnaire?", "Info");
                    dialog.Commands.Add(new UICommand { Id = 1, Label = "Save" });
                    dialog.Commands.Add(new UICommand { Id = 2, Label = "Cancel" });

                    var res = await dialog.ShowAsync();

                    if (res.Id.Equals(2))
                    {
                        return;
                    }
                }

            }
            catch
            {
            }


            if (callback != null)
                callback(result);
        }
    }
}
