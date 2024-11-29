using System;
using System.Windows.Forms;

namespace TicTacToe
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // —оздаем и показываем форму выбора режима
            using (ModeSelectionForm modeForm = new ModeSelectionForm())
            {
                var result = modeForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    // ѕолучаем выбранный режим
                    GameMode selectedMode = modeForm.SelectedMode;

                    // «апускаем основную форму с выбранным режимом
                    Application.Run(new Form1(selectedMode));
                }
                else
                {
                    // ≈сли пользователь закрыл форму без выбора, завершаем приложение
                    Application.Exit();
                }
            }
        }
    }
}
