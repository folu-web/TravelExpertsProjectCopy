using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/// <summary>
/// Author: Ligeng Peng
/// </summary>

namespace TravelExpertsProjectGUI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnPkg_Click(object sender, EventArgs e)
        {
            frmPackageMaintenance form2 = new frmPackageMaintenance();
            form2.ShowDialog();
            this.Hide();
        }

        private void btnPrd_Click(object sender, EventArgs e)
        {
            frmProduct anodaPage = new frmProduct();
            anodaPage.ShowDialog();
            this.Hide();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            coverForm page = new coverForm();
            page.ShowDialog();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmProductSuppliers forpage = new frmProductSuppliers();
            forpage.ShowDialog();
            this.Hide();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnSup_Click(object sender, EventArgs e)
        {
            Form1 content = new Form1();
            content.ShowDialog();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
