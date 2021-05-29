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
    public partial class frmAddModifyPackage : Form
    {
        public Packages package; // main form will set the product for the second form
        public bool isAdd; // main form will set isAdd for second form, isAdd = true means add product

        public frmAddModifyPackage()
        {
            InitializeComponent();
        }

        private void frmAddModifyPackage_Load(object sender, EventArgs e)
        {
            // is it Add  or modify
            if (this.isAdd) // Add
            {
                this.Text = "Add Package";
            }
            else // Modify
            {
                this.Text = "Modify Package";
                // display product data
                txtPkgId.Text = package.PackageId.ToString();
                txtName.Text = package.PkgName;
                dtpStartDate.Value = package.PkgStartDate.Value;
                dtpEndDate.Value = package.PkgEndDate.Value;
                txtDesc.Text = package.PkgDesc;
                txtPrice.Text = package.PkgBasePrice.ToString();
                txtCommission.Text = package.PkgAgencyCommission.ToString();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (Validator.IsPresent(txtName, "Package Name") &&
                Validator.NotEarlierThanToday(dtpStartDate.Value, "Package Start Date") &&
                Validator.NotEarlierThanToday(dtpEndDate.Value, "Package End Date") &&
                Validator.IsPresent(txtDesc, "Package Description") &&
                Validator.IsPresent(txtPrice, "Package Base Price") &&
                Validator.IsNonNegativeDecimal(txtPrice, "Package Base Price") &&
                Validator.IsPresent(txtCommission, "Package Agency Commission") &&
                Validator.IsNonNegativeDecimal(txtCommission, "Package Agency Commission") &&
                EndDateValidateor(dtpEndDate, dtpStartDate) &&
                CommisionLessThanBasePrice(txtPrice, txtCommission)
               )
            {

                if (isAdd)
                {
                    package = new Packages();

                    // load customer data
                    //package.PackageId = Convert.ToInt32(txtPkgId.Text); //Auto generate from system
                    package.PkgName = txtName.Text;
                    package.PkgStartDate = dtpStartDate.Value;
                    package.PkgEndDate = dtpEndDate.Value;
                    package.PkgDesc = txtDesc.Text;
                    package.PkgBasePrice = Convert.ToDecimal(txtPrice.Text);
                    package.PkgAgencyCommission = Convert.ToDecimal(txtCommission.Text);
                    this.DialogResult = DialogResult.OK;
                }

                else // if modify, the Package object is alredy there
                {
                    //load customer data
                    package.PackageId = Convert.ToInt32(txtPkgId.Text);
                    package.PkgName = txtName.Text;
                    package.PkgStartDate = dtpStartDate.Value;
                    package.PkgEndDate = dtpEndDate.Value;
                    package.PkgDesc = txtDesc.Text;
                    package.PkgBasePrice = Convert.ToDecimal(txtPrice.Text);
                    package.PkgAgencyCommission = Convert.ToDecimal(txtCommission.Text);

                    this.DialogResult = DialogResult.OK;
                }
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Validator confirm package end date is later than start date
        /// </summary>
        /// <param name="endDate"></param> package end date DateTimePicker
        /// <param name="startDate"></param> package start date DateTimePicker
        /// <returns>true if valid, and false if not</returns>
        private static bool EndDateValidateor(DateTimePicker endDate, DateTimePicker startDate)
        {
            bool isValid = true; // "innocent until proven guilty"
            if (endDate.Value < startDate.Value) //end date is earlier than start date
            {
                isValid = false;
                MessageBox.Show("Package end date cannot be earlier than package start date.");
            }
            return isValid;
        }

        /// <summary>
        /// Validator confirm commission is less than package base price
        /// </summary>
        /// <param name="basePrice"></param> package base price textbox
        /// <param name="commission"></param> package agent commission textbox
        /// <returns>true if valid, and false if not</returns>
        private static bool CommisionLessThanBasePrice(TextBox basePrice, TextBox commission)
        {
            bool isValid = true; // "innocent until proven guilty"
            if (Convert.ToInt32(commission.Text) > Convert.ToInt32(basePrice.Text)) //commission is larger than basePrice
            {
                isValid = false;
                MessageBox.Show("Commission cannot be larger than the Package Base Price.");
                commission.SelectAll();
                commission.Focus();
            }
            return isValid;
        }
    }
}
