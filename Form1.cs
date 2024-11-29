using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        private Game game = null!;
        private GameMode gameMode;

        // Параметризированный конструктор
        public Form1(GameMode mode)
        {
            InitializeComponent();
            gameMode = mode;
            InitializeGame();
        }

        // Параметрless конструктор для работы с дизайнером
        public Form1() : this(GameMode.PlayerVsPlayer)
        {
        }

        private void InitializeGame()
        {
            game = new Game();
            game.MoveMade += Game_MoveMade;
            game.GameEnded += Game_GameEnded;
            UpdateStatus();

            // Если режим PlayerVsComputer и компьютер ходит первым (например, O)
            if (gameMode == GameMode.PlayerVsComputer && game.CurrentPlayer == Player.O)
            {
                MakeComputerMove();
            }
        }

        private void Game_MoveMade(Player player, int row, int col)
        {
            string buttonName = $"button{row}{col}";
            // Найти кнопку по имени внутри tableLayoutPanel1
            Button? btn = tableLayoutPanel1.Controls.OfType<Button>().FirstOrDefault(b => b.Name == buttonName);
            if (btn != null)
            {
                btn.Text = player == Player.X ? "X" : "O";
                btn.Enabled = false;
            }
        }

        private void Game_GameEnded(GameState state, Player winner)
        {
            if (state == GameState.Win)
            {
                HighlightWinningLine();
                MessageBox.Show($"Победил игрок {winner}!", "Победа", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DisableAllButtons();
            }
            else if (state == GameState.Draw)
            {
                MessageBox.Show("Ничья!", "Игра завершена", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DisableAllButtons();
            }

            UpdateStatus();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button? btn = sender as Button;
            if (btn == null || game.State != GameState.Ongoing)
                return;

            // Определение позиции кнопки по имени (например, button00)
            string name = btn.Name;
            if (name.Length != 8)
                return; // Проверка корректности имени кнопки

            // Извлечение индексов строки и столбца из имени кнопки
            if (!int.TryParse(name[6].ToString(), out int row) || !int.TryParse(name[7].ToString(), out int col))
                return; // Проверка корректности индексов

            if (game.MakeMove(row, col))
            {
                // Если режим игры против компьютера и игра продолжается, делаем ход компьютера
                if (gameMode == GameMode.PlayerVsComputer && game.State == GameState.Ongoing)
                {
                    MakeComputerMove();
                }
            }
        }

        private void MakeComputerMove()
        {
            // Находим все пустые ячейки
            var emptyCells = from r in Enumerable.Range(0, 3)
                             from c in Enumerable.Range(0, 3)
                             where game.Board[r, c] == Player.None
                             select new { Row = r, Col = c };

            if (!emptyCells.Any())
                return; // Нет доступных ходов

            // Выбираем случайную пустую ячейку
            var random = new Random();
            var move = emptyCells.ElementAt(random.Next(emptyCells.Count()));

            // Выполняем ход
            game.MakeMove(move.Row, move.Col);
        }

        private void HighlightWinningLine()
        {
            if (game.WinningLine == null)
                return;

            var start = game.WinningLine.Item1;
            var end = game.WinningLine.Item2;

            if (start.Item1 == end.Item1) // Горизонтальная линия
            {
                for (int col = 0; col < 3; col++)
                {
                    var btn = tableLayoutPanel1.GetControlFromPosition(col, start.Item1) as Button;
                    if (btn != null)
                        btn.BackColor = Color.LightGreen;
                }
            }
            else if (start.Item2 == end.Item2) // Вертикальная линия
            {
                for (int row = 0; row < 3; row++)
                {
                    var btn = tableLayoutPanel1.GetControlFromPosition(start.Item2, row) as Button;
                    if (btn != null)
                        btn.BackColor = Color.LightGreen;
                }
            }
            else // Диагональная линия
            {
                if (start.Item1 == 0 && start.Item2 == 0) // Главная диагональ
                {
                    for (int i = 0; i < 3; i++)
                    {
                        var btn = tableLayoutPanel1.GetControlFromPosition(i, i) as Button;
                        if (btn != null)
                            btn.BackColor = Color.LightGreen;
                    }
                }
                else // Побочная диагональ
                {
                    for (int i = 0; i < 3; i++)
                    {
                        var btn = tableLayoutPanel1.GetControlFromPosition(i, 2 - i) as Button;
                        if (btn != null)
                            btn.BackColor = Color.LightGreen;
                    }
                }
            }
        }

        private void UpdateStatus()
        {
            if (game.State == GameState.Ongoing)
            {
                lblStatus.Text = $"Ход: {game.CurrentPlayer}";
            }
            else if (game.State == GameState.Win)
            {
                lblStatus.Text = $"Победил: {game.Winner}";
            }
            else if (game.State == GameState.Draw)
            {
                lblStatus.Text = "Ничья!";
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            game.Reset();
            lblStatus.Text = $"Ход: {game.CurrentPlayer}";
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                if (control is Button btn)
                {
                    btn.Text = "";
                    btn.Enabled = true;
                    btn.BackColor = SystemColors.Control;
                }
            }

            // Если режим PlayerVsComputer и текущий игрок — компьютер, сделать ход
            if (gameMode == GameMode.PlayerVsComputer && game.CurrentPlayer == Player.O)
            {
                MakeComputerMove();
            }
        }

        private void DisableAllButtons()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                if (control is Button btn)
                {
                    btn.Enabled = false;
                }
            }
        }
    }
}
