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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WatchHub
{
    public partial class LoginForm : Form
    {
        Database dataBase = new Database();

        private bool isManager, isUser;
        
        public LoginForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

       

        private void LoginForm_Load(object sender, EventArgs e)
        {
            passwordTextBoxLoginForm.UseSystemPasswordChar = true; 
            pictureBoxOpen.Visible = false;
        }

        private void loginButtonLoginForm_Click(object sender, EventArgs e)
        {

            BtnLogin();

        }

        private void linkToSingUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUpForm signUpForm = new SignUpForm();
            this.Hide();
            signUpForm.Show();
        }

        private void isManagerRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            isManager = true;
            isUser = false;
        }

        private void BtnLogin()
        {
            if (isManager == true)
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
                    MessageBox.Show("Ви успішно увійшли!", "Успіх!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ManagerForm managerForm = new ManagerForm();
                    this.Hide();
                    managerForm.Show();
                    
                }
                else
                {
                    MessageBox.Show("Такого акаунту не існує!", "Акаунту немає!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            else if (isUser == true)
            {
                var userName = userTextBoxLoginForm.Text;
                var password = passwordTextBoxLoginForm.Text;
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable table = new DataTable();

                string querystring = $"select user_id, login, password from users where login = '{userName}' and password = '{password}'";

                SqlCommand command = new SqlCommand(querystring, dataBase.getConnection());

                adapter.SelectCommand = command;
                adapter.Fill(table);

                if (table.Rows.Count == 1)
                {
                    MessageBox.Show("Ви успішно увійшли в додаток!", "Успіх!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UserForm userForm = new UserForm();
                    this.Hide();
                    userForm.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Такого аккаунту не існує!", "Акаунту нема!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            else if (isUser == false && isManager == false)
            {
                MessageBox.Show("Оберіть кто ви є!", "Оберіть !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void pictureBoxOpen_Click(object sender, EventArgs e)
        {
            passwordTextBoxLoginForm.UseSystemPasswordChar = true; 
            pictureBoxOpen.Visible = false;
            pictureBoxClosed.Visible = true;
        }

        private void pictureBoxClosed_Click(object sender, EventArgs e)
        {
            passwordTextBoxLoginForm.UseSystemPasswordChar = false; 
            pictureBoxOpen.Visible = true;
            pictureBoxClosed.Visible = false;
        }

        private void isUserRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            isUser = true;
            isManager = false;
        }
    }
}
