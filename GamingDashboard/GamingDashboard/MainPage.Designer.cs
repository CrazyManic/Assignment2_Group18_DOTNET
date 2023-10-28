
namespace GamingDashboard
{
    partial class MainPage
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
            this.EpicSalesBtn = new System.Windows.Forms.Button();
            this.ReviewsBtn = new System.Windows.Forms.Button();
            this.ComingSoonBtn = new System.Windows.Forms.Button();
            this.MyFavouritesBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.UserNameLbl = new System.Windows.Forms.Label();
            this.ManageAccountBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // EpicSalesBtn
            // 
            this.EpicSalesBtn.Location = new System.Drawing.Point(85, 154);
            this.EpicSalesBtn.Name = "EpicSalesBtn";
            this.EpicSalesBtn.Size = new System.Drawing.Size(219, 257);
            this.EpicSalesBtn.TabIndex = 0;
            this.EpicSalesBtn.Text = "EPIC Sales";
            this.EpicSalesBtn.UseVisualStyleBackColor = true;
            this.EpicSalesBtn.Click += new System.EventHandler(this.EpicSalesBtn_Click);
            // 
            // ReviewsBtn
            // 
            this.ReviewsBtn.Location = new System.Drawing.Point(310, 154);
            this.ReviewsBtn.Name = "ReviewsBtn";
            this.ReviewsBtn.Size = new System.Drawing.Size(262, 81);
            this.ReviewsBtn.TabIndex = 1;
            this.ReviewsBtn.Text = "Reviews";
            this.ReviewsBtn.UseVisualStyleBackColor = true;
            // 
            // ComingSoonBtn
            // 
            this.ComingSoonBtn.Location = new System.Drawing.Point(310, 241);
            this.ComingSoonBtn.Name = "ComingSoonBtn";
            this.ComingSoonBtn.Size = new System.Drawing.Size(262, 82);
            this.ComingSoonBtn.TabIndex = 2;
            this.ComingSoonBtn.Text = "Coming Soon";
            this.ComingSoonBtn.UseVisualStyleBackColor = true;
            this.ComingSoonBtn.Click += new System.EventHandler(this.ComingSoonBtn_Click);
            // 
            // MyFavouritesBtn
            // 
            this.MyFavouritesBtn.Location = new System.Drawing.Point(310, 329);
            this.MyFavouritesBtn.Name = "MyFavouritesBtn";
            this.MyFavouritesBtn.Size = new System.Drawing.Size(262, 82);
            this.MyFavouritesBtn.TabIndex = 3;
            this.MyFavouritesBtn.Text = "My Favourites";
            this.MyFavouritesBtn.UseVisualStyleBackColor = true;
            this.MyFavouritesBtn.Click += new System.EventHandler(this.MyFavouritesBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GamingDashboard.Properties.Resources.Video_Game_Controller_Logo;
            this.pictureBox1.Location = new System.Drawing.Point(-31, -23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(268, 202);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("ROG Fonts", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(184, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(579, 77);
            this.label1.TabIndex = 5;
            this.label1.Text = "Dash Gaming";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::GamingDashboard.Properties.Resources.pattern;
            this.pictureBox2.Location = new System.Drawing.Point(578, 86);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(210, 252);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // UserNameLbl
            // 
            this.UserNameLbl.AutoSize = true;
            this.UserNameLbl.BackColor = System.Drawing.Color.Transparent;
            this.UserNameLbl.Font = new System.Drawing.Font("Niagara Engraved", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserNameLbl.ForeColor = System.Drawing.Color.Transparent;
            this.UserNameLbl.Location = new System.Drawing.Point(643, 195);
            this.UserNameLbl.Name = "UserNameLbl";
            this.UserNameLbl.Size = new System.Drawing.Size(73, 40);
            this.UserNameLbl.TabIndex = 7;
            this.UserNameLbl.Text = "label2";
            this.UserNameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.UserNameLbl.Click += new System.EventHandler(this.label2_Click);
            // 
            // ManageAccountBtn
            // 
            this.ManageAccountBtn.Location = new System.Drawing.Point(598, 279);
            this.ManageAccountBtn.Name = "ManageAccountBtn";
            this.ManageAccountBtn.Size = new System.Drawing.Size(165, 34);
            this.ManageAccountBtn.TabIndex = 8;
            this.ManageAccountBtn.Text = "ManageAccount";
            this.ManageAccountBtn.UseVisualStyleBackColor = true;
            this.ManageAccountBtn.Click += new System.EventHandler(this.ManageAccountBtn_Click);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ManageAccountBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MyFavouritesBtn);
            this.Controls.Add(this.ComingSoonBtn);
            this.Controls.Add(this.ReviewsBtn);
            this.Controls.Add(this.EpicSalesBtn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.UserNameLbl);
            this.Controls.Add(this.pictureBox2);
            this.Name = "MainPage";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button EpicSalesBtn;
        private System.Windows.Forms.Button ReviewsBtn;
        private System.Windows.Forms.Button ComingSoonBtn;
        private System.Windows.Forms.Button MyFavouritesBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label UserNameLbl;
        private System.Windows.Forms.Button ManageAccountBtn;
    }
}