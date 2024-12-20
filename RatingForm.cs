// RatingForm.cs
using System;
using System.Data;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class RatingForm : Form
    {
        private Database db;

        public RatingForm()
        {
            InitializeComponent();
            db = new Database();
            LoadRatings();
        }

        private void LoadRatings()
        {
            try
            {
                DataTable ratings = db.GetRatings();
                if (ratings != null)
                {
                    dataGridViewRatings.DataSource = ratings;
                    dataGridViewRatings.Columns["user_login"].HeaderText = "Логин";
                    dataGridViewRatings.Columns["win_user"].HeaderText = "Победы";
                    dataGridViewRatings.Columns["lose_user"].HeaderText = "Поражения";
                    dataGridViewRatings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки рейтинга: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RatingForm_Load(object sender, EventArgs e)
        {

        }
    }
}
