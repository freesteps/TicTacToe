// Player.cs
namespace TicTacToe
{
    public class Player
    {
        public string Login { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public Marker Marker { get; set; }

        public Player(string login, Marker marker = Marker.None)
        {
            Login = login;
            Wins = 0;
            Losses = 0;
            Marker = marker;
        }
    }
}
