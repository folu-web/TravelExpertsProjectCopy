using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TravelExpertsData;
/// <summary>
/// Author: Foluke Edafe
/// </summary>

namespace TravelExpertsProjectGUI
{
    public partial class frmProduct : Form
    {
        private TravelExpertsContext db = new TravelExpertsContext(); // creating a new database db object
        private Products getProduct; // product to appear on 
        public frmProduct()
        {
            InitializeComponent();
        }

       
        private void frmProduct_Load(object sender, EventArgs e)
        {
            DisplayProduct();

        }

        private void DisplayProduct()
        {
            dgvProducts.Columns.Clear();
            var products = db.Products.OrderBy(p => ProductName).Select
                 (p => new
                 {
                     p.ProductId,
                     p.ProdName
                 }).ToList();
            dgvProducts.DataSource = products;

            //column header format
            dgvProducts.Columns[0].HeaderText = "Product ID";
            dgvProducts.Columns[1].HeaderText = "Product Name";

            dgvProducts.ColumnHeadersDefaultCellStyle.Font
                = new Font("Arial", 12, FontStyle.Bold);
            dgvProducts.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvProducts.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dgvProducts.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;
            //add column
            var modifyColumn = new DataGridViewButtonColumn()
            {
                UseColumnTextForButtonValue = true,
                HeaderText = "",
                Text = "Modify"
            };
            //adding it to the datagrid on my form after creating
            dgvProducts.Columns.Add(modifyColumn);

            var deleteColumn = new DataGridViewButtonColumn()
            {
                UseColumnTextForButtonValue = true,
                HeaderText = "",
                Text = "Delete"
            };
            //adding it to the datagrid on my form after creating
            dgvProducts.Columns.Add(deleteColumn);
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var frmAddModifyProduct = new frmAddModifyProduct()
            {
                AddProduct = true
            };
            DialogResult result = frmAddModifyProduct.ShowDialog();

            if (result == DialogResult.OK)// user clicked on Accept on the second form
            {
                try
                {
                    getProduct = frmAddModifyProduct.Product;// record product from the second
                                                             // form as the current product
                    db.Products.Add(getProduct);
                   
                    db.SaveChanges();
                    DisplayProduct();
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

        

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            const int ModifyIndex = 2;
            const int DeleteIndex = 3;

            if(e.ColumnIndex == ModifyIndex || e.ColumnIndex == DeleteIndex)
            {
                int productCode = Convert.ToInt32(dgvProducts.Rows[e.RowIndex].Cells[0].Value.ToString().Trim());
                getProduct = db.Products.Find(productCode);
            }

            if (e.ColumnIndex == ModifyIndex)
            {
                ModiifyProduct();
            }
            else if (e.ColumnIndex == DeleteIndex)
            {
                DeleteProduct();
            }
        }

        private void DeleteProduct()
        {
            DialogResult result =
                MessageBox.Show($"Are you sure you want to Delete {getProduct.ProdName.ToString().Trim()}?",
                "Confirm Delete", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.Yes)// user confirmed
            {
                try
                {
                    db.Products.Remove(getProduct);
                    db.SaveChanges(true);
                    DisplayProduct();
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
        //this method is called anytime the column index is the modify index and this brings 
        //the addform out and allows for the modification on the form
        private void ModiifyProduct()
        {
            var frmAddModifyProduct = new frmAddModifyProduct()
            {
                AddProduct = false,
                Product = getProduct      

            };
            DialogResult result = frmAddModifyProduct.ShowDialog();// display modal
            if (result == DialogResult.OK)// user clicked Accept on the second form
            {
                try
                {
                    getProduct = frmAddModifyProduct.Product; // new data
                    db.SaveChanges();
                    DisplayProduct();
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

            var state = db.Entry(getProduct).State;
            if (state == EntityState.Detached)
            {
                MessageBox.Show("Another user has deleted that product.",
                    "Concurrency Error");
            }
            else
            {
                string message = "Another user has updated that product.\n" +
                    "The current database values will be displayed.";
                MessageBox.Show(message, "Concurrency Error");
            }
            this.DisplayProduct();
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

        private void HandleGeneralError(Exception ex)
        {
            MessageBox.Show(ex.Message, ex.GetType().ToString());
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            frmMain secondpage = new frmMain();
            secondpage.ShowDialog();
            this.Hide();
        }
    }


}
