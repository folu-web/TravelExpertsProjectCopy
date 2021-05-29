using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TravelExpertsData;
/// <summary>
/// Author: Foluke Edafe
/// </summary>

namespace TravelExpertsProjectGUI
{
    public partial class frmProductSuppliers : Form
    {
        private TravelExpertsContext db = new TravelExpertsContext();
        private ProductsSuppliers getProdSupplier;
        //List<Products> productList = TravelExpertsContext.db.Products();
        public frmProductSuppliers()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            frmMain secondpage = new frmMain();
            secondpage.ShowDialog();
        }

        private void frmProductSuppliers_Load(object sender, EventArgs e)
        {
            DisplayProductSuppliers();
        }

        private void DisplayProductSuppliers()
        {
            dgvProductSuppliers.Columns.Clear();
            var productSupplier = db.ProductsSuppliers.Select
                 (p => new
                 {
                     p.ProductSupplierId,
                     p.ProductId,                     
                     p.SupplierId
                 }).ToList();
            dgvProductSuppliers.DataSource = productSupplier;

            //column header format
            dgvProductSuppliers.Columns[0].HeaderText = "Product-SupplierID";
            dgvProductSuppliers.Columns[1].HeaderText = "Product ID";
            dgvProductSuppliers.Columns[2].HeaderText = "Supplier ID";

            dgvProductSuppliers.ColumnHeadersDefaultCellStyle.Font
                = new Font("Segoe UI", 10, FontStyle.Bold);

            dgvProductSuppliers.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;
            //add column
            var modifyColumn = new DataGridViewButtonColumn()
            {
                UseColumnTextForButtonValue = true,
                HeaderText = "",
                Text = "Modify"
            };
            //adding it to the datagrid on my form after creating
            dgvProductSuppliers.Columns.Add(modifyColumn);
        }

        private void dgvProductSuppliers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            const int ModifyIndex = 3;
            

            if (e.ColumnIndex == ModifyIndex)
            {
                int code = Convert.ToInt32(dgvProductSuppliers.Rows[e.RowIndex].Cells[0].Value.ToString().Trim());
                getProdSupplier = db.ProductsSuppliers.Find(code);
                ModifyProductSuppliers();
            }
        }

        private void ModifyProductSuppliers()
        {
            var frmAddModifyProductSuppliers = new frmAddModifyProductSuppliers()
            {
                AddProd = false,
                ProductSupplier = getProdSupplier

            };
            DialogResult result = frmAddModifyProductSuppliers.ShowDialog();// display modal
            if (result == DialogResult.OK)// user clicked Accept on the second form
            {
                try
                {
                    getProdSupplier = frmAddModifyProductSuppliers.ProductSupplier; // new data
                    db.SaveChanges();
                    DisplayProductSuppliers();
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

        //private void btnAdd_Click(object sender, EventArgs e)
        //{
        //    var frmAddModifyProductSuppliers = new frmAddModifyProductSuppliers()
        //    {
        //        AddProd = true
        //    };
        //    DialogResult result = frmAddModifyProductSuppliers.ShowDialog();

        //    if (result == DialogResult.OK)// user clicked on Accept on the second form
        //    {
        //        try
        //        {
        //            getProdSupplier = frmAddModifyProductSuppliers.ProductsSuppliers;// record product from the second
        //                                                                             // form as the current product
        //            db.ProductsSuppliers.Add(getProdSupplier);

        //            db.SaveChanges();
        //            DisplayProductSuppliers();
        //        }
        //        catch (DbUpdateException ex)
        //        {
        //            HandleDatabaseError(ex);
        //        }
        //        catch (Exception ex)
        //        {
        //            HandleGeneralError(ex);
        //        }
        //    }
        //}
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

        private void HandleGeneralError(Exception ex)
        {
            MessageBox.Show(ex.Message, ex.GetType().ToString());
        }
    }
}
