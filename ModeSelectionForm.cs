using System;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class ModeSelectionForm : Form
    {
        public GameMode SelectedMode { get; private set; }

        public ModeSelectionForm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (rbPlayerVsComputer.Checked)
            {
                SelectedMode = GameMode.PlayerVsComputer;
            }
            else
            {
                SelectedMode = GameMode.PlayerVsPlayer;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
