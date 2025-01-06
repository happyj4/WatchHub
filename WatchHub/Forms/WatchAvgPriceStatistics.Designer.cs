namespace WatchHub.Forms
{
    partial class WatchAvgPriceStatistics
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
            this.buttonAvgWatchPriceByBrand = new System.Windows.Forms.Button();
            this.buttonAvgWatchPrice = new System.Windows.Forms.Button();
            this.comboBoxBrand = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(78, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 28);
            this.label1.TabIndex = 11;
            this.label1.Text = "Оберіть бренд годинника";
            // 
            // buttonAvgWatchPriceByBrand
            // 
            this.buttonAvgWatchPriceByBrand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.buttonAvgWatchPriceByBrand.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAvgWatchPriceByBrand.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonAvgWatchPriceByBrand.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic);
            this.buttonAvgWatchPriceByBrand.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonAvgWatchPriceByBrand.Location = new System.Drawing.Point(240, 162);
            this.buttonAvgWatchPriceByBrand.Name = "buttonAvgWatchPriceByBrand";
            this.buttonAvgWatchPriceByBrand.Size = new System.Drawing.Size(153, 75);
            this.buttonAvgWatchPriceByBrand.TabIndex = 13;
            this.buttonAvgWatchPriceByBrand.Text = "Середня ціна за обранним брендом";
            this.buttonAvgWatchPriceByBrand.UseVisualStyleBackColor = false;
            this.buttonAvgWatchPriceByBrand.Click += new System.EventHandler(this.buttonAvgWatchPriceByBrand_Click);
            // 
            // buttonAvgWatchPrice
            // 
            this.buttonAvgWatchPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.buttonAvgWatchPrice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAvgWatchPrice.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonAvgWatchPrice.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic);
            this.buttonAvgWatchPrice.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonAvgWatchPrice.Location = new System.Drawing.Point(12, 162);
            this.buttonAvgWatchPrice.Name = "buttonAvgWatchPrice";
            this.buttonAvgWatchPrice.Size = new System.Drawing.Size(153, 75);
            this.buttonAvgWatchPrice.TabIndex = 12;
            this.buttonAvgWatchPrice.Text = "Середня ціна за годинник ";
            this.buttonAvgWatchPrice.UseVisualStyleBackColor = false;
            this.buttonAvgWatchPrice.Click += new System.EventHandler(this.buttonAvgWatchPrice_Click);
            // 
            // comboBoxBrand
            // 
            this.comboBoxBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBrand.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic);
            this.comboBoxBrand.FormattingEnabled = true;
            this.comboBoxBrand.Items.AddRange(new object[] {
            "Casio",
            "Oris",
            "Tissot",
            "Citizen",
            "Hamilton",
            "Longines",
            "Atlantic",
            "Orient",
            "Rado",
            "Breitling",
            "Certina",
            "Epos"});
            this.comboBoxBrand.Location = new System.Drawing.Point(98, 74);
            this.comboBoxBrand.Name = "comboBoxBrand";
            this.comboBoxBrand.Size = new System.Drawing.Size(187, 30);
            this.comboBoxBrand.TabIndex = 14;
            // 
            // WatchAvgPriceStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(112)))), ((int)(((byte)(94)))));
            this.ClientSize = new System.Drawing.Size(405, 495);
            this.Controls.Add(this.comboBoxBrand);
            this.Controls.Add(this.buttonAvgWatchPriceByBrand);
            this.Controls.Add(this.buttonAvgWatchPrice);
            this.Controls.Add(this.label1);
            this.Name = "WatchAvgPriceStatistics";
            this.Text = "Середння ціна за годинник";
            this.Load += new System.EventHandler(this.WatchAvgPriceStatistics_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAvgWatchPriceByBrand;
        private System.Windows.Forms.Button buttonAvgWatchPrice;
        private System.Windows.Forms.ComboBox comboBoxBrand;
    }
}