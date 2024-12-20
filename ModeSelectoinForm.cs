// ModeSelectionForm.cs
using System;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class ModeSelectionForm : Form
    {
        /// <summary>
        /// Выбранный режим игры.
        /// </summary>
        public GameMode SelectedMode { get; private set; }

        public ModeSelectionForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик события загрузки формы.
        /// </summary>
        private void ModeSelectionForm_Load(object sender, EventArgs e)
        {
            // Установить режим по умолчанию
            rbPlayerVsPlayer.Checked = true;
        }

        /// <summary>
        /// Обработчик события клика по кнопке "Начать игру".
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (rbPlayerVsPlayer.Checked)
            {
                SelectedMode = GameMode.PlayerVsPlayer;
            }
            else if (rbPlayerVsComputer.Checked)
            {
                SelectedMode = GameMode.PlayerVsComputer;
            }
            else
            {
                // По умолчанию устанавливаем PlayerVsPlayer, если ничего не выбрано
                SelectedMode = GameMode.PlayerVsPlayer;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
