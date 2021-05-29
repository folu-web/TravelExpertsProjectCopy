
namespace TravelExpertsProjectGUI
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gpbPkg = new System.Windows.Forms.GroupBox();
            this.btnPkg = new System.Windows.Forms.Button();
            this.btnPrd = new System.Windows.Forms.Button();
            this.gpbPrd = new System.Windows.Forms.GroupBox();
            this.btnSup = new System.Windows.Forms.Button();
            this.gpbSup = new System.Windows.Forms.GroupBox();
            this.btnHome = new System.Windows.Forms.Button();
            this.gpbProdSub = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.gpbPkg.SuspendLayout();
            this.gpbPrd.SuspendLayout();
            this.gpbSup.SuspendLayout();
            this.gpbProdSub.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbPkg
            // 
            this.gpbPkg.Controls.Add(this.btnPkg);
            this.gpbPkg.Location = new System.Drawing.Point(82, 60);
            this.gpbPkg.Name = "gpbPkg";
            this.gpbPkg.Size = new System.Drawing.Size(180, 166);
            this.gpbPkg.TabIndex = 0;
            this.gpbPkg.TabStop = false;
            this.gpbPkg.Text = "Packages";
            // 
            // btnPkg
            // 
            this.btnPkg.Location = new System.Drawing.Point(41, 110);
            this.btnPkg.Name = "btnPkg";
            this.btnPkg.Size = new System.Drawing.Size(90, 43);
            this.btnPkg.TabIndex = 0;
            this.btnPkg.Text = "View";
            this.btnPkg.UseVisualStyleBackColor = true;
            this.btnPkg.Click += new System.EventHandler(this.btnPkg_Click);
            // 
            // btnPrd
            // 
            this.btnPrd.Location = new System.Drawing.Point(41, 100);
            this.btnPrd.Name = "btnPrd";
            this.btnPrd.Size = new System.Drawing.Size(90, 43);
            this.btnPrd.TabIndex = 0;
            this.btnPrd.Text = "View";
            this.btnPrd.UseVisualStyleBackColor = true;
            this.btnPrd.Click += new System.EventHandler(this.btnPrd_Click);
            // 
            // gpbPrd
            // 
            this.gpbPrd.Controls.Add(this.btnPrd);
            this.gpbPrd.Location = new System.Drawing.Point(388, 70);
            this.gpbPrd.Name = "gpbPrd";
            this.gpbPrd.Size = new System.Drawing.Size(200, 166);
            this.gpbPrd.TabIndex = 1;
            this.gpbPrd.TabStop = false;
            this.gpbPrd.Text = "Products";
            // 
            // btnSup
            // 
            this.btnSup.Location = new System.Drawing.Point(41, 100);
            this.btnSup.Name = "btnSup";
            this.btnSup.Size = new System.Drawing.Size(90, 40);
            this.btnSup.TabIndex = 0;
            this.btnSup.Text = "View";
            this.btnSup.UseVisualStyleBackColor = true;
            this.btnSup.Click += new System.EventHandler(this.btnSup_Click);
            // 
            // gpbSup
            // 
            this.gpbSup.Controls.Add(this.btnSup);
            this.gpbSup.Location = new System.Drawing.Point(82, 291);
            this.gpbSup.Name = "gpbSup";
            this.gpbSup.Size = new System.Drawing.Size(180, 166);
            this.gpbSup.TabIndex = 1;
            this.gpbSup.TabStop = false;
            this.gpbSup.Text = "Suppliers";
            // 
            // btnHome
            // 
            this.btnHome.Location = new System.Drawing.Point(698, 348);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(147, 47);
            this.btnHome.TabIndex = 2;
            this.btnHome.Text = "<< Home";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // gpbProdSub
            // 
            this.gpbProdSub.Controls.Add(this.button1);
            this.gpbProdSub.Location = new System.Drawing.Point(388, 291);
            this.gpbProdSub.Name = "gpbProdSub";
            this.gpbProdSub.Size = new System.Drawing.Size(200, 166);
            this.gpbProdSub.TabIndex = 3;
            this.gpbProdSub.TabStop = false;
            this.gpbProdSub.Text = "Product_Suppliers";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(41, 100);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 40);
            this.button1.TabIndex = 0;
            this.button1.Text = "View";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SeaShell;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 495);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(900, 55);
            this.panel1.TabIndex = 4;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.SeaShell;
            this.label1.Font = new System.Drawing.Font("MV Boli", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(618, 502);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 44);
            this.label1.TabIndex = 5;
            this.label1.Text = "Travel experts";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Peru;
            this.ClientSize = new System.Drawing.Size(900, 550);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gpbProdSub);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.gpbSup);
            this.Controls.Add(this.gpbPrd);
            this.Controls.Add(this.gpbPkg);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Welcome to Travel Expert";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.gpbPkg.ResumeLayout(false);
            this.gpbPrd.ResumeLayout(false);
            this.gpbSup.ResumeLayout(false);
            this.gpbProdSub.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbPkg;
        private System.Windows.Forms.Button btnPkg;
        private System.Windows.Forms.Button btnPrd;
        private System.Windows.Forms.GroupBox gpbPrd;
        private System.Windows.Forms.Button btnSup;
        private System.Windows.Forms.GroupBox gpbSup;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.GroupBox gpbProdSub;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}

