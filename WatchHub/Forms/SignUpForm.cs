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
        

        // last_name
        private void surnameTextBoxSignUp_Enter(object sender, EventArgs e)
        {
            surnameTextBoxSignUp.Text = "";
        }

        private void surnameTextBoxSignUp_Leave(object sender, EventArgs e)
        {

        }

        // email
        private void emailTextBoxSignUp_Enter(object sender, EventArgs e)
        {
            emailTextBoxSignUp.Text = "";
        }

        private void emailTextBoxSignUp_Leave(object sender, EventArgs e)
        {

        }


        // city
        private void cityTextBoxSignUp_Enter(object sender, EventArgs e)
        {
            cityTextBoxSignUp.Text = "";
        }

        private void cityTextBoxSignUp_Leave(object sender, EventArgs e)
        {

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
        private void streetTextBoxSignUp_Enter(object sender, EventArgs e)
        {
            streetTextBoxSignUp.Text = "";
        }


        private void streetTextBoxSignUp_Leave(object sender, EventArgs e)
        {

        }

        //house_number
        private void houseNumberTextBoxSignUp_Enter(object sender, EventArgs e)
        {
            houseNumberTextBoxSignUp.Text = "";
        }


        private void houseNumberTextBoxSignUp_Leave(object sender, EventArgs e)
        {

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
        private void loginTextBoxSignUp_Enter(object sender, EventArgs e)
        {
            loginTextBoxSignUp.Text = "";
        }

        private void loginTextBoxSignUp_Leave(object sender, EventArgs e)
        {

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
    }
}
