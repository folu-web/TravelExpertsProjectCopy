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
    public partial class frmAddModifyProduct : Form
    {
        public Products Product { get; set; }
        public bool AddProduct { get; set; }

        public frmAddModifyProduct()
        {
            InitializeComponent();
        }

        private void frmAddModifyProduct_Load(object sender, EventArgs e)
        {
            if (AddProduct)
            {
                this.Text = "Add Product";
                txtProductID.ReadOnly = true;
                
            }
            else
            {
                this.Text = "Modify Product";
                txtProductID.ReadOnly = true;
                this.DisplayProduct();
            }
        }
        private void DisplayProduct()
        {
            
            txtProductName.Text = Product.ProdName;
           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                if (AddProduct) // this is Add
                {
                    // initialize the Product property with new Products object
                    this.Product = new Products();
                }
                this.LoadProductData(); // we have an object (public property Product) with new data
                this.DialogResult = DialogResult.OK;
            }
        }
        private bool IsValidData()
        {
            bool success = true;
            if (Validator.IsPresent(txtProductName, "Name"))
            {
                success = true;
            }
            else
                success = false;
            return success;
        }

        private void LoadProductData()
        {
            Product.ProdName = txtProductName.Text;
            
        }
    }
}
