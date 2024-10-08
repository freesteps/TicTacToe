using System;
using System.Drawing;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        private Game _game;

        public Form1()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            _game = new Game();

            // Привязка событий к кнопкам
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                if (control is Button button)
                {
                    button.Text = "";
                    button.Enabled = true;
                    button.Click += Cell_Click;
                }
            }

            lblStatus.Text = $"Ход: {_game.CurrentPlayer}";
        }

        private void Cell_Click(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                // Определение позиции кнопки
                int row = tableLayoutPanel1.GetRow(button);
                int col = tableLayoutPanel1.GetColumn(button);

                // Сохраняем текущего игрока перед выполнением MakeMove
                Player currentPlayer = _game.CurrentPlayer;

                if (_game.MakeMove(row, col))
                {
                    // Обновляем текст кнопки с символом текущего игрока до вызова SwitchPlayer
                    button.Text = currentPlayer == Player.X ? "X" : "O";
                    button.Enabled = false;

                    if (_game.State == GameState.Win)
                    {
                        lblStatus.Text = $"Победитель: {currentPlayer}";
                        DisableAllButtons();
                    }
                    else if (_game.State == GameState.Draw)
                    {
                        lblStatus.Text = "Ничья!";
                        DisableAllButtons();
                    }
                    else
                    {
                        lblStatus.Text = $"Ход: {_game.CurrentPlayer}";
                    }
                }
            }
        }



        private void DisableAllButtons()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                if (control is Button button)
                {
                    button.Enabled = false;
                }
            }
        }

        private void OnGameEnded(Game game)
        {
            if (game.Winner == Player.None)
            {
                lblStatus.Text = "Ничья!";
            }
            else
            {
                lblStatus.Text = $"Победитель: {game.Winner}";
            }

            // Отключение всех кнопок
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                if (control is Button button)
                {
                    button.Enabled = false;
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            _game.Reset();
            InitializeGame();
        }
    }
}