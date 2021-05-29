
namespace TravelExpertsProjectGUI
{
    partial class coverForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(coverForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.picFacebook = new System.Windows.Forms.PictureBox();
            this.picInstagram = new System.Windows.Forms.PictureBox();
            this.picTwitter = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnWelcome = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picFacebook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInstagram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTwitter)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SeaShell;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(100, 550);
            this.panel1.TabIndex = 0;
            // 
            // picFacebook
            // 
            this.picFacebook.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picFacebook.BackgroundImage")));
            this.picFacebook.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picFacebook.Location = new System.Drawing.Point(34, 383);
            this.picFacebook.Name = "picFacebook";
            this.picFacebook.Size = new System.Drawing.Size(62, 45);
            this.picFacebook.TabIndex = 1;
            this.picFacebook.TabStop = false;
            // 
            // picInstagram
            // 
            this.picInstagram.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picInstagram.BackgroundImage")));
            this.picInstagram.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picInstagram.Location = new System.Drawing.Point(34, 478);
            this.picInstagram.Name = "picInstagram";
            this.picInstagram.Size = new System.Drawing.Size(62, 45);
            this.picInstagram.TabIndex = 3;
            this.picInstagram.TabStop = false;
            // 
            // picTwitter
            // 
            this.picTwitter.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picTwitter.BackgroundImage")));
            this.picTwitter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picTwitter.Location = new System.Drawing.Point(34, 430);
            this.picTwitter.Name = "picTwitter";
            this.picTwitter.Size = new System.Drawing.Size(62, 45);
            this.picTwitter.TabIndex = 4;
            this.picTwitter.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MV Boli", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(126, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(442, 79);
            this.label1.TabIndex = 5;
            this.label1.Text = "Travel experts";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Script MT Bold", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(270, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(466, 28);
            this.label2.TabIndex = 6;
            this.label2.Text = "Giving lifelong experiences that will amaze you.....";
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExit.BackgroundImage")));
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExit.Location = new System.Drawing.Point(878, 19);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(72, 57);
            this.btnExit.TabIndex = 7;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnWelcome
            // 
            this.btnWelcome.BackColor = System.Drawing.Color.SeaShell;
            this.btnWelcome.Font = new System.Drawing.Font("Modern No. 20", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnWelcome.Location = new System.Drawing.Point(586, 275);
            this.btnWelcome.Name = "btnWelcome";
            this.btnWelcome.Size = new System.Drawing.Size(254, 49);
            this.btnWelcome.TabIndex = 8;
            this.btnWelcome.Text = "Welcome>>>";
            this.btnWelcome.UseVisualStyleBackColor = false;
            this.btnWelcome.Click += new System.EventHandler(this.btnWelcome_Click);
            // 
            // coverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1000, 550);
            this.Controls.Add(this.btnWelcome);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picTwitter);
            this.Controls.Add(this.picInstagram);
            this.Controls.Add(this.picFacebook);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "coverForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "coverForm";
            ((System.ComponentModel.ISupportInitialize)(this.picFacebook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInstagram)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTwitter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picFacebook;
        private System.Windows.Forms.PictureBox picInstagram;
        private System.Windows.Forms.PictureBox picTwitter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnWelcome;
    }
}