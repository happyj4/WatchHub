using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using WatchHub.Forms;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;

namespace WatchHub
{
    enum RowState
    {
        Existed,
        New,
        Modified,
        ModifiedNew,
        Deleted
    }


    public partial class ManagerForm : Form
    {
        Database dataBase = new Database();
        public ManagerForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        int selectedRow;

        private void CreateColumns()
        {
            dataGridView1.Columns.Add("id", "id");
            dataGridView1.Columns.Add("brand", "Бренд");
            dataGridView1.Columns.Add("title", "Назва");
            dataGridView1.Columns.Add("watch_version", "Версія годинників");
            dataGridView1.Columns.Add("mechanism_type", "Тип механізму");
            dataGridView1.Columns.Add("housing_material", "Матеріал корпусу");
            dataGridView1.Columns.Add("belt_material", "Матеріал ремінця");
            dataGridView1.Columns.Add("price", "Ціна");
            dataGridView1.Columns.Add("case_diameter", "Діаметр корпусу");
            dataGridView1.Columns.Add("case_color", "Колір корпусу");
            dataGridView1.Columns.Add("case_shape", "Форма корпусу");
            dataGridView1.Columns.Add("water_resistance", "Водонепроникність");
            dataGridView1.Columns.Add("dial_color", "Колір циферблату");
            dataGridView1.Columns.Add("glass_type", "Тип скла");
            dataGridView1.Columns.Add("indication_type", "Тип індикації");
            dataGridView1.Columns.Add("indication_view", "Вид індикації");
            dataGridView1.Columns.Add("stock_quantity", "Кількість на складі");
            dataGridView1.Columns.Add("description", "Опис");

            dataGridView1.Columns.Add("IsNew", String.Empty);
            

        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetString(4), record.GetString(5),
             record.GetString(6), record.GetDecimal(7), record.GetDouble(8),   
                 record.GetString(9), record.GetString(10), record.GetString(11), record.GetString(12), record.GetString(13),
                record.GetString(14), record.GetString(15), record.GetInt32(16), record.GetString(17), RowState.ModifiedNew);
        }

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string queryString = $"select * from watch";

            SqlCommand command = new SqlCommand(queryString,dataBase.getConnection());

            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }
            reader.Close();
        }



        private void ManagerForm_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid(dataGridView1);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          selectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];

                id_textBox.Text = row.Cells[0].Value.ToString();
                brand_textBox.Text = row.Cells[1].Value.ToString();
                title_textBox.Text = row.Cells[2].Value.ToString();
                watch_version_textBox.Text = row.Cells[3].Value.ToString();
                mechanism_type_textBox.Text = row.Cells[4].Value.ToString();
                housing_material_textBox.Text = row.Cells[5].Value.ToString();
                belt_material_textBox.Text = row.Cells[6].Value.ToString();
                price_textBox.Text = row.Cells[7].Value.ToString();
                case_diameter_textBox.Text = row.Cells[8].Value.ToString();
                case_color_textBox.Text = row.Cells[9].Value.ToString();
                case_shape_textBox.Text = row.Cells[10].Value.ToString();
                water_resistance_textBox.Text = row.Cells[11].Value.ToString();
                dial_color_textBox.Text = row.Cells[12].Value.ToString();
                glass_type_textBox.Text = row.Cells[13].Value.ToString();
                indication_type_textBox.Text = row.Cells[14].Value.ToString();
                indication_view_textBox.Text = row.Cells[15].Value.ToString();
                stock_quantity_textBox.Text = row.Cells[16].Value.ToString();
                description_textBox.Text = row.Cells[17].Value.ToString();


            }
        }

        private void ClearFields ()
        {

            id_textBox.Text = "";
            brand_textBox.Text = "";
            title_textBox.Text = "";
            watch_version_textBox.Text = "";
            mechanism_type_textBox.Text = "";
            housing_material_textBox.Text = "";
            belt_material_textBox.Text = "";
            price_textBox.Text = "";
            case_diameter_textBox.Text = "";
            case_color_textBox.Text = "";
            case_shape_textBox.Text = "";
            water_resistance_textBox.Text = "";
            dial_color_textBox.Text = "";
            glass_type_textBox.Text = "";
            indication_type_textBox.Text = "";
            indication_view_textBox.Text = "";
            stock_quantity_textBox.Text = "";
            description_textBox.Text = "";

        }

        private void deleteRow()
        {
            int index = dataGridView1.CurrentCell.RowIndex;

            dataGridView1.Rows[index].Visible = false;

            if (dataGridView1.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridView1.Rows[index].Cells[18].Value = RowState.Deleted;
                return;
            }

            dataGridView1.Rows[index].Cells[18].Value = RowState.Deleted;
        }

        private void Update()
        {
            dataBase.openConnection();

            for (int index = 0; index < dataGridView1.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView1.Rows[index].Cells[18].Value;

                if (rowState == RowState.Existed)
                    continue;

                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
                    var deleteQuery = $"delete from watch where watch_id = {id}";

                    var command = new SqlCommand(deleteQuery,dataBase.getConnection());
                    command.ExecuteNonQuery();
                }

                if (rowState == RowState.Modified)
                {
                    var id = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
                    var brand = dataGridView1.Rows[index].Cells[1].Value.ToString();
                    var title = dataGridView1.Rows[index].Cells[2].Value.ToString();
                    var watch_version = dataGridView1.Rows[index].Cells[3].Value.ToString();
                    var mechanism_type = dataGridView1.Rows[index].Cells[4].Value.ToString();
                    var housing_material = dataGridView1.Rows[index].Cells[5].Value.ToString();
                    var belt_material = dataGridView1.Rows[index].Cells[6].Value.ToString();
                    var price = Convert.ToDecimal(dataGridView1.Rows[index].Cells[7].Value);
                    var case_diameter = Convert.ToDecimal(dataGridView1.Rows[index].Cells[8].Value);
                    var case_color = dataGridView1.Rows[index].Cells[9].Value.ToString();
                    var case_shape = dataGridView1.Rows[index].Cells[10].Value.ToString();
                    var water_resistance = dataGridView1.Rows[index].Cells[11].Value.ToString();
                    var dial_color = dataGridView1.Rows[index].Cells[12].Value.ToString();
                    var glass_type = dataGridView1.Rows[index].Cells[13].Value.ToString();
                    var indication_type = dataGridView1.Rows[index].Cells[14].Value.ToString();
                    var indication_view = dataGridView1.Rows[index].Cells[15].Value.ToString();
                    var stock_quantity = Convert.ToInt32(dataGridView1.Rows[index].Cells[16].Value);
                    var description = dataGridView1.Rows[index].Cells[17].Value.ToString();

                    var changeQuery = "UPDATE watch SET " +
                        "brand = @brand, title = @title, watch_version = @watch_version, " +
                        "mechanism_type = @mechanism_type, housing_material = @housing_material, belt_material = @belt_material, " +
                        "price = @price, case_diameter = @case_diameter, case_color = @case_color, case_shape = @case_shape, " +
                        "water_resistance = @water_resistance, dial_color = @dial_color, glass_type = @glass_type, " +
                        "indication_type = @indication_type, indication_view = @indication_view, " +
                        "stock_quantity = @stock_quantity, description = @description " +
                        "WHERE watch_id = @id";

                    using (var command = new SqlCommand(changeQuery, dataBase.getConnection()))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@brand", brand);
                        command.Parameters.AddWithValue("@title", title);
                        command.Parameters.AddWithValue("@watch_version", watch_version);
                        command.Parameters.AddWithValue("@mechanism_type", mechanism_type);
                        command.Parameters.AddWithValue("@housing_material", housing_material);
                        command.Parameters.AddWithValue("@belt_material", belt_material);
                        command.Parameters.AddWithValue("@price", price);
                        command.Parameters.AddWithValue("@case_diameter", case_diameter);
                        command.Parameters.AddWithValue("@case_color", case_color);
                        command.Parameters.AddWithValue("@case_shape", case_shape);
                        command.Parameters.AddWithValue("@water_resistance", water_resistance);
                        command.Parameters.AddWithValue("@dial_color", dial_color);
                        command.Parameters.AddWithValue("@glass_type", glass_type);
                        command.Parameters.AddWithValue("@indication_type", indication_type);
                        command.Parameters.AddWithValue("@indication_view", indication_view);
                        command.Parameters.AddWithValue("@stock_quantity", stock_quantity);
                        command.Parameters.AddWithValue("@description", description);

                        command.ExecuteNonQuery();
                    }
                }
            }
            dataBase.closeConnection();
        }


        private void refresh_btn_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(dataGridView1);
            ClearFields();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Add_Form add_Form = new Add_Form();
            add_Form.Show();
        }

        private void Search (DataGridView dgw)
        {
            dgw.Rows.Clear();

            string searchString = $"select * from watch where concat (brand, title, watch_version, mechanism_type, housing_material, " +
                $"belt_material, price, case_diameter, case_color, case_shape, water_resistance, dial_color, glass_type, indication_type, " +
                $"indication_view, stock_quantity, description) like '%" + textBox_search.Text + "%'";

            SqlCommand com = new SqlCommand(searchString, dataBase.getConnection());

            dataBase.openConnection();
            SqlDataReader read = com.ExecuteReader();

            while (read.Read())
            {
                ReadSingleRow(dgw,read);
               
            }

            read.Close();

        }

        private void textBox_search_TextChanged(object sender, EventArgs e)
        {
            Search(dataGridView1);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            deleteRow();
            ClearFields();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            Update();
        }


        private void Change()
        {
            var selectedRowIndex = dataGridView1.CurrentCell.RowIndex;


           

                var id = id_textBox.Text;
                var brand = brand_textBox.Text;
                var title = title_textBox.Text;
                var watch_version = watch_version_textBox.Text;
                var mechanism_type = mechanism_type_textBox.Text;
                var housing_material = housing_material_textBox.Text;
                var belt_material = belt_material_textBox.Text;
                decimal price;
                double case_diameter;
                var case_color = case_color_textBox.Text;
                var case_shape = case_shape_textBox.Text;
                var water_resistance = water_resistance_textBox.Text;
                var dial_color = dial_color_textBox.Text;
                var glass_type = glass_type_textBox.Text;
                var indication_type = indication_type_textBox.Text;
                var indication_view = indication_view_textBox.Text;
                int stock_quantity;
                var description = description_textBox.Text;

                string errorMessage = null;


            if (dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {

                if (!decimal.TryParse(price_textBox.Text, out price))
                    errorMessage = "Неверное значение цены. Введите корректное число.";

                if (!double.TryParse(case_diameter_textBox.Text, out case_diameter))
                    errorMessage = "Неверное значение диаметра корпуса. Введите корректное число.";

                if (!int.TryParse(stock_quantity_textBox.Text, out stock_quantity))
                    errorMessage = "Неверное значение количества на складе. Введите целое число.";

                if (errorMessage != null)
                {
                    MessageBox.Show(errorMessage, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (errorMessage == null )
                {
                    dataGridView1.Rows[selectedRowIndex].SetValues(id, brand, title, watch_version, mechanism_type, housing_material, belt_material,
                    price, case_diameter, case_color, case_shape, water_resistance, dial_color, glass_type, indication_type, indication_view, stock_quantity, description);
                    dataGridView1.Rows[selectedRowIndex].Cells[18].Value = RowState.Modified;
                }
                

            }

            
        }



        private void changeBtn_Click(object sender, EventArgs e)
        {
            Change();
            ClearFields();
        }

   

        private void buttonClientOrderZvit_Click(object sender, EventArgs e)
        {
            ClientOrderZvit clientOrderZvit = new ClientOrderZvit();
            clientOrderZvit.Show();
        }

        private void buttonTop10watch_Click(object sender, EventArgs e)
        {
            // Підключення до бази
            Database db = new Database();

            string query = @"
SELECT TOP 10 
    w.title AS watch_name,
    w.brand,
    SUM(oi.quantity) AS total_quantity_sold,
    w.price
FROM order_items oi
JOIN watch w ON oi.watch_id = w.watch_id
GROUP BY w.title, w.brand, w.price
ORDER BY SUM(oi.quantity) DESC;
";

            try
            {
                db.openConnection();
                using (SqlCommand command = new SqlCommand(query, db.getConnection()))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            MessageBox.Show("Дані про продажі не знайдені.");
                            return;
                        }

                        // Створення документа
                        var document = new MigraDoc.DocumentObjectModel.Document();
                        var section = document.AddSection();

                        // Заголовок документа
                        var title = section.AddParagraph("Топ-10 годинників за продажами");
                        title.Format.Font.Size = 18;
                        title.Format.Font.Bold = true;
                        title.Format.SpaceAfter = "1cm";
                        title.Format.Alignment = ParagraphAlignment.Center;

                        // Дата створення звіту
                        section.AddParagraph($"Дата створення звіту: {DateTime.Now:yyyy-MM-dd HH:mm}");
                        section.AddParagraph("\n");

                        // Створення таблиці
                        var table = section.AddTable();
                        table.Borders.Width = 0.75;

                        // Додати колонки
                        table.AddColumn("6cm"); // Назва годинника
                        table.AddColumn("3cm"); // Бренд
                        table.AddColumn("3cm"); // Загальна кількість
                        table.AddColumn("3cm"); // Ціна

                        // Додати заголовок таблиці
                        var headerRow = table.AddRow();
                        headerRow.Cells[0].AddParagraph("Назва годинника");
                        headerRow.Cells[1].AddParagraph("Бренд");
                        headerRow.Cells[2].AddParagraph("Продано одиниць");
                        headerRow.Cells[3].AddParagraph("Ціна (грн)");

                        headerRow.Format.Font.Bold = true;

                        // Заповнення таблиці
                        while (reader.Read())
                        {
                            var dataRow = table.AddRow();
                            dataRow.Cells[0].AddParagraph(reader["watch_name"].ToString());
                            dataRow.Cells[1].AddParagraph(reader["brand"].ToString());
                            dataRow.Cells[2].AddParagraph(reader["total_quantity_sold"].ToString());
                            dataRow.Cells[3].AddParagraph(Convert.ToDecimal(reader["price"]).ToString("F2"));
                        }

                        // Рендеринг PDF
                        var renderer = new PdfDocumentRenderer(true)
                        {
                            Document = document
                        };
                        renderer.RenderDocument();

                        string pdfFilePath = $"Top10WatchesReport.pdf";
                        renderer.PdfDocument.Save(pdfFilePath);

                        MessageBox.Show($"Звіт створено: {pdfFilePath}");
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Помилка SQL: {sqlEx.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
            }
            finally
            {
                db.closeConnection();
            }
        }
    }
}
