// RegistrationForm.cs
using System;
using System.Windows.Forms;
using BCrypt.Net;

namespace TicTacToe
{
    public partial class RegistrationForm : Form
    {
        private Database db;

        public RegistrationForm()
        {
            InitializeComponent();
            db = new Database();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (db.UserExists(login))
            {
                DialogResult result = MessageBox.Show("Пользователь с таким логином уже существует. Войти?", "Пользователь существует", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    this.Close(); // Закрыть форму регистрации
                    PlayerLoginForm loginForm = new PlayerLoginForm();
                    loginForm.Show();
                }
                return;
            }

            // Хеширование пароля
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            db.RegisterUser(login, hashedPassword);
            MessageBox.Show("Регистрация успешна! Теперь вы можете войти.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close(); // Закрыть форму регистрации
            PlayerLoginForm lf = new PlayerLoginForm();
            lf.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {

        }
    }
}
