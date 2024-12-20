using System;
using System.Windows.Forms;
using TicTacToe;

static class Program
{
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        // �������� ����� ����� ��� ������� ������
        PlayerLoginForm loginForm = new PlayerLoginForm();
        var loginResult = loginForm.ShowDialog();

        if (loginResult == DialogResult.OK)
        {
            Player player1 = loginForm.LoggedInPlayer;

            // �������� ����� ������ ������
            using (ModeSelectionForm modeForm = new ModeSelectionForm())
            {
                var result = modeForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    GameMode selectedMode = modeForm.SelectedMode;

                    Player? player2 = null;

                    // ���� ������ ����� PlayerVsPlayer, ���������� ������� ������ ������ ����
                    if (selectedMode == GameMode.PlayerVsPlayer)
                    {
                        PlayerLoginForm secondPlayerLoginForm = new PlayerLoginForm();

                        bool isLoginUnique = false;
                        while (!isLoginUnique)
                        {
                            var secondPlayerResult = secondPlayerLoginForm.ShowDialog();

                            if (secondPlayerResult == DialogResult.OK)
                            {
                                if (secondPlayerLoginForm.LoggedInPlayer.Login == player1.Login)
                                {
                                    MessageBox.Show("����� ������� ������ �� ����� ��������� � ������� ������� ������.", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    player2 = secondPlayerLoginForm.LoggedInPlayer;
                                    isLoginUnique = true;
                                }
                            }
                            else
                            {
                                MessageBox.Show("������ ����� �� �����. ���� �� ����� ��������.", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Application.Exit();
                                return;
                            }
                        }
                    }
                    else
                    {
                        player2 = null;
                    }

                    // ��������� �������� ����� � ��������� ������� � ��������
                    Application.Run(new Form1(selectedMode, player1, player2));
                }
                else
                {
                    // ���� ������������ ������ ����� ������ ������, ��������� ����������
                    Application.Exit();
                }
            }
        }
        else
        {
            // ���� ���� ������� ������ �� ��� ��������, ��������� ����������
            Application.Exit();
        }
    }
}
