using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TravelExpertsData;
/// <summary>
/// Muneer Suleiman
/// </summary>

namespace TravelExpertsProjectGUI
{
    public partial class frmAddModifySupplier : Form
    {
        public Suppliers Supplier { get; set; }
        public bool AddSupplier { get; set; }
        public frmAddModifySupplier()
        {
            InitializeComponent();
        }

       

        private void frmAddModifySupplier_Load(object sender, EventArgs e)
        {
            if (AddSupplier)
            {
                this.Text = "Add Supplier";
                txtSupplierID.ReadOnly = false;

            }
            else
            {
                this.Text = "Modify Supplier";
                txtSupplierID.ReadOnly = true;
                this.DisplaySupplier();
            }
        }

        private void DisplaySupplier()
        {
            txtSupplierName.Text = Supplier.SupName;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                if (AddSupplier) // this is Add
                {
                    // initialize the Product property with new Products object
                    this.Supplier = new Suppliers();
                }
                this.LoadSupplierData(); // we have an object (public property Product) with new data
                this.DialogResult = DialogResult.OK;
            }
        }
        private bool IsValidData()
        {
            bool success = true;
            if (Validator.IsPresent(txtSupplierName, "Name"))
            {
                success = true;
            }
            else
                success = false;
            return success;
        }
        private void LoadSupplierData()
        {
            Supplier.SupName = txtSupplierName.Text;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
