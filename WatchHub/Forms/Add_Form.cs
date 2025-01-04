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
    public partial class Add_Form : Form
    {
        Database dataBase = new Database();

        public Add_Form()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Add_Form_Load(object sender, EventArgs e)
        {

        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                dataBase.openConnection();

                var brand = brand_comboBox.Text;
                var title = title_textBox_add.Text;
                var watch_version = version_comboBox.Text;
                var mechanism_type = mechanism_comboBox.Text;
                var housing_material = caseMaterial_comboBox.Text;
                var belt_material = beltMaterial_comboBox.Text;
                decimal price;
                double case_diameter;
                var case_color = caseColor_comboBox.Text;
                var case_shape = caseShape_comboBox.Text;
                var water_resistance = waterRistance_comboBox.Text;
                var dial_color = dialColor_comboBox.Text;
                var glass_type = glassType_comboBofx.Text;
                var indication_type = indicationType_comboBox.Text;
                var indication_view = indicationView_comboBox.Text;
                int stock_quantity;
                var description = description_textBox_add.Text;
                var gender = gender_comboBox.Text;

                string errorMessage = null;

                if (!decimal.TryParse(price_textBox_add.Text, out price))
                    errorMessage = "Неверное значение цены. Введите корректное число.";

                if (!double.TryParse(case_diameter_textBox_add.Text, out case_diameter))
                    errorMessage = "Неверное значение диаметра корпуса. Введите корректное число.";

                if (!int.TryParse(stock_quantity_textBox_add.Text, out stock_quantity))
                    errorMessage = "Неверное значение количества на складе. Введите целое число.";

                if (errorMessage != null)
                {
                    MessageBox.Show(errorMessage, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var addQuery = $"INSERT INTO watch (brand, title, watch_version, mechanism_type, housing_material, belt_material, price, " +
                               $"case_diameter, case_color, case_shape, water_resistance, dial_color, glass_type, indication_type, " +
                               $"indication_view, stock_quantity, description,gender) VALUES " +
                               $"('{brand}', '{title}', '{watch_version}', '{mechanism_type}', '{housing_material}', '{belt_material}', " +
                               $"'{price}', '{case_diameter}', '{case_color}', '{case_shape}', '{water_resistance}', '{dial_color}', " +
                               $"'{glass_type}', '{indication_type}', '{indication_view}', '{stock_quantity}', '{description}', '{gender}')";

                var command = new SqlCommand(addQuery, dataBase.getConnection());
                command.ExecuteNonQuery();

                // Показ сообщения об успешной операции
                MessageBox.Show("Данные успешно добавлены.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Показ сообщения об ошибке
                MessageBox.Show($"Ошибка при добавлении данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Закрытие соединения
                dataBase.closeConnection();
            }
        }

    }
}
