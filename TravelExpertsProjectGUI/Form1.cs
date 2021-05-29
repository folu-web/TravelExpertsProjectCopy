using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelExpertsData;
using TravelExpertsProjectGUI;
/// <summary>
/// Author: Muneer Suleiman
/// </summary>

namespace TravelExpertsProjectGUI
{
    public partial class Form1 : Form
    {
        private TravelExpertsContext db = new TravelExpertsContext(); // creating a new database db object
        private Suppliers getSupplier; // product to appear on


        public Form1()
        {
            InitializeComponent();
        }

      

        private void Form1_Load(object sender, EventArgs e)
        {
            DisplaySuppliers();
        }

        private void DisplaySuppliers()
        {
            dgvSuppliers.Columns.Clear();
            var suppliers = db.Suppliers.Select
                 (s => new
                 {
                     s.SupplierId,
                     s.SupName
                 }).ToList();
            dgvSuppliers.DataSource = suppliers;

            //column header format
            dgvSuppliers.Columns[0].HeaderText = "Supplier ID";
            dgvSuppliers.Columns[1].HeaderText = "Supplier Name";

            dgvSuppliers.ColumnHeadersDefaultCellStyle.Font
                = new Font("Segoe UI", 10, FontStyle.Bold);

            dgvSuppliers.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;
            //add column
            var modifyColumn = new DataGridViewButtonColumn()
            {
                UseColumnTextForButtonValue = true,
                HeaderText = "",
                Text = "Modify"
            };
            //adding it to the datagrid on my form after creating
            dgvSuppliers.Columns.Add(modifyColumn);

            var deleteColumn = new DataGridViewButtonColumn()
            {
                UseColumnTextForButtonValue = true,
                HeaderText = "",
                Text = "Delete"
            };
            //adding it to the datagrid on my form after creating
            dgvSuppliers.Columns.Add(deleteColumn);
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            frmMain secondpage = new frmMain();
            secondpage.ShowDialog();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var frmAddModifySupplier = new frmAddModifySupplier()
            {
                AddSupplier = true
            };
            DialogResult result = frmAddModifySupplier.ShowDialog();

            if (result == DialogResult.OK)// user clicked on Accept on the second form
            {
                try
                {
                    getSupplier = frmAddModifySupplier.Supplier;// record product from the second
                                                                // form as the current supplier
                    db.Suppliers.Add(getSupplier);

                    db.SaveChanges();
                    DisplaySuppliers();
                }
                catch (DbUpdateException ex)
                {
                    HandleDatabaseError(ex);
                }
                catch (Exception ex)
                {
                    HandleGeneralError(ex);
                }
            }
        }

        private void HandleGeneralError(Exception ex)
        {
            MessageBox.Show(ex.Message, ex.GetType().ToString());
        }

        private void HandleDatabaseError(DbUpdateException ex)
        {
            string errorMessage = "";
            var sqlException = (SqlException)ex.InnerException;
            foreach (SqlError error in sqlException.Errors)
            {
                errorMessage += "ERROR CODE:  " + error.Number + " " +
                                error.Message + "\n";
            }
            MessageBox.Show(errorMessage);
        }

        private void dgvSuppliers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            const int ModifyIndex = 2;
            const int DeleteIndex = 3;

            if (e.ColumnIndex == ModifyIndex || e.ColumnIndex == DeleteIndex)
            {
                int productCode = Convert.ToInt32(dgvSuppliers.Rows[e.RowIndex].Cells[0].Value.ToString().Trim());
                getSupplier = db.Suppliers.Find(productCode);
            }

            if (e.ColumnIndex == ModifyIndex)
            {
                ModiifySupplier();
            }
            else if (e.ColumnIndex == DeleteIndex)
            {
                DeleteSupplier();
            }
        }

        private void ModiifySupplier()
        {
            var frmAddModifySupplier = new frmAddModifySupplier()
            {
                AddSupplier = false,
                Supplier = getSupplier

            };
            DialogResult result = frmAddModifySupplier.ShowDialog();// display modal
            if (result == DialogResult.OK)// user clicked Accept on the second form
            {
                try
                {
                    getSupplier = frmAddModifySupplier.Supplier; // new data
                    db.SaveChanges();
                    DisplaySuppliers();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    HandleConcurrencyError(ex);
                }
                catch (DbUpdateException ex)
                {
                    HandleDatabaseError(ex);
                }
                catch (Exception ex)
                {
                    HandleGeneralError(ex);
                }
            }
            }

        private void DeleteSupplier()
        {
            DialogResult result =
                MessageBox.Show($"Are you sure you want to Delete {getSupplier.SupName.ToString().Trim()}?",
                "Confirm Delete", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.Yes)// user confirmed
            {
                try
                {
                    db.Suppliers.Remove(getSupplier);
                    db.SaveChanges(true);
                    DisplaySuppliers();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    HandleConcurrencyError(ex);
                }
                catch (DbUpdateException ex)
                {
                    HandleDatabaseError(ex);
                }
                catch (Exception ex)
                {
                    HandleGeneralError(ex);
                }




            }
        }

        private void HandleConcurrencyError(DbUpdateConcurrencyException ex)
        {
            ex.Entries.Single().Reload();

            var state = db.Entry(getSupplier).State;
            if (state == EntityState.Detached)
            {
                MessageBox.Show("Another user has deleted the supplier.",
                    "Concurrency Error");
            }
            else
            {
                string message = "Another user has updated that supplier.\n" +
                    "The current database values will be displayed.";
                MessageBox.Show(message, "Concurrency Error");
            }
            this.DisplaySuppliers();
        }

        
    }
}


       
    






 