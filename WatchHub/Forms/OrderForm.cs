using iText.StyledXmlParser.Node;
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

    public partial class OrderForm : Form
    {
        private Database dataBase;
        private int count = 0;
        public OrderForm(
         string brand, string title, string watchVersion, string mechanismType,
         string housingMaterial, string beltMaterial, decimal price, double caseDiameter,
         string caseColor, string caseShape, string waterResistance, string dialColor,
         string glassType, string indicationType, string indicationView, string description,
         string gender, int quantity)
        {
            InitializeComponent();

            // Присвоюємо значення до кожного Label
            brand_label.Text = brand;
            title_label.Text = title;
            watch_version_label.Text = watchVersion;
            mechanism_type_label.Text = mechanismType;
            housing_material_label.Text = housingMaterial;
            belt_material_label.Text = beltMaterial;
            price_label.Text = price.ToString();
            case_diametr_label.Text = caseDiameter.ToString();
            case_color_label.Text = caseColor;
            case_shape_label.Text = caseShape;
            water_resistance_label.Text = waterResistance;
            dial_color_label.Text = dialColor;
            glass_type_label.Text = glassType;
            indication_type_label.Text = indicationType;
            indication_view_label.Text = indicationView;
            description_label.Text = description;
            gender_label.Text = gender;
            quantity_label.Text = quantity.ToString();
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {

        }

        public void SetName(string userName)
        {
            labelUserName.Text = userName;
        }





        private void UpdateLabel()
        {
            labelCount.Text = count.ToString();
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            if (count > 1)
            {
                count--;
            }
            UpdateLabel();
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {

            count++;
            UpdateLabel();
        }

        private void orderWatch_btn_Click(object sender, EventArgs e)
        {
            // Ініціалізація бази даних
            Database dataBase = new Database();

            try
            {
                // Зчитуємо дані з форми
                string watchTitle = title_label.Text; // Замість ID використовуємо назву годинника
                decimal price = Convert.ToDecimal(price_label.Text);
                int quantity = int.TryParse(labelCount.Text, out int parsedQuantity) ? parsedQuantity : 0;

                if (quantity <= 0)
                {
                    MessageBox.Show("Введіть коректну кількість товару!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string userLogin = labelUserName.Text;
                dataBase.openConnection();
                SqlConnection connection = dataBase.getConnection();

                // Отримуємо watch_id та stock_quantity за назвою (title)
                string getWatchQuery = "SELECT watch_id, stock_quantity FROM watch WHERE title = @title";
                SqlCommand getWatchCommand = new SqlCommand(getWatchQuery, connection);
                getWatchCommand.Parameters.AddWithValue("@title", watchTitle);

                SqlDataReader reader = getWatchCommand.ExecuteReader();
                if (!reader.Read())
                {
                    MessageBox.Show("Годинника з такою назвою не знайдено!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    reader.Close();
                    return;
                }
                int watchId = Convert.ToInt32(reader["watch_id"]);
                int stockQuantity = Convert.ToInt32(reader["stock_quantity"]);
                reader.Close();

                // Перевіряємо, чи достатньо товару на складі
                if (quantity > stockQuantity)
                {
                    MessageBox.Show($"На складі недостатньо товару! Доступна кількість: {stockQuantity}.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Отримуємо ID користувача
                string getUserIdQuery = "SELECT user_id FROM users WHERE login = @login";
                SqlCommand getUserIdCommand = new SqlCommand(getUserIdQuery, connection);
                getUserIdCommand.Parameters.AddWithValue("@login", userLogin);

                object userIdObj = getUserIdCommand.ExecuteScalar();
                if (userIdObj == null)
                {
                    MessageBox.Show("Користувача не знайдено!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int userId = Convert.ToInt32(userIdObj);

                // Перевіряємо, чи існує замовлення для цього користувача
                string getOrderIdQuery = "SELECT order_id FROM orders WHERE id_user = @idUser";
                SqlCommand getOrderIdCommand = new SqlCommand(getOrderIdQuery, connection);
                getOrderIdCommand.Parameters.AddWithValue("@idUser", userId);

                object orderIdObj = getOrderIdCommand.ExecuteScalar();
                int orderId;

                if (orderIdObj == null)
                {
                    // Якщо замовлення ще немає, створюємо нове
                    string insertOrderQuery = @"
INSERT INTO orders (order_date, total_amount, id_user, id_manager)
VALUES (@orderDate, @totalAmount, @idUser, @idManager);
SELECT SCOPE_IDENTITY();";
                    SqlCommand insertOrderCommand = new SqlCommand(insertOrderQuery, connection);
                    insertOrderCommand.Parameters.AddWithValue("@orderDate", DateTime.Now);
                    insertOrderCommand.Parameters.AddWithValue("@totalAmount", price * quantity);
                    insertOrderCommand.Parameters.AddWithValue("@idUser", userId);
                    insertOrderCommand.Parameters.AddWithValue("@idManager", 1); // Ставимо id_manager за замовчуванням

                    orderIdObj = insertOrderCommand.ExecuteScalar();
                    if (orderIdObj == null)
                    {
                        MessageBox.Show("Помилка створення замовлення!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    orderId = Convert.ToInt32(orderIdObj);
                }
                else
                {
                    // Якщо замовлення вже є, отримуємо існуючий order_id
                    orderId = Convert.ToInt32(orderIdObj);
                }

                // Додаємо запис у таблицю order_items
                string insertOrderItemQuery = @"
INSERT INTO order_items (order_id, watch_id, quantity, price)
VALUES (@orderId, @watchId, @quantity, @price)";
                SqlCommand insertOrderItemCommand = new SqlCommand(insertOrderItemQuery, connection);
                insertOrderItemCommand.Parameters.AddWithValue("@orderId", orderId);
                insertOrderItemCommand.Parameters.AddWithValue("@watchId", watchId);
                insertOrderItemCommand.Parameters.AddWithValue("@quantity", quantity);
                insertOrderItemCommand.Parameters.AddWithValue("@price", price);

                insertOrderItemCommand.ExecuteNonQuery();

                // Оновлюємо stock_quantity у таблиці watch
                string updateStockQuery = "UPDATE watch SET stock_quantity = stock_quantity - @quantity WHERE watch_id = @watchId";
                SqlCommand updateStockCommand = new SqlCommand(updateStockQuery, connection);
                updateStockCommand.Parameters.AddWithValue("@quantity", quantity);
                updateStockCommand.Parameters.AddWithValue("@watchId", watchId);

                updateStockCommand.ExecuteNonQuery();

                // Успішне повідомлення
                MessageBox.Show("Замовлення успішно створено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася помилка: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataBase.closeConnection();
            }
        }

    }
} 


