using Prism.Events;
using Prism.Mvvm;
using SnakeOnlineClient.ViewModels.Commands;
using System.ComponentModel;
using System.Windows.Input;

namespace SnakeOnlineClient.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public new event PropertyChangedEventHandler PropertyChanged = (a, s) => { };

        public IEventAggregator _eventAggregator;
        public MainWindowViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        private string _title = "Snake Client";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        
        private ICommand leftCommand;
        public ICommand LeftCommand
        {
            get
            {
                return leftCommand
                    ?? (leftCommand = new ActionCommand(() =>
                    {
                        _eventAggregator.GetEvent<DirectionEvent>().Publish("Left");
                    }));
            }
        }
        private ICommand rightCommand;
        public ICommand RightCommand
        {
            get
            {
                return rightCommand
                    ?? (rightCommand = new ActionCommand(() =>
                    {
                        _eventAggregator.GetEvent<DirectionEvent>().Publish("Right");
                    }));
            }
        }
        private ICommand upCommand;
        public ICommand UpCommand
        {
            get
            {
                return upCommand
                    ?? (upCommand = new ActionCommand(() =>
                    {
                        _eventAggregator.GetEvent<DirectionEvent>().Publish("Top");
                    }));
            }
        }
        private ICommand downCommand;
        public ICommand DownCommand
        {
            get
            {
                return downCommand
                    ?? (downCommand = new ActionCommand(() =>
                    {
                        _eventAggregator.GetEvent<DirectionEvent>().Publish("Bottom");
                    }));
            }
        }
    }
}
