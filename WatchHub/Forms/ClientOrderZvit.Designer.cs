namespace WatchHub.Forms
{
    partial class ClientOrderZvit
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
            this.textBoxClientIdZvit = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.buttonCreateZvitOrder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxClientIdZvit
            // 
            this.textBoxClientIdZvit.Location = new System.Drawing.Point(198, 89);
            this.textBoxClientIdZvit.Name = "textBoxClientIdZvit";
            this.textBoxClientIdZvit.Size = new System.Drawing.Size(50, 20);
            this.textBoxClientIdZvit.TabIndex = 9;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label21.Location = new System.Drawing.Point(43, 86);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(153, 22);
            this.label21.TabIndex = 8;
            this.label21.Text = "Обрати id клієнта -";
            // 
            // buttonCreateZvitOrder
            // 
            this.buttonCreateZvitOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.buttonCreateZvitOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCreateZvitOrder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonCreateZvitOrder.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic);
            this.buttonCreateZvitOrder.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonCreateZvitOrder.Location = new System.Drawing.Point(71, 164);
            this.buttonCreateZvitOrder.Name = "buttonCreateZvitOrder";
            this.buttonCreateZvitOrder.Size = new System.Drawing.Size(153, 60);
            this.buttonCreateZvitOrder.TabIndex = 7;
            this.buttonCreateZvitOrder.Text = "Створити звіт";
            this.buttonCreateZvitOrder.UseVisualStyleBackColor = false;
            this.buttonCreateZvitOrder.Click += new System.EventHandler(this.buttonCreateZvitOrder_Click);
            // 
            // ClientOrderZvit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(112)))), ((int)(((byte)(94)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(282, 268);
            this.Controls.Add(this.textBoxClientIdZvit);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.buttonCreateZvitOrder);
            this.Name = "ClientOrderZvit";
            this.Text = "ЗВІТ - Конкретне замволення кліента";
            this.Load += new System.EventHandler(this.ClientOrderZvit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxClientIdZvit;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button buttonCreateZvitOrder;
    }
}