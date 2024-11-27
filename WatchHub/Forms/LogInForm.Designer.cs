namespace WatchHub
{
    partial class LoginForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.userTextBoxLoginForm = new System.Windows.Forms.TextBox();
            this.passwordTextBoxLoginForm = new System.Windows.Forms.TextBox();
            this.loginButtonLoginForm = new System.Windows.Forms.Button();
            this.linkToSingUp = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // userTextBoxLoginForm
            // 
            this.userTextBoxLoginForm.Location = new System.Drawing.Point(97, 133);
            this.userTextBoxLoginForm.Name = "userTextBoxLoginForm";
            this.userTextBoxLoginForm.Size = new System.Drawing.Size(177, 20);
            this.userTextBoxLoginForm.TabIndex = 3;
            this.userTextBoxLoginForm.Text = "Username";
            this.userTextBoxLoginForm.Enter += new System.EventHandler(this.userTextBoxLoginForm_Enter);
            this.userTextBoxLoginForm.Leave += new System.EventHandler(this.userTextBoxLoginForm_Leave);
            // 
            // passwordTextBoxLoginForm
            // 
            this.passwordTextBoxLoginForm.Location = new System.Drawing.Point(97, 201);
            this.passwordTextBoxLoginForm.Name = "passwordTextBoxLoginForm";
            this.passwordTextBoxLoginForm.Size = new System.Drawing.Size(177, 20);
            this.passwordTextBoxLoginForm.TabIndex = 3;
            this.passwordTextBoxLoginForm.Text = "Password";
            this.passwordTextBoxLoginForm.Enter += new System.EventHandler(this.passwordTextBoxLoginForm_Enter);
            this.passwordTextBoxLoginForm.Leave += new System.EventHandler(this.passwordTextBoxLoginForm_Leave);
            // 
            // loginButtonLoginForm
            // 
            this.loginButtonLoginForm.Location = new System.Drawing.Point(142, 240);
            this.loginButtonLoginForm.Name = "loginButtonLoginForm";
            this.loginButtonLoginForm.Size = new System.Drawing.Size(75, 23);
            this.loginButtonLoginForm.TabIndex = 2;
            this.loginButtonLoginForm.Text = "Вхід";
            this.loginButtonLoginForm.UseVisualStyleBackColor = true;
            this.loginButtonLoginForm.Click += new System.EventHandler(this.loginButtonLoginForm_Click);
            // 
            // linkToSingUp
            // 
            this.linkToSingUp.AutoSize = true;
            this.linkToSingUp.Location = new System.Drawing.Point(118, 279);
            this.linkToSingUp.Name = "linkToSingUp";
            this.linkToSingUp.Size = new System.Drawing.Size(127, 13);
            this.linkToSingUp.TabIndex = 4;
            this.linkToSingUp.TabStop = true;
            this.linkToSingUp.Text = "Ще не маєте аккаунта?";
            this.linkToSingUp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkToSingUp_LinkClicked);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 511);
            this.Controls.Add(this.linkToSingUp);
            this.Controls.Add(this.loginButtonLoginForm);
            this.Controls.Add(this.passwordTextBoxLoginForm);
            this.Controls.Add(this.userTextBoxLoginForm);
            this.Name = "LoginForm";
            this.Text = "Login ";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox userTextBoxLoginForm;
        private System.Windows.Forms.TextBox passwordTextBoxLoginForm;
        private System.Windows.Forms.Button loginButtonLoginForm;
        private System.Windows.Forms.LinkLabel linkToSingUp;
    }
}

