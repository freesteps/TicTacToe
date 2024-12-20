// Game.cs
using System;

namespace TicTacToe
{
    public enum GameState
    {
        Ongoing,
        Draw,
        Win
    }

    public class Game
    {
        public Marker[,] Board { get; private set; } = new Marker[3, 3];
        public Player CurrentPlayer { get; private set; }
        public GameState State { get; private set; }
        public Player? Winner { get; private set; }

        // Координаты победной линии
        public Tuple<Tuple<int, int>, Tuple<int, int>>? WinningLine { get; private set; }

        public event Action<Player, int, int>? MoveMade;
        public event Action<GameState, Player?>? GameEnded;

        public Player Player1 { get; private set; }
        public Player Player2 { get; private set; }

        public Game(Player player1, Player player2)
        {
            Player1 = player1;
            Player2 = player2;
            Player1.Marker = Marker.X;
            Player2.Marker = Marker.O;
            Reset();
        }

        public bool MakeMove(int row, int col)
        {
            if (State != GameState.Ongoing || Board[row, col] != Marker.None)
                return false;

            Board[row, col] = CurrentPlayer.Marker;

            // Вызов MoveMade перед проверкой выигрыша
            MoveMade?.Invoke(CurrentPlayer, row, col);

            if (CheckWin(row, col))
            {
                State = GameState.Win;
                Winner = CurrentPlayer;
                GameEnded?.Invoke(State, Winner);
            }
            else if (IsBoardFull())
            {
                State = GameState.Draw;
                Winner = null;
                GameEnded?.Invoke(State, Winner);
            }
            else
            {
                SwitchPlayer();
            }

            return true;
        }

        private void SwitchPlayer()
        {
            CurrentPlayer = CurrentPlayer == Player1 ? Player2 : Player1;
        }

        private bool CheckWin(int row, int col)
        {
            Marker marker = Board[row, col];

            // Проверка строки
            if (Board[row, 0] == marker && Board[row, 1] == marker && Board[row, 2] == marker)
            {
                WinningLine = Tuple.Create(Tuple.Create(row, 0), Tuple.Create(row, 2));
                return true;
            }

            // Проверка столбца
            if (Board[0, col] == marker && Board[1, col] == marker && Board[2, col] == marker)
            {
                WinningLine = Tuple.Create(Tuple.Create(0, col), Tuple.Create(2, col));
                return true;
            }

            // Проверка главной диагонали
            if (row == col && Board[0, 0] == marker && Board[1, 1] == marker && Board[2, 2] == marker)
            {
                WinningLine = Tuple.Create(Tuple.Create(0, 0), Tuple.Create(2, 2));
                return true;
            }

            // Проверка побочной диагонали
            if (row + col == 2 && Board[0, 2] == marker && Board[1, 1] == marker && Board[2, 0] == marker)
            {
                WinningLine = Tuple.Create(Tuple.Create(0, 2), Tuple.Create(2, 0));
                return true;
            }

            return false;
        }

        private bool IsBoardFull()
        {
            foreach (var cell in Board)
            {
                if (cell == Marker.None)
                    return false;
            }
            return true;
        }

        public void Reset()
        {
            Board = new Marker[3, 3];
            CurrentPlayer = Player1;
            State = GameState.Ongoing;
            Winner = null;
            WinningLine = null;
        }
    }
}
