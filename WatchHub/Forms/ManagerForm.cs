﻿using System;
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
using Color = System.Drawing.Color;



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
            InitializeCheckBoxes();
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
            dataGridView1.Columns.Add("gender", "Стать");

            dataGridView1.Columns.Add("IsNew", String.Empty);
            

        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetString(4), record.GetString(5),
             record.GetString(6), record.GetDecimal(7), record.GetDouble(8),   
                 record.GetString(9), record.GetString(10), record.GetString(11), record.GetString(12), record.GetString(13),
                record.GetString(14), record.GetString(15), record.GetInt32(16), record.GetString(17), record.GetString(18), RowState.ModifiedNew);
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
                brand_comboBox.Text = row.Cells[1].Value.ToString();
                title_textBox.Text = row.Cells[2].Value.ToString();
                version_comboBox.Text = row.Cells[3].Value.ToString();
                mechanism_comboBox.Text = row.Cells[4].Value.ToString();
                caseMaterial_comboBox.Text = row.Cells[5].Value.ToString();
                beltMaterial_comboBox.Text = row.Cells[6].Value.ToString();
                price_textBox.Text = row.Cells[7].Value.ToString();
                case_diameter_textBox.Text = row.Cells[8].Value.ToString();
                caseColor_comboBox.Text = row.Cells[9].Value.ToString();
                caseShape_comboBox.Text = row.Cells[10].Value.ToString();
                waterRistance_comboBox.Text = row.Cells[11].Value.ToString();
                dialColor_comboBox.Text = row.Cells[12].Value.ToString();
                glassType_comboBofx.Text = row.Cells[13].Value.ToString();
                indicationType_comboBox.Text = row.Cells[14].Value.ToString();
                indicationView_comboBox.Text = row.Cells[15].Value.ToString();
                stock_quantity_textBox.Text = row.Cells[16].Value.ToString();
                description_textBox.Text = row.Cells[17].Value.ToString();
                gender_comboBox.Text = row.Cells[18].Value.ToString();


            }
        }

        private void ClearFields ()
        {

            id_textBox.Text = "";
            brand_comboBox.Text = "";
            title_textBox.Text = "";
            version_comboBox.Text = "";
            mechanism_comboBox.Text = "";
            caseMaterial_comboBox.Text = "";
            beltMaterial_comboBox.Text = "";
            price_textBox.Text = "";
            case_diameter_textBox.Text = "";
            caseColor_comboBox.Text = "";
            caseShape_comboBox.Text = "";
            waterRistance_comboBox.Text = "";
            dialColor_comboBox.Text = "";
            glassType_comboBofx.Text = "";
            indicationType_comboBox.Text = "";
            indicationView_comboBox.Text = "";
            stock_quantity_textBox.Text = "";
            description_textBox.Text = "";
            gender_comboBox.Text = "";

        }

        private void deleteRow()
        {
            int index = dataGridView1.CurrentCell.RowIndex;

            dataGridView1.Rows[index].Visible = false;

            if (dataGridView1.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridView1.Rows[index].Cells[19].Value = RowState.Deleted;
                return;
            }

            dataGridView1.Rows[index].Cells[19].Value = RowState.Deleted;
        }

        private void Update()
        {
            dataBase.openConnection();

            for (int index = 0; index < dataGridView1.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView1.Rows[index].Cells[19].Value;

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
                    var gender = dataGridView1.Rows[index].Cells[18].Value.ToString();


                    var changeQuery = "UPDATE watch SET " +
                        "brand = @brand, title = @title, watch_version = @watch_version, " +
                        "mechanism_type = @mechanism_type, housing_material = @housing_material, belt_material = @belt_material, " +
                        "price = @price, case_diameter = @case_diameter, case_color = @case_color, case_shape = @case_shape, " +
                        "water_resistance = @water_resistance, dial_color = @dial_color, glass_type = @glass_type, " +
                        "indication_type = @indication_type, indication_view = @indication_view, " +
                        "stock_quantity = @stock_quantity, description = @description, gender = @gender " + 
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
                        command.Parameters.AddWithValue("@gender", gender);

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
                $"indication_view, stock_quantity, description, gender) like '%" + textBox_search.Text + "%'";

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
                var brand = brand_comboBox.Text;
                var title = title_textBox.Text;
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
                var description = description_textBox.Text;
                var gender = gender_comboBox.Text;

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
                    price, case_diameter, case_color, case_shape, water_resistance, dial_color, glass_type, indication_type, indication_view, stock_quantity, description,gender);
                    dataGridView1.Rows[selectedRowIndex].Cells[19].Value = RowState.Modified;
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

            string queryString = $"SELECT watch_id, brand, title, watch_version, mechanism_type, housing_material, belt_material, price, case_diameter, case_color, case_shape, water_resistance, dial_color, glass_type, indication_type, indication_view, stock_quantity, description, gender FROM watch";


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
SELECT watch_id, brand, title, watch_version, mechanism_type, housing_material, belt_material, price, case_diameter, case_color, case_shape, water_resistance, dial_color, glass_type, indication_type, indication_view, stock_quantity, description, gender 
FROM watch 
WHERE gender IN ({string.Join(", ", activeGenders.Select(g => $"'{g}'"))})";

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
SELECT watch_id, brand, title, watch_version, mechanism_type, housing_material, belt_material, price, case_diameter, case_color, case_shape, water_resistance, dial_color, glass_type, indication_type, indication_view, stock_quantity, description, gender 
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
SELECT watch_id, brand, title, watch_version, mechanism_type, housing_material, belt_material, price, case_diameter, case_color, case_shape, water_resistance, dial_color, glass_type, indication_type, indication_view, stock_quantity, description, gender 
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
                string brandCondition = string.Join(", ", activeBrands.Select((b, index) => $"@brand{index}"));
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
                        reader.GetInt32 (0),// id
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

    }
}
