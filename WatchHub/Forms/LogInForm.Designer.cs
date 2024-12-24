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
            this.components = new System.ComponentModel.Container();
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
            this.label3 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClosed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOpen)).BeginInit();
            this.SuspendLayout();
            // 
            // userTextBoxLoginForm
            // 
            this.userTextBoxLoginForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userTextBoxLoginForm.ForeColor = System.Drawing.SystemColors.MenuText;
            this.userTextBoxLoginForm.Location = new System.Drawing.Point(154, 142);
            this.userTextBoxLoginForm.Name = "userTextBoxLoginForm";
            this.userTextBoxLoginForm.Size = new System.Drawing.Size(177, 24);
            this.userTextBoxLoginForm.TabIndex = 3;
            // 
            // passwordTextBoxLoginForm
            // 
            this.passwordTextBoxLoginForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passwordTextBoxLoginForm.ForeColor = System.Drawing.SystemColors.InfoText;
            this.passwordTextBoxLoginForm.Location = new System.Drawing.Point(154, 191);
            this.passwordTextBoxLoginForm.Name = "passwordTextBoxLoginForm";
            this.passwordTextBoxLoginForm.Size = new System.Drawing.Size(177, 22);
            this.passwordTextBoxLoginForm.TabIndex = 3;
            this.passwordTextBoxLoginForm.UseSystemPasswordChar = true;
            // 
            // loginButtonLoginForm
            // 
            this.loginButtonLoginForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.loginButtonLoginForm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.loginButtonLoginForm.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic);
            this.loginButtonLoginForm.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.loginButtonLoginForm.Location = new System.Drawing.Point(132, 312);
            this.loginButtonLoginForm.Name = "loginButtonLoginForm";
            this.loginButtonLoginForm.Size = new System.Drawing.Size(142, 67);
            this.loginButtonLoginForm.TabIndex = 2;
            this.loginButtonLoginForm.Text = "Вхід";
            this.loginButtonLoginForm.UseVisualStyleBackColor = false;
            this.loginButtonLoginForm.Click += new System.EventHandler(this.loginButtonLoginForm_Click);
            // 
            // linkToSingUp
            // 
            this.linkToSingUp.AutoSize = true;
            this.linkToSingUp.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic);
            this.linkToSingUp.LinkColor = System.Drawing.Color.Transparent;
            this.linkToSingUp.Location = new System.Drawing.Point(129, 410);
            this.linkToSingUp.Name = "linkToSingUp";
            this.linkToSingUp.Size = new System.Drawing.Size(185, 22);
            this.linkToSingUp.TabIndex = 4;
            this.linkToSingUp.TabStop = true;
            this.linkToSingUp.Text = "Ще не маєте аккаунта?";
            this.linkToSingUp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkToSingUp_LinkClicked);
            // 
            // isManagerRadioBtn
            // 
            this.isManagerRadioBtn.AutoSize = true;
            this.isManagerRadioBtn.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic);
            this.isManagerRadioBtn.Location = new System.Drawing.Point(49, 235);
            this.isManagerRadioBtn.Name = "isManagerRadioBtn";
            this.isManagerRadioBtn.Size = new System.Drawing.Size(105, 26);
            this.isManagerRadioBtn.TabIndex = 5;
            this.isManagerRadioBtn.TabStop = true;
            this.isManagerRadioBtn.Text = "Я менджер";
            this.isManagerRadioBtn.UseVisualStyleBackColor = true;
            this.isManagerRadioBtn.CheckedChanged += new System.EventHandler(this.isManagerRadioBtn_CheckedChanged);
            // 
            // isUserRadioBtn
            // 
            this.isUserRadioBtn.AutoSize = true;
            this.isUserRadioBtn.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic);
            this.isUserRadioBtn.Location = new System.Drawing.Point(206, 235);
            this.isUserRadioBtn.Name = "isUserRadioBtn";
            this.isUserRadioBtn.Size = new System.Drawing.Size(125, 26);
            this.isUserRadioBtn.TabIndex = 6;
            this.isUserRadioBtn.TabStop = true;
            this.isUserRadioBtn.Text = "Я користувач";
            this.isUserRadioBtn.UseVisualStyleBackColor = true;
            this.isUserRadioBtn.CheckedChanged += new System.EventHandler(this.isUserRadioBtn_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(43, 180);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 33);
            this.label1.TabIndex = 7;
            this.label1.Text = "Пароль:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Monotype Corsiva", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(43, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 33);
            this.label2.TabIndex = 8;
            this.label2.Text = "Логін:";
            // 
            // pictureBoxClosed
            // 
            this.pictureBoxClosed.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxClosed.BackgroundImage")));
            this.pictureBoxClosed.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxClosed.Location = new System.Drawing.Point(337, 191);
            this.pictureBoxClosed.Name = "pictureBoxClosed";
            this.pictureBoxClosed.Size = new System.Drawing.Size(22, 22);
            this.pictureBoxClosed.TabIndex = 9;
            this.pictureBoxClosed.TabStop = false;
            this.pictureBoxClosed.Click += new System.EventHandler(this.pictureBoxClosed_Click);
            // 
            // pictureBoxOpen
            // 
            this.pictureBoxOpen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxOpen.BackgroundImage")));
            this.pictureBoxOpen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxOpen.Location = new System.Drawing.Point(337, 191);
            this.pictureBoxOpen.Name = "pictureBoxOpen";
            this.pictureBoxOpen.Size = new System.Drawing.Size(22, 22);
            this.pictureBoxOpen.TabIndex = 10;
            this.pictureBoxOpen.TabStop = false;
            this.pictureBoxOpen.Click += new System.EventHandler(this.pictureBoxOpen_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label3.Font = new System.Drawing.Font("Monotype Corsiva", 48F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(97, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 79);
            this.label3.TabIndex = 11;
            this.label3.Text = "ВХІД";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(112)))), ((int)(((byte)(94)))));
            this.ClientSize = new System.Drawing.Size(408, 511);
            this.Controls.Add(this.label3);
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
            this.Text = "Вхід";
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}

