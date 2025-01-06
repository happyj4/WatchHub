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
using MigraDoc.DocumentObjectModel;



namespace WatchHub.Forms
{
    public partial class WatchAvgPriceStatistics : Form
    {
        public WatchAvgPriceStatistics()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void WatchAvgPriceStatistics_Load(object sender, EventArgs e)
        {

        }

        private void buttonAvgWatchPrice_Click(object sender, EventArgs e)
        {
            // Підключення до бази
            Database db = new Database();

            // SQL-запит для обчислення середньої ціни на годинник
            string query = @"
SELECT 
    AVG(price) AS AveragePrice
FROM watch;
";

            try
            {
                db.openConnection();
                using (SqlCommand command = new SqlCommand(query, db.getConnection()))
                {
                    object result = command.ExecuteScalar();

                    if (result == DBNull.Value || result == null)
                    {
                        MessageBox.Show("Дані про середню ціну годинників не знайдені.");
                        return;
                    }

                    decimal averagePrice = Convert.ToDecimal(result);

                    // Створення документа
                    var document = new MigraDoc.DocumentObjectModel.Document();
                    var section = document.AddSection();

                    // Заголовок документа
                    var title = section.AddParagraph("Середня ціна на годинник");
                    title.Format.Font.Size = 18;
                    title.Format.Font.Bold = true;
                    title.Format.SpaceAfter = "1cm";
                    title.Format.Alignment = ParagraphAlignment.Center;

                    // Дата створення звіту
                    section.AddParagraph($"Дата створення звіту: {DateTime.Now:yyyy-MM-dd HH:mm}");
                    section.AddParagraph("\n");

                    // Додати середню ціну
                    var paragraph = section.AddParagraph($"Середня ціна на годинник: {averagePrice:F2} грн");
                    paragraph.Format.Font.Size = 14;
                    paragraph.Format.Font.Bold = true;
                    paragraph.Format.SpaceAfter = "1cm";

                    // Рендеринг PDF
                    var renderer = new PdfDocumentRenderer(true)
                    {
                        Document = document
                    };
                    renderer.RenderDocument();

                    string pdfFilePath = $"AverageWatchPriceReport.pdf";
                    renderer.PdfDocument.Save(pdfFilePath);

                    MessageBox.Show($"Звіт створено: {pdfFilePath}");
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

        private void buttonAvgWatchPriceByBrand_Click(object sender, EventArgs e)
        {
            // Перевірка, чи вибрано бренд
            if (string.IsNullOrEmpty(comboBoxBrand.Text))
            {
                MessageBox.Show("Будь ласка, оберіть бренд.");
                return;
            }

            // Отримання обраного бренду
            string selectedBrand = comboBoxBrand.Text;

            // Підключення до бази
            Database db = new Database();

            // SQL-запит для обчислення середньої ціни годинників за обраним брендом
            string query = @"
SELECT 
    AVG(price) AS AveragePrice
FROM watch
WHERE brand = @Brand;
";

            try
            {
                db.openConnection();
                using (SqlCommand command = new SqlCommand(query, db.getConnection()))
                {
                    // Додавання параметра до запиту
                    command.Parameters.AddWithValue("@Brand", selectedBrand);

                    object result = command.ExecuteScalar();

                    if (result == DBNull.Value || result == null)
                    {
                        MessageBox.Show($"Дані про середню ціну годинників для бренду '{selectedBrand}' не знайдені.");
                        return;
                    }

                    decimal averagePrice = Convert.ToDecimal(result);

                    // Створення документа
                    var document = new MigraDoc.DocumentObjectModel.Document();
                    var section = document.AddSection();

                    // Заголовок документа
                    var title = section.AddParagraph($"Середня ціна на годинники бренду '{selectedBrand}'");
                    title.Format.Font.Size = 18;
                    title.Format.Font.Bold = true;
                    title.Format.SpaceAfter = "1cm";
                    title.Format.Alignment = ParagraphAlignment.Center;

                    // Дата створення звіту
                    section.AddParagraph($"Дата створення звіту: {DateTime.Now:yyyy-MM-dd HH:mm}");
                    section.AddParagraph("\n");

                    // Додати середню ціну
                    var paragraph = section.AddParagraph($"Середня ціна на годинники бренду '{selectedBrand}': {averagePrice:F2} грн");
                    paragraph.Format.Font.Size = 14;
                    paragraph.Format.Font.Bold = true;
                    paragraph.Format.SpaceAfter = "1cm";

                    // Рендеринг PDF
                    var renderer = new PdfDocumentRenderer(true)
                    {
                        Document = document
                    };
                    renderer.RenderDocument();

                    string pdfFilePath = $"AverageWatchPriceByBrand_{selectedBrand}.pdf";
                    renderer.PdfDocument.Save(pdfFilePath);

                    MessageBox.Show($"Звіт створено: {pdfFilePath}");
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
