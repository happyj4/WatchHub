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
    public partial class AddSupply : Form
    {
        Database dataBase = new Database();
        public AddSupply()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void AddSupply_Load(object sender, EventArgs e)
        {

        }

       
            private void saveBtn_Click(object sender, EventArgs e)
            {
                try
                {
                    dataBase.openConnection();

                    // Збір даних з текстових полів
                    DateTime supplyDate = dateTimePicker1.Value;
                    if (!int.TryParse(textBox_supply_volume.Text, out int supplyVolume) || supplyVolume <= 0)
                    {
                        MessageBox.Show("Некоректне значення обсягу поставки. Введіть додатнє число.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (!decimal.TryParse(textBox_supplyPrice.Text, out decimal supplyPrice) || supplyPrice <= 0)
                    {
                        MessageBox.Show("Некоректне значення ціни поставки. Введіть додатнє число.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string supplyTerms = textBox_supplyTerms.Text;
                    if (string.IsNullOrWhiteSpace(supplyTerms))
                    {
                        MessageBox.Show("Поле 'Умови поставки' не може бути порожнім.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (!int.TryParse(textBox_idSupplier.Text, out int idSupplier) || idSupplier <= 0)
                    {
                        MessageBox.Show("Некоректне значення ID постачальника. Введіть додатнє ціле число.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (!int.TryParse(textBox_watch_id.Text, out int watchId) || watchId <= 0)
                    {
                        MessageBox.Show("Некоректне значення ID годинника. Введіть додатнє ціле число.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Перевірка існування постачальника
                    string checkSupplierQuery = "SELECT COUNT(*) FROM suppliers WHERE supplier_id = @idSupplier";
                    using (SqlCommand checkSupplierCmd = new SqlCommand(checkSupplierQuery, dataBase.getConnection()))
                    {
                        checkSupplierCmd.Parameters.AddWithValue("@idSupplier", idSupplier);
                        int supplierExists = (int)checkSupplierCmd.ExecuteScalar();
                        if (supplierExists == 0)
                        {
                            MessageBox.Show("Постачальник із вказаним ID не знайдений.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Перевірка існування годинника
                    string checkWatchQuery = "SELECT COUNT(*) FROM watch WHERE watch_id = @watchId";
                    using (SqlCommand checkWatchCmd = new SqlCommand(checkWatchQuery, dataBase.getConnection()))
                    {
                        checkWatchCmd.Parameters.AddWithValue("@watchId", watchId);
                        int watchExists = (int)checkWatchCmd.ExecuteScalar();
                        if (watchExists == 0)
                        {
                            MessageBox.Show("Годинник із вказаним ID не знайдений.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // SQL-запит для вставки нової поставки
                    string addQuery = $"INSERT INTO supply (supply_date, supply_volume, supply_price, supply_terms, id_supplier, watch_id) " +
                                      $"VALUES (@supplyDate, @supplyVolume, @supplyPrice, @supplyTerms, @idSupplier, @watchId)";

                    using (SqlCommand command = new SqlCommand(addQuery, dataBase.getConnection()))
                    {
                        command.Parameters.AddWithValue("@supplyDate", supplyDate);
                        command.Parameters.AddWithValue("@supplyVolume", supplyVolume);
                        command.Parameters.AddWithValue("@supplyPrice", supplyPrice);
                        command.Parameters.AddWithValue("@supplyTerms", supplyTerms);
                        command.Parameters.AddWithValue("@idSupplier", idSupplier);
                        command.Parameters.AddWithValue("@watchId", watchId);

                        command.ExecuteNonQuery();
                    }

                    // Оновлення stock_quantity у таблиці watch
                    string updateStockQuery = "UPDATE watch SET stock_quantity = stock_quantity + @supplyVolume WHERE watch_id = @watchId";
                    using (SqlCommand updateStockCmd = new SqlCommand(updateStockQuery, dataBase.getConnection()))
                    {
                        updateStockCmd.Parameters.AddWithValue("@supplyVolume", supplyVolume);
                        updateStockCmd.Parameters.AddWithValue("@watchId", watchId);

                        updateStockCmd.ExecuteNonQuery();
                    }

                    // Повідомлення про успішне додавання
                    MessageBox.Show("Поставка успішно додана та кількість на складі оновлена!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    // Виведення повідомлення про помилку
                    MessageBox.Show($"Помилка при додаванні поставки: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // Закриття з'єднання
                    dataBase.closeConnection();
                }
            }

        }
    }


