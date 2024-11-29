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

            // ������� � ���������� ����� ������ ������
            using (ModeSelectionForm modeForm = new ModeSelectionForm())
            {
                var result = modeForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    // �������� ��������� �����
                    GameMode selectedMode = modeForm.SelectedMode;

                    // ��������� �������� ����� � ��������� �������
                    Application.Run(new Form1(selectedMode));
                }
                else
                {
                    // ���� ������������ ������ ����� ��� ������, ��������� ����������
                    Application.Exit();
                }
            }
        }
    }
}
