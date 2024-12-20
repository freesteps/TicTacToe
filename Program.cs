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

        // Показать форму входа для первого игрока
        PlayerLoginForm loginForm = new PlayerLoginForm();
        var loginResult = loginForm.ShowDialog();

        if (loginResult == DialogResult.OK)
        {
            Player player1 = loginForm.LoggedInPlayer;

            // Показать форму выбора режима
            using (ModeSelectionForm modeForm = new ModeSelectionForm())
            {
                var result = modeForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    GameMode selectedMode = modeForm.SelectedMode;

                    Player? player2 = null;

                    // Если выбран режим PlayerVsPlayer, предлагаем второму игроку пройти вход
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
                                    MessageBox.Show("Логин второго игрока не может совпадать с логином первого игрока.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    player2 = secondPlayerLoginForm.LoggedInPlayer;
                                    isLoginUnique = true;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Второй игрок не вошел. Игра не может начаться.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Application.Exit();
                                return;
                            }
                        }
                    }
                    else
                    {
                        player2 = null;
                    }

                    // Запускаем основную форму с выбранным режимом и игроками
                    Application.Run(new Form1(selectedMode, player1, player2));
                }
                else
                {
                    // Если пользователь закрыл форму выбора режима, завершаем приложение
                    Application.Exit();
                }
            }
        }
        else
        {
            // Если вход первого игрока не был успешным, завершаем приложение
            Application.Exit();
        }
    }
}
