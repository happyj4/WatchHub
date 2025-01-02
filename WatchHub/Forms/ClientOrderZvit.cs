using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using PdfSharp.Pdf;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using System.Data.SqlClient;
using iText.IO.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.IO.Font;
using iText.Kernel.Font;
using iText.Kernel.Font;
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
using System.Xml.Linq;


namespace WatchHub.Forms
{
    public partial class ClientOrderZvit : Form
    {
        public ClientOrderZvit()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void ClientOrderZvit_Load(object sender, EventArgs e)
        {

        }




        private void buttonCreateZvitOrder_Click(object sender, EventArgs e)
        {
            // Підключення до бази
            Database db = new Database();

            if (!int.TryParse(textBoxClientIdZvit.Text, out int userId))
            {
                MessageBox.Show("Введіть коректний ID користувача!");
                return;
            }

            string query = @"
SELECT 
    o.order_id,
    o.order_date,
    w.title AS watch_name,
    oi.quantity,
    oi.price,
    (oi.price * oi.quantity) AS item_total,
    u.first_name,
    u.last_name,
    u.email,
    u.city,
    u.country,
    u.street,
    u.house_number,
    u.phone_number,
    SUM(oi.price * oi.quantity) OVER (PARTITION BY o.order_id) AS total_order_amount
FROM orders o
JOIN order_items oi ON o.order_id = oi.order_id
JOIN watch w ON oi.watch_id = w.watch_id
JOIN users u ON o.id_user = u.user_id
WHERE u.user_id = @UserId;
";

            try
            {
                db.openConnection();
                using (SqlCommand command = new SqlCommand(query, db.getConnection()))
                {
                    command.Parameters.AddWithValue("@UserId", userId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            MessageBox.Show("Замовлення для цього користувача не знайдено.");
                            return;
                        }

                        // Створення документа
                        var document = new MigraDoc.DocumentObjectModel.Document();
                        var section = document.AddSection();

                        // Заголовок документа
                        var title = section.AddParagraph("Звіт про замовлення");
                        title.Format.Font.Size = 18;
                        title.Format.Font.Bold = true;
                        title.Format.SpaceAfter = "1cm";
                        title.Format.Alignment = ParagraphAlignment.Center;

                        // Додати інформацію про користувача
                        if (reader.Read())
                        {
                            section.AddParagraph($"Користувач ID: {userId}");
                            section.AddParagraph($"Ім'я: {reader["first_name"]} {reader["last_name"]}");
                            section.AddParagraph($"Email: {reader["email"]}");
                            section.AddParagraph($"Адреса: {reader["street"]}, {reader["house_number"]}, {reader["city"]}, {reader["country"]}");
                            section.AddParagraph($"Телефон: {reader["phone_number"]}");
                            section.AddParagraph($"Дата створення звіту: {DateTime.Now:yyyy-MM-dd HH:mm}");
                            section.AddParagraph("\n");
                        }

                        // Створення таблиці
                        var table = section.AddTable();
                        table.Borders.Width = 0.75;

                        // Додати колонки
                        table.AddColumn("3cm"); // ID замовлення
                        table.AddColumn("3cm"); // Дата замовлення
                        table.AddColumn("4cm"); // Назва годинника
                        table.AddColumn("2cm"); // Кількість
                        table.AddColumn("2cm"); // Ціна
                        table.AddColumn("3cm"); // Сума за позицію

                        // Додати заголовок таблиці
                        var headerRow = table.AddRow();
                        headerRow.Cells[0].AddParagraph("ID Замовлення");
                        headerRow.Cells[1].AddParagraph("Дата");
                        headerRow.Cells[2].AddParagraph("Назва годинника");
                        headerRow.Cells[3].AddParagraph("Кількість");
                        headerRow.Cells[4].AddParagraph("Ціна (грн)");
                        headerRow.Cells[5].AddParagraph("Сума за позицію (грн)");

                        headerRow.Format.Font.Bold = true;

                        decimal totalOrderAmount = 0;

                        // Заповнення таблиці
                        do
                        {
                            var dataRow = table.AddRow();
                            dataRow.Cells[0].AddParagraph(reader["order_id"].ToString());
                            dataRow.Cells[1].AddParagraph(Convert.ToDateTime(reader["order_date"]).ToString("yyyy-MM-dd"));
                            dataRow.Cells[2].AddParagraph(reader["watch_name"].ToString());
                            dataRow.Cells[3].AddParagraph(reader["quantity"].ToString());
                            dataRow.Cells[4].AddParagraph(Convert.ToDecimal(reader["price"]).ToString("F2"));
                            dataRow.Cells[5].AddParagraph(Convert.ToDecimal(reader["item_total"]).ToString("F2"));

                            totalOrderAmount = Convert.ToDecimal(reader["total_order_amount"]);
                        } while (reader.Read());

                        // Додати текст із загальною сумою під таблицею
                        section.AddParagraph("\n");
                        var totalParagraph = section.AddParagraph($"Загальна сума замовлення: {totalOrderAmount:F2} грн");
                        totalParagraph.Format.Font.Bold = true;
                        totalParagraph.Format.SpaceBefore = "1cm";

                        // Рендеринг PDF
                        var renderer = new PdfDocumentRenderer(true)
                        {
                            Document = document
                        };
                        renderer.RenderDocument();

                        string pdfFilePath = $"OrderReport_User_{userId}.pdf";
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
