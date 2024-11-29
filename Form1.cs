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

        // ������������������� �����������
        public Form1(GameMode mode)
        {
            InitializeComponent();
            gameMode = mode;
            InitializeGame();
        }

        // ��������less ����������� ��� ������ � ����������
        public Form1() : this(GameMode.PlayerVsPlayer)
        {
        }

        private void InitializeGame()
        {
            game = new Game();
            game.MoveMade += Game_MoveMade;
            game.GameEnded += Game_GameEnded;
            UpdateStatus();

            // ���� ����� PlayerVsComputer � ��������� ����� ������ (��������, O)
            if (gameMode == GameMode.PlayerVsComputer && game.CurrentPlayer == Player.O)
            {
                MakeComputerMove();
            }
        }

        private void Game_MoveMade(Player player, int row, int col)
        {
            string buttonName = $"button{row}{col}";
            // ����� ������ �� ����� ������ tableLayoutPanel1
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
                MessageBox.Show($"������� ����� {winner}!", "������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DisableAllButtons();
            }
            else if (state == GameState.Draw)
            {
                MessageBox.Show("�����!", "���� ���������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DisableAllButtons();
            }

            UpdateStatus();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button? btn = sender as Button;
            if (btn == null || game.State != GameState.Ongoing)
                return;

            // ����������� ������� ������ �� ����� (��������, button00)
            string name = btn.Name;
            if (name.Length != 8)
                return; // �������� ������������ ����� ������

            // ���������� �������� ������ � ������� �� ����� ������
            if (!int.TryParse(name[6].ToString(), out int row) || !int.TryParse(name[7].ToString(), out int col))
                return; // �������� ������������ ��������

            if (game.MakeMove(row, col))
            {
                // ���� ����� ���� ������ ���������� � ���� ������������, ������ ��� ����������
                if (gameMode == GameMode.PlayerVsComputer && game.State == GameState.Ongoing)
                {
                    MakeComputerMove();
                }
            }
        }

        private void MakeComputerMove()
        {
            // ������� ��� ������ ������
            var emptyCells = from r in Enumerable.Range(0, 3)
                             from c in Enumerable.Range(0, 3)
                             where game.Board[r, c] == Player.None
                             select new { Row = r, Col = c };

            if (!emptyCells.Any())
                return; // ��� ��������� �����

            // �������� ��������� ������ ������
            var random = new Random();
            var move = emptyCells.ElementAt(random.Next(emptyCells.Count()));

            // ��������� ���
            game.MakeMove(move.Row, move.Col);
        }

        private void HighlightWinningLine()
        {
            if (game.WinningLine == null)
                return;

            var start = game.WinningLine.Item1;
            var end = game.WinningLine.Item2;

            if (start.Item1 == end.Item1) // �������������� �����
            {
                for (int col = 0; col < 3; col++)
                {
                    var btn = tableLayoutPanel1.GetControlFromPosition(col, start.Item1) as Button;
                    if (btn != null)
                        btn.BackColor = Color.LightGreen;
                }
            }
            else if (start.Item2 == end.Item2) // ������������ �����
            {
                for (int row = 0; row < 3; row++)
                {
                    var btn = tableLayoutPanel1.GetControlFromPosition(start.Item2, row) as Button;
                    if (btn != null)
                        btn.BackColor = Color.LightGreen;
                }
            }
            else // ������������ �����
            {
                if (start.Item1 == 0 && start.Item2 == 0) // ������� ���������
                {
                    for (int i = 0; i < 3; i++)
                    {
                        var btn = tableLayoutPanel1.GetControlFromPosition(i, i) as Button;
                        if (btn != null)
                            btn.BackColor = Color.LightGreen;
                    }
                }
                else // �������� ���������
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
                lblStatus.Text = $"���: {game.CurrentPlayer}";
            }
            else if (game.State == GameState.Win)
            {
                lblStatus.Text = $"�������: {game.Winner}";
            }
            else if (game.State == GameState.Draw)
            {
                lblStatus.Text = "�����!";
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            game.Reset();
            lblStatus.Text = $"���: {game.CurrentPlayer}";
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                if (control is Button btn)
                {
                    btn.Text = "";
                    btn.Enabled = true;
                    btn.BackColor = SystemColors.Control;
                }
            }

            // ���� ����� PlayerVsComputer � ������� ����� � ���������, ������� ���
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
