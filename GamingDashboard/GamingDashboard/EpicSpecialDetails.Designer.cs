
namespace GamingDashboard
{
    partial class EpicSpecialDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EpicSpecialDetails));
            this.GameTitle = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.GameDesc = new System.Windows.Forms.Label();
            this.PriceLbl = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // GameTitle
            // 
            this.GameTitle.Font = new System.Drawing.Font("ROG Fonts", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameTitle.Location = new System.Drawing.Point(337, 26);
            this.GameTitle.Name = "GameTitle";
            this.GameTitle.Size = new System.Drawing.Size(385, 99);
            this.GameTitle.TabIndex = 15;
            this.GameTitle.Text = "Epic Specials";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(72, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 47);
            this.button1.TabIndex = 17;
            this.button1.Text = "Return";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // GameDesc
            // 
            this.GameDesc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.GameDesc.Location = new System.Drawing.Point(382, 136);
            this.GameDesc.Name = "GameDesc";
            this.GameDesc.Size = new System.Drawing.Size(340, 200);
            this.GameDesc.TabIndex = 18;
            this.GameDesc.Text = resources.GetString("GameDesc.Text");
            this.GameDesc.Click += new System.EventHandler(this.DameDesc_Click);
            // 
            // PriceLbl
            // 
            this.PriceLbl.AutoSize = true;
            this.PriceLbl.BackColor = System.Drawing.SystemColors.Control;
            this.PriceLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PriceLbl.Location = new System.Drawing.Point(423, 286);
            this.PriceLbl.Name = "PriceLbl";
            this.PriceLbl.Size = new System.Drawing.Size(61, 25);
            this.PriceLbl.TabIndex = 19;
            this.PriceLbl.Text = "Price";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.InitialImage = global::GamingDashboard.Properties.Resources.Video_Game_Controller_Logo;
            this.pictureBox1.Location = new System.Drawing.Point(48, 95);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(283, 330);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.WaitOnLoad = true;
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::GamingDashboard.Properties.Resources.Heart;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(585, 263);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(56, 48);
            this.button2.TabIndex = 20;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // EpicSpecialDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.PriceLbl);
            this.Controls.Add(this.GameDesc);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.GameTitle);
            this.Name = "EpicSpecialDetails";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label GameTitle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label GameDesc;
        private System.Windows.Forms.Label PriceLbl;
        private System.Windows.Forms.Button button2;
    }
}