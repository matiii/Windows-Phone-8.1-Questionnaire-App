using Questionnaire.Core.ViewModel;
using System.Linq;

namespace Questionnaire.Core.Commands
{
    public class EventTextChangedCommand : NameTextChangedCommand
    {
        public override void Execute(object parameter)
        {
            var viewModel = parameter as ScreenerViewModel; //can't be null
            viewModel.Event = viewModel.Events.FirstOrDefault(e => e.Name == viewModel.EventName);

            if (viewModel.Event == null)
            {
                var events = viewModel.EventsString.Where(n => ContainsIgnoreCase(n, viewModel.EventName));
                viewModel.EventSuggestBox.ItemsSource = events;
            }

        }
    }
}
