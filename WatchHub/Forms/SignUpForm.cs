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

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void createAcSignUpForm_Click(object sender, EventArgs e)
        {
         

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

            string querystring = $"insert into users(first_name, last_name, email, city, country, street, house_number, password, login,phone_number) values('{first_name}','{last_name}','{email}','{city}','{country}','{street}','{houseNum}','{password}','{login}','{phonenum}')";


            SqlCommand command = new SqlCommand(querystring, dataBase.getConnection());

            dataBase.openConnection();

            if (command.ExecuteNonQuery() == 1)   
            {
                MessageBox.Show("Акаунт успешно создан","Успех!");
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Акаунт не создан!");
            }
            dataBase.closeConnection();




        }

        private Boolean checkuser()
        {
            var loginUser = loginTextBoxSignUp.Text;
           
            var emailUser = emailTextBoxSignUp.Text;
           
            var phonenumUser = phoneNumberTextBoxSignUp.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string querystring = $"select user_id, login, email, phone_number from users where login = '{loginUser}', email = '{emailUser}', phone_number = '{phonenumUser}'";
            SqlCommand command = new SqlCommand(querystring, dataBase.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Пользователь уже существует!");
                return true;
            }
            else
            {
                return false;
            }
          
        }

        private void SignUpForm_Load(object sender, EventArgs e)
        {
            passwordTextBoxSignUp.UseSystemPasswordChar = true;
            pictureBoxOpen.Visible = false;
        }


        private void loginTextBoxSignUp_TextChanged(object sender, EventArgs e)
        {

        }
        // name 
        private void nameTextBoxSignUp_Enter(object sender, EventArgs e)
        {
            nameTextBoxSignUp.Text = "";
        }

        private void nameTextBoxSignUp_Leave(object sender, EventArgs e)
        {
            if (nameTextBoxSignUp.Text == "")
            {
                nameTextBoxSignUp.Text = "Ім'я";
            }

           else if  (!(Regex.IsMatch(nameTextBoxSignUp.Text, @"^[a-zA-Zа-яА-ЯёЁіІїЇєЄґҐ]+$") )) {

                MessageBox.Show("Помилка: ім'я повинно складатися тільки з літер.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nameTextBoxSignUp.Text = "";
            }
            else if (nameTextBoxSignUp.Text.Length == 1)
            {
                MessageBox.Show("Помилка: ім'я повинно бути більше однієї літери.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nameTextBoxSignUp.Text = "";
            }

        }

        // surname
        private void surnameTextBoxSignUp_Leave(object sender, EventArgs e)
        {
            if (surnameTextBoxSignUp.Text == "")
            {
                surnameTextBoxSignUp.Text = "Прізвище";
            }
            else if (!(Regex.IsMatch(surnameTextBoxSignUp.Text, @"^[a-zA-Zа-яА-ЯёЁіІїЇєЄґҐ]+$")))
            {
                MessageBox.Show("Помилка: прізвище повинно складатися тільки з літер.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                surnameTextBoxSignUp.Text = "";
            }
            else if (surnameTextBoxSignUp.Text.Length < 2)
            {
                MessageBox.Show("Помилка: прізвище повинно бути більше однієї літери.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                surnameTextBoxSignUp.Text = "";
            }
        }

        // email
        private void emailTextBoxSignUp_Leave(object sender, EventArgs e)
        {
            if (emailTextBoxSignUp.Text == "")
            {
                emailTextBoxSignUp.Text = "Електронна пошта";
            }
            else if (!(Regex.IsMatch(emailTextBoxSignUp.Text, @"^[^\s@]+@[^\s@]+\.[^\s@]+$")))
            {
                MessageBox.Show("Помилка: введіть коректну електронну адресу.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                emailTextBoxSignUp.Text = "";
            }
        }


        // city
        private void cityTextBoxSignUp_Leave(object sender, EventArgs e)
        {
            if (cityTextBoxSignUp.Text == "")
            {
                cityTextBoxSignUp.Text = "Місто";
            }
            else if (!(Regex.IsMatch(cityTextBoxSignUp.Text, @"^[a-zA-Zа-яА-ЯёЁіІїЇєЄґҐ]+$")))
            {
                MessageBox.Show("Помилка: місто повинно складатися тільки з літер.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cityTextBoxSignUp.Text = "";
            }
            else if (cityTextBoxSignUp.Text.Length < 2)
            {
                MessageBox.Show("Помилка: назва міста повинна бути більше однієї літери.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cityTextBoxSignUp.Text = "";
            }
        }

        // country
        private void countryTextBoxSignUp_Enter(object sender, EventArgs e)
        {
            countryTextBoxSignUp.Text = "";
        }

        private void countryTextBoxSignUp_Leave(object sender, EventArgs e)
        {
            if (countryTextBoxSignUp.Text == "")
            {
                countryTextBoxSignUp.Text = "Країна";
            }

            else if (!(Regex.IsMatch(countryTextBoxSignUp.Text, @"^[a-zA-Zа-яА-ЯёЁіІїЇєЄґҐ]+$")))
            {

                MessageBox.Show("Помилка: країна не може складатися  з чисел.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                countryTextBoxSignUp.Text = "";
            }
            else if (countryTextBoxSignUp.Text.Length < 3)
            {
                MessageBox.Show("Помилка: Країна повинно бути більше трьох літери.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                countryTextBoxSignUp.Text = "";
            }
        }

        // street
        private void streetTextBoxSignUp_Leave(object sender, EventArgs e)
        {
            if (streetTextBoxSignUp.Text == "")
            {
                streetTextBoxSignUp.Text = "Вулиця";
            }
            else if (!(Regex.IsMatch(streetTextBoxSignUp.Text, @"^[a-zA-Zа-яА-ЯёЁіІїЇєЄґҐ\s]+$")))
            {
                MessageBox.Show("Помилка: назва вулиці повинна складатися тільки з літер.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                streetTextBoxSignUp.Text = "";
            }
            else if (streetTextBoxSignUp.Text.Length < 2)
            {
                MessageBox.Show("Помилка: назва вулиці повинна бути більше однієї літери.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                streetTextBoxSignUp.Text = "";
            }
        }


        // house_number
        private void houseNumberTextBoxSignUp_Leave(object sender, EventArgs e)
        {
            if (houseNumberTextBoxSignUp.Text == "")
            {
                houseNumberTextBoxSignUp.Text = "Номер будинку";
            }
            else if (!(Regex.IsMatch(houseNumberTextBoxSignUp.Text, @"^\d+$")))
            {
                MessageBox.Show("Помилка: номер будинку повинен містити тільки цифри.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                houseNumberTextBoxSignUp.Text = "";
            }
        }


        

        // password
        private void passwordTextBoxSignUp_Leave(object sender, EventArgs e)
        {
            passwordTextBoxSignUp.UseSystemPasswordChar = false;

        }


        private void passwordTextBoxSignUp_Enter(object sender, EventArgs e)
        {
            passwordTextBoxSignUp.Text = "";
            passwordTextBoxSignUp.UseSystemPasswordChar = true;
        }

        // login
        private void loginTextBoxSignUp_Leave(object sender, EventArgs e)
        {
            if (loginTextBoxSignUp.Text == "")
            {
                loginTextBoxSignUp.Text = "Логін";
            }
            else if (!(Regex.IsMatch(loginTextBoxSignUp.Text, @"^[a-zA-Z0-9_]+$")))
            {
                MessageBox.Show("Помилка: логін може містити тільки літери, цифри та підкреслення.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                loginTextBoxSignUp.Text = "";
            }
            else if (loginTextBoxSignUp.Text.Length < 3)
            {
                MessageBox.Show("Помилка: логін повинен бути більше трьох символів.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                loginTextBoxSignUp.Text = "";
            }
        }


        //phone_num

        private void phoneNumberTextBoxSignUp_Enter(object sender, EventArgs e)
        {
           
            phoneNumberTextBoxSignUp.Text = "";

        }

        private void phoneNumberTextBoxSignUp_Leave(object sender, EventArgs e)
        {
            if (phoneNumberTextBoxSignUp.Text == "")
            {
                phoneNumberTextBoxSignUp.Text = "Номер телефону";
            }

            else if ((Regex.IsMatch(phoneNumberTextBoxSignUp.Text, @"^[a-zA-Zа-яА-ЯёЁіІїЇєЄґҐ]+$")))
            {

                MessageBox.Show("Помилка: номер телефону не може складатися  з літер.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                phoneNumberTextBoxSignUp.Text = "";
            }
            else if (phoneNumberTextBoxSignUp.Text.Length < 12)
            {
                MessageBox.Show("Помилка: Країна повинно бути більше тринадцяти символів.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                phoneNumberTextBoxSignUp.Text = "";
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
