using Questionnaire.Core.ViewModel;
using System;
using System.Linq;
using System.Windows.Input;

namespace Questionnaire.Core.Commands
{
    public class NameTextChangedCommand: ICommand
    {
        public bool CanExecute(object parameter)
        {
            return parameter is ScreenerViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public virtual void Execute(object parameter)
        {
            var viewModel = (ScreenerViewModel)parameter; //can't be null
            if (!viewModel.Names.Any(n => n == viewModel.Name))
                viewModel.NameSuggestBox.ItemsSource = viewModel.Names.Where(n => ContainsIgnoreCase(n, viewModel.Name));
        }

        protected bool ContainsIgnoreCase(string parameter, string compareSource)
        {
            return parameter.IndexOf(compareSource, StringComparison.CurrentCultureIgnoreCase) > -1;
        }
    }
}
