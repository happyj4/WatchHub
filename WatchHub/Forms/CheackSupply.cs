using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WatchHub.Forms
{
    public partial class CheackSupply : Form
    {
        private Database dataBase = new Database();

        public CheackSupply()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void CheackSupply_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadData();
        }

        private void SetupDataGridView()
        {
            dataGridView1.Columns.Add("id", "ID");
            dataGridView1.Columns.Add("supply_date", "Дата поставки");
            dataGridView1.Columns.Add("supply_volume", "Обсяг поставки");
            dataGridView1.Columns.Add("supply_price", "Ціна");
            dataGridView1.Columns.Add("supply_terms", "Умови поставки");
            dataGridView1.Columns.Add("id_supplier", "ID постачальника");
            dataGridView1.Columns.Add("watch_id", "ID годинника");

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.AllowUserToAddRows = false;
        }

        private void LoadData()
        {
            dataGridView1.Rows.Clear();
            string query = "SELECT * FROM supply";

            try
            {
                dataBase.openConnection();
                using (SqlCommand command = new SqlCommand(query, dataBase.getConnection()))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(
                            reader.GetInt32(0), // id
                            reader.GetDateTime(1), // supply_date
                            reader.GetInt32(2), // supply_volume
                            reader.GetDecimal(3), // supply_price
                            reader.GetString(4), // supply_terms
                            reader.GetInt32(5), // id_supplier
                            reader.GetInt32(6)  // watch_id
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
            textBoxSupplyID.Clear();
            dateTimePicker1.Value = DateTime.Now;
            textBoxSupplyVolume.Clear();
            textBoxSupply_price.Clear();
            textBoxSupply_terms.Clear();
            textBox_id_supplier.Clear();
            textBox_watch_id.Clear();
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                int id = Convert.ToInt32(selectedRow.Cells[0].Value);

                var confirmResult = MessageBox.Show("Ви впевнені, що хочете видалити цей запис?",
                                                     "Підтвердження видалення",
                                                     MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        dataBase.openConnection();
                        string query = "DELETE FROM supply WHERE id = @id";

                        using (SqlCommand command = new SqlCommand(query, dataBase.getConnection()))
                        {
                            command.Parameters.AddWithValue("@id", id);
                            command.ExecuteNonQuery();
                        }

                        MessageBox.Show("Поставку успішно видалено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void refresh_btn_Click(object sender, EventArgs e)
        {
            LoadData();
            ClearFields();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridView1.Rows[e.RowIndex];
                textBoxSupplyID.Text = row.Cells[0].Value.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(row.Cells[1].Value);
                textBoxSupplyVolume.Text = row.Cells[2].Value.ToString();
                textBoxSupply_price.Text = row.Cells[3].Value.ToString();
                textBoxSupply_terms.Text = row.Cells[4].Value.ToString();
                textBox_id_supplier.Text = row.Cells[5].Value.ToString();
                textBox_watch_id.Text = row.Cells[6].Value.ToString();
            }
        }

        private void changeBtn_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                int id = Convert.ToInt32(selectedRow.Cells[0].Value);

                try
                {
                    dataBase.openConnection();
                    string query = "UPDATE supply SET supply_date = @supply_date, supply_volume = @supply_volume, " +
                                   "supply_price = @supply_price, supply_terms = @supply_terms, " +
                                   "id_supplier = @id_supplier, watch_id = @watch_id WHERE id = @id";

                    using (SqlCommand command = new SqlCommand(query, dataBase.getConnection()))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@supply_date", dateTimePicker1.Value);
                        command.Parameters.AddWithValue("@supply_volume", Convert.ToInt32(textBoxSupplyVolume.Text));
                        command.Parameters.AddWithValue("@supply_price", Convert.ToDecimal(textBoxSupply_price.Text));
                        command.Parameters.AddWithValue("@supply_terms", textBoxSupply_terms.Text);
                        command.Parameters.AddWithValue("@id_supplier", Convert.ToInt32(textBox_id_supplier.Text));
                        command.Parameters.AddWithValue("@watch_id", Convert.ToInt32(textBox_watch_id.Text));

                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Дані успішно оновлено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            AddSupply addSupply = new AddSupply();
            addSupply.ShowDialog();
        }


        private void Search(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string searchString = $"SELECT * FROM supply WHERE CONCAT(supply_date, supply_volume, supply_price, supply_terms, id_supplier, watch_id) LIKE '%{textBoxSearchSupllier.Text}%'";

            SqlCommand command = new SqlCommand(searchString, dataBase.getConnection());
            dataBase.openConnection();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }


            reader.Close();
        }

        // Обробники подій
        private void textBoxSearchSupplier_TextChanged(object sender, EventArgs e)
        {
            Search(dataGridView1);
        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetDateTime(1), record.GetInt32(2),
                         record.GetDecimal(3), record.GetString(4), record.GetInt32(5),
                         record.GetInt32(6), RowState.Existed); // Инициализация правильным статусом
        }

       
    }
}
