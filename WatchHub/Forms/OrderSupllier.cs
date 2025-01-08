using iText.Layout.Renderer;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
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
    public partial class OrderSupllier : Form
    {
        public OrderSupllier()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }
        Database dataBase = new Database();

        private void OrderSupllier_Load(object sender, EventArgs e)
        {
            CreateColumns();
            LoadWatchData();
        }

        public void SetManagerName(string userName)
        {
            label_managerLogin5.Text = userName;
        }

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
            dataGridView1.Columns.Add("gender", "Стать");




        }





        public void SetSupInformation(string name, string last_name, string counrty, string city, string street, string houseNum, string phoneNum, string email, string
             cooperation_terms, string payment_terms)
        {
            nameLabel.Text = name;
            lastNameLabel.Text = last_name;
            countryLabel.Text = counrty;
            CityLabel.Text = city;
            StreetLabel.Text = street;
            houseNumberLabel.Text = houseNum;
            PhoneNumLabel.Text = phoneNum;
            emailLabel.Text = email;
            cooperation_terms_label.Text = cooperation_terms;
            payment_terms_label.Text = payment_terms;
        }
        public void LoadWatchData()
        {
            dataGridView1.Rows.Clear();

            string queryString = "SELECT watch_id, brand, title, watch_version, mechanism_type, housing_material, belt_material, price, case_diameter, case_color, case_shape, water_resistance, dial_color, glass_type, indication_type, indication_view, stock_quantity, description, gender FROM watch";

            using (SqlCommand command = new SqlCommand(queryString, dataBase.getConnection()))
            {
                try
                {
                    dataBase.openConnection();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        // Додавання рядка з усіма даними
                        dataGridView1.Rows.Add(
                            reader.GetInt32(0), // id
                            reader.GetString(1), // brand
                            reader.GetString(2), // title
                            reader.GetString(3), // watch_version
                            reader.GetString(4), // mechanism_type
                            reader.GetString(5), // housing_material
                            reader.GetString(6), // belt_material
                            reader.GetDecimal(7), // price
                            reader.GetDouble(8), // case_diameter
                            reader.GetString(9),  // case_color
                            reader.GetString(10), // case_shape
                            reader.GetString(11), // water_resistance
                            reader.GetString(12), // dial_color
                            reader.GetString(13), // glass_type
                            reader.GetString(14), // indication_type
                            reader.GetString(15), // indication_view
                            reader.GetInt32(16),  // stock_quantity
                            reader.GetString(17), // description
                            reader.GetString(18), // gender
                            null // IsNew (за замовчуванням null або можна передати значення)
                        );
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка при завантаженні даних: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    dataBase.closeConnection();
                }
            }
        }

        //  методи для обробки бренду годинника
        public HashSet<string> activeBrands = new HashSet<string>();

        public void FilterByBrands()
        {
            dataGridView1.Rows.Clear();

            if (activeBrands.Count == 0)
            {

                LoadWatchData(); // Загружаем все данные, если брендов нет
                return;
            }

            string queryString = $@"
SELECT watch_id, brand, title, watch_version, mechanism_type, housing_material, belt_material, price, case_diameter, case_color, case_shape, water_resistance, dial_color, glass_type, indication_type, indication_view, stock_quantity, description, gender 
FROM watch 
WHERE brand IN ({string.Join(", ", activeBrands.Select(b => $"'{b}'"))})";

            using (SqlCommand command = new SqlCommand(queryString, dataBase.getConnection()))
            {
                dataBase.openConnection();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    dataGridView1.Rows.Add(
                         reader.GetInt32(0), // id
                        reader.GetString(1), // brand
                        reader.GetString(2), // title
                        reader.GetString(3), // watch_version
                        reader.GetString(4), // mechanism_type
                        reader.GetString(5), // housing_material
                        reader.GetString(6), // belt_material
                        reader.GetDecimal(7), // price
                        reader.GetDouble(8), // case_diameter
                        reader.GetString(9),  // case_color
                         reader.GetString(10),  // case_shape
                          reader.GetString(11),  // water
                           reader.GetString(12),  // dial_color
                            reader.GetString(13),  // glass_type
                             reader.GetString(14),  // indication_type
                               reader.GetString(15),  // indication_view
                              reader.GetInt32(16),  // stock
                               reader.GetString(17),  // descrip
                                reader.GetString(18)  // gender
                     );
                }
                reader.Close();
                dataBase.closeConnection();
            }
        }

        public void ToggleBrandFilter(string brand, Button button)
        {
            if (activeBrands.Contains(brand))
            {
                activeBrands.Remove(brand);
                button.BackColor = System.Drawing.Color.FromArgb(109, 112, 94); // Неактивный цвет
            }
            else
            {
                activeBrands.Add(brand);
                button.BackColor = System.Drawing.Color.White; // Активный цвет
            }

            FilterByBrands(); // Обновляем фильтр
        }

        // кнопки вибору бренду годинників
        private void buttonCasio_Click(object sender, EventArgs e)
        {
            ToggleBrandFilter("Casio", buttonCasio);
            ApplyFilters();
        }

        private void buttonOris_Click(object sender, EventArgs e)
        {
            ToggleBrandFilter("Oris", buttonOris);
            ApplyFilters();
        }

        private void buttonTissot_Click(object sender, EventArgs e)
        {
            ToggleBrandFilter("Tissot", buttonTissot);
            ApplyFilters();
        }

        private void buttonCitizen_Click(object sender, EventArgs e)
        {
            ToggleBrandFilter("Citizen", buttonCitizen);
            ApplyFilters();
        }

        private void buttonHamilton_Click(object sender, EventArgs e)
        {
            ToggleBrandFilter("Hamilton", buttonHamilton);
            ApplyFilters();
        }

        private void buttonLongines_Click(object sender, EventArgs e)
        {
            ToggleBrandFilter("Longines", buttonLongines);
            ApplyFilters();
        }

        private void buttonAtlantic_Click(object sender, EventArgs e)
        {
            ToggleBrandFilter("Atlantic", buttonAtlantic);
            ApplyFilters();
        }

        private void buttonOrient_Click(object sender, EventArgs e)
        {
            ToggleBrandFilter("Orient", buttonOrient);
            ApplyFilters();
        }

        private void buttonRado_Click(object sender, EventArgs e)
        {
            ToggleBrandFilter("Rado", buttonRado);
            ApplyFilters();
        }

        private void buttonBreitling_Click(object sender, EventArgs e)
        {
            ToggleBrandFilter("Breitling", buttonBreitling);
            ApplyFilters();
        }

        private void buttonCertina_Click(object sender, EventArgs e)
        {
            ToggleBrandFilter("Certina", buttonCertina);
            ApplyFilters();
        }

        private void buttonEpos_Click(object sender, EventArgs e)
        {
            ToggleBrandFilter("Epos", buttonEpos);
            ApplyFilters();
        }


        public void ApplyFilters()
        {
            // Базовий запит
            string queryString = @"
SELECT watch_id, brand, title, watch_version, mechanism_type, housing_material, belt_material, price, case_diameter, case_color, case_shape, water_resistance, dial_color, glass_type, indication_type, indication_view, stock_quantity, description, gender 
FROM watch 
WHERE 1=1"; // Базова умова, яка завжди істинна

            // Динамічні умови
            List<string> conditions = new List<string>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();



            // Фільтр за брендами
            if (activeBrands.Count > 0)
            {
                string brandCondition = string.Join(", ", activeBrands.Select((b, index) => $"@brand{index}"));
                conditions.Add($"brand IN ({brandCondition})");

                int brandIndex = 0;
                foreach (string brand in activeBrands)
                {
                    parameters.Add($"@brand{brandIndex++}", brand);
                }
            }

            // Додаємо всі умови до запиту
            if (conditions.Count > 0)
            {
                queryString += " AND " + string.Join(" AND ", conditions);
            }

            // Виконуємо запит
            using (SqlCommand command = new SqlCommand(queryString, dataBase.getConnection()))
            {
                foreach (var param in parameters)
                {
                    command.Parameters.AddWithValue(param.Key, param.Value);
                }

                dataBase.openConnection();
                SqlDataReader reader = command.ExecuteReader();

                dataGridView1.Rows.Clear(); // Очищаємо таблицю

                while (reader.Read())
                {
                    dataGridView1.Rows.Add(
                        reader.GetInt32(0),// id
                        reader.GetString(1), // brand
                        reader.GetString(2), // title
                        reader.GetString(3), // watch_version
                        reader.GetString(4), // mechanism_type
                        reader.GetString(5), // housing_material
                        reader.GetString(6), // belt_material
                        reader.GetDecimal(7), // price
                        reader.GetDouble(8), // case_diameter
                        reader.GetString(9),  // case_color
                        reader.GetString(10),  // case_shape
                        reader.GetString(11), // water_resistance
                        reader.GetString(12), // dial_color
                        reader.GetString(13), // glass_type
                        reader.GetString(14), // indication_type
                        reader.GetString(15), // indication_view
                        reader.GetInt32(16),  // stock_quantity
                        reader.GetString(17), // description
                        reader.GetString(18)  // gender
                    );
                }

                reader.Close();
                dataBase.closeConnection();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Переконайтеся, що натиснута комірка не є заголовком
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Присвойте значення вибраного рядка у відповідні Labels
                label_id.Text = row.Cells["id"].Value?.ToString() ?? string.Empty;
                label_title.Text = row.Cells["title"].Value?.ToString() ?? string.Empty;
                label_brand.Text = row.Cells["brand"].Value?.ToString() ?? string.Empty;
                label_price.Text = row.Cells["price"].Value?.ToString() ?? string.Empty;
                label_quantity.Text = row.Cells["stock_quantity"].Value?.ToString() ?? string.Empty;

            }


        }

        private void buttonConfirmOrderSupplier_Click(object sender, EventArgs e)
        {
            Database dataBase = new Database();

            try
            {
                // Зчитуємо дані постачальника
                string supplierName = nameLabel.Text;
                string supplierLastName = lastNameLabel.Text;
                string supplierCountry = countryLabel.Text;
                string supplierCity = CityLabel.Text;
                string supplierStreet = StreetLabel.Text;
                string supplierHouseNumber = houseNumberLabel.Text;
                string supplierCooperationTerms = cooperation_terms_label.Text;

                // Зчитуємо дані годинника
                int watchId = Convert.ToInt32(label_id.Text);
                string watchTitle = label_title.Text;
                string watchBrand = label_brand.Text;
                decimal watchPrice = Convert.ToDecimal(label_price.Text);
                int supplyVolume = int.TryParse(textBoxQuantitiyWatch.Text, out int quantity) ? quantity : 0;

                if (supplyVolume <= 0)
                {
                    MessageBox.Show("Введіть коректну кількість замовлення!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                dataBase.openConnection();
                SqlConnection connection = dataBase.getConnection();

                // Отримуємо ID постачальника
                string getSupplierIdQuery = "SELECT supplier_id FROM suppliers WHERE name = @name AND last_name = @lastName AND country = @country AND city = @city";
                SqlCommand getSupplierIdCommand = new SqlCommand(getSupplierIdQuery, connection);
                getSupplierIdCommand.Parameters.AddWithValue("@name", supplierName);
                getSupplierIdCommand.Parameters.AddWithValue("@lastName", supplierLastName);
                getSupplierIdCommand.Parameters.AddWithValue("@country", supplierCountry);
                getSupplierIdCommand.Parameters.AddWithValue("@city", supplierCity);

                object supplierIdObj = getSupplierIdCommand.ExecuteScalar();
                if (supplierIdObj == null)
                {
                    MessageBox.Show("Постачальник не знайдений!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int supplierId = Convert.ToInt32(supplierIdObj);

                // Додаємо запис у таблицю supply
                string insertSupplyQuery = @"
INSERT INTO supply (supply_date, supply_volume, supply_price, supply_terms, id_supplier, watch_id)
VALUES (@supplyDate, @supplyVolume, @supplyPrice, @supplyTerms, @supplierId, @watchId)";
                SqlCommand insertSupplyCommand = new SqlCommand(insertSupplyQuery, connection);
                insertSupplyCommand.Parameters.AddWithValue("@supplyDate", DateTime.Now);
                insertSupplyCommand.Parameters.AddWithValue("@supplyVolume", supplyVolume);
                insertSupplyCommand.Parameters.AddWithValue("@supplyPrice", watchPrice * supplyVolume);
                insertSupplyCommand.Parameters.AddWithValue("@supplyTerms", supplierCooperationTerms);
                insertSupplyCommand.Parameters.AddWithValue("@supplierId", supplierId);
                insertSupplyCommand.Parameters.AddWithValue("@watchId", watchId);

                insertSupplyCommand.ExecuteNonQuery();

                // Оновлюємо кількість годинників
                string updateWatchQuery = "UPDATE watch SET stock_quantity = stock_quantity + @supplyVolume WHERE watch_id = @watchId";
                SqlCommand updateWatchCommand = new SqlCommand(updateWatchQuery, connection);
                updateWatchCommand.Parameters.AddWithValue("@supplyVolume", supplyVolume);
                updateWatchCommand.Parameters.AddWithValue("@watchId", watchId);

                updateWatchCommand.ExecuteNonQuery();

                // Отримуємо дані менеджера
                string managerLogin = label_managerLogin5.Text;

                // Видаляємо частину "Привіт, " і залишаємо лише логін
                if (managerLogin.StartsWith("Привіт, "))
                {
                    managerLogin = managerLogin.Replace("Привіт, ", "").Trim('"').TrimEnd('!');
                }
                string getManagerInfoQuery = "SELECT first_name, last_name, email, phone_number FROM manager WHERE login = @login";
                SqlCommand getManagerInfoCommand = new SqlCommand(getManagerInfoQuery, connection);
                getManagerInfoCommand.Parameters.AddWithValue("@login", managerLogin);

                string managerFirstName = "", managerLastName = "", managerEmail = "", managerPhone = "";

                using (SqlDataReader reader = getManagerInfoCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        managerFirstName = reader["first_name"].ToString();
                        managerLastName = reader["last_name"].ToString();
                        managerEmail = reader["email"].ToString();
                        managerPhone = reader["phone_number"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Менеджера не знайдено!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Створюємо звіт
                CreateSupplyReport(supplyVolume, watchPrice * supplyVolume, managerFirstName, managerLastName, managerEmail, managerPhone,
                    supplierName, supplierLastName, supplierCountry, supplierCity, supplierStreet, supplierHouseNumber,
                    watchTitle, watchBrand, watchPrice);

                MessageBox.Show("Замовлення успішно підтверджено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
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


        private void CreateSupplyReport(int supplyVolume, decimal supplyPrice, string managerFirstName, string managerLastName, string managerEmail, string managerPhone,
                                        string supplierName, string supplierLastName, string supplierCountry, string supplierCity, string supplierStreet, string supplierHouseNumber,
                                        string watchTitle, string watchBrand, decimal watchPrice)
        {
           
            try
            {
                // Створення документа
                var document = new MigraDoc.DocumentObjectModel.Document();
                var section = document.AddSection();

                // Заголовок документа
                var title = section.AddParagraph("Звіт про постачання годинників");
                title.Format.Font.Size = 18;
                title.Format.Font.Bold = true;
                title.Format.SpaceAfter = "1cm";
                title.Format.Alignment = ParagraphAlignment.Center;

                // Дата створення звіту
                section.AddParagraph($"Дата створення звіту: {DateTime.Now:yyyy-MM-dd HH:mm}");
                section.AddParagraph("\n");

                // Інформація про постачання
                section.AddParagraph("Деталі постачання:");
                section.AddParagraph($"Обсяг поставки: {supplyVolume} годинників");
                section.AddParagraph($"Загальна вартість: {supplyPrice} грн");
                section.AddParagraph("\n");

                // Інформація про постачальника
                section.AddParagraph("Деталі постачальника:");
                section.AddParagraph($"Ім'я: {supplierName}");
                section.AddParagraph($"Прізвище: {supplierLastName}");
                section.AddParagraph($"Країна: {supplierCountry}, Місто: {supplierCity}");
                section.AddParagraph($"Вулиця: {supplierStreet}, Будинок: {supplierHouseNumber}");
                section.AddParagraph("\n");

                // Інформація про годинник
                section.AddParagraph("Деталі годинника:");
                section.AddParagraph($"Назва: {watchTitle}");
                section.AddParagraph($"Бренд: {watchBrand}");
                section.AddParagraph($"Ціна за одиницю: {watchPrice} грн");
                section.AddParagraph("\n");

                // Інформація про менеджера
                section.AddParagraph("Деталі менеджера:");
                section.AddParagraph($"Ім'я: {managerFirstName}");
                section.AddParagraph($"Прізвище: {managerLastName}");
                section.AddParagraph($"Email: {managerEmail}");
                section.AddParagraph($"Телефон: {managerPhone}");
                section.AddParagraph("\n");

                // Рендеринг PDF
                var renderer = new PdfDocumentRenderer(true)
                {
                    Document = document
                };
                renderer.RenderDocument();

                string pdfFilePath = $"SupplyReport_{DateTime.Now:yyyyMMddHHmmss}.pdf";
                renderer.PdfDocument.Save(pdfFilePath);

                MessageBox.Show($"Звіт про постачання створено: {pdfFilePath}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка створення звіту: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }

    }

}

