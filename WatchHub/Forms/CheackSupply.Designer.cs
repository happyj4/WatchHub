namespace WatchHub.Forms
{
    partial class CheackSupply
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheackSupply));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBoxSearchSupllier = new System.Windows.Forms.TextBox();
            this.refresh_btn = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.changeBtn = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxSupplyID = new System.Windows.Forms.TextBox();
            this.textBoxSupplyVolume = new System.Windows.Forms.TextBox();
            this.textBox_id_supplier = new System.Windows.Forms.TextBox();
            this.textBoxSupply_terms = new System.Windows.Forms.TextBox();
            this.textBoxSupply_price = new System.Windows.Forms.TextBox();
            this.textBox_watch_id = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(51, 48);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(860, 402);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
           
            // 
            // textBoxSearchSupllier
            // 
            this.textBoxSearchSupllier.Location = new System.Drawing.Point(930, 48);
            this.textBoxSearchSupllier.Name = "textBoxSearchSupllier";
            this.textBoxSearchSupllier.Size = new System.Drawing.Size(157, 20);
            this.textBoxSearchSupllier.TabIndex = 25;
            this.textBoxSearchSupllier.TextChanged += new System.EventHandler(this.textBoxSearchSupplier_TextChanged);
            // 
            // refresh_btn
            // 
            this.refresh_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.refresh_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.refresh_btn.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic);
            this.refresh_btn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.refresh_btn.Location = new System.Drawing.Point(934, 74);
            this.refresh_btn.Name = "refresh_btn";
            this.refresh_btn.Size = new System.Drawing.Size(153, 60);
            this.refresh_btn.TabIndex = 26;
            this.refresh_btn.Text = "Оновити";
            this.refresh_btn.UseVisualStyleBackColor = false;
            this.refresh_btn.Click += new System.EventHandler(this.refresh_btn_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Monotype Corsiva", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label20.Location = new System.Drawing.Point(683, 453);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(228, 28);
            this.label20.TabIndex = 28;
            this.label20.Text = "Управління записами";
            
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.changeBtn);
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnNew);
            this.panel2.Location = new System.Drawing.Point(667, 514);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(265, 275);
            this.panel2.TabIndex = 27;
           
            // 
            // changeBtn
            // 
            this.changeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.changeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.changeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.changeBtn.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic);
            this.changeBtn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.changeBtn.Location = new System.Drawing.Point(60, 196);
            this.changeBtn.Name = "changeBtn";
            this.changeBtn.Size = new System.Drawing.Size(153, 60);
            this.changeBtn.TabIndex = 2;
            this.changeBtn.Text = "Змінити";
            this.changeBtn.UseVisualStyleBackColor = false;
            this.changeBtn.Click += new System.EventHandler(this.changeBtn_Click_1);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelete.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic);
            this.btnDelete.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDelete.Location = new System.Drawing.Point(60, 114);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(153, 60);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Видалити";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.btnNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNew.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic);
            this.btnNew.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnNew.Location = new System.Drawing.Point(60, 42);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(153, 60);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "Новий запис";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic);
            this.label1.Location = new System.Drawing.Point(251, 475);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 22);
            this.label1.TabIndex = 29;
            this.label1.Text = "ID -";
            
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic);
            this.label2.Location = new System.Drawing.Point(158, 511);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 22);
            this.label2.TabIndex = 30;
            this.label2.Text = "Дата поставки -";
          
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic);
            this.label3.Location = new System.Drawing.Point(34, 537);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(256, 22);
            this.label3.TabIndex = 32;
            this.label3.Text = "Кількість годинників в поставці -";
          
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic);
            this.label4.Location = new System.Drawing.Point(146, 566);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 22);
            this.label4.TabIndex = 31;
            this.label4.Text = "Ціна за поставку -";
           
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic);
            this.label5.Location = new System.Drawing.Point(133, 616);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(157, 22);
            this.label5.TabIndex = 34;
            this.label5.Text = "ID Постачальника -";
         
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic);
            this.label6.Location = new System.Drawing.Point(150, 590);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(140, 22);
            this.label6.TabIndex = 33;
            this.label6.Text = "Умови поставки -";
         
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic);
            this.label8.Location = new System.Drawing.Point(169, 645);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 22);
            this.label8.TabIndex = 35;
            this.label8.Text = "ID Годинника -";
           
            // 
            // textBoxSupplyID
            // 
            this.textBoxSupplyID.Location = new System.Drawing.Point(296, 475);
            this.textBoxSupplyID.Name = "textBoxSupplyID";
            this.textBoxSupplyID.Size = new System.Drawing.Size(138, 20);
            this.textBoxSupplyID.TabIndex = 36;
          
            // 
            // textBoxSupplyVolume
            // 
            this.textBoxSupplyVolume.Location = new System.Drawing.Point(296, 540);
            this.textBoxSupplyVolume.Name = "textBoxSupplyVolume";
            this.textBoxSupplyVolume.Size = new System.Drawing.Size(138, 20);
            this.textBoxSupplyVolume.TabIndex = 38;
           
            // 
            // textBox_id_supplier
            // 
            this.textBox_id_supplier.Location = new System.Drawing.Point(296, 619);
            this.textBox_id_supplier.Name = "textBox_id_supplier";
            this.textBox_id_supplier.Size = new System.Drawing.Size(138, 20);
            this.textBox_id_supplier.TabIndex = 41;
          
            // 
            // textBoxSupply_terms
            // 
            this.textBoxSupply_terms.Location = new System.Drawing.Point(296, 593);
            this.textBoxSupply_terms.Name = "textBoxSupply_terms";
            this.textBoxSupply_terms.Size = new System.Drawing.Size(138, 20);
            this.textBoxSupply_terms.TabIndex = 40;
           
            // 
            // textBoxSupply_price
            // 
            this.textBoxSupply_price.Location = new System.Drawing.Point(296, 566);
            this.textBoxSupply_price.Name = "textBoxSupply_price";
            this.textBoxSupply_price.Size = new System.Drawing.Size(138, 20);
            this.textBoxSupply_price.TabIndex = 39;
           
            // 
            // textBox_watch_id
            // 
            this.textBox_watch_id.Location = new System.Drawing.Point(296, 645);
            this.textBox_watch_id.Name = "textBox_watch_id";
            this.textBox_watch_id.Size = new System.Drawing.Size(138, 20);
            this.textBox_watch_id.TabIndex = 42;
            
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(297, 512);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(137, 20);
            this.dateTimePicker1.TabIndex = 43;
            
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(1093, 48);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(25, 20);
            this.pictureBox2.TabIndex = 24;
            this.pictureBox2.TabStop = false;
            
            // 
            // CheackSupply
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(112)))), ((int)(((byte)(94)))));
            this.ClientSize = new System.Drawing.Size(1131, 933);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.textBox_watch_id);
            this.Controls.Add(this.textBox_id_supplier);
            this.Controls.Add(this.textBoxSupply_terms);
            this.Controls.Add(this.textBoxSupply_price);
            this.Controls.Add(this.textBoxSupplyVolume);
            this.Controls.Add(this.textBoxSupplyID);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.refresh_btn);
            this.Controls.Add(this.textBoxSearchSupllier);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "CheackSupply";
            this.Text = "Поставки";
            this.Load += new System.EventHandler(this.CheackSupply_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBoxSearchSupllier;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button refresh_btn;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button changeBtn;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxSupplyID;
        private System.Windows.Forms.TextBox textBoxSupplyVolume;
        private System.Windows.Forms.TextBox textBox_id_supplier;
        private System.Windows.Forms.TextBox textBoxSupply_terms;
        private System.Windows.Forms.TextBox textBoxSupply_price;
        private System.Windows.Forms.TextBox textBox_watch_id;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}