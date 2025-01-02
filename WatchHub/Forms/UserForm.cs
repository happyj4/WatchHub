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
using WatchHub.Forms;


namespace WatchHub
{
    public partial class UserForm : Form
    {
        Database dataBase = new Database();
        public UserForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            CreateColumns();
            LoadWatchData();
         
        }
        private void LoadWatchData()
        {
            dataGridView1.Rows.Clear();

            string queryString = $"SELECT brand, title, watch_version, mechanism_type, housing_material, belt_material, price, case_diameter, case_color, case_shape, water_resistance, dial_color, glass_type, indication_type, indication_view, stock_quantity, description, gender FROM watch";


            using (SqlCommand command = new SqlCommand(queryString, dataBase.getConnection()))
            {
                dataBase.openConnection();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    dataGridView1.Rows.Add(
                        reader.GetString(0), // brand
                        reader.GetString(1), // title
                        reader.GetString(2), // watch_version
                        reader.GetString(3), // mechanism_type
                        reader.GetString(4), // housing_material
                        reader.GetString(5), // belt_material
                        reader.GetDecimal(6), // price
                        reader.GetDouble(7), // case_diameter
                        reader.GetString(8),  // case_color
                         reader.GetString(9),  // case_shape
                          reader.GetString(10),  // water
                           reader.GetString(11),  // dial_color
                            reader.GetString(12),  // glass_type
                             reader.GetString(13),  // indication_type
                               reader.GetString(14),  // indication_view
                              reader.GetInt32(15),  // stock
                               reader.GetString(16),  // descrip
                                reader.GetString(17)  // gender
                    );
                }
                reader.Close();
                dataBase.closeConnection();
            }
        }


        private void CreateColumns()
        {
            dataGridView1.Columns.Add("brand", "Бренд");
            dataGridView1.Columns.Add("title", "Назва");
            dataGridView1.Columns.Add("watch_version", "Версія");
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
            dataGridView1.Columns.Add("indicationF_view", "Вид індикації");
            dataGridView1.Columns.Add("stock_quantity", "В наявності");
            dataGridView1.Columns.Add("description", "Опис");
            dataGridView1.Columns.Add("gender", "Стать");
        }


        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                string brand = row.Cells[0].Value.ToString();
                string title = row.Cells[1].Value.ToString();
                string watchVersion = row.Cells[2].Value.ToString();
                string mechanismType = row.Cells[3].Value.ToString();
                decimal price = Convert.ToDecimal(row.Cells[6].Value);

                // Передаем данные в форму оформления заказа
               // OrderForm orderForm = new OrderForm(brand, title, watchVersion, mechanismType, price);
                //orderForm.ShowDialog();
            }
        }



        public void SetUserName(string userName)
        {
            labelUserName.Text = $"Привіт, {userName}!";
        }


        private HashSet<string> activeBrands = new HashSet<string>();

        private void FilterByBrands()
        {
            dataGridView1.Rows.Clear();

            if (activeBrands.Count == 0)
            {
                LoadWatchData(); // Загружаем все данные, если брендов нет
                return;
            }

            string queryString = $@"
SELECT brand, title, watch_version, mechanism_type, housing_material, belt_material, price, case_diameter, case_color, case_shape, water_resistance, dial_color, glass_type, indication_type, indication_view, stock_quantity, description, gender 
FROM watch 
WHERE brand IN ({string.Join(", ", activeBrands.Select(b => $"'{b}'"))})";

            using (SqlCommand command = new SqlCommand(queryString, dataBase.getConnection()))
            {
                dataBase.openConnection();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    dataGridView1.Rows.Add(
                        reader.GetString(0), // brand
                        reader.GetString(1), // title
                        reader.GetString(2), // watch_version
                        reader.GetString(3), // mechanism_type
                        reader.GetString(4), // housing_material
                        reader.GetString(5), // belt_material
                        reader.GetDecimal(6), // price
                        reader.GetDouble(7), // case_diameter
                        reader.GetString(8),  // case_color
                        reader.GetString(9),  // case_shape
                        reader.GetString(10), // water_resistance
                        reader.GetString(11), // dial_color
                        reader.GetString(12), // glass_type
                        reader.GetString(13), // indication_type
                        reader.GetString(14), // indication_view
                        reader.GetInt32(15),  // stock_quantity
                        reader.GetString(16), // description
                        reader.GetString(17)  // gender
                    );
                }
                reader.Close();
                dataBase.closeConnection();
            }
        }



        private void ToggleBrandFilter(string brand, Button button)
        {
            if (activeBrands.Contains(brand))
            {
                activeBrands.Remove(brand);
                button.BackColor = Color.FromArgb(109, 112, 94); // Неактивный цвет
            }
            else
            {
                activeBrands.Add(brand);
                button.BackColor = Color.White; // Активный цвет
            }

            FilterByBrands(); // Обновляем фильтр
        }



        private void buttonCasio_Click(object sender, EventArgs e)
        {
            ToggleBrandFilter("Casio", buttonCasio);
        }

        private void buttonOris_Click(object sender, EventArgs e)
        {
            ToggleBrandFilter("Oris", buttonOris);
        }

        private void buttonTissot_Click(object sender, EventArgs e)
        {
            ToggleBrandFilter("Tissot", buttonTissot);
        }

        private void buttonCitizen_Click(object sender, EventArgs e)
        {
            ToggleBrandFilter("Citizen", buttonCitizen);
        }



        private void buttonHamilton_Click(object sender, EventArgs e)
        {
            ToggleBrandFilter("Hamilton", buttonHamilton);
        }

        private void buttonLongines_Click(object sender, EventArgs e)
        {
            ToggleBrandFilter("Longines", buttonLongines);
        }

        private void buttonAtlantic_Click(object sender, EventArgs e)
        {
            ToggleBrandFilter("Atlantic", buttonAtlantic);
        }

        private void buttonOrient_Click(object sender, EventArgs e)
        {
            ToggleBrandFilter("Orient", buttonOrient);
        }

        private void buttonRado_Click(object sender, EventArgs e)
        {
            ToggleBrandFilter("Rado", buttonRado);
        }

        private void buttonBreitling_Click(object sender, EventArgs e)
        {
            ToggleBrandFilter("Breitling", buttonBreitling);
        }

        private void buttonCertina_Click(object sender, EventArgs e)
        {
            ToggleBrandFilter("Certina", buttonCertina);
        }

        private void buttonEpos_Click(object sender, EventArgs e)
        {
            ToggleBrandFilter("Epos", buttonEpos);
        }
    }
}
