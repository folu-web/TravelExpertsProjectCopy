using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TravelExpertsData;
/// <summary>
/// Author: Ligeng Peng
/// </summary>

namespace TravelExpertsProjectGUI
{
    public partial class frmPackageMaintenance : Form
    {
        private TravelExpertsContext context = new TravelExpertsContext(); // create db context object
        private Packages selectedPackage; // package select from list box

        public frmPackageMaintenance()
        {
            InitializeComponent();
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            frmMain form1 = new frmMain();
            form1.ShowDialog();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPackageMaintenance_Load(object sender, EventArgs e)
        {            
            DisplayPackages();           
        }

        private void DisplayPackages()
        {
            dgvPkgs.Columns.Clear(); // clears old content
            var packages = context.Packages // retrieve products data
                .OrderBy(p => p.PackageId) // ordered alpabetically by description
                .Select(p => new { p.PackageId, p.PkgName, p.PkgStartDate, p.PkgEndDate, p.PkgDesc, p.PkgBasePrice, p.PkgAgencyCommission }) // total seven columns
                .ToList();

            dgvPkgs.DataSource = packages;

            // add column for modify button
            var modifyColumn = new DataGridViewButtonColumn()
            { // object initializer
                UseColumnTextForButtonValue = true,
                HeaderText = "", // header on the top
                Text = "Modify"
            };

            dgvPkgs.Columns.Add(modifyColumn);// add new column to the grid view

            // add column for delete button
            var deleteColumn = new DataGridViewButtonColumn()
            {
                UseColumnTextForButtonValue = true,
                HeaderText = "",
                Text = "Delete"
            };
            dgvPkgs.Columns.Add(deleteColumn);

            // add column for add product
            var productColumn = new DataGridViewButtonColumn()
            {
                UseColumnTextForButtonValue = true,
                HeaderText = "",
                Text = "Add Product"
            };
            dgvPkgs.Columns.Add(productColumn);

            // format the column header
            dgvPkgs.EnableHeadersVisualStyles = false;
            dgvPkgs.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            dgvPkgs.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray; // golden background on headers
            dgvPkgs.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black; // text on headers

            // format the odd numbered rows
            dgvPkgs.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;

            // format the first column
            dgvPkgs.Columns[0].HeaderText = "ID";
            dgvPkgs.Columns[0].Width = 100;

            // format the second column
            dgvPkgs.Columns[1].HeaderText = "Package Name";
            dgvPkgs.Columns[1].Width = 150;

            // format the third column
            dgvPkgs.Columns[2].HeaderText = "Start Date";
            //dgvPkgs.Columns[2].Width = 1020;
            dgvPkgs.Columns[2].DefaultCellStyle.Format = "MM/dd/yyyy";

            // format the fourth column
            dgvPkgs.Columns[3].HeaderText = "End Date";
            dgvPkgs.Columns[3].Width = 100;
            dgvPkgs.Columns[3].DefaultCellStyle.Format = "MM/dd/yyyy";

            // format the fifth column
            dgvPkgs.Columns[4].HeaderText = "Package Description";
            dgvPkgs.Columns[4].Width = 500;

            // format the sixth column
            dgvPkgs.Columns[5].HeaderText = "Unit Price";
            dgvPkgs.Columns[5].Width = 90;
            dgvPkgs.Columns[5].DefaultCellStyle.Format = "c";

            // format the sixth column
            dgvPkgs.Columns[6].HeaderText = "Agency Commission";
            dgvPkgs.Columns[6].Width = 90;
            dgvPkgs.Columns[6].DefaultCellStyle.Format = "c";
        }
        private void dgvPkgs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // store index values for Modify and Delete button columns
            const int ModifyIndex = 7; // Modify buttins are column 8
            const int DeleteIndex = 8; // Delete buttons are column 9
            const int ProductIndex = 9; // add product buttons are column 10

            if (e.ColumnIndex == ModifyIndex || e.ColumnIndex == DeleteIndex || e.ColumnIndex == ProductIndex) // is it a button?
            {
                // get the product code: 
                // grid view has properties (collection) Rows and Columns
                // product code is cell number 0 in the current row
                // need to trim white spaces from char(10) column
                string value = dgvPkgs.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
                int pkgId = Convert.ToInt32(value);
                selectedPackage = context.Packages.Find(pkgId);// find by PK value
            }

            if (e.ColumnIndex == ModifyIndex) // user clicked on Modify
            {
                ModifyProduct();
            }
            else if (e.ColumnIndex == DeleteIndex) // user clicked on Delete
            {
                DeleteProduct();
            }
            else if (e.ColumnIndex == ProductIndex) // user clicked on Delete
            {
                AddProduct();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // create second form
            frmAddModifyPackage secondForm = new frmAddModifyPackage();

            // set its data
            secondForm.isAdd = true;
            secondForm.package = null; // set package to null as we are add a new package

            // show it modal
            DialogResult result = secondForm.ShowDialog(); // Accept returns OK

            // get data from it and perform add
            if (result == DialogResult.OK)
            {
                selectedPackage = secondForm.package; // the Add/Modify form collected data
                try
                {
                    context.Packages.Add(selectedPackage); // add new package to database
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

        private void ModifyProduct()
        {
            // create second form
            frmAddModifyPackage secondForm = new frmAddModifyPackage();

            // set its data
            secondForm.isAdd = false;
            secondForm.package = selectedPackage; // set package to null as we are add a new package

            // show it modal
            DialogResult result = secondForm.ShowDialog(); // Accept returns OK

            // get data from it and perform add
            if (result == DialogResult.OK)
            {
                selectedPackage = secondForm.package; // the Add/Modify form collected data
                try
                {
                    context.SaveChanges(); // save changes in the context
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

        private void DeleteProduct()
        {
            // get confirmation from the user
            DialogResult result = MessageBox.Show($"Do you want to delete {selectedPackage.PkgName}?",
                            "Confirm Delete", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    // remove the package
                    context.Packages.Remove(selectedPackage);
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

        private void AddProduct()
        {
            // create new form
            frmPackageProductSupplier thirdForm = new frmPackageProductSupplier();

            // set its data
            thirdForm.package = selectedPackage; // selected package

            // show it modal
            DialogResult result = thirdForm.ShowDialog(); // Accept returns OK
        }
    }
}
