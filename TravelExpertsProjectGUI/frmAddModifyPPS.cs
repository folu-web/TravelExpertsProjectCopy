using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TravelExpertsData;
/// <summary>
/// Author: Ligeng Peng
/// </summary>

namespace TravelExpertsProjectGUI
{
    public partial class frmAddModifyPPS : Form
    {
        private TravelExpertsContext context = new TravelExpertsContext(); // create db context object
        public PackagesProductsSuppliers PPS;
        public Packages package;
        public bool isAdd;
        public frmAddModifyPPS()
        {
            InitializeComponent();
        }

        private void frmAddModifyPPS_Load(object sender, EventArgs e)
        {
            // is it Add  or modify
            if (this.isAdd) // Add
            {
                this.Text = "Add Package Product Supperiler";
                txtPkgID.Text = package.PackageId.ToString();
                lblDisplay.Text = "Please enter the Product Supplier ID you want add to the Current Package:";
            }
            else // Modify
            {
                this.Text = "Modify Package Product Supperiler";
                txtPkgID.Text = package.PackageId.ToString();
                lblDisplay.Text = "Please enter the new Product Supplier ID to the Current Package:";

            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            PPS = new PackagesProductsSuppliers();

            // load customer data
            PPS.PackageId = Convert.ToInt32(txtPkgID.Text);
            PPS.ProductSupplierId = Convert.ToInt32(txt2.Text);

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
