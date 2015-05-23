using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;
using Questionnaire.Core.Abstract;
using Questionnaire.Core.Commands;
using Questionnaire.Core.Dal;
using Questionnaire.Core.Model;

namespace Questionnaire.Core.ViewModel
{
    public class ScreenerViewModel: ViewModel
    {
        private readonly IScreenerDataSource dataSource = new ScreenerDataSource();
        private readonly AutoSuggestBox nameSuggestBox;
        private readonly AutoSuggestBox eventSuggestBox;

        public ScreenerViewModel(AutoSuggestBox nameSuggestBox, AutoSuggestBox eventSuggestBox)
        {
            this.nameSuggestBox = nameSuggestBox;
            this.eventSuggestBox = eventSuggestBox;

            eventSuggestBox.SuggestionChosen += (obj, e) =>
            {
                var ev = e.SelectedItem as string;

                if (ev != null)
                {
                    _event = Events.First(v => v.Name == ev);
                }
            };
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                if (value != _name)
                {
                    _name = value;
                    NotifyPropertyChanged();
                    NotifyPropertyChanged("CanGoNext");
                }
            }
        }

        private string _eventName;

        public string EventName
        {
            get { return _eventName; }
            set
            {
                if (value != _eventName)
                {
                    _eventName = value;
                    NotifyPropertyChanged();
                    NotifyPropertyChanged("CanGoNext");
                }
            }
        }

        private Event _event;

        public Event Event
        {
            get { return _event; }
            set
            {
                if (value != _event)
                {
                    _event = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private IList<string> _names;

        public IList<string> Names
        {
            get { return _names ?? (_names = dataSource.GetAllNames()); }
        }

        private IList<Event> _events;

        public IList<Event> Events
        {
            get { return _events ?? (_events = dataSource.GetAllEvents()); }
        }

        public IList<string> EventsString
        {
            get
            {
                if (_events == null)
                {
                    _events = dataSource.GetAllEvents();
                }

                return _events.Select(e => e.Name).ToList();
            }
        }

        private ICommand _nameChangedCommand;

        public ICommand NameChangedCommand
        {
            get { return _nameChangedCommand ?? (_nameChangedCommand = new NameTextChangedCommand()); }
        }

        private ICommand _eventChangedCommand;

        public ICommand EventChangedCommand
        {
            get { return _eventChangedCommand ?? (_eventChangedCommand = new EventTextChangedCommand()); }
        }

        public AutoSuggestBox NameSuggestBox
        {
            get { return nameSuggestBox; }
        }

        public AutoSuggestBox EventSuggestBox
        {
            get { return eventSuggestBox; }
        }

        public bool CanGoNext
        {
            get
            {
                return Names.Any(n => n == Name) && Events.Any(e => e == Event);
            }
        }
    }
}
