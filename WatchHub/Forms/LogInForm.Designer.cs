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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.userTextBoxLoginForm = new System.Windows.Forms.TextBox();
            this.passwordTextBoxLoginForm = new System.Windows.Forms.TextBox();
            this.loginButtonLoginForm = new System.Windows.Forms.Button();
            this.linkToSingUp = new System.Windows.Forms.LinkLabel();
            this.isManagerRadioBtn = new System.Windows.Forms.RadioButton();
            this.isUserRadioBtn = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBoxClosed = new System.Windows.Forms.PictureBox();
            this.pictureBoxOpen = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClosed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOpen)).BeginInit();
            this.SuspendLayout();
            // 
            // userTextBoxLoginForm
            // 
            this.userTextBoxLoginForm.ForeColor = System.Drawing.SystemColors.MenuText;
            this.userTextBoxLoginForm.Location = new System.Drawing.Point(97, 133);
            this.userTextBoxLoginForm.Name = "userTextBoxLoginForm";
            this.userTextBoxLoginForm.Size = new System.Drawing.Size(177, 20);
            this.userTextBoxLoginForm.TabIndex = 3;
            // 
            // passwordTextBoxLoginForm
            // 
            this.passwordTextBoxLoginForm.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.passwordTextBoxLoginForm.Location = new System.Drawing.Point(97, 188);
            this.passwordTextBoxLoginForm.Name = "passwordTextBoxLoginForm";
            this.passwordTextBoxLoginForm.Size = new System.Drawing.Size(177, 20);
            this.passwordTextBoxLoginForm.TabIndex = 3;
            this.passwordTextBoxLoginForm.UseSystemPasswordChar = true;
            // 
            // loginButtonLoginForm
            // 
            this.loginButtonLoginForm.Location = new System.Drawing.Point(148, 290);
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
            this.linkToSingUp.LinkColor = System.Drawing.Color.Gray;
            this.linkToSingUp.Location = new System.Drawing.Point(128, 316);
            this.linkToSingUp.Name = "linkToSingUp";
            this.linkToSingUp.Size = new System.Drawing.Size(127, 13);
            this.linkToSingUp.TabIndex = 4;
            this.linkToSingUp.TabStop = true;
            this.linkToSingUp.Text = "Ще не маєте аккаунта?";
            this.linkToSingUp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkToSingUp_LinkClicked);
            // 
            // isManagerRadioBtn
            // 
            this.isManagerRadioBtn.AutoSize = true;
            this.isManagerRadioBtn.Location = new System.Drawing.Point(97, 230);
            this.isManagerRadioBtn.Name = "isManagerRadioBtn";
            this.isManagerRadioBtn.Size = new System.Drawing.Size(82, 17);
            this.isManagerRadioBtn.TabIndex = 5;
            this.isManagerRadioBtn.TabStop = true;
            this.isManagerRadioBtn.Text = "Я менджер";
            this.isManagerRadioBtn.UseVisualStyleBackColor = true;
            this.isManagerRadioBtn.CheckedChanged += new System.EventHandler(this.isManagerRadioBtn_CheckedChanged);
            // 
            // isUserRadioBtn
            // 
            this.isUserRadioBtn.AutoSize = true;
            this.isUserRadioBtn.Location = new System.Drawing.Point(189, 230);
            this.isUserRadioBtn.Name = "isUserRadioBtn";
            this.isUserRadioBtn.Size = new System.Drawing.Size(93, 17);
            this.isUserRadioBtn.TabIndex = 6;
            this.isUserRadioBtn.TabStop = true;
            this.isUserRadioBtn.Text = "Я користувач";
            this.isUserRadioBtn.UseVisualStyleBackColor = true;
            this.isUserRadioBtn.CheckedChanged += new System.EventHandler(this.isUserRadioBtn_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 191);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Пароль:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Логін:";
            // 
            // pictureBoxClosed
            // 
            this.pictureBoxClosed.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxClosed.BackgroundImage")));
            this.pictureBoxClosed.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxClosed.Location = new System.Drawing.Point(289, 188);
            this.pictureBoxClosed.Name = "pictureBoxClosed";
            this.pictureBoxClosed.Size = new System.Drawing.Size(33, 31);
            this.pictureBoxClosed.TabIndex = 9;
            this.pictureBoxClosed.TabStop = false;
            this.pictureBoxClosed.Click += new System.EventHandler(this.pictureBoxClosed_Click);
            // 
            // pictureBoxOpen
            // 
            this.pictureBoxOpen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxOpen.BackgroundImage")));
            this.pictureBoxOpen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxOpen.Location = new System.Drawing.Point(289, 188);
            this.pictureBoxOpen.Name = "pictureBoxOpen";
            this.pictureBoxOpen.Size = new System.Drawing.Size(33, 31);
            this.pictureBoxOpen.TabIndex = 10;
            this.pictureBoxOpen.TabStop = false;
            this.pictureBoxOpen.Click += new System.EventHandler(this.pictureBoxOpen_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 511);
            this.Controls.Add(this.pictureBoxOpen);
            this.Controls.Add(this.pictureBoxClosed);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.isUserRadioBtn);
            this.Controls.Add(this.isManagerRadioBtn);
            this.Controls.Add(this.linkToSingUp);
            this.Controls.Add(this.loginButtonLoginForm);
            this.Controls.Add(this.passwordTextBoxLoginForm);
            this.Controls.Add(this.userTextBoxLoginForm);
            this.Name = "LoginForm";
            this.Text = "Login ";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClosed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOpen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox userTextBoxLoginForm;
        private System.Windows.Forms.TextBox passwordTextBoxLoginForm;
        private System.Windows.Forms.Button loginButtonLoginForm;
        private System.Windows.Forms.LinkLabel linkToSingUp;
        private System.Windows.Forms.RadioButton isManagerRadioBtn;
        private System.Windows.Forms.RadioButton isUserRadioBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBoxClosed;
        private System.Windows.Forms.PictureBox pictureBoxOpen;
    }
}

