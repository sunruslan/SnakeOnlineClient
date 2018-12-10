using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeOnlineClient.Models
{
    public sealed class GameBoardResponse
    {
        public bool IsStarted { get; set; }
        public bool IsPaused { get; set; }
        public int RoundNumber { get; set; }
        public int TurnNumber { get; set; }
        public int TurnTimeMilleseconds { get; set; }
        public int TimeUntilNextTurnMilleseconds { get; set; }
        public Shape GameBoardSize {get; set;}
        public int MaxFood { get; set; }
        public List<Player> Players { get; set; }
        public List<Point> Food { get; set; }
        public List<Wall> Walls { get; set; }
    }
    public sealed class Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }
    public sealed class Player
    {
        public string Name { get; set; }
        public bool IsSpawnPtotected { get; set; }
        public List<Point> Snake { get; set; }
    }
    public sealed class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
    public sealed class Wall
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
