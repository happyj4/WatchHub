using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WatchHub.Forms
{
    public partial class AddNewSupplier : Form
    {
        Database dataBase;
        public AddNewSupplier()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            dataBase = new Database();
        }

        private void AddNewSupplier_Load(object sender, EventArgs e)
        {

        }

        private void AddSupplierBtn_Click(object sender, EventArgs e)
        {
            // Перевірка, що всі обов'язкові текстові поля заповнені
            if (string.IsNullOrWhiteSpace(nameTextBox.Text) ||
                string.IsNullOrWhiteSpace(surnameTextBox.Text) ||
                string.IsNullOrWhiteSpace(countryTextBox.Text) ||
                string.IsNullOrWhiteSpace(cityTextBox.Text) ||
                string.IsNullOrWhiteSpace(streetTextBox.Text) ||
                string.IsNullOrWhiteSpace(houseNumberTextBox.Text) ||
                string.IsNullOrWhiteSpace(phoneNumberTextBox.Text) ||
                string.IsNullOrWhiteSpace(emailTextBox.Text) ||
                string.IsNullOrWhiteSpace(cooperationTermstextBox.Text) ||
                string.IsNullOrWhiteSpace(paymentTermsTextBox.Text))
            {
                MessageBox.Show("Будь ласка, заповніть всі поля.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Перевірка, чи номер будинку є числом
            if (!int.TryParse(houseNumberTextBox.Text, out int houseNumber))
            {
                MessageBox.Show("Будь ласка, введіть коректний номер будинку (ціле число).", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Перевірка формату номера телефону
            if (!System.Text.RegularExpressions.Regex.IsMatch(phoneNumberTextBox.Text, @"^\+?\d{10,15}$"))
            {
                MessageBox.Show("Будь ласка, введіть коректний номер телефону (10-15 цифр, можна з +).", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Перевірка формату email
            if (!System.Text.RegularExpressions.Regex.IsMatch(emailTextBox.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Будь ласка, введіть коректний email.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // SQL-запрос для добавления нового постачальника без явного указания supplier_id
                string query = "INSERT INTO suppliers (name, last_name, country, city, street, house_number, phone_number, email, cooperation_terms, payment_terms) " +
                               "VALUES (@name, @last_name, @country, @city, @street, @house_number, @phone_number, @email, @cooperation_terms, @payment_terms)";

                using (SqlCommand command = new SqlCommand(query, dataBase.getConnection()))
                {
                    // Добавляем параметры
                    command.Parameters.AddWithValue("@name", nameTextBox.Text.Trim());
                    command.Parameters.AddWithValue("@last_name", surnameTextBox.Text.Trim());
                    command.Parameters.AddWithValue("@country", countryTextBox.Text.Trim());
                    command.Parameters.AddWithValue("@city", cityTextBox.Text.Trim());
                    command.Parameters.AddWithValue("@street", streetTextBox.Text.Trim());
                    command.Parameters.AddWithValue("@house_number", int.Parse(houseNumberTextBox.Text.Trim()));
                    command.Parameters.AddWithValue("@phone_number", phoneNumberTextBox.Text.Trim());
                    command.Parameters.AddWithValue("@email", emailTextBox.Text.Trim());
                    command.Parameters.AddWithValue("@cooperation_terms", cooperationTermstextBox.Text.Trim());
                    command.Parameters.AddWithValue("@payment_terms", paymentTermsTextBox.Text.Trim());

                    // Открываем соединение, выполняем команду
                    dataBase.openConnection();
                    command.ExecuteNonQuery();

                    MessageBox.Show("Новий постачальник успішно доданий!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Очищаем поля после добавления
                    ClearSupplierFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при додаванні постачальника: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataBase.closeConnection();
            }
        }

        // Метод для визначення наступного доступного ID
        private int GetNextSupplierId()
        {
            int maxId = 0;
            string query = "SELECT ISNULL(MAX(supplier_id), 0) FROM suppliers";

            try
            {
                dataBase.openConnection();
                using (SqlCommand command = new SqlCommand(query, dataBase.getConnection()))
                {
                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int value))
                    {
                        maxId = value;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при отриманні наступного ID: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataBase.closeConnection();
            }

            return maxId + 1; // Наступне значення ID
        }

        // Метод для очищення текстових полів
        private void ClearSupplierFields()
        {
            nameTextBox.Clear();
            surnameTextBox.Clear();
            countryTextBox.Clear();
            cityTextBox.Clear();
            streetTextBox.Clear();
            houseNumberTextBox.Clear();
            phoneNumberTextBox.Clear();
            emailTextBox.Clear();
            cooperationTermstextBox.Clear();
            paymentTermsTextBox.Clear();
        }

    }
}
