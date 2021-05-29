using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TravelExpertsData;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
/// <summary>
/// Author: Ligeng Peng
/// </summary>

namespace TravelExpertsProjectGUI
{
    public partial class frmPackageProductSupplier : Form
    {
        private TravelExpertsContext context = new TravelExpertsContext(); // create db context object
        public PackagesProductsSuppliers selectedPPS;
        public Packages package;
        public frmPackageProductSupplier()
        {
            InitializeComponent();
        }

        private void frmPackageProductSupplier_Load(object sender, EventArgs e)
        {
            DisplayPackages();
        }
        private void DisplayPackages()
        {
            dgvPPS.Columns.Clear(); // clears old content
            var packages = context.PackagesProductsSuppliers // retrieve products data
                .OrderBy(p => p.PackageId) // ordered alpabetically by description
                .Select(p => new { p.PackageId, p.ProductSupplierId }) // total seven columns
                .Where(p => p.PackageId == package.PackageId)
                .ToList();

            dgvPPS.DataSource = packages;

            // add column for modify button
            var modifyColumn = new DataGridViewButtonColumn()
            { // object initializer
                UseColumnTextForButtonValue = true,
                HeaderText = "", // header on the top
                Text = "Modify"
            };
            dgvPPS.Columns.Add(modifyColumn);// add new column to the grid view

            // add column for delete button
            var deleteColumn = new DataGridViewButtonColumn()
            {
                UseColumnTextForButtonValue = true,
                HeaderText = "",
                Text = "Delete"
            };
            dgvPPS.Columns.Add(deleteColumn);

            // format the column header
            dgvPPS.EnableHeadersVisualStyles = false;
            dgvPPS.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            dgvPPS.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray; // golden background on headers
            dgvPPS.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black; // text on headers

            // format the odd numbered rows
            dgvPPS.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            // format the first column
            dgvPPS.Columns[0].HeaderText = "Package ID";
            dgvPPS.Columns[0].Width = 100;

            // format the second column
            dgvPPS.Columns[1].HeaderText = "Product Supplier ID";
            dgvPPS.Columns[1].Width = 100;
        }

        private void dgvPPS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // store index values for Modify and Delete button columns
            const int ModifyIndex = 2; // Modify buttons are column 3
            const int DeleteIndex = 3; // Delete buttons are column 4

            if (e.ColumnIndex == ModifyIndex || e.ColumnIndex == DeleteIndex) // is it a button?
            {
                string firstId = dgvPPS.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
                string secondId = dgvPPS.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
                int pkgId = Convert.ToInt32(firstId);
                int productSupplierId = Convert.ToInt32(secondId);
                selectedPPS = context.PackagesProductsSuppliers.Find(pkgId, productSupplierId);// find by PK value
            }

            if (e.ColumnIndex == ModifyIndex) // user clicked on Modify
            {
                ModifyPPS();
            }
            else if (e.ColumnIndex == DeleteIndex) // user clicked on Delete
            {
                DeletePPS();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddModifyPPS fourthForm = new frmAddModifyPPS(); //create new form

            // set its data
            fourthForm.isAdd = true; // add new product_supplier
            fourthForm.PPS = null; // PPS is null for 
            fourthForm.package = package;

            // show it modal
            DialogResult result = fourthForm.ShowDialog(); // Accept returns OK

            // get data from it and perform add
            if (result == DialogResult.OK)
            {
                selectedPPS = fourthForm.PPS; // the Add/Modify form collected data
                try
                {
                    context.PackagesProductsSuppliers.Add(selectedPPS); // add new package to database
                    context.SaveChanges(); // ave changes in the context
                    DisplayPackages(); // show new data from database to listbox
                }
                catch (DbUpdateException ex)
                {
                    HandleDataError(ex);
                }
                catch (Exception ex)
                {
                    HandleGeneralError(ex);
                }
            }
        }

        // displays error message of unknown (any) error
        private void HandleGeneralError(Exception ex)
        {
            MessageBox.Show(ex.Message, ex.GetType().ToString());
        }

        // DbUpdateException occured
        private void HandleDataError(DbUpdateException ex)
        {
            var sqlException = (SqlException)ex.InnerException; //can carry multiple errors
            string message = "";
            foreach (SqlError error in sqlException.Errors)
            {
                message += "ERROR code: " + error.Number + " - " + error.Message + "\n";
            }
            MessageBox.Show(message, "Data Error(s)");
        }
        private void ModifyPPS()
        {
            frmAddModifyPPS fourthForm = new frmAddModifyPPS(); //create new form

            // set its data
            fourthForm.isAdd = false;
            fourthForm.PPS = selectedPPS; // selected package
            fourthForm.package = package; // pass package to modify form

            // show it modal
            DialogResult result = fourthForm.ShowDialog(); // Accept returns OK

            // get data from it and perform add
            if (result == DialogResult.OK)
            {
                context.PackagesProductsSuppliers.Remove(selectedPPS);
                selectedPPS = fourthForm.PPS; // the Add/Modify form collected data
                try
                {
                    context.PackagesProductsSuppliers.Add(selectedPPS);
                    context.SaveChanges(); // save changes in the context
                    DisplayPackages(); // show new data from database
                }
                catch (DbUpdateException ex)
                {
                    HandleDataError(ex);
                }
                catch (Exception ex)
                {
                    HandleGeneralError(ex);
                }
            }
        }

        private void DeletePPS()
        {
            // get confirmation from the user
            DialogResult result = MessageBox.Show($"Do you want to delete Product Supplier ID: {selectedPPS.ProductSupplierId}?",
                            "Confirm Delete", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    // remove the package
                    context.PackagesProductsSuppliers.Remove(selectedPPS);
                    context.SaveChanges();
                    DisplayPackages(); // show new data from database to listbox
                }
                catch (DbUpdateException ex)
                {
                    HandleDataError(ex);
                }
                catch (Exception ex)
                {
                    HandleGeneralError(ex);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
