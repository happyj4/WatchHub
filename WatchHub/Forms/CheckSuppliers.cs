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
    public partial class CheckSuppliers : Form
    {
        private Database dataBase = new Database();

        public CheckSuppliers()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void CheckSuppliers_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadData();
        }

        private void SetupDataGridView()
        {
            dataGridView1.Columns.Add("supplier_id", "ID");
            dataGridView1.Columns.Add("name", "Ім'я");
            dataGridView1.Columns.Add("last_name", "Прізвище");
            dataGridView1.Columns.Add("country", "Країна");
            dataGridView1.Columns.Add("city", "Місто");
            dataGridView1.Columns.Add("street", "Вулиця");
            dataGridView1.Columns.Add("house_number", "Номер будинку");
            dataGridView1.Columns.Add("phone_number", "Телефон");
            dataGridView1.Columns.Add("email", "Email");
            dataGridView1.Columns.Add("cooperation_terms", "Умови співпраці");
            dataGridView1.Columns.Add("payment_terms", "Умови оплати");

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.AllowUserToAddRows = false;
        }

        private void LoadData()
        {
            dataGridView1.Rows.Clear();
            string query = "SELECT * FROM suppliers";

            try
            {
                dataBase.openConnection();
                using (SqlCommand command = new SqlCommand(query, dataBase.getConnection()))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(
                            reader.GetInt32(0), // supplier_id
                            reader.GetString(1), // name
                            reader.GetString(2), // last_name
                            reader.GetString(3), // country
                            reader.GetString(4), // city
                            reader.GetString(5), // street
                            reader.GetString(6), // house_number
                            reader.GetString(7), // phone_number
                            reader.GetString(8), // email
                            reader.GetString(9), // cooperation_terms
                            reader.GetString(10) // payment_terms
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження даних: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataBase.closeConnection();
            }
        }

        private void ClearFields()
        {
            textBoxSupplierID.Clear();
            textBox_SupplierName.Clear();
            textBoxSupplierLastName.Clear();
            textBoxSupplierCountry.Clear();
            textBoxSupplierStreet.Clear();
            textBox_supplierHouseNum.Clear();
            textBox_supplierPhoneNumber.Clear();
            textBoxEmail.Clear();
            textBoxCooperationTerms.Clear();
            textBoxPaymentTerms.Clear();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                dataBase.openConnection();
                string query = "INSERT INTO suppliers (name, last_name, country, city, street, house_number, phone_number, email, cooperation_terms, payment_terms) " +
                               "VALUES (@name, @last_name, @country, @city, @street, @house_number, @phone_number, @email, @cooperation_terms, @payment_terms)";

                using (SqlCommand command = new SqlCommand(query, dataBase.getConnection()))
                {
                    command.Parameters.AddWithValue("@name", textBox_SupplierName.Text);
                    command.Parameters.AddWithValue("@last_name", textBoxSupplierLastName.Text);
                    command.Parameters.AddWithValue("@country", textBoxSupplierCountry.Text);
                    command.Parameters.AddWithValue("@city", textBoxSupplierCountry.Text);
                    command.Parameters.AddWithValue("@street", textBoxSupplierStreet.Text);
                    command.Parameters.AddWithValue("@house_number", textBox_supplierHouseNum.Text);
                    command.Parameters.AddWithValue("@phone_number", textBox_supplierPhoneNumber.Text);
                    command.Parameters.AddWithValue("@email", textBoxEmail.Text);
                    command.Parameters.AddWithValue("@cooperation_terms", textBoxCooperationTerms.Text);
                    command.Parameters.AddWithValue("@payment_terms", textBoxPaymentTerms.Text);

                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Новий постачальник успішно доданий!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка додавання: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataBase.closeConnection();
            }
        }

        private void changeBtn_Click(object sender, EventArgs e)
        {
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridView1.Rows[e.RowIndex];
                textBoxSupplierID.Text = row.Cells[0].Value.ToString();
                textBox_SupplierName.Text = row.Cells[1].Value.ToString();
                textBoxSupplierLastName.Text = row.Cells[2].Value.ToString();
                textBoxSupplierCountry.Text = row.Cells[3].Value.ToString();
                textBoxSupplierStreet.Text = row.Cells[5].Value.ToString();
                textBox_supplierHouseNum.Text = row.Cells[6].Value.ToString();
                textBox_supplierPhoneNumber.Text = row.Cells[7].Value.ToString();
                textBoxEmail.Text = row.Cells[8].Value.ToString();
                textBoxCooperationTerms.Text = row.Cells[9].Value.ToString();
                textBoxPaymentTerms.Text = row.Cells[10].Value.ToString();
            }
        }

        private void refresh_btn_Click(object sender, EventArgs e)
        {
            LoadData();
            ClearFields();
        }
        private void Search(DataGridView dgw)
        {
            dgw.Rows.Clear();

            // Пошуковий запит для таблиці suppliers
            string searchString = $"SELECT * FROM suppliers WHERE CONCAT(name, last_name, country, city, street, house_number, phone_number, email, cooperation_terms, payment_terms) LIKE @search";

            try
            {
                SqlCommand command = new SqlCommand(searchString, dataBase.getConnection());
                command.Parameters.AddWithValue("@search", $"%{textBoxSearchSupllier.Text}%");

                dataBase.openConnection();
                SqlDataReader reader = command.ExecuteReader();

                // Зчитуємо дані рядок за рядком
                while (reader.Read())
                {
                    ReadSingleRow(dgw, reader);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка під час пошуку: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataBase.closeConnection();
            }
        }

        // Обробник події для текстового поля пошуку
        private void textBoxSearchSupplier_TextChanged(object sender, EventArgs e)
        {
            Search(dataGridView1);
        }

        // Додавання одного рядка до DataGridView
        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(
                record.GetInt32(0),        // supplier_id
                record.GetString(1),       // name
                record.GetString(2),       // last_name
                record.GetString(3),       // country
                record.GetString(4),       // city
                record.GetString(5),       // street
                record.GetString(6),        // house_number
                record.GetString(7),       // phone_number
                record.GetString(8),       // email
                record.GetString(9),       // cooperation_terms
                record.GetString(10)       // payment_terms
            );
        }

        private void btnNew_Click_1(object sender, EventArgs e)
        {
            AddNewSupplier addNewSupplier = new AddNewSupplier();
            addNewSupplier.ShowDialog();
        }

        private void changeBtn_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                int supplierId = Convert.ToInt32(selectedRow.Cells[0].Value);

                try
                {
                    dataBase.openConnection();
                    string query = "UPDATE suppliers SET name = @name, last_name = @last_name, country = @country, " +
                                   "city = @city, street = @street, house_number = @house_number, phone_number = @phone_number, " +
                                   "email = @email, cooperation_terms = @cooperation_terms, payment_terms = @payment_terms WHERE supplier_id = @supplier_id";

                    using (SqlCommand command = new SqlCommand(query, dataBase.getConnection()))
                    {
                        command.Parameters.AddWithValue("@supplier_id", supplierId);
                        command.Parameters.AddWithValue("@name", textBox_SupplierName.Text);
                        command.Parameters.AddWithValue("@last_name", textBoxSupplierLastName.Text);
                        command.Parameters.AddWithValue("@country", textBoxSupplierCountry.Text);
                        command.Parameters.AddWithValue("@city", textBoxSupplierCountry.Text);
                        command.Parameters.AddWithValue("@street", textBoxSupplierStreet.Text);
                        command.Parameters.AddWithValue("@house_number", textBox_supplierHouseNum.Text);
                        command.Parameters.AddWithValue("@phone_number", textBox_supplierPhoneNumber.Text);
                        command.Parameters.AddWithValue("@email", textBoxEmail.Text);
                        command.Parameters.AddWithValue("@cooperation_terms", textBoxCooperationTerms.Text);
                        command.Parameters.AddWithValue("@payment_terms", textBoxPaymentTerms.Text);

                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Дані постачальника успішно оновлені!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка оновлення: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    dataBase.closeConnection();
                }
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                int supplierId = Convert.ToInt32(selectedRow.Cells[0].Value);

                var confirmResult = MessageBox.Show("Ви впевнені, що хочете видалити цього постачальника?",
                                                     "Підтвердження видалення",
                                                     MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        dataBase.openConnection();
                        string query = "DELETE FROM suppliers WHERE supplier_id = @supplier_id";

                        using (SqlCommand command = new SqlCommand(query, dataBase.getConnection()))
                        {
                            command.Parameters.AddWithValue("@supplier_id", supplierId);
                            command.ExecuteNonQuery();
                        }

                        MessageBox.Show("Постачальника успішно видалено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        ClearFields();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Помилка видалення: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        dataBase.closeConnection();
                    }
                }
            }
        }
    }
}
