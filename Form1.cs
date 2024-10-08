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

            // �������� ������� � �������
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                if (control is Button button)
                {
                    button.Text = "";
                    button.Enabled = true;
                    button.Click += Cell_Click;
                }
            }

            lblStatus.Text = $"���: {_game.CurrentPlayer}";
        }

        private void Cell_Click(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                // ����������� ������� ������
                int row = tableLayoutPanel1.GetRow(button);
                int col = tableLayoutPanel1.GetColumn(button);

                // ��������� �������� ������ ����� ����������� MakeMove
                Player currentPlayer = _game.CurrentPlayer;

                if (_game.MakeMove(row, col))
                {
                    // ��������� ����� ������ � �������� �������� ������ �� ������ SwitchPlayer
                    button.Text = currentPlayer == Player.X ? "X" : "O";
                    button.Enabled = false;

                    if (_game.State == GameState.Win)
                    {
                        lblStatus.Text = $"����������: {currentPlayer}";
                        DisableAllButtons();
                    }
                    else if (_game.State == GameState.Draw)
                    {
                        lblStatus.Text = "�����!";
                        DisableAllButtons();
                    }
                    else
                    {
                        lblStatus.Text = $"���: {_game.CurrentPlayer}";
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
                lblStatus.Text = "�����!";
            }
            else
            {
                lblStatus.Text = $"����������: {game.Winner}";
            }

            // ���������� ���� ������
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