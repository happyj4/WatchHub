namespace WatchHub.Forms
{
    partial class WatchStorageCountStatistics
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
            this.buttonWatchCountByTitleAndBrand = new System.Windows.Forms.Button();
            this.buttonAllCountWatchStorage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonWatchCountByTitleAndBrand
            // 
            this.buttonWatchCountByTitleAndBrand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.buttonWatchCountByTitleAndBrand.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonWatchCountByTitleAndBrand.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonWatchCountByTitleAndBrand.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic);
            this.buttonWatchCountByTitleAndBrand.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonWatchCountByTitleAndBrand.Location = new System.Drawing.Point(219, 28);
            this.buttonWatchCountByTitleAndBrand.Name = "buttonWatchCountByTitleAndBrand";
            this.buttonWatchCountByTitleAndBrand.Size = new System.Drawing.Size(220, 75);
            this.buttonWatchCountByTitleAndBrand.TabIndex = 11;
            this.buttonWatchCountByTitleAndBrand.Text = "\"Найбільша та найменша  кількість товарів одного виду в наявності \"";
            this.buttonWatchCountByTitleAndBrand.UseVisualStyleBackColor = false;
            this.buttonWatchCountByTitleAndBrand.Click += new System.EventHandler(this.buttonWatchCountByTitleAndBrand_Click);
            // 
            // buttonAllCountWatchStorage
            // 
            this.buttonAllCountWatchStorage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.buttonAllCountWatchStorage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAllCountWatchStorage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonAllCountWatchStorage.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic);
            this.buttonAllCountWatchStorage.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonAllCountWatchStorage.Location = new System.Drawing.Point(12, 28);
            this.buttonAllCountWatchStorage.Name = "buttonAllCountWatchStorage";
            this.buttonAllCountWatchStorage.Size = new System.Drawing.Size(201, 75);
            this.buttonAllCountWatchStorage.TabIndex = 12;
            this.buttonAllCountWatchStorage.Text = "\"Загальна кількість годинників на складі\"";
            this.buttonAllCountWatchStorage.UseVisualStyleBackColor = false;
            this.buttonAllCountWatchStorage.Click += new System.EventHandler(this.buttonAllCountWatchStorage_Click);
            // 
            // WatchStorageCountStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(112)))), ((int)(((byte)(94)))));
            this.ClientSize = new System.Drawing.Size(448, 130);
            this.Controls.Add(this.buttonAllCountWatchStorage);
            this.Controls.Add(this.buttonWatchCountByTitleAndBrand);
            this.Name = "WatchStorageCountStatistics";
            this.Text = "Кількість годинників на складі";
            this.Load += new System.EventHandler(this.WatchStorageCountStatistics_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonWatchCountByTitleAndBrand;
        private System.Windows.Forms.Button buttonAllCountWatchStorage;
    }
}