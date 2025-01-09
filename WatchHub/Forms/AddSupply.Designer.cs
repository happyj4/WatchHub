namespace WatchHub.Forms
{
    partial class AddSupply
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.saveBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox_id = new System.Windows.Forms.TextBox();
            this.textBox_supplyPrice = new System.Windows.Forms.TextBox();
            this.textBox_supplyTerms = new System.Windows.Forms.TextBox();
            this.textBox_idSupplier = new System.Windows.Forms.TextBox();
            this.textBox_watch_id = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_supply_volume = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 36F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(210, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(400, 57);
            this.label1.TabIndex = 8;
            this.label1.Text = "Додавання поставки";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.textBox_supply_volume);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.textBox_watch_id);
            this.panel1.Controls.Add(this.textBox_idSupplier);
            this.panel1.Controls.Add(this.textBox_supplyTerms);
            this.panel1.Controls.Add(this.textBox_supplyPrice);
            this.panel1.Controls.Add(this.textBox_id);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic);
            this.panel1.Location = new System.Drawing.Point(112, 127);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(826, 523);
            this.panel1.TabIndex = 7;
            // 
            // saveBtn
            // 
            this.saveBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.saveBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.saveBtn.Font = new System.Drawing.Font("Monotype Corsiva", 24F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveBtn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.saveBtn.Location = new System.Drawing.Point(112, 668);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(829, 117);
            this.saveBtn.TabIndex = 6;
            this.saveBtn.Text = "Зберегти";
            this.saveBtn.UseVisualStyleBackColor = false;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::WatchHub.Properties.Resources._4172394_goods_merchandise_stock_supply_vendibles_icon;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(616, 45);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(90, 63);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Monotype Corsiva", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(229, 401);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 33);
            this.label2.TabIndex = 53;
            this.label2.Text = "ID Годинника -";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Monotype Corsiva", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(179, 329);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(222, 33);
            this.label5.TabIndex = 52;
            this.label5.Text = "ID Постачальника -";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Monotype Corsiva", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(203, 277);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(198, 33);
            this.label3.TabIndex = 51;
            this.label3.Text = "Умови поставки -";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Monotype Corsiva", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(198, 156);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(203, 33);
            this.label9.TabIndex = 49;
            this.label9.Text = "Ціна за поставку -";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Monotype Corsiva", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(214, 107);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(187, 33);
            this.label11.TabIndex = 48;
            this.label11.Text = "Дата поставки -";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Monotype Corsiva", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.Location = new System.Drawing.Point(343, 62);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 33);
            this.label14.TabIndex = 47;
            this.label14.Text = "ID -";
            // 
            // textBox_id
            // 
            this.textBox_id.Location = new System.Drawing.Point(407, 62);
            this.textBox_id.Name = "textBox_id";
            this.textBox_id.Size = new System.Drawing.Size(100, 29);
            this.textBox_id.TabIndex = 54;
            // 
            // textBox_supplyPrice
            // 
            this.textBox_supplyPrice.Location = new System.Drawing.Point(407, 156);
            this.textBox_supplyPrice.Name = "textBox_supplyPrice";
            this.textBox_supplyPrice.Size = new System.Drawing.Size(100, 29);
            this.textBox_supplyPrice.TabIndex = 56;
            // 
            // textBox_supplyTerms
            // 
            this.textBox_supplyTerms.Location = new System.Drawing.Point(407, 282);
            this.textBox_supplyTerms.Name = "textBox_supplyTerms";
            this.textBox_supplyTerms.Size = new System.Drawing.Size(100, 29);
            this.textBox_supplyTerms.TabIndex = 57;
            // 
            // textBox_idSupplier
            // 
            this.textBox_idSupplier.Location = new System.Drawing.Point(407, 333);
            this.textBox_idSupplier.Name = "textBox_idSupplier";
            this.textBox_idSupplier.Size = new System.Drawing.Size(100, 29);
            this.textBox_idSupplier.TabIndex = 58;
            // 
            // textBox_watch_id
            // 
            this.textBox_watch_id.Location = new System.Drawing.Point(407, 406);
            this.textBox_watch_id.Name = "textBox_watch_id";
            this.textBox_watch_id.Size = new System.Drawing.Size(100, 29);
            this.textBox_watch_id.TabIndex = 59;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Monotype Corsiva", 20.25F, System.Drawing.FontStyle.Italic);
            this.label7.Location = new System.Drawing.Point(44, 217);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(357, 33);
            this.label7.TabIndex = 63;
            this.label7.Text = "Кількість годинників в поставці -";
            // 
            // textBox_supply_volume
            // 
            this.textBox_supply_volume.Location = new System.Drawing.Point(407, 222);
            this.textBox_supply_volume.Name = "textBox_supply_volume";
            this.textBox_supply_volume.Size = new System.Drawing.Size(100, 29);
            this.textBox_supply_volume.TabIndex = 64;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(407, 111);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 29);
            this.dateTimePicker1.TabIndex = 65;
            // 
            // AddSupply
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(112)))), ((int)(((byte)(94)))));
            this.ClientSize = new System.Drawing.Size(1052, 797);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.saveBtn);
            this.Name = "AddSupply";
            this.Text = "Додавання поставки";
            this.Load += new System.EventHandler(this.AddSupply_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.TextBox textBox_watch_id;
        private System.Windows.Forms.TextBox textBox_idSupplier;
        private System.Windows.Forms.TextBox textBox_supplyTerms;
        private System.Windows.Forms.TextBox textBox_supplyPrice;
        private System.Windows.Forms.TextBox textBox_id;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox_supply_volume;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}