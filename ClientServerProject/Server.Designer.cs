namespace ClientServerProject
{
    partial class Server
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.rchTxtBox = new System.Windows.Forms.RichTextBox();
            this.lampBox = new System.Windows.Forms.PictureBox();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.lampBox)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(153, 295);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 75);
            this.button1.TabIndex = 0;
            this.button1.Text = "Aç/Kapa";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(521, 295);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(78, 75);
            this.button2.TabIndex = 1;
            this.button2.Text = "Sayı Oluştur";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // rchTxtBox
            // 
            this.rchTxtBox.Location = new System.Drawing.Point(443, 65);
            this.rchTxtBox.Name = "rchTxtBox";
            this.rchTxtBox.Size = new System.Drawing.Size(224, 224);
            this.rchTxtBox.TabIndex = 3;
            this.rchTxtBox.Text = "Boş Alan Göndermeyin.";
            this.rchTxtBox.TextChanged += new System.EventHandler(this.rchTxtBox_TextChanged);
            // 
            // lampBox
            // 
            this.lampBox.Image = global::ClientServerProject.Properties.Resources.kapali_lamba;
            this.lampBox.Location = new System.Drawing.Point(87, 65);
            this.lampBox.Name = "lampBox";
            this.lampBox.Size = new System.Drawing.Size(224, 224);
            this.lampBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.lampBox.TabIndex = 2;
            this.lampBox.TabStop = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(105, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Server\'ı kapat";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 389);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.rchTxtBox);
            this.Controls.Add(this.lampBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Server";
            this.Text = "Server";
            this.Load += new System.EventHandler(this.Server_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lampBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox rchTxtBox;
        internal System.Windows.Forms.PictureBox lampBox;
        private System.Windows.Forms.Button button3;
    }
}

