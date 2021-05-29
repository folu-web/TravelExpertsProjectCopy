using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TravelExpertsData;
/// <summary>
/// Author: Foluke Edafe
/// </summary>

namespace TravelExpertsProjectGUI
{
    public partial class frmAddModifyProductSuppliers : Form
    {
        public ProductsSuppliers ProductSupplier { get; set; }
        public bool AddProd { get; set; }
        public frmAddModifyProductSuppliers()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void frmAddModifyProductSuppliers_Load(object sender, EventArgs e)
        {
            if (AddProd)
            {
                this.Text = "Add Product";
                txtProductId.ReadOnly = true;

            }
            else
            {
                this.Text = "Modify Product";
                txtProductId.ReadOnly = true;
                this.DisplayProduct();
            }
        }

        private void DisplayProduct()
        {
            //txtProductId.Text = ProductsSuppliers;
            txtSupplier.Text = ProductSupplier.ToString();
        }
    }
}
