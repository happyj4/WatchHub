namespace WatchHub
{
    partial class SignUpForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.nameTextBoxSignUp = new System.Windows.Forms.TextBox();
            this.surnameTextBoxSignUp = new System.Windows.Forms.TextBox();
            this.emailTextBoxSignUp = new System.Windows.Forms.TextBox();
            this.countryTextBoxSignUp = new System.Windows.Forms.TextBox();
            this.streetTextBoxSignUp = new System.Windows.Forms.TextBox();
            this.houseNumberTextBoxSignUp = new System.Windows.Forms.TextBox();
            this.passwordTextBoxSignUp = new System.Windows.Forms.TextBox();
            this.cityTextBoxSignUp = new System.Windows.Forms.TextBox();
            this.phoneNumberTextBoxSignUp = new System.Windows.Forms.TextBox();
            this.loginTextBoxSignUp = new System.Windows.Forms.TextBox();
            this.createAcSignUpForm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nameTextBoxSignUp
            // 
            this.nameTextBoxSignUp.Location = new System.Drawing.Point(44, 72);
            this.nameTextBoxSignUp.Name = "nameTextBoxSignUp";
            this.nameTextBoxSignUp.Size = new System.Drawing.Size(142, 20);
            this.nameTextBoxSignUp.TabIndex = 0;
            this.nameTextBoxSignUp.Text = "Ім\'я";
            // 
            // surnameTextBoxSignUp
            // 
            this.surnameTextBoxSignUp.Location = new System.Drawing.Point(44, 111);
            this.surnameTextBoxSignUp.Name = "surnameTextBoxSignUp";
            this.surnameTextBoxSignUp.Size = new System.Drawing.Size(142, 20);
            this.surnameTextBoxSignUp.TabIndex = 1;
            this.surnameTextBoxSignUp.Text = "Прізвище";
            // 
            // emailTextBoxSignUp
            // 
            this.emailTextBoxSignUp.Location = new System.Drawing.Point(44, 179);
            this.emailTextBoxSignUp.Name = "emailTextBoxSignUp";
            this.emailTextBoxSignUp.Size = new System.Drawing.Size(142, 20);
            this.emailTextBoxSignUp.TabIndex = 2;
            this.emailTextBoxSignUp.Text = "email";
            // 
            // countryTextBoxSignUp
            // 
            this.countryTextBoxSignUp.Location = new System.Drawing.Point(44, 215);
            this.countryTextBoxSignUp.Name = "countryTextBoxSignUp";
            this.countryTextBoxSignUp.Size = new System.Drawing.Size(142, 20);
            this.countryTextBoxSignUp.TabIndex = 3;
            this.countryTextBoxSignUp.Text = "country";
            // 
            // streetTextBoxSignUp
            // 
            this.streetTextBoxSignUp.Location = new System.Drawing.Point(44, 330);
            this.streetTextBoxSignUp.Name = "streetTextBoxSignUp";
            this.streetTextBoxSignUp.Size = new System.Drawing.Size(142, 20);
            this.streetTextBoxSignUp.TabIndex = 4;
            this.streetTextBoxSignUp.Text = "street";
            // 
            // houseNumberTextBoxSignUp
            // 
            this.houseNumberTextBoxSignUp.Location = new System.Drawing.Point(44, 383);
            this.houseNumberTextBoxSignUp.Name = "houseNumberTextBoxSignUp";
            this.houseNumberTextBoxSignUp.Size = new System.Drawing.Size(142, 20);
            this.houseNumberTextBoxSignUp.TabIndex = 5;
            this.houseNumberTextBoxSignUp.Text = "house number";
            // 
            // passwordTextBoxSignUp
            // 
            this.passwordTextBoxSignUp.Location = new System.Drawing.Point(44, 427);
            this.passwordTextBoxSignUp.Name = "passwordTextBoxSignUp";
            this.passwordTextBoxSignUp.Size = new System.Drawing.Size(142, 20);
            this.passwordTextBoxSignUp.TabIndex = 6;
            this.passwordTextBoxSignUp.Text = "password";
            // 
            // cityTextBoxSignUp
            // 
            this.cityTextBoxSignUp.Location = new System.Drawing.Point(44, 272);
            this.cityTextBoxSignUp.Name = "cityTextBoxSignUp";
            this.cityTextBoxSignUp.Size = new System.Drawing.Size(142, 20);
            this.cityTextBoxSignUp.TabIndex = 7;
            this.cityTextBoxSignUp.Text = "city";
            // 
            // phoneNumberTextBoxSignUp
            // 
            this.phoneNumberTextBoxSignUp.Location = new System.Drawing.Point(44, 141);
            this.phoneNumberTextBoxSignUp.Name = "phoneNumberTextBoxSignUp";
            this.phoneNumberTextBoxSignUp.Size = new System.Drawing.Size(142, 20);
            this.phoneNumberTextBoxSignUp.TabIndex = 8;
            this.phoneNumberTextBoxSignUp.Text = "phone number";
            this.phoneNumberTextBoxSignUp.TextChanged += new System.EventHandler(this.textBox9_TextChanged);
            // 
            // loginTextBoxSignUp
            // 
            this.loginTextBoxSignUp.Location = new System.Drawing.Point(44, 30);
            this.loginTextBoxSignUp.Name = "loginTextBoxSignUp";
            this.loginTextBoxSignUp.Size = new System.Drawing.Size(142, 20);
            this.loginTextBoxSignUp.TabIndex = 9;
            this.loginTextBoxSignUp.Text = "Login";
            // 
            // createAcSignUpForm
            // 
            this.createAcSignUpForm.Location = new System.Drawing.Point(230, 517);
            this.createAcSignUpForm.Name = "createAcSignUpForm";
            this.createAcSignUpForm.Size = new System.Drawing.Size(129, 68);
            this.createAcSignUpForm.TabIndex = 10;
            this.createAcSignUpForm.Text = "Створити аккаунт";
            this.createAcSignUpForm.UseVisualStyleBackColor = true;
            this.createAcSignUpForm.Click += new System.EventHandler(this.createAcSignUpForm_Click);
            // 
            // SignUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 777);
            this.Controls.Add(this.createAcSignUpForm);
            this.Controls.Add(this.loginTextBoxSignUp);
            this.Controls.Add(this.phoneNumberTextBoxSignUp);
            this.Controls.Add(this.cityTextBoxSignUp);
            this.Controls.Add(this.passwordTextBoxSignUp);
            this.Controls.Add(this.houseNumberTextBoxSignUp);
            this.Controls.Add(this.streetTextBoxSignUp);
            this.Controls.Add(this.countryTextBoxSignUp);
            this.Controls.Add(this.emailTextBoxSignUp);
            this.Controls.Add(this.surnameTextBoxSignUp);
            this.Controls.Add(this.nameTextBoxSignUp);
            this.Name = "SignUpForm";
            this.Text = "SignUpForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameTextBoxSignUp;
        private System.Windows.Forms.TextBox surnameTextBoxSignUp;
        private System.Windows.Forms.TextBox emailTextBoxSignUp;
        private System.Windows.Forms.TextBox countryTextBoxSignUp;
        private System.Windows.Forms.TextBox streetTextBoxSignUp;
        private System.Windows.Forms.TextBox houseNumberTextBoxSignUp;
        private System.Windows.Forms.TextBox passwordTextBoxSignUp;
        private System.Windows.Forms.TextBox cityTextBoxSignUp;
        private System.Windows.Forms.TextBox phoneNumberTextBoxSignUp;
        private System.Windows.Forms.TextBox loginTextBoxSignUp;
        private System.Windows.Forms.Button createAcSignUpForm;
    }
}