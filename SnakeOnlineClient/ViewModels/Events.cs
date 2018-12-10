using Prism.Events;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SnakeOnlineClient.ViewModels
{
    public class GameInfoEvent : PubSubEvent<string>
    {
    }
    public class GameStartInfo
    {
        public bool isStarted { get; set; }
        public string Nickname { get; set; }
        public Client client { get; set; }
        public string Token { get; set; }
    }
    public class GameStartInfoEvent : PubSubEvent<GameStartInfo>
    {
    }
    public class DirectionEvent : PubSubEvent<string>
    {
    }

    public class User
    {
        public int Score { get; set; }
        public string Name { get; set; }
        public User (string name, int score)
        {
            Name = name;
            Score = score;
        }
    }
    public class RoundInfo
    {
        public ObservableCollection<User> Players;
        public int Round;
    }
    public class RoundEvent : PubSubEvent<RoundInfo>
    {

    }
}
