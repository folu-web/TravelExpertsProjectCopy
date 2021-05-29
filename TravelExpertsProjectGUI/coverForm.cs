using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
/// <summary>
/// Author: Foluke Edafe
/// </summary>

namespace TravelExpertsProjectGUI
{
    public partial class coverForm : Form
    {
        public coverForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnWelcome_Click(object sender, EventArgs e)
        {
            frmMain secondpage = new frmMain();
            secondpage.ShowDialog();
            this.Close();
        }
    }
}
