// Login.cs

// Author: Jimmy Swanbeck
// Endicott College
// 1/13/15

// This form will take input from the user for a username and password,
// retrieve the stored username, password, and email from the database,
// generate a salt (formula: [first half of email] + [first half of username]),
// hash [password + salt], and match that against the stored password to
// verify that the user logged in successfully.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace Encrypted_Search_Client
{
    public partial class frmLogin : Form
    {
        TextBox loginName;
        Button loginButton;
        string connString = "server=10.45.17.128;port=3333;database=encrypted_search;uid=root;password=root";

        public frmLogin()
        {
            InitializeComponent();
        }

        public void setPointers(TextBox txtUsername, Button btnLogin)
        {
            loginName = txtUsername;
            loginButton = btnLogin;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                SHA512 sha512 = SHA512.Create();
                MySqlConnection conn = new MySqlConnection(connString);
                MySqlCommand command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM users WHERE username=\"" + txtUsername.Text + "\"";
                conn.Open();
                MySqlDataReader reader = command.ExecuteReader();
                reader.Read();

                string storedUsername = reader["username"].ToString();
                string storedPassword = reader["password"].ToString();
                string storedEmail = reader["email"].ToString();

                conn.Close();

                string data = storedEmail.Substring(0, storedEmail.Length/2) + storedUsername.Substring(0, storedUsername.Length/2);

                byte[] saltHashData = sha512.ComputeHash(Encoding.Default.GetBytes(data));
                StringBuilder salt = new StringBuilder();
                for (int i = 0; i < saltHashData.Length; i++)
                {
                    salt.Append(saltHashData[i].ToString("x2"));
                }
                byte[] passwordHashData = sha512.ComputeHash(Encoding.Default.GetBytes(txtPassword.Text + salt));
                StringBuilder hashedPw = new StringBuilder();
                for (int i = 0; i < passwordHashData.Length; i++)
                {
                    hashedPw.Append(passwordHashData[i].ToString("x2"));
                }

                if (hashedPw.ToString() == storedPassword)
                {
                    MessageBox.Show("Login successful: " + storedUsername);
                    loginName.Text = storedUsername;
                    
                    loginButton.Text = "Logout";
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Login failed: invalid password");
                    txtUsername.Clear();
                    txtPassword.Clear();
                    txtUsername.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login failed: username not found");
                txtUsername.Clear();
                txtPassword.Clear();
                txtUsername.Focus();
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
