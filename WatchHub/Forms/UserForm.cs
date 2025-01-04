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
      
        
        Database dataBase = new Database(); // підключення до бд
      




        public UserForm()
        {
            InitializeComponent();
            InitializeCheckBoxes(); // ініціалізація чекбоксів
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            CreateColumns();
            LoadWatchData();
        }

        // ініціалізація чекбоксів
        private void InitializeCheckBoxes()
        {


            checkBoxFashion.CheckedChanged += CheckBoxCategory_CheckedChanged;
            checkBoxKids.CheckedChanged += CheckBoxCategory_CheckedChanged;
            checkBoxClassic.CheckedChanged += CheckBoxCategory_CheckedChanged;
            checkBoxSport.CheckedChanged += CheckBoxCategory_CheckedChanged;

            checkBoxSaphirove_glass.CheckedChanged += CheckBoxGlassType_CheckedChanged;
            checkBoxMineralne_glass.CheckedChanged += CheckBoxGlassType_CheckedChanged;
            checkBoxZagartowane_glass.CheckedChanged += CheckBoxGlassType_CheckedChanged;
            checkBoxAkril_glass.CheckedChanged += CheckBoxGlassType_CheckedChanged;
            checkBoxPower_glass.CheckedChanged += CheckBoxGlassType_CheckedChanged;
            checkBoxLonX_glass.CheckedChanged += CheckBoxGlassType_CheckedChanged;
            checkBoxGorilla_glass.CheckedChanged += CheckBoxGlassType_CheckedChanged;
            checkBoxCorningGlass_glass.CheckedChanged += CheckBoxGlassType_CheckedChanged;

            checkBoxMechanic_mechanismType.CheckedChanged += CheckBoxMechanismType_CheckedChanged;
            checkBoxMexanikaZAvtopid_mechanismType.CheckedChanged += CheckBoxMechanismType_CheckedChanged;
            checkBoxKvarc_mechanismType.CheckedChanged += CheckBoxMechanismType_CheckedChanged;
            checkBoxAvtoKvarc_mechanismType.CheckedChanged += CheckBoxMechanismType_CheckedChanged;

            radioButton21_33mm.CheckedChanged += RadioButtonDiameter_CheckedChanged;
            radioButton33_38mm.CheckedChanged += RadioButtonDiameter_CheckedChanged;
            radioButton38_41mm.CheckedChanged += RadioButtonDiameter_CheckedChanged;
            radioButton41_43mm.CheckedChanged += RadioButtonDiameter_CheckedChanged;
            radioButton43_45mm.CheckedChanged += RadioButtonDiameter_CheckedChanged;
            radioButton45_87mm.CheckedChanged += RadioButtonDiameter_CheckedChanged;

            // Обробники для кольорів корпусу
            checkBoxBlack_corpus.CheckedChanged += CheckBoxCorpusColor_CheckedChanged;
            checkBoxChervony_corpus.CheckedChanged += CheckBoxCorpusColor_CheckedChanged;
            checkBoxKhaki_corpus.CheckedChanged += CheckBoxCorpusColor_CheckedChanged;
            checkBoxFioletovu_corpus.CheckedChanged += CheckBoxCorpusColor_CheckedChanged;
            checkBoxSriblaystuy_corpus.CheckedChanged += CheckBoxCorpusColor_CheckedChanged;
            checkBoxSiriy_corpus.CheckedChanged += CheckBoxCorpusColor_CheckedChanged;
            checkBoxSiniy_corpus.CheckedChanged += CheckBoxCorpusColor_CheckedChanged;
            checkBoxRozheve_corpus.CheckedChanged += CheckBoxCorpusColor_CheckedChanged;
            checkBoxRozheveZoloto_corpus.CheckedChanged += CheckBoxCorpusColor_CheckedChanged;
            checkBoxProzoru_corpus.CheckedChanged += CheckBoxCorpusColor_CheckedChanged;
            checkBoxPomaranchevy_corpus.CheckedChanged += CheckBoxCorpusColor_CheckedChanged;
            checkBoxKorichnevy_corpus.CheckedChanged += CheckBoxCorpusColor_CheckedChanged;
            checkBoxZolotustu_corpus.CheckedChanged += CheckBoxCorpusColor_CheckedChanged;
            checkBoxGreen_corpus.CheckedChanged += CheckBoxCorpusColor_CheckedChanged;
            checkBoxZhovty_corpus.CheckedChanged += CheckBoxCorpusColor_CheckedChanged;
            checkBoxBlakitniy_corpus.CheckedChanged += CheckBoxCorpusColor_CheckedChanged;
            checkBoxWhite_corpus.CheckedChanged += CheckBoxCorpusColor_CheckedChanged;
            checkBoxBezhevi_corpus.CheckedChanged += CheckBoxCorpusColor_CheckedChanged;

            // Обробники для матеріалів корпусу
            checkBoxPolimer_corpus.CheckedChanged += CheckBoxCorpusMaterial_CheckedChanged;
            checkBoxNerzhaStal_corpus.CheckedChanged += CheckBoxCorpusMaterial_CheckedChanged;
            checkBoxLatun_corpus.CheckedChanged += CheckBoxCorpusMaterial_CheckedChanged;
            checkBoxKeramikaAndStal_corpus.CheckedChanged += CheckBoxCorpusMaterial_CheckedChanged;
            checkBoxKeramika_corpus.CheckedChanged += CheckBoxCorpusMaterial_CheckedChanged;
            checkBoxCarbon_corpus.CheckedChanged += CheckBoxCorpusMaterial_CheckedChanged;
            checkBoxZolotoOrStal_corpus.CheckedChanged += CheckBoxCorpusMaterial_CheckedChanged;
            checkBoxZoloto_corpus.CheckedChanged += CheckBoxCorpusMaterial_CheckedChanged;
            checkBoxAlumin_corpus.CheckedChanged += CheckBoxCorpusMaterial_CheckedChanged;

            // Обробники для форм корпусу
            checkBoxTriangle_corpus.CheckedChanged += CheckBoxCorpusShape_CheckedChanged;
            checkBoxPryamokutni_corpus.CheckedChanged += CheckBoxCorpusShape_CheckedChanged;
            checkBoxOvalni_corpus.CheckedChanged += CheckBoxCorpusShape_CheckedChanged;
            checkBoxNestandartni_corpus.CheckedChanged += CheckBoxCorpusShape_CheckedChanged;
            checkBoxKrugli_corpus.CheckedChanged += CheckBoxCorpusShape_CheckedChanged;
            checkBoxKvadratni_corpus.CheckedChanged += CheckBoxCorpusShape_CheckedChanged;
            checkBoxBochka_corpus.CheckedChanged += CheckBoxCorpusShape_CheckedChanged;

            // Обробники для водозахисту
            checkBoxWithoutZakhust.CheckedChanged += CheckBoxWaterResistance_CheckedChanged;
            checkBox_600wr.CheckedChanged += CheckBoxWaterResistance_CheckedChanged;
            checkBox_50wr.CheckedChanged += CheckBoxWaterResistance_CheckedChanged;
            checkBox_500wr.CheckedChanged += CheckBoxWaterResistance_CheckedChanged;
            checkBox_30wr.CheckedChanged += CheckBoxWaterResistance_CheckedChanged;
            checkBox_300wr.CheckedChanged += CheckBoxWaterResistance_CheckedChanged;
            checkBox_3000wr.CheckedChanged += CheckBoxWaterResistance_CheckedChanged;
            checkBox_200wr.CheckedChanged += CheckBoxWaterResistance_CheckedChanged;
            checkBox_2000wr.CheckedChanged += CheckBoxWaterResistance_CheckedChanged;
            checkBox_1500wr.CheckedChanged += CheckBoxWaterResistance_CheckedChanged;
            checkBox_100wr.CheckedChanged += CheckBoxWaterResistance_CheckedChanged;
            checkBox_1000wr.CheckedChanged += CheckBoxWaterResistance_CheckedChanged;

            // Обробники для кольорів циферблату
            checkBoxRed_ciferblat.CheckedChanged += CheckBoxDialColor_CheckedChanged;
            checkBoxFiolet_ciferblat.CheckedChanged += CheckBoxDialColor_CheckedChanged;
            checkBoxSriblyasty_ciferblat.CheckedChanged += CheckBoxDialColor_CheckedChanged;
            checkBoxSiriy_ciferblat.CheckedChanged += CheckBoxDialColor_CheckedChanged;
            checkBoxSiniy_ciferblat.CheckedChanged += CheckBoxDialColor_CheckedChanged;
            checkBoxRozhevy_ciferblat.CheckedChanged += CheckBoxDialColor_CheckedChanged;
            checkBoxColorovy_ciferblat.CheckedChanged += CheckBoxDialColor_CheckedChanged;
            checkBoxZolotusty_ciferblat.CheckedChanged += CheckBoxDialColor_CheckedChanged;
            checkBoxGreen_ciferblat.CheckedChanged += CheckBoxDialColor_CheckedChanged;
            checkBoxZhovty_ciferblat.CheckedChanged += CheckBoxDialColor_CheckedChanged;
            checkBoxBlue_ciferblat.CheckedChanged += CheckBoxDialColor_CheckedChanged;
            checkBoxWhite_ciferblat.CheckedChanged += CheckBoxDialColor_CheckedChanged;
            checkBoxBezhevy_ciferblat.CheckedChanged += CheckBoxDialColor_CheckedChanged;

            // Обробники для видів індикації
            checkBoxRomAndInd_ind.CheckedChanged += CheckBoxIndicationView_CheckedChanged;
            checkBoxRom_ind.CheckedChanged += CheckBoxIndicationView_CheckedChanged;
            checkBoxRomAndArab_ind.CheckedChanged += CheckBoxIndicationView_CheckedChanged;
            checkBoxInd_ind.CheckedChanged += CheckBoxIndicationView_CheckedChanged;
            checkBoxElectrn_ind.CheckedChanged += CheckBoxIndicationView_CheckedChanged;
            checkBoxWithout_ind.CheckedChanged += CheckBoxIndicationView_CheckedChanged;
            checkBoxArabAndInd_ind.CheckedChanged += CheckBoxIndicationView_CheckedChanged;
            checkBoxArab_ind.CheckedChanged += CheckBoxIndicationView_CheckedChanged;

            // Обробники для матеріалу браслета
            checkBoxShkiroZaminnuk_beltMaterial.CheckedChanged += CheckBoxBeltMaterial_CheckedChanged;
            checkBoxShkira_beltMaterial.CheckedChanged += CheckBoxBeltMaterial_CheckedChanged;
            checkBoxTitan_beltMaterial.CheckedChanged += CheckBoxBeltMaterial_CheckedChanged;
            checkBoxTekstul_beltMaterial.CheckedChanged += CheckBoxBeltMaterial_CheckedChanged;
            checkBoxSulikon_beltMaterial.CheckedChanged += CheckBoxBeltMaterial_CheckedChanged;
            checkBoxPolimer_beltMaterial.CheckedChanged += CheckBoxBeltMaterial_CheckedChanged;
            checkBoxStal_beltMaterial.CheckedChanged += CheckBoxBeltMaterial_CheckedChanged;
            checkBoxNeylon_beltMaterial.CheckedChanged += CheckBoxBeltMaterial_CheckedChanged;
            checkBoxKeramika_beltMaterial.CheckedChanged += CheckBoxBeltMaterial_CheckedChanged;
            checkBoxKauchuk_beltMaterial.CheckedChanged += CheckBoxBeltMaterial_CheckedChanged;
            checkBoxZolotoStal_beltMaterial.CheckedChanged += CheckBoxBeltMaterial_CheckedChanged;

            // Обробники для типу індикації
            checkBoxCufrovy_indType.CheckedChanged += CheckBoxIndicationType_CheckedChanged;
            checkBoxAnalogAndCufrov_indType.CheckedChanged += CheckBoxIndicationType_CheckedChanged;
            checkBoxAnalogv_indType.CheckedChanged += CheckBoxIndicationType_CheckedChanged;
        }

        // загрузка бд в датагрід
        public void LoadWatchData()
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


        // створення стовпців
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
            dataGridView1.Columns.Add("indication_view", "Вид індикації");
            dataGridView1.Columns.Add("stock_quantity", "В наявності");
            dataGridView1.Columns.Add("description", "Опис");
            dataGridView1.Columns.Add("gender", "Стать");
        }

        // імя на сторінці 
        public void SetUserName(string userName)
        {
            labelUserName.Text = $"Привіт, {userName}!";
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

        public void ToggleBrandFilter(string brand, Button button)
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







        // методи за фільтром по статті
        private HashSet<string> activeGenders = new HashSet<string>();

        private void FilterByGender()
        {
            dataGridView1.Rows.Clear();

            if (activeGenders.Count == 0)
            {
                LoadWatchData(); // Завантажуємо всі дані, якщо статі не вибрані
                return;
            }

            string queryString = $@"
SELECT brand, title, watch_version, mechanism_type, housing_material, belt_material, price, case_diameter, case_color, case_shape, water_resistance, dial_color, glass_type, indication_type, indication_view, stock_quantity, description, gender 
FROM watch 
WHERE gender IN ({string.Join(", ", activeGenders.Select(g => $"'{g}'"))})";

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

        private void ToggleGenderFilter(string gender, Button button)
        {
            if (activeGenders.Contains(gender))
            {
                activeGenders.Remove(gender);
                button.BackColor = Color.FromArgb(109, 112, 94); // Неактивний колір
            }
            else
            {
                activeGenders.Add(gender);
                button.BackColor = Color.White; // Активний колір
            }

            FilterByGender(); // Оновлюємо фільтр
        }

        // обробник натискань на  стать
        private void buttonWomen_Click(object sender, EventArgs e)
        {
            ToggleGenderFilter("Women", buttonWomen);
            ApplyFilters();
        }

        private void buttonUniSex_Click(object sender, EventArgs e)
        {
            ToggleGenderFilter("Unisex", buttonUniSex);
            ApplyFilters();
        }

        private void buttonMen_Click(object sender, EventArgs e)
        {
            ToggleGenderFilter("Men", buttonMen);
            ApplyFilters();
        }






        // методи для пошуку за ціною 

        private void findByPrice()
        {
            decimal minPrice = 0;
            decimal maxPrice = decimal.MaxValue;

            // Перевіряємо введені значення та конвертуємо їх
            if (!string.IsNullOrWhiteSpace(textBoxMinPrice.Text) &&
                !decimal.TryParse(textBoxMinPrice.Text, out minPrice))
            {
                MessageBox.Show("Некоректне значення мінімальної ціни", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!string.IsNullOrWhiteSpace(textBoxMaxPrice.Text) &&
                !decimal.TryParse(textBoxMaxPrice.Text, out maxPrice))
            {
                MessageBox.Show("Некоректне значення максимальної ціни", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (minPrice > maxPrice)
            {
                MessageBox.Show("Мінімальна ціна не може бути більшою за максимальну", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Очищаємо таблицю
            dataGridView1.Rows.Clear();

            // SQL-запит із фільтром за ціною
            string queryString = $@"
SELECT brand, title, watch_version, mechanism_type, housing_material, belt_material, price, case_diameter, case_color, case_shape, water_resistance, dial_color, glass_type, indication_type, indication_view, stock_quantity, description, gender 
FROM watch 
WHERE price BETWEEN @minPrice AND @maxPrice";

            using (SqlCommand command = new SqlCommand(queryString, dataBase.getConnection()))
            {
                // Передаємо параметри
                command.Parameters.AddWithValue("@minPrice", minPrice);
                command.Parameters.AddWithValue("@maxPrice", maxPrice);

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

        // обробник натискань на пошук за ціною
        private void buttonFindByPrice_Click(object sender, EventArgs e)
        {
            findByPrice();
            ApplyFilters();
        }







        // Версія годинників Fashion Kids Men Women

        private HashSet<string> activeCategories = new HashSet<string>();

        private void CheckBoxCategory_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;

            if (checkBox == null) return;

            // Додаємо або видаляємо вибрану категорію
            if (checkBox.Checked)
            {
                activeCategories.Add(checkBox.Tag.ToString());
            }
            else
            {
                activeCategories.Remove(checkBox.Tag.ToString());
            }

            // Оновлюємо фільтр
            FilterByCategories();
        }

        private void FilterByCategories()
        {
            dataGridView1.Rows.Clear();

            if (activeCategories.Count == 0)
            {
                LoadWatchData(); // Показуємо всі записи, якщо категорії не вибрано
                return;
            }

            string queryString = $@"
SELECT brand, title, watch_version, mechanism_type, housing_material, belt_material, price, case_diameter, case_color, case_shape, water_resistance, dial_color, glass_type, indication_type, indication_view, stock_quantity, description, gender
FROM watch 
WHERE watch_version IN ({string.Join(", ", activeCategories.Select(c => $"'{c}'"))})";

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
                        reader.GetString(17) // gender
                       
                    );
                }

                reader.Close();
                dataBase.closeConnection();
                ApplyFilters();
            }
        }








        // діаметр корпусу

        private Tuple<double, double> GetDiameterRange()
        {
            // Перевіряємо, який RadioButton обрано, і повертаємо відповідний діапазон.
            if (radioButton21_33mm.Checked)
                return Tuple.Create(21.0, 33.0);
            else if (radioButton33_38mm.Checked)
                return Tuple.Create(33.0, 38.0);
            else if (radioButton38_41mm.Checked)
                return Tuple.Create(38.0, 41.0);
            else if (radioButton41_43mm.Checked)
                return Tuple.Create(41.0, 43.0);
            else if (radioButton43_45mm.Checked)
                return Tuple.Create(43.0, 45.0);
            else if (radioButton45_87mm.Checked)
                return Tuple.Create(45.0, 87.0);

            // Якщо нічого не вибрано, повертаємо null.
            return null;
        }

        private void RadioButtonDiameter_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked) // Перевіряємо, чи RadioButton обраний
            {
                ApplyFilters(); // Викликаємо метод для застосування фільтрів
            }
        }









        // матеріал корпусу
        private List<string> activeCorpusMaterials = new List<string>();

        private void CheckBoxCorpusMaterial_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;

            if (checkBox.Checked)
            {
                activeCorpusMaterials.Add(checkBox.Text); // Додаємо обраний матеріал до списку
            }
            else
            {
                activeCorpusMaterials.Remove(checkBox.Text); // Видаляємо матеріал зі списку
            }

            ApplyFilters(); // Оновлюємо дані
        }







        // колір корпусу
        private List<string> activeCorpusColors = new List<string>();
        private void CheckBoxCorpusColor_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;

            if (checkBox.Checked)
            {
                activeCorpusColors.Add(checkBox.Text); // Додаємо обраний колір до списку
            }
            else
            {
                activeCorpusColors.Remove(checkBox.Text); // Видаляємо колір зі списку
            }

            ApplyFilters(); // Оновлюємо дані
        }






        // форма корпусу
        private List<string> activeCorpusShapes = new List<string>();
        private void CheckBoxCorpusShape_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;

            if (checkBox.Checked)
            {
                activeCorpusShapes.Add(checkBox.Text); // Додаємо обрану форму до списку
            }
            else
            {
                activeCorpusShapes.Remove(checkBox.Text); // Видаляємо форму зі списку
            }

            ApplyFilters(); // Оновлюємо дані
        }




        // водозахист
        private List<string> activeWaterResistances = new List<string>();
        private void CheckBoxWaterResistance_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;

            if (checkBox.Checked)
            {
                activeWaterResistances.Add(checkBox.Text); // Додаємо обраний рівень водозахисту до списку
            }
            else
            {
                activeWaterResistances.Remove(checkBox.Text); // Видаляємо рівень зі списку
            }

            ApplyFilters(); // Оновлюємо дані
        }






        // колір циферблату
        private List<string> activeDialColors = new List<string>();
        private void CheckBoxDialColor_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;

            if (checkBox.Checked)
            {
                activeDialColors.Add(checkBox.Text); // Додаємо обраний колір до списку
            }
            else
            {
                activeDialColors.Remove(checkBox.Text); // Видаляємо колір зі списку
            }

            ApplyFilters(); // Оновлюємо дані
        }






        // вид індикації
        private List<string> activeIndicationViews = new List<string>();
        private void CheckBoxIndicationView_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;

            if (checkBox.Checked)
            {
                activeIndicationViews.Add(checkBox.Text); // Додаємо обраний вид індикації до списку
            }
            else
            {
                activeIndicationViews.Remove(checkBox.Text); // Видаляємо вид зі списку
            }

            ApplyFilters(); // Оновлюємо дані
        }






        // матеріал браслету 
        private List<string> activeBeltMaterials = new List<string>();
        private void CheckBoxBeltMaterial_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;

            if (checkBox.Checked)
            {
                activeBeltMaterials.Add(checkBox.Text); // Додаємо вибраний матеріал до списку
            }
            else
            {
                activeBeltMaterials.Remove(checkBox.Text); // Видаляємо матеріал зі списку
            }

            ApplyFilters(); // Оновлюємо фільтрацію після зміни
        }







        // тип індикації
        private List<string> activeIndicationTypes = new List<string>();
        private void CheckBoxIndicationType_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;

            if (checkBox.Checked)
            {
                activeIndicationTypes.Add(checkBox.Text); // Додаємо вибраний тип індикації до списку
            }
            else
            {
                activeIndicationTypes.Remove(checkBox.Text); // Видаляємо тип індикації зі списку
            }

            ApplyFilters(); // Оновлюємо фільтрацію після зміни
        }








        // механізми 

        // Колекція для збереження вибраних типів механізмів
        private HashSet<string> activeMechanismTypes = new HashSet<string>();

        // Подія для фільтрації за типом механізму
        private void CheckBoxMechanismType_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;

            if (checkBox == null || checkBox.Tag == null) return;

            string mechanismType = checkBox.Tag.ToString();

            // Додаємо або видаляємо тип механізму зі списку
            if (checkBox.Checked)
            {
                activeMechanismTypes.Add(mechanismType);
            }
            else
            {
                activeMechanismTypes.Remove(mechanismType);
            }

            // Оновлюємо фільтр
            FilterByMechanismType();
        }

        // Функція фільтрації за типами механізмів
        private void FilterByMechanismType()
        {
            dataGridView1.Rows.Clear();

            if (activeMechanismTypes.Count == 0)
            {
                LoadWatchData(); // Показуємо всі записи, якщо типи механізмів не вибрано
                return;
            }

            // Формуємо SQL-запит для фільтрації за типами механізмів
            string queryString = @"
SELECT brand, title, watch_version, mechanism_type, housing_material, belt_material, price, case_diameter, case_color, case_shape, water_resistance, dial_color, glass_type, indication_type, indication_view, stock_quantity, description, gender
FROM watch 
WHERE mechanism_type IN (" + string.Join(", ", activeMechanismTypes.Select(m => $"'{m}'")) + ")";

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








        // тип скла

        private HashSet<string> activeGlassTypes = new HashSet<string>();

        private void CheckBoxGlassType_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;

            if (checkBox == null || checkBox.Tag == null) return;

            string glassType = checkBox.Tag.ToString();

            // Додаємо або видаляємо тип скла зі списку
            if (checkBox.Checked)
            {
                activeGlassTypes.Add(glassType);
            }
            else
            {
                activeGlassTypes.Remove(glassType);
            }

            // Оновлюємо фільтр
            FilterByGlassType();
        }

        private void FilterByGlassType()
        {
            dataGridView1.Rows.Clear();

            if (activeGlassTypes.Count == 0)
            {
                LoadWatchData(); // Показуємо всі записи, якщо типи скла не вибрано
                return;
            }

            // Формуємо SQL-запит
            string queryString = @"
SELECT brand, title, watch_version, mechanism_type, housing_material, belt_material, price, case_diameter, case_color, case_shape, water_resistance, dial_color, glass_type, indication_type, indication_view, stock_quantity, description, gender
FROM watch 
WHERE glass_type IN (" + string.Join(", ", activeGlassTypes.Select(g => $"'{g}'")) + ")";

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
                ApplyFilters();
            }
        }






       





       
        // метод для комбінованого пошуку
        public void ApplyFilters()
        {
            // Базовий запит
            string queryString = @"
SELECT brand, title, watch_version, mechanism_type, housing_material, belt_material, price, case_diameter, case_color, case_shape, water_resistance, dial_color, glass_type, indication_type, indication_view, stock_quantity, description, gender 
FROM watch 
WHERE 1=1"; // Базова умова, яка завжди істинна

            // Динамічні умови
            List<string> conditions = new List<string>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            // Фільтр за watch_version
            if (activeCategories.Count > 0)
            {
                string categoryCondition = string.Join(", ", activeCategories.Select((c, index) => $"@watchVersion{index}"));
                conditions.Add($"watch_version IN ({categoryCondition})");

                int categoryIndex = 0;
                foreach (string category in activeCategories)
                {
                    parameters.Add($"@watchVersion{categoryIndex++}", category);
                }
            }

            // Фільтр за брендами
            if (activeBrands.Count > 0)
            {
                string brandCondition = string.Join(", ",activeBrands.Select((b, index) => $"@brand{index}"));
                conditions.Add($"brand IN ({brandCondition})");

                int brandIndex = 0;
                foreach (string brand in activeBrands)
                {
                    parameters.Add($"@brand{brandIndex++}", brand);
                }
            }

            // Фільтр за типом індикації (indication_type)
            if (activeIndicationTypes.Count > 0)
            {
                string indicationTypeCondition = string.Join(", ", activeIndicationTypes.Select((i, index) => $"@indicationType{index}"));
                conditions.Add($"indication_type IN ({indicationTypeCondition})");

                int indicationTypeIndex = 0;
                foreach (string indicationType in activeIndicationTypes)
                {
                    parameters.Add($"@indicationType{indicationTypeIndex++}", indicationType);
                }
            }


            // Фільтр за матеріалом браслета (belt_material)
            if (activeBeltMaterials.Count > 0)
            {
                string beltMaterialCondition = string.Join(", ", activeBeltMaterials.Select((b, index) => $"@beltMaterial{index}"));
                conditions.Add($"belt_material IN ({beltMaterialCondition})");

                int beltMaterialIndex = 0;
                foreach (string beltMaterial in activeBeltMaterials)
                {
                    parameters.Add($"@beltMaterial{beltMaterialIndex++}", beltMaterial);
                }
            }


            // Фільтр за кольором циферблату
            if (activeDialColors.Count > 0)
            {
                string dialColorCondition = string.Join(", ", activeDialColors.Select((c, index) => $"@dialColor{index}"));
                conditions.Add($"dial_color IN ({dialColorCondition})");

                int dialColorIndex = 0;
                foreach (string dialColor in activeDialColors)
                {
                    parameters.Add($"@dialColor{dialColorIndex++}", dialColor);
                }
            }

            // Фільтр за видом індикації (indication_view)
            if (activeIndicationViews.Count > 0)
            {
                string indicationViewCondition = string.Join(", ", activeIndicationViews.Select((i, index) => $"@indicationView{index}"));
                conditions.Add($"indication_view IN ({indicationViewCondition})");

                int indicationViewIndex = 0;
                foreach (string indicationView in activeIndicationViews)
                {
                    parameters.Add($"@indicationView{indicationViewIndex++}", indicationView);
                }
            }



            // Фільтр за водозахистом
            if (activeWaterResistances.Count > 0)
            {
                string waterResistanceCondition = string.Join(", ", activeWaterResistances.Select((w, index) => $"@waterResistance{index}"));
                conditions.Add($"water_resistance IN ({waterResistanceCondition})");

                int waterResistanceIndex = 0;
                foreach (string waterResistance in activeWaterResistances)
                {
                    parameters.Add($"@waterResistance{waterResistanceIndex++}", waterResistance);
                }
            }


            // Фільтр за формою корпусу
            if (activeCorpusShapes.Count > 0)
            {
                string shapeCondition = string.Join(", ", activeCorpusShapes.Select((s, index) => $"@caseShape{index}"));
                conditions.Add($"case_shape IN ({shapeCondition})");

                int shapeIndex = 0;
                foreach (string shape in activeCorpusShapes)
                {
                    parameters.Add($"@caseShape{shapeIndex++}", shape);
                }
            }

            // Фільтр за статтю
            if (activeGenders.Count > 0)
            {
                string genderCondition = string.Join(", ", activeGenders.Select((g, index) => $"@gender{index}"));
                conditions.Add($"gender IN ({genderCondition})");

                int genderIndex = 0;
                foreach (string gender in activeGenders)
                {
                    parameters.Add($"@gender{genderIndex++}", gender);
                }
            }

            // Фільтр за матеріалом корпусу
            if (activeCorpusMaterials.Count > 0)
            {
                string materialCondition = string.Join(", ", activeCorpusMaterials.Select((m, index) => $"@caseMaterial{index}"));
                conditions.Add($"housing_material IN ({materialCondition})");

                int materialIndex = 0;
                foreach (string material in activeCorpusMaterials)
                {
                    parameters.Add($"@caseMaterial{materialIndex++}", material);
                }
            }

            // Фільтр за ціною
            if (decimal.TryParse(textBoxMinPrice.Text, out decimal minPrice))
            {
                conditions.Add("price >= @minPrice");
                parameters.Add("@minPrice", minPrice);
            }

            if (decimal.TryParse(textBoxMaxPrice.Text, out decimal maxPrice))
            {
                conditions.Add("price <= @maxPrice");
                parameters.Add("@maxPrice", maxPrice);
            }

            // Фільтр за діаметром корпусу
            var diameterRange = GetDiameterRange();
            if (diameterRange != null)
            {
                conditions.Add("case_diameter BETWEEN @minDiameter AND @maxDiameter");
                parameters.Add("@minDiameter", diameterRange.Item1);
                parameters.Add("@maxDiameter", diameterRange.Item2);
            }


            // Фільтр за кольором корпусу
            if (activeCorpusColors.Count > 0)
            {
                string colorCondition = string.Join(", ", activeCorpusColors.Select((c, index) => $"@caseColor{index}"));
                conditions.Add($"case_color IN ({colorCondition})");

                int colorIndex = 0;
                foreach (string color in activeCorpusColors)
                {
                    parameters.Add($"@caseColor{colorIndex++}", color);
                }
            }

            // Фільтр за типом скла
            if (activeGlassTypes.Count > 0)
            {
                string glassTypeCondition = string.Join(", ", activeGlassTypes.Select((g, index) => $"@glassType{index}"));
                conditions.Add($"glass_type IN ({glassTypeCondition})");

                int glassTypeIndex = 0;
                foreach (string glassType in activeGlassTypes)
                {
                    parameters.Add($"@glassType{glassTypeIndex++}", glassType);
                }
            }

            // Фільтр за типом механізму
            List<string> mechanismTypes = new List<string>();

            if (checkBoxMechanic_mechanismType.Checked)
            {
                mechanismTypes.Add("Механічний");
            }

            if (checkBoxMexanikaZAvtopid_mechanismType.Checked)
            {
                mechanismTypes.Add("Механіка з автопідзаводом");
            }

            if (checkBoxKvarc_mechanismType.Checked)
            {
                mechanismTypes.Add("Кварцевий");
            }

            if (checkBoxAvtoKvarc_mechanismType.Checked)
            {
                mechanismTypes.Add("Автокварцевий");
            }

            if (mechanismTypes.Count > 0)
            {
                string mechanismCondition = string.Join(", ", mechanismTypes.Select((m, index) => $"@mechanismType{index}"));
                conditions.Add($"mechanism_type IN ({mechanismCondition})");

                int mechanismIndex = 0;
                foreach (string mechanismType in mechanismTypes)
                {
                    parameters.Add($"@mechanismType{mechanismIndex++}", mechanismType);
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






        // подвійне натискання на дата грід 
        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Отримуємо значення з вибраного рядка
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                string brand = row.Cells["brand"].Value.ToString();
                string title = row.Cells["title"].Value.ToString();
                string watchVersion = row.Cells["watch_version"].Value.ToString();
                string mechanismType = row.Cells["mechanism_type"].Value.ToString();
                string housingMaterial = row.Cells["housing_material"].Value.ToString();
                string beltMaterial = row.Cells["belt_material"].Value.ToString();
                decimal price = Convert.ToDecimal(row.Cells["price"].Value);
                double caseDiameter = Convert.ToDouble(row.Cells["case_diameter"].Value);
                string caseColor = row.Cells["case_color"].Value.ToString();
                string caseShape = row.Cells["case_shape"].Value.ToString();
                string waterResistance = row.Cells["water_resistance"].Value.ToString();
                string dialColor = row.Cells["dial_color"].Value.ToString();
                string glassType = row.Cells["glass_type"].Value.ToString();
                string indicationType = row.Cells["indication_type"].Value.ToString();
                string indicationView = row.Cells["indication_view"].Value.ToString();
                string description = row.Cells["description"].Value.ToString();
                string gender = row.Cells["gender"].Value.ToString();
                int quantity = Convert.ToInt32(row.Cells["stock_quantity"].Value.ToString() );

                // Відкриваємо форму OrderForm з передачею даних
                OrderForm orderForm = new OrderForm(
                    brand, title, watchVersion, mechanismType, housingMaterial, beltMaterial,
                    price, caseDiameter, caseColor, caseShape, waterResistance, dialColor,
                    glassType, indicationType, indicationView, description, gender, quantity);

                orderForm.ShowDialog(); // Показуємо форму
            }
        }
    }
}
