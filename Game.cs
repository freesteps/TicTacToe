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
        public Player[,] Board { get; private set; }
        public Player CurrentPlayer { get; private set; }
        public GameState State { get; private set; }
        public Player Winner { get; private set; }

        public event Action<Player, int, int> MoveMade;
        public event Action<GameState, Player> GameEnded;

        public Game()
        {
            Board = new Player[3, 3];
            CurrentPlayer = Player.X;
            State = GameState.Ongoing;
            Winner = Player.None;
        }

        public bool MakeMove(int row, int col)
        {
            if (State != GameState.Ongoing || Board[row, col] != Player.None)
                return false;

            Board[row, col] = CurrentPlayer;
            if (CheckWin(row, col))
            {
                State = GameState.Win;
                Winner = CurrentPlayer;
                GameEnded?.Invoke(State, Winner);
            }
            else if (IsBoardFull())
            {
                State = GameState.Draw;
                GameEnded?.Invoke(State, Player.None);
            }
            else
            {
                SwitchPlayer();
            }

            MoveMade?.Invoke(CurrentPlayer, row, col);
            return true;
        }

        private void SwitchPlayer()
        {
            CurrentPlayer = CurrentPlayer == Player.X ? Player.O : Player.X;
        }

        private bool CheckWin(int row, int col)
        {
            // Check row
            if (Board[row, 0] == CurrentPlayer && Board[row, 1] == CurrentPlayer && Board[row, 2] == CurrentPlayer)
                return true;

            // Check column
            if (Board[0, col] == CurrentPlayer && Board[1, col] == CurrentPlayer && Board[2, col] == CurrentPlayer)
                return true;

            // Check diagonal (top-left to bottom-right)
            if (row == col && Board[0, 0] == CurrentPlayer && Board[1, 1] == CurrentPlayer && Board[2, 2] == CurrentPlayer)
                return true;

            // Check diagonal (top-right to bottom-left)
            if (row + col == 2 && Board[0, 2] == CurrentPlayer && Board[1, 1] == CurrentPlayer && Board[2, 0] == CurrentPlayer)
                return true;

            return false;
        }

        private bool IsBoardFull()
        {
            foreach (var cell in Board)
            {
                if (cell == Player.None)
                {
                    return false;
                }
            }
            return true;
        }

        public void Reset()
        {
            Board = new Player[3, 3];
            CurrentPlayer = Player.X;
            State = GameState.Ongoing;
            Winner = Player.None;
        }
    }
}