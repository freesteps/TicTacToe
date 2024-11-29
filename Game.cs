

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
        public Player[,] Board { get; private set; } = new Player[3, 3]; // Инициализация при объявлении
        public Player CurrentPlayer { get; private set; }
        public GameState State { get; private set; }
        public Player Winner { get; private set; }

        // Координаты победной линии
        public Tuple<Tuple<int, int>, Tuple<int, int>>? WinningLine { get; private set; }

        public event Action<Player, int, int>? MoveMade;
        public event Action<GameState, Player>? GameEnded;

        public Game()
        {
            Reset();
        }

        public bool MakeMove(int row, int col)
        {
            if (State != GameState.Ongoing || Board[row, col] != Player.None)
                return false;

            Player playerMadeMove = CurrentPlayer;

            Board[row, col] = CurrentPlayer;

            // Вызов MoveMade перед проверкой выигрыша
            MoveMade?.Invoke(playerMadeMove, row, col);

            if (CheckWin(row, col))
            {
                State = GameState.Win;
                Winner = CurrentPlayer;
                GameEnded?.Invoke(State, Winner);
            }
            else if (IsBoardFull())
            {
                State = GameState.Draw;
                Winner = Player.None;
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
            CurrentPlayer = CurrentPlayer == Player.X ? Player.O : Player.X;
        }

        private bool CheckWin(int row, int col)
        {
            // Проверка строки
            if (Board[row, 0] == CurrentPlayer && Board[row, 1] == CurrentPlayer && Board[row, 2] == CurrentPlayer)
            {
                WinningLine = Tuple.Create(Tuple.Create(row, 0), Tuple.Create(row, 2));
                return true;
            }

            // Проверка столбца
            if (Board[0, col] == CurrentPlayer && Board[1, col] == CurrentPlayer && Board[2, col] == CurrentPlayer)
            {
                WinningLine = Tuple.Create(Tuple.Create(0, col), Tuple.Create(2, col));
                return true;
            }

            // Проверка главной диагонали
            if (row == col && Board[0, 0] == CurrentPlayer && Board[1, 1] == CurrentPlayer && Board[2, 2] == CurrentPlayer)
            {
                WinningLine = Tuple.Create(Tuple.Create(0, 0), Tuple.Create(2, 2));
                return true;
            }

            // Проверка побочной диагонали
            if (row + col == 2 && Board[0, 2] == CurrentPlayer && Board[1, 1] == CurrentPlayer && Board[2, 0] == CurrentPlayer)
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
                if (cell == Player.None)
                    return false;
            }
            return true;
        }

        public void Reset()
        {
            Board = new Player[3, 3];
            CurrentPlayer = Player.X;
            State = GameState.Ongoing;
            Winner = Player.None;
            WinningLine = null;
        }
    }
}
