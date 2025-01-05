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
using System.Text.RegularExpressions;

namespace WatchHub
{
    public partial class SignUpForm : Form

    {




        Database dataBase = new Database();
        public SignUpForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }



        private void createAcSignUpForm_Click(object sender, EventArgs e)
        {
            if (checkuser())
            {
                return; // Зупиняємо виконання, якщо користувач уже існує
            }

            var login = loginTextBoxSignUp.Text;
            var first_name = nameTextBoxSignUp.Text;
            var last_name = surnameTextBoxSignUp.Text;
            var email = emailTextBoxSignUp.Text;
            var city = cityTextBoxSignUp.Text;
            var country = countryTextBoxSignUp.Text;
            var street = streetTextBoxSignUp.Text;
            var houseNum = houseNumberTextBoxSignUp.Text;
            var password = passwordTextBoxSignUp.Text;
            var phonenum = phoneNumberTextBoxSignUp.Text;

            string querystring = "INSERT INTO users(first_name, last_name, email, city, country, street, house_number, password, login, phone_number) " +
                                 "VALUES(@first_name, @last_name, @email, @city, @country, @street, @houseNum, @password, @login, @phonenum)";

            SqlCommand command = new SqlCommand(querystring, dataBase.getConnection());
            command.Parameters.AddWithValue("@first_name", first_name);
            command.Parameters.AddWithValue("@last_name", last_name);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@city", city);
            command.Parameters.AddWithValue("@country", country);
            command.Parameters.AddWithValue("@street", street);
            command.Parameters.AddWithValue("@houseNum", houseNum);
            command.Parameters.AddWithValue("@password", password);
            command.Parameters.AddWithValue("@login", login);
            command.Parameters.AddWithValue("@phonenum", phonenum);

            dataBase.openConnection();

            try
            {
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Акаунт створено", "Успіх!");
                    LoginForm loginForm = new LoginForm();
                    loginForm.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("Акаунт не створено!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
            }
            finally
            {
                dataBase.closeConnection();
            }
        }



        private Boolean checkuser()
        {
            var loginUser = loginTextBoxSignUp.Text;
            var emailUser = emailTextBoxSignUp.Text;
            var phonenumUser = phoneNumberTextBoxSignUp.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            // Перевірка на унікальність login, email і phone_number
            string querystring = "SELECT user_id FROM users WHERE login = @login OR email = @email OR phone_number = @phone";

            SqlCommand command = new SqlCommand(querystring, dataBase.getConnection());
            command.Parameters.AddWithValue("@login", loginUser);
            command.Parameters.AddWithValue("@email", emailUser);
            command.Parameters.AddWithValue("@phone", phonenumUser);

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Користувач з таким логіном, електронною поштою або номером телефону вже існує!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true; // Користувач існує
            }
            else
            {
                return false; // Користувач не існує
            }
        }



        private void SignUpForm_Load(object sender, EventArgs e)
        {
            passwordTextBoxSignUp.UseSystemPasswordChar = true;
            pictureBoxOpen.Visible = false;
        }


        // Встановлюємо текст за замовчуванням у поля
        private void SetDefaultText(TextBox textBox, string defaultText)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = defaultText;
            }
        }

        private void ClearDefaultText(TextBox textBox, string defaultText)
        {
            if (textBox.Text == defaultText)
            {
                textBox.Text = "";
            }
        }

        private void ValidateText(TextBox textBox, string regexPattern, string errorMessage, int minLength = 2)
        {
            if (!Regex.IsMatch(textBox.Text, regexPattern))
            {
                MessageBox.Show(errorMessage, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox.Text = "";
            }
            else if (textBox.Text.Length < minLength)
            {
                MessageBox.Show($"Помилка: значення повинно бути більше {minLength - 1} символів.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox.Text = "";
            }
        }


        // Обробка для імені
        private void nameTextBoxSignUp_Enter(object sender, EventArgs e)
        {
            ClearDefaultText(nameTextBoxSignUp, "Ім'я");
        }

        private void nameTextBoxSignUp_Leave(object sender, EventArgs e)
        {
            SetDefaultText(nameTextBoxSignUp, "Ім'я");
            if (nameTextBoxSignUp.Text != "Ім'я")
            {
                ValidateText(nameTextBoxSignUp, @"^[a-zA-Zа-яА-ЯёЁіІїЇєЄґҐ]+$", "Помилка: ім'я повинно складатися тільки з літер.", 2);
            }
        }

        // Обробка для прізвища
        private void surnameTextBoxSignUp_Enter(object sender, EventArgs e)
        {
            ClearDefaultText(surnameTextBoxSignUp, "Прізвище");
        }

        private void surnameTextBoxSignUp_Leave(object sender, EventArgs e)
        {
            SetDefaultText(surnameTextBoxSignUp, "Прізвище");
            if (surnameTextBoxSignUp.Text != "Прізвище")
            {
                ValidateText(surnameTextBoxSignUp, @"^[a-zA-Zа-яА-ЯёЁіІїЇєЄґҐ]+$", "Помилка: прізвище повинно складатися тільки з літер.", 2);
            }
        }


        // Обробка для електронної пошти
        private void emailTextBoxSignUp_Enter(object sender, EventArgs e)
        {
            ClearDefaultText(emailTextBoxSignUp, "Електронна пошта");
        }

        private void emailTextBoxSignUp_Leave(object sender, EventArgs e)
        {
            SetDefaultText(emailTextBoxSignUp, "Електронна пошта");
            if (emailTextBoxSignUp.Text != "Електронна пошта")
            {
                ValidateText(emailTextBoxSignUp, @"^[^\s@]+@[^\s@]+\.[^\s@]+$", "Помилка: введіть коректну електронну адресу.", 5);
            }
        }

        // Обробка для міста
        private void cityTextBoxSignUp_Enter(object sender, EventArgs e)
        {
            ClearDefaultText(cityTextBoxSignUp, "Місто");
        }

        private void cityTextBoxSignUp_Leave(object sender, EventArgs e)
        {
            SetDefaultText(cityTextBoxSignUp, "Місто");
            if (cityTextBoxSignUp.Text != "Місто")
            {
                ValidateText(cityTextBoxSignUp, @"^[a-zA-Zа-яА-ЯёЁіІїЇєЄґҐ]+$", "Помилка: місто повинно складатися тільки з літер.", 2);
            }
        }

        // Країна
        private void countryTextBoxSignUp_Enter(object sender, EventArgs e)
        {
            ClearDefaultText(countryTextBoxSignUp, "Країна");
        }

        private void countryTextBoxSignUp_Leave(object sender, EventArgs e)
        {
            SetDefaultText(countryTextBoxSignUp, "Країна");
            if (countryTextBoxSignUp.Text != "Країна")
            {
                ValidateText(countryTextBoxSignUp, @"^[a-zA-Zа-яА-ЯёЁіІїЇєЄґҐ]+$", "Помилка: країна повинна складатися тільки з літер.", 3);
            }
        }


        // Вулиця
        private void streetTextBoxSignUp_Enter(object sender, EventArgs e)
        {
            ClearDefaultText(streetTextBoxSignUp, "Вулиця");
        }

        private void streetTextBoxSignUp_Leave(object sender, EventArgs e)
        {
            SetDefaultText(streetTextBoxSignUp, "Вулиця");
            if (streetTextBoxSignUp.Text != "Вулиця")
            {
                ValidateText(streetTextBoxSignUp, @"^[a-zA-Zа-яА-ЯёЁіІїЇєЄґҐ\s]+$", "Помилка: назва вулиці повинна складатися тільки з літер.", 2);
            }
        }

        // Номер будинку
        private void houseNumberTextBoxSignUp_Enter(object sender, EventArgs e)
        {
            ClearDefaultText(houseNumberTextBoxSignUp, "Номер будинку");
        }

        private void houseNumberTextBoxSignUp_Leave(object sender, EventArgs e)
        {
            SetDefaultText(houseNumberTextBoxSignUp, "Номер будинку");
            if (houseNumberTextBoxSignUp.Text != "Номер будинку")
            {
                ValidateText(houseNumberTextBoxSignUp, @"^\d+$", "Помилка: номер будинку повинен містити тільки цифри.");
            }
        }




        // Пароль
        private void passwordTextBoxSignUp_Enter(object sender, EventArgs e)
        {
            passwordTextBoxSignUp.Text = "";
            passwordTextBoxSignUp.UseSystemPasswordChar = true;
        }

        private void passwordTextBoxSignUp_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(passwordTextBoxSignUp.Text))
            {
                passwordTextBoxSignUp.UseSystemPasswordChar = false;
                passwordTextBoxSignUp.Text = "Пароль";
            }
        }



       
        // Логін
        private void loginTextBoxSignUp_Enter(object sender, EventArgs e)
        {
            ClearDefaultText(loginTextBoxSignUp, "Логін");
        }

        private void loginTextBoxSignUp_Leave(object sender, EventArgs e)
        {
            SetDefaultText(loginTextBoxSignUp, "Логін");
            if (loginTextBoxSignUp.Text != "Логін")
            {
                ValidateText(loginTextBoxSignUp, @"^[a-zA-Z0-9_]+$", "Помилка: логін може містити тільки літери, цифри та підкреслення.", 3);
            }
        }


        //  для номера телефону
        private void phoneNumberTextBoxSignUp_Enter(object sender, EventArgs e)
        {
            ClearDefaultText(phoneNumberTextBoxSignUp, "Номер телефону");
        }

        private void phoneNumberTextBoxSignUp_Leave(object sender, EventArgs e)
        {
            SetDefaultText(phoneNumberTextBoxSignUp, "Номер телефону");
            if (phoneNumberTextBoxSignUp.Text != "Номер телефону")
            {
                if (!Regex.IsMatch(phoneNumberTextBoxSignUp.Text, @"^\d+$"))
                {
                    MessageBox.Show("Помилка: номер телефону повинен містити тільки цифри.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    phoneNumberTextBoxSignUp.Text = "";
                }
                else if (phoneNumberTextBoxSignUp.Text.Length < 10)
                {
                    MessageBox.Show("Помилка: номер телефону повинен бути не менше 10 цифр.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    phoneNumberTextBoxSignUp.Text = "";
                }
            }
        }

        private void pictureBoxOpen_Click(object sender, EventArgs e)
        {
            passwordTextBoxSignUp.UseSystemPasswordChar = true;
            pictureBoxOpen.Visible = false;
            pictureBoxClosed.Visible = true;
        }

        private void pictureBoxClosed_Click(object sender, EventArgs e)
        {
            passwordTextBoxSignUp.UseSystemPasswordChar = false;
            pictureBoxOpen.Visible = true;
            pictureBoxClosed.Visible = false;
        }

      

        private void button_backToLogin_Click(object sender, EventArgs e)
        {
            LoginForm login_form = new LoginForm();
            login_form.Show();
            Hide();
        }
    }
}
