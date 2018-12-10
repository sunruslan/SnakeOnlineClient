using Prism.Events;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace SnakeOnlineClient.ViewModels
{
    public class InfoBarViewModel : BindableBase, INotifyPropertyChanged
    {

        private string _Nickname;
        public string Nickname
        {
            get
            {
                return _Nickname;
            }
            set
            {
                _Nickname = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Nickname)));
            }
        }
        private int _Round;
        public int Round
        {
            get
            {
                return _Round;
            }
            set
            {
                _Round = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Round)));
            }
        }
        private ObservableCollection<User> _Players;
        public ObservableCollection<User> Players
        {
            get
            {
                return _Players;
            }
            set
            {
                _Players = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Players)));
            }
        }
        private IEventAggregator _eventAggregator;
        public InfoBarViewModel(IEventAggregator eventAggregator)
        { 
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<GameInfoEvent>().Subscribe(UpdateNickname);
            _eventAggregator.GetEvent<RoundEvent>().Subscribe(UpdateRoundInfo);
        }
        public void UpdateNickname(string nickname)
        {
            Nickname = nickname;
        }
        public void UpdateRoundInfo(RoundInfo roundInfo)
        {
            Round = roundInfo.Round;
            Players = roundInfo.Players;
        }

        public new event PropertyChangedEventHandler PropertyChanged = (a, s) => { };
    }
}
