namespace WatchHub.Forms
{
    partial class OrdersSumStatistics
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
            this.buttonCreateStatZagalSum = new System.Windows.Forms.Button();
            this.buttonCreateStatDateSum = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFinish = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonCreateStatZagalSum
            // 
            this.buttonCreateStatZagalSum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.buttonCreateStatZagalSum.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCreateStatZagalSum.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonCreateStatZagalSum.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic);
            this.buttonCreateStatZagalSum.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonCreateStatZagalSum.Location = new System.Drawing.Point(12, 159);
            this.buttonCreateStatZagalSum.Name = "buttonCreateStatZagalSum";
            this.buttonCreateStatZagalSum.Size = new System.Drawing.Size(153, 75);
            this.buttonCreateStatZagalSum.TabIndex = 8;
            this.buttonCreateStatZagalSum.Text = "Загальна сума прибутку";
            this.buttonCreateStatZagalSum.UseVisualStyleBackColor = false;
            this.buttonCreateStatZagalSum.Click += new System.EventHandler(this.buttonCreateStatZagalSum_Click);
            // 
            // buttonCreateStatDateSum
            // 
            this.buttonCreateStatDateSum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.buttonCreateStatDateSum.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCreateStatDateSum.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonCreateStatDateSum.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic);
            this.buttonCreateStatDateSum.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonCreateStatDateSum.Location = new System.Drawing.Point(324, 159);
            this.buttonCreateStatDateSum.Name = "buttonCreateStatDateSum";
            this.buttonCreateStatDateSum.Size = new System.Drawing.Size(153, 75);
            this.buttonCreateStatDateSum.TabIndex = 9;
            this.buttonCreateStatDateSum.Text = "Загальна сума прибутку (за певний час)";
            this.buttonCreateStatDateSum.UseVisualStyleBackColor = false;
            this.buttonCreateStatDateSum.Click += new System.EventHandler(this.buttonCreateStatDateSum_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic);
            this.label1.Location = new System.Drawing.Point(191, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 22);
            this.label1.TabIndex = 10;
            this.label1.Text = "Оберіть час ";
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Location = new System.Drawing.Point(12, 90);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerStart.TabIndex = 11;
            // 
            // dateTimePickerFinish
            // 
            this.dateTimePickerFinish.Location = new System.Drawing.Point(277, 90);
            this.dateTimePickerFinish.Name = "dateTimePickerFinish";
            this.dateTimePickerFinish.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerFinish.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(222, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "--------------";
            // 
            // OrdersSumStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(112)))), ((int)(((byte)(94)))));
            this.ClientSize = new System.Drawing.Size(508, 253);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePickerFinish);
            this.Controls.Add(this.dateTimePickerStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCreateStatDateSum);
            this.Controls.Add(this.buttonCreateStatZagalSum);
            this.Name = "OrdersSumStatistics";
            this.Text = "Сума прибутку за замовлення";
            this.Load += new System.EventHandler(this.OrdersSumStatistics_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCreateStatZagalSum;
        private System.Windows.Forms.Button buttonCreateStatDateSum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.DateTimePicker dateTimePickerFinish;
        private System.Windows.Forms.Label label2;
    }
}