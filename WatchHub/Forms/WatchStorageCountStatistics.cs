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
    public partial class WatchStorageCountStatistics : Form
    {
        public WatchStorageCountStatistics()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void WatchStorageCountStatistics_Load(object sender, EventArgs e)
        {

        }

        private void buttonAllCountWatchStorage_Click(object sender, EventArgs e)
        {
            // Підключення до бази
            Database db = new Database();

            // SQL-запит для отримання загальної кількості годинників і їх розподілу по брендам
            string query = @"
SELECT 
    (SELECT SUM(stock_quantity) FROM watch) AS TotalCount,
    brand,
    SUM(stock_quantity) AS BrandStockCount
FROM watch
GROUP BY brand;
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
                            MessageBox.Show("Дані про товари на складі не знайдені.");
                            return;
                        }

                        // Створення документа
                        var document = new MigraDoc.DocumentObjectModel.Document();
                        var section = document.AddSection();

                        // Заголовок документа
                        var title = section.AddParagraph("Статистика складу годинників");
                        title.Format.Font.Size = 18;
                        title.Format.Font.Bold = true;
                        title.Format.SpaceAfter = "1cm";
                        title.Format.Alignment = ParagraphAlignment.Center;

                        // Дата створення звіту
                        section.AddParagraph($"Дата створення звіту: {DateTime.Now:yyyy-MM-dd HH:mm}");
                        section.AddParagraph("\n");

                        // Загальна кількість годинників
                        if (reader.Read())
                        {
                            int totalCount = Convert.ToInt32(reader["TotalCount"]);
                            var totalParagraph = section.AddParagraph($"Загальна кількість годинників на складі: {totalCount}");
                            totalParagraph.Format.Font.Size = 14;
                            totalParagraph.Format.Font.Bold = true;
                            totalParagraph.Format.SpaceAfter = "1cm";
                        }

                        // Повертаємо курсор до наступних рядків
                        do
                        {
                            // Бренд і кількість товару на складі
                            string brand = reader["brand"].ToString();
                            int stockCount = Convert.ToInt32(reader["BrandStockCount"]);

                            var brandParagraph = section.AddParagraph($"{brand}: {stockCount} годинників");
                            brandParagraph.Format.Font.Size = 12;
                        }
                        while (reader.Read());

                        // Рендеринг PDF
                        var renderer = new PdfDocumentRenderer(true)
                        {
                            Document = document
                        };
                        renderer.RenderDocument();

                        string pdfFilePath = $"WatchStorageReport.pdf";
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

        private void buttonWatchCountByTitleAndBrand_Click(object sender, EventArgs e)
        {
            // Підключення до бази
            Database db = new Database();

            // SQL-запит для отримання брендів і годинників з найбільшою та найменшою кількістю на складі
            string query = @"
WITH MaxStock AS (
    SELECT 
        brand,
        title AS WatchWithMaxStock,
        stock_quantity AS MaxStockQuantity,
        ROW_NUMBER() OVER (PARTITION BY brand ORDER BY stock_quantity DESC) AS RowNumberMax
    FROM watch
),
MinStock AS (
    SELECT 
        brand,
        title AS WatchWithMinStock,
        stock_quantity AS MinStockQuantity,
        ROW_NUMBER() OVER (PARTITION BY brand ORDER BY stock_quantity ASC) AS RowNumberMin
    FROM watch
)
SELECT 
    MaxStock.brand, -- явно указываем таблицу для brand
    MAX(CASE WHEN RowNumberMax = 1 THEN WatchWithMaxStock ELSE NULL END) AS WatchWithMaxStock,
    MAX(CASE WHEN RowNumberMax = 1 THEN MaxStockQuantity ELSE NULL END) AS MaxStockQuantity,
    MAX(CASE WHEN RowNumberMin = 1 THEN WatchWithMinStock ELSE NULL END) AS WatchWithMinStock,
    MAX(CASE WHEN RowNumberMin = 1 THEN MinStockQuantity ELSE NULL END) AS MinStockQuantity
FROM MaxStock
JOIN MinStock ON MaxStock.brand = MinStock.brand
GROUP BY MaxStock.brand;

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
                            MessageBox.Show("Дані про товари на складі не знайдені.");
                            return;
                        }

                        // Створення документа
                        var document = new MigraDoc.DocumentObjectModel.Document();
                        var section = document.AddSection();

                        // Заголовок документа
                        var title = section.AddParagraph("Статистика складу: найбільша та найменша кількість годинників за брендом");
                        title.Format.Font.Size = 18;
                        title.Format.Font.Bold = true;
                        title.Format.SpaceAfter = "1cm";
                        title.Format.Alignment = ParagraphAlignment.Center;

                        // Дата створення звіту
                        section.AddParagraph($"Дата створення звіту: {DateTime.Now:yyyy-MM-dd HH:mm}");
                        section.AddParagraph("\n");

                        // Формування таблиці результатів
                        var table = section.AddTable();
                        table.Borders.Width = 0.75;

                        // Додати колонки
                        table.AddColumn("4cm"); // Бренд
                        table.AddColumn("5cm"); // Годинник із найбільшою кількістю
                        table.AddColumn("2cm"); // Кількість (максимум)
                        table.AddColumn("5cm"); // Годинник із найменшою кількістю
                        table.AddColumn("2cm"); // Кількість (мінімум)

                        // Додати заголовок таблиці
                        var headerRow = table.AddRow();
                        headerRow.Cells[0].AddParagraph("Бренд");
                        headerRow.Cells[1].AddParagraph("Годинник (Макс)");
                        headerRow.Cells[2].AddParagraph("Кількість (Макс)");
                        headerRow.Cells[3].AddParagraph("Годинник (Мін)");
                        headerRow.Cells[4].AddParagraph("Кількість (Мін)");

                        headerRow.Format.Font.Bold = true;

                        // Заповнення таблиці
                        while (reader.Read())
                        {
                            var dataRow = table.AddRow();
                            dataRow.Cells[0].AddParagraph(reader["brand"].ToString());
                            dataRow.Cells[1].AddParagraph(reader["WatchWithMaxStock"].ToString());
                            dataRow.Cells[2].AddParagraph(reader["MaxStockQuantity"].ToString());
                            dataRow.Cells[3].AddParagraph(reader["WatchWithMinStock"].ToString());
                            dataRow.Cells[4].AddParagraph(reader["MinStockQuantity"].ToString());
                        }

                        // Рендеринг PDF
                        var renderer = new PdfDocumentRenderer(true)
                        {
                            Document = document
                        };
                        renderer.RenderDocument();

                        string pdfFilePath = $"WatchBrandStatsReport.pdf";
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
