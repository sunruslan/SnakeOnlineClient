using Prism.Events;
using Prism.Mvvm;
using SnakeOnlineClient.Models;
using SnakeOnlineClient.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using Point = SnakeOnlineClient.Models.Point;

namespace SnakeOnlineClient.ViewModels
{
    public class GameBoardViewModel : BindableBase, INotifyPropertyChanged
    {
        private Client client;
        private string Token;
        readonly IEventAggregator _eventAggregator;
        private RoundInfo roundInfo = new RoundInfo();
        private GameBoardResponse _GameBoard;
        private string _Nickname;
        private ObservableCollection<ObservableCollection<CellType>> Cells;
        public new event PropertyChangedEventHandler PropertyChanged = (a, s) => { };

        public GameBoardViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<GameStartInfoEvent>().Subscribe(GameStart);
            _eventAggregator.GetEvent<DirectionEvent>().Subscribe(Post);
        }
        private async void GameStart (GameStartInfo gameStartInfo)
        {
            if (!gameStartInfo.isStarted)
            {
                return;
            }
            _Nickname = gameStartInfo.Nickname;
            roundInfo.Players = new ObservableCollection<User>();
            client = gameStartInfo.client;
            Token = gameStartInfo.Token;
            _GameBoard = await client.GetGameBoardAsync();
            client.PostSnakeDirection(Token, "Left");
            DispatcherTimer timer1 = new DispatcherTimer();
            timer1.Tick += new EventHandler(GameStep);
            timer1.Interval = TimeSpan.FromMilliseconds(_GameBoard.TurnTimeMilleseconds);
            timer1.Start();
        }
        private async void GameStep(object sender, EventArgs e)
        {
            _GameBoard = await client.GetGameBoardAsync();
            roundInfo.Players.Clear();
            UpdateCells(_GameBoard, roundInfo.Round != _GameBoard.RoundNumber);
            roundInfo.Round = _GameBoard.RoundNumber;
            _eventAggregator.GetEvent<RoundEvent>().Publish(roundInfo);
        }


        private async void Post(string direction)
        {
            await Task.Delay(_GameBoard.TimeUntilNextTurnMilleseconds);
            client.PostSnakeDirection(Token, direction);
        }
        private void UpdateCells(GameBoardResponse gameBoard, bool full = false)
        {
            var height = 2 + gameBoard.GameBoardSize.Height;
            var width = 2 + gameBoard.GameBoardSize.Width;
            if (Cells is null || full && (height != Cells.Count() || width != Cells.Count()))
            {
                Cells = new ObservableCollection<ObservableCollection<CellType>>();
                for (int i = 0; i < height; ++i)
                {
                    ObservableCollection<CellType> Row = new ObservableCollection<CellType>();
                    for (int j = 0; j < width; ++j)
                    {
                        if (j == 0 || j + 1 == width || i == 0 || i + 1 == height)
                        {
                            Row.Add(CellType.WALL);
                        }
                        else
                        {
                            Row.Add(CellType.EMPTY);
                        }
                    }
                    Cells.Add(Row);
                }
            }
            else
            {
                for (int i = 0; i < height; ++i)
                {
                    for (int j = 0; j < width; ++j)
                    {
                        if (Cells[i][j] != CellType.WALL)
                        {
                            Cells[i][j] = CellType.EMPTY;
                        }
                    }
                }
            }
            foreach (Point food in gameBoard.Food ?? Enumerable.Empty<Point>())
            {
                Cells[food.Y + 1][food.X + 1] = CellType.APPLE;
            }
            foreach (Player snake in gameBoard.Players ?? Enumerable.Empty<Player>())
            {
                roundInfo.Players.Add(new User(snake.Name, snake.Snake == null ? 0 :snake.Snake.Count));
                foreach (Point point in snake.Snake ?? Enumerable.Empty<Point>())
                {
                    if (snake.Name == _Nickname)
                    {
                        Cells[point.Y + 1][point.X + 1] = snake.IsSpawnPtotected ? CellType.MY_SNAKE_PROTECTED
                        : CellType.MY_SNAKE;
                    }
                    else
                    {
                        Cells[point.Y + 1][point.X + 1] = snake.IsSpawnPtotected ? CellType.ALIAN_SNAKE_PROTECTED
                        : CellType.ALIAN_SNAKE;
                    }
                }
            }
            if (full)
            {
                foreach (Wall wall in gameBoard.Walls ?? Enumerable.Empty<Wall>())
                {
                    for (int i = 0; i < wall.Height; ++i)
                    {
                        for (int j = 0; j < wall.Width; ++j)
                        {
                            Cells[wall.Y + i + 1][wall.X + j + 1] = CellType.WALL;
                        }
                    }
                }
            }
            PropertyChanged(this, new PropertyChangedEventArgs(nameof(GridCells)));
        }
        public ObservableCollection<ObservableCollection<CellType>> GridCells
        {
            get
            {
                return Cells;
            }
            set
            {
                Cells = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(GridCells)));
            }
        }
    }

    public enum CellType
    {
        MY_SNAKE = 1,
        MY_SNAKE_PROTECTED = 2,
        APPLE = 3,
        WALL = 4,
        ALIAN_SNAKE = 5,
        ALIAN_SNAKE_PROTECTED = 6,
        EMPTY = 7
    }

}
