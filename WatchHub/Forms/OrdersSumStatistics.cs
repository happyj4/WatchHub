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
    public partial class OrdersSumStatistics : Form
    {
        public OrdersSumStatistics()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void OrdersSumStatistics_Load(object sender, EventArgs e)
        {

        }

        private void buttonCreateStatZagalSum_Click(object sender, EventArgs e)
        {
            // Підключення до бази
            Database db = new Database();

            // SQL-запит для обчислення загальної суми прибутку
            string query = @"
SELECT 
    SUM(oi.quantity * oi.price) AS TotalRevenue
FROM order_items oi;
";

            try
            {
                db.openConnection();
                using (SqlCommand command = new SqlCommand(query, db.getConnection()))
                {
                    object result = command.ExecuteScalar();

                    if (result == DBNull.Value || result == null)
                    {
                        MessageBox.Show("Дані про прибуток не знайдені.");
                        return;
                    }

                    decimal totalRevenue = Convert.ToDecimal(result);

                    // Створення документа
                    var document = new MigraDoc.DocumentObjectModel.Document();
                    var section = document.AddSection();

                    // Заголовок документа
                    var title = section.AddParagraph("Загальна сума прибутку");
                    title.Format.Font.Size = 18;
                    title.Format.Font.Bold = true;
                    title.Format.SpaceAfter = "1cm";
                    title.Format.Alignment = ParagraphAlignment.Center;

                    // Дата створення звіту
                    section.AddParagraph($"Дата створення звіту: {DateTime.Now:yyyy-MM-dd HH:mm}");
                    section.AddParagraph("\n");

                    // Додати суму прибутку
                    var paragraph = section.AddParagraph($"Загальна сума прибутку: {totalRevenue:F2} грн");
                    paragraph.Format.Font.Size = 14;
                    paragraph.Format.Font.Bold = true;
                    paragraph.Format.SpaceAfter = "1cm";

                    // Рендеринг PDF
                    var renderer = new PdfDocumentRenderer(true)
                    {
                        Document = document
                    };
                    renderer.RenderDocument();

                    string pdfFilePath = $"TotalRevenueReport.pdf";
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

        private void buttonCreateStatDateSum_Click(object sender, EventArgs e)
        {

            // Підключення до бази
            Database db = new Database();

            // Отримання дат з DateTimePicker
            DateTime startDate = dateTimePickerStart.Value;
            DateTime finishDate = dateTimePickerFinish.Value;

            // SQL-запит для обчислення прибутку за певний період
            string query = @"
SELECT 
    SUM(oi.quantity * oi.price) AS TotalRevenue
FROM order_items oi
JOIN orders o ON oi.order_id = o.order_id
WHERE o.order_date >= @StartDate AND o.order_date <= @FinishDate;
";

            try
            {
                db.openConnection();
                using (SqlCommand command = new SqlCommand(query, db.getConnection()))
                {
                    // Передача параметрів
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@FinishDate", finishDate);

                    object result = command.ExecuteScalar();

                    if (result == DBNull.Value || result == null)
                    {
                        MessageBox.Show("Дані про прибуток за обраний період не знайдені.");
                        return;
                    }

                    decimal totalRevenue = Convert.ToDecimal(result);

                    // Створення документа
                    var document = new MigraDoc.DocumentObjectModel.Document();
                    var section = document.AddSection();

                    // Заголовок документа
                    var title = section.AddParagraph("Загальна сума прибутку за обраний період");
                    title.Format.Font.Size = 18;
                    title.Format.Font.Bold = true;
                    title.Format.SpaceAfter = "1cm";
                    title.Format.Alignment = ParagraphAlignment.Center;

                    // Дата створення звіту
                    section.AddParagraph($"Дата створення звіту: {DateTime.Now:yyyy-MM-dd HH:mm}");
                    section.AddParagraph("\n");

                    // Період
                    section.AddParagraph($"Період: від {startDate:yyyy-MM-dd} до {finishDate:yyyy-MM-dd}\n");

                    // Додати суму прибутку
                    var paragraph = section.AddParagraph($"Загальна сума прибутку: {totalRevenue:F2} грн");
                    paragraph.Format.Font.Size = 14;
                    paragraph.Format.Font.Bold = true;
                    paragraph.Format.SpaceAfter = "1cm";

                    // Рендеринг PDF
                    var renderer = new PdfDocumentRenderer(true)
                    {
                        Document = document
                    };
                    renderer.RenderDocument();

                    string pdfFilePath = $"TotalRevenueReport_{startDate:yyyyMMdd}_{finishDate:yyyyMMdd}.pdf";
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
