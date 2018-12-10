using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System.ComponentModel;

namespace SnakeOnlineClient.ViewModels
{
    public class MenuViewModel : BindableBase
    {
        private Client client = new Client("http://safeboard.northeurope.cloudapp.azure.com");

        private string _Token = "r>03p-84a^_]o3EYv)8}";
        public string Token
        {
            get
            {
                return _Token;
            }
            set
            {
                SetProperty(ref _Token, value);
            }
        }
        public new event PropertyChangedEventHandler PropertyChanged = (a, s) => { };
        public IEventAggregator _eventAggregator;
        public MenuViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            StartCommand = new DelegateCommand(StartGame);
        }

        public DelegateCommand StartCommand { get; set; }
        private async void StartGame()
        {
            string nickname = await client.GetNameAsync(Token);
            _eventAggregator.GetEvent<GameInfoEvent>().Publish(nickname);
            GameStartInfo gameStartInfo = new GameStartInfo();
            gameStartInfo.isStarted = true;
            gameStartInfo.Nickname = nickname;
            gameStartInfo.Token = Token;
            gameStartInfo.client = client;
            _eventAggregator.GetEvent<GameStartInfoEvent>().Publish(gameStartInfo);
        }

    }
}
