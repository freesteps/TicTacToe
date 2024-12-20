using System;
using System.Linq;
using System.Windows.Forms;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;

namespace TicTacToe
{
    // Настройка контекста базы данных
    public class TicTacToeContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        // Переопределяем метод OnConfiguring для подключения к базе данных PostgreSQL
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Указываем строку подключения к базе данных PostgreSQL
                optionsBuilder.UseNpgsql("Host=194.87.84.68;Port=5432;Username=windows_pc;Password=new_password;Database=tictactoe_db");
            }
        }

        // Переопределяем метод OnModelCreating для настройки схемы и таблицы
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Указываем схему 'user_list' для таблицы 'Users'
            modelBuilder.Entity<User>().ToTable("users", "user_list");

            // Настроим имена столбцов согласно схеме
            modelBuilder.Entity<User>()
                .Property(u => u.UserLogin)
                .HasColumnName("user_login");

            modelBuilder.Entity<User>()
                .Property(u => u.UserPassword)
                .HasColumnName("user_password");

            modelBuilder.Entity<User>()
                .Property(u => u.WinUser)
                .HasColumnName("win_user");

            modelBuilder.Entity<User>()
                .Property(u => u.LoseUser)
                .HasColumnName("lose_user");

            // Устанавливаем user_login как первичный ключ
            modelBuilder.Entity<User>()
                .HasKey(u => u.UserLogin);
        }
    }

    // Класс пользователя
    public class User
    {
        public string UserLogin { get; set; }  // Логин пользователя (ключ)
        public string UserPassword { get; set; }
        public int WinUser { get; set; }
        public int LoseUser { get; set; }
    }

    // Класс для работы с базой данных
    public class Database
    {
        // Метод для проверки существования пользователя
        public bool UserExists(string login)
        {
            try
            {
                using (var context = new TicTacToeContext())
                {
                    var user = context.Users.SingleOrDefault(u => u.UserLogin == login);
                    return user != null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при проверке пользователя: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Метод для валидации пользователя
        public bool ValidateUser(string login, string password)
        {
            try
            {
                using (var context = new TicTacToeContext())
                {
                    var user = context.Users.SingleOrDefault(u => u.UserLogin == login);
                    if (user == null)
                        return false;
                    return BCrypt.Net.BCrypt.Verify(password, user.UserPassword);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при проверке пользователя: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Метод для регистрации нового пользователя
        public void RegisterUser(string login, string hashedPassword)
        {
            try
            {
                using (var context = new TicTacToeContext())
                {
                    var user = new User
                    {
                        UserLogin = login,
                        UserPassword = hashedPassword,
                    };
                    context.Users.Add(user);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при регистрации пользователя: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Метод для обновления статистики пользователя
        public void UpdateStatistics(string login, bool isWin)
        {
            try
            {
                using (var context = new TicTacToeContext())
                {
                    var user = context.Users.SingleOrDefault(u => u.UserLogin == login);
                    if (user == null)
                        return;

                    if (isWin)
                        user.WinUser++;
                    else
                        user.LoseUser++;

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении статистики: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Метод для получения рейтингов пользователей
        public object GetRatings()
        {
            try
            {
                using (var context = new TicTacToeContext())
                {
                    var ratings = context.Users
                        .OrderByDescending(u => u.WinUser)
                        .Select(u => new { u.UserLogin, u.WinUser, u.LoseUser })
                        .ToList();
                    return ratings;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении рейтинга: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
