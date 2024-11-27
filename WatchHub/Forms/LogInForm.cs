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
    public partial class LoginForm : Form
    {
        Database dataBase = new Database();
        public LoginForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void userTextBoxLoginForm_Enter(object sender, EventArgs e)
        {
            if (userTextBoxLoginForm.Text == "Username")
            {
                userTextBoxLoginForm.Text = "";
            }
        }

        private void userTextBoxLoginForm_Leave(object sender, EventArgs e)
        {
            if (userTextBoxLoginForm.Text == "")
            {
                userTextBoxLoginForm.Text = "Username";
            }
        }

        private void passwordTextBoxLoginForm_Enter(object sender, EventArgs e)
        {
            if (passwordTextBoxLoginForm.Text == "Password")
            {
                passwordTextBoxLoginForm.Text = "";
            }
        }

        private void passwordTextBoxLoginForm_Leave(object sender, EventArgs e)
        {
            if (passwordTextBoxLoginForm.Text == "")
            {
                passwordTextBoxLoginForm.Text = "Password";
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void loginButtonLoginForm_Click(object sender, EventArgs e)
        {
            var userName = userTextBoxLoginForm.Text;
            var password = passwordTextBoxLoginForm.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string querystring = $"select manager_id, login, password from manager where login = '{userName}' and password = '{password}'";

            SqlCommand command = new SqlCommand(querystring, dataBase.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count == 1)
            {
                MessageBox.Show("Вы успешно вошли!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ManagerForm managerForm = new ManagerForm();
                this.Hide();
                managerForm.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Такого аккаунта не сущевствует!", "Акаунта нет!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
