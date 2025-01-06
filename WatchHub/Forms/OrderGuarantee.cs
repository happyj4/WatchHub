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
    public partial class OrderGuarantee : Form
    {
        public OrderGuarantee()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void buttonCreateGuarantZvit_Click(object sender, EventArgs e)
        {
            // Підключення до бази
            Database db = new Database();

            if (!int.TryParse(textBoxOrder_id.Text, out int orderId))
            {
                MessageBox.Show("Введіть коректний ID замовлення!");
                return;
            }

            string query = @"
SELECT 
    o.order_id,
    o.order_date,
    w.title AS watch_name,
    w.brand,
    oi.quantity,
    u.first_name,
    u.last_name,
    u.email,
    u.city,
    u.country,
    u.street,
    u.house_number,
    u.phone_number
FROM orders o
JOIN order_items oi ON o.order_id = oi.order_id
JOIN watch w ON oi.watch_id = w.watch_id
JOIN users u ON o.id_user = u.user_id
WHERE o.order_id = @OrderId;
";

            try
            {
                db.openConnection();
                using (SqlCommand command = new SqlCommand(query, db.getConnection()))
                {
                    command.Parameters.AddWithValue("@OrderId", orderId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            MessageBox.Show("Замовлення з таким ID не знайдено.");
                            return;
                        }

                        // Створення документа
                        var document = new MigraDoc.DocumentObjectModel.Document();
                        var section = document.AddSection();

                        // Заголовок документа
                        var title = section.AddParagraph("Гарантійний звіт");
                        title.Format.Font.Size = 18;
                        title.Format.Font.Bold = true;
                        title.Format.SpaceAfter = "1cm";
                        title.Format.Alignment = ParagraphAlignment.Center;

                        // Додати інформацію про клієнта
                        if (reader.Read())
                        {
                            section.AddParagraph($"Клієнт: {reader["first_name"]} {reader["last_name"]}");
                            section.AddParagraph($"Email: {reader["email"]}");
                            section.AddParagraph($"Адреса: {reader["street"]}, {reader["house_number"]}, {reader["city"]}, {reader["country"]}");
                            section.AddParagraph($"Телефон: {reader["phone_number"]}");
                            section.AddParagraph($"Дата створення звіту: {DateTime.Now:yyyy-MM-dd HH:mm}");
                            section.AddParagraph($"ID Замовлення: {reader["order_id"]}");
                            section.AddParagraph($"Дата замовлення: {Convert.ToDateTime(reader["order_date"]).ToString("yyyy-MM-dd")}");
                            section.AddParagraph("\n");
                        }

                        // Створення таблиці
                        var table = section.AddTable();
                        table.Borders.Width = 0.75;

                        // Додати колонки
                        table.AddColumn("4cm"); // Назва годинника
                        table.AddColumn("3cm"); // Бренд
                        table.AddColumn("2cm"); // Кількість
                        table.AddColumn("4cm"); // Гарантійний термін

                        // Додати заголовок таблиці
                        var headerRow = table.AddRow();
                        headerRow.Cells[0].AddParagraph("Назва годинника");
                        headerRow.Cells[1].AddParagraph("Бренд");
                        headerRow.Cells[2].AddParagraph("Кількість");
                        headerRow.Cells[3].AddParagraph("Гарантійний термін");
                        headerRow.Format.Font.Bold = true;

                        // Заповнення таблиці
                        do
                        {
                            string brand = reader["brand"].ToString();
                            int warrantyYears = GetWarrantyYearsByBrand(brand);

                            var dataRow = table.AddRow();
                            dataRow.Cells[0].AddParagraph(reader["watch_name"].ToString());
                            dataRow.Cells[1].AddParagraph(brand);
                            dataRow.Cells[2].AddParagraph(reader["quantity"].ToString());
                            dataRow.Cells[3].AddParagraph($"{warrantyYears} роки");
                        } while (reader.Read());

                        // Рендеринг PDF
                        var renderer = new PdfDocumentRenderer(true)
                        {
                            Document = document
                        };
                        renderer.RenderDocument();

                        string pdfFilePath = $"WarrantyReport_Order_{orderId}.pdf";
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

        private int GetWarrantyYearsByBrand(string brand)
        {
            switch (brand)
            {
                case "Atlantic": return 2;
                case "Breitling": return 4;
                case "Bulgari": return 3;
                case "Casio": return 1;
                case "Citizen": return 2;
                case "Epos": return 3;
                case "Fossil": return 2;
                case "Hamilton": return 3;
                case "Hublot": return 4;
                case "Invicta": return 2;
                case "Longines": return 3;
                case "Omega": return 4;
                case "Orient": return 2;
                case "Oris": return 3;
                case "Patek Philippe": return 4;
                case "Rado": return 3;
                case "Rolex": return 4;
                case "Swatch": return 1;
                case "Tag Heuer": return 3;
                case "Timex": return 1;
                case "Tissot": return 2;
                default: return 1; // Значення за замовчуванням
            }
        }


        private void OrderGuarantee_Load(object sender, EventArgs e)
        {

        }
    }
}
