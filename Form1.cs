using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TicTacToe;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        private Game game = null!;
        private GameMode gameMode;
        private Player player1;
        private Player player2;
        private Database db;
        private bool isGameInProgress = false; // Флаг для отслеживания состояния игры

        // Параметризированный конструктор
        public Form1(GameMode mode, Player player1, Player? player2 = null)
        {
            InitializeComponent();
            db = new Database();
            gameMode = mode;
            this.player1 = player1;
            if (player2 == null && gameMode == GameMode.PlayerVsComputer)
            {
                player2 = new Player("Компьютер", Marker.O);
            }
            this.player2 = player2!;
            InitializeGame();
        }

        // Параметрless конструктор для работы с дизайнером
        public Form1() : this(GameMode.PlayerVsPlayer, new Player("Игрок 1", Marker.X), new Player("Игрок 2", Marker.O))
        {
        }

        private void InitializeGame()
        {
            game = new Game(player1, player2);
            game.MoveMade += Game_MoveMade;
            game.GameEnded += Game_GameEnded;
            UpdateStatus();

            // Если режим PlayerVsComputer и компьютер ходит первым
            if (gameMode == GameMode.PlayerVsComputer && game.CurrentPlayer.Marker == Marker.O)
            {
                MakeComputerMove();
            }

            isGameInProgress = true; // Игра началась
            UpdateUI(); // Обновляем интерфейс
        }

        private void Game_MoveMade(Player player, int row, int col)
        {
            string buttonName = $"button{row}{col}";
            // Найти кнопку по имени внутри tableLayoutPanel1
            Button? btn = tableLayoutPanel1.Controls.OfType<Button>().FirstOrDefault(b => b.Name == buttonName);
            if (btn != null)
            {
                btn.Text = player.Marker.ToString();
                btn.Enabled = false;
            }
        }

        private void Game_GameEnded(GameState state, Player? winner)
        {
            if (state == GameState.Win && winner != null)
            {
                // Обновляем статистику победы и поражения
                db.UpdateStatistics(winner.Login, true);
                db.UpdateStatistics(game.CurrentPlayer.Login, false); // Игрок, который не победил

                HighlightWinningLine();
                MessageBox.Show($"Победил игрок {winner.Login}!", "Победа", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DisableAllButtons();
            }
            else if (state == GameState.Draw)
            {
                MessageBox.Show("Ничья!", "Игра завершена", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DisableAllButtons();
            }

            isGameInProgress = false; // Игра завершена
            UpdateUI();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button? btn = sender as Button;
            if (btn == null || game.State != GameState.Ongoing || !isGameInProgress)
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
                             where game.Board[r, c] == Marker.None
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
                lblStatus.Text = $"Ход: {game.CurrentPlayer.Login} ({game.CurrentPlayer.Marker})";
            }
            else if (game.State == GameState.Win && game.Winner != null)
            {
                lblStatus.Text = $"Победил: {game.Winner.Login}";
            }
            else if (game.State == GameState.Draw)
            {
                lblStatus.Text = "Ничья!";
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (isGameInProgress) // Если игра в процессе, не даем сбросить
            {
                MessageBox.Show("Невозможно сбросить игру во время раунда!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            game.Reset();
            lblStatus.Text = $"Ход: {game.CurrentPlayer.Login} ({game.CurrentPlayer.Marker})";
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
            if (gameMode == GameMode.PlayerVsComputer && game.CurrentPlayer.Marker == Marker.O)
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

        private void UpdateUI()
        {
            btnReset.Enabled = !isGameInProgress; // Делаем кнопку сброса неактивной, если игра идет
        }

        private void lblStatus_Click(object sender, EventArgs e)
        {
            // Ничего не происходит, просто событие по клику
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
