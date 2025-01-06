namespace WatchHub.Forms
{
    partial class OrderGuarantee
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
            this.label21 = new System.Windows.Forms.Label();
            this.textBoxOrder_id = new System.Windows.Forms.TextBox();
            this.buttonCreateGuarantZvit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label21.Location = new System.Drawing.Point(34, 137);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(187, 22);
            this.label21.TabIndex = 9;
            this.label21.Text = "Оберіть id замовлення - ";
            // 
            // textBoxOrder_id
            // 
            this.textBoxOrder_id.Location = new System.Drawing.Point(227, 140);
            this.textBoxOrder_id.Name = "textBoxOrder_id";
            this.textBoxOrder_id.Size = new System.Drawing.Size(47, 20);
            this.textBoxOrder_id.TabIndex = 10;
            // 
            // buttonCreateGuarantZvit
            // 
            this.buttonCreateGuarantZvit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.buttonCreateGuarantZvit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCreateGuarantZvit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonCreateGuarantZvit.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic);
            this.buttonCreateGuarantZvit.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonCreateGuarantZvit.Location = new System.Drawing.Point(68, 224);
            this.buttonCreateGuarantZvit.Name = "buttonCreateGuarantZvit";
            this.buttonCreateGuarantZvit.Size = new System.Drawing.Size(153, 60);
            this.buttonCreateGuarantZvit.TabIndex = 11;
            this.buttonCreateGuarantZvit.Text = "Створити";
            this.buttonCreateGuarantZvit.UseVisualStyleBackColor = false;
            this.buttonCreateGuarantZvit.Click += new System.EventHandler(this.buttonCreateGuarantZvit_Click);
            // 
            // OrderGuarantee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(112)))), ((int)(((byte)(94)))));
            this.ClientSize = new System.Drawing.Size(427, 450);
            this.Controls.Add(this.buttonCreateGuarantZvit);
            this.Controls.Add(this.textBoxOrder_id);
            this.Controls.Add(this.label21);
            this.Name = "OrderGuarantee";
            this.Text = "Видача гарантії";
            this.Load += new System.EventHandler(this.OrderGuarantee_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox textBoxOrder_id;
        private System.Windows.Forms.Button buttonCreateGuarantZvit;
    }
}