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
                loginForm.ShowDialog();
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
    }
}
