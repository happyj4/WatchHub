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

        private void refresh_btn_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(dataGridView1);       
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
    }
}
