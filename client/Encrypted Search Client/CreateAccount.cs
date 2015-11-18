// CreateAccount.cs

// Author: Jimmy Swanbeck
// Endicott College
// 1/13/15

// This form will take input from the user for a username, password, and email,
// generate a salt (formula: [first half of email] + [first half of username]),
// and hash [password + salt] to generate a hashed password, then store everything
// in the database.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encrypted_Search_Client
{
    public partial class frmCreateAccount : Form
    {
        public frmCreateAccount()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text.IndexOf('@') != 1)
            {
                MessageBox.Show("Invalid email");
            }
            else
            {
                this.Close();
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            txtUsername.Text = txtUsername.Text.Trim(new char[] { ',' });
            txtUsername.Text = txtUsername.Text.Trim(new char[] { ' ' });
            txtUsername.Select(txtUsername.Text.Length, 0);
        }
    }
}
