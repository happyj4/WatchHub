using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WatchHub.Forms
{
    public partial class AddNewManager : Form
    {
        private Database dataBase;
        public AddNewManager()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            dataBase = new Database();
        }

        private void AddNewManager_Load(object sender, EventArgs e)
        {

        }

        private void createManager_Click(object sender, EventArgs e)
        {
           
            if (string.IsNullOrWhiteSpace(nameTextBox.Text) ||
                string.IsNullOrWhiteSpace(surnameTextBox.Text) ||
                string.IsNullOrWhiteSpace(loginTextBox.Text) ||
                string.IsNullOrWhiteSpace(passwordTextBox.Text) ||
                string.IsNullOrWhiteSpace(emailTextBox.Text) ||
                string.IsNullOrWhiteSpace(phoneNumberTextBox.Text))
            {
                MessageBox.Show("Будь ласка, заповніть всі поля.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Перевірка формату номера телефону
            if (!Regex.IsMatch(phoneNumberTextBox.Text, @"^\+?\d{10,15}$"))
            {
                MessageBox.Show("Будь ласка, введіть коректний номер телефону (10-15 цифр, можна з +).", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Перевірка формату email
            if (!Regex.IsMatch(emailTextBox.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Будь ласка, введіть коректний email.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // SQL-запит для додавання нового менеджера
                string query = "INSERT INTO manager (first_name, last_name, login, password, email, phone_number) " +
                               "VALUES (@first_name, @last_name, @login, @password, @email, @phone_number)";

                using (SqlCommand command = new SqlCommand(query, dataBase.getConnection()))
                {
                    // Додаємо параметри
                    command.Parameters.AddWithValue("@first_name", nameTextBox.Text.Trim());
                    command.Parameters.AddWithValue("@last_name", surnameTextBox.Text.Trim());
                    command.Parameters.AddWithValue("@login", loginTextBox.Text.Trim());
                    command.Parameters.AddWithValue("@password", passwordTextBox.Text.Trim());
                    command.Parameters.AddWithValue("@email", emailTextBox.Text.Trim());
                    command.Parameters.AddWithValue("@phone_number", phoneNumberTextBox.Text.Trim());

                    // Відкриваємо з'єднання та виконуємо команду
                    dataBase.openConnection();
                    command.ExecuteNonQuery();

                    MessageBox.Show("Новий менеджер успішно доданий!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Очищення текстових полів після додавання
                    ClearManagerFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при додаванні менеджера: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataBase.closeConnection();
            }
        }

        private void ClearManagerFields()
        {
            nameTextBox.Clear();
            surnameTextBox.Clear();
            loginTextBox.Clear();
            passwordTextBox.Clear();
            emailTextBox.Clear();
            phoneNumberTextBox.Clear();
        }



    }
}
