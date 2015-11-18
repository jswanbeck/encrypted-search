// Main.cs

// Author: Jimmy Swanbeck
// Endicott College
// 1/12/15

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
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace Encrypted_Search_Client
{
    public struct Document
    {
        public int Id;
        public string Sender;
        public string Recipients;
        public string Subject;
        public string Body;
        public string SearchIndex;
        public string Timestamp;
        public int Encrypted;
        public Document(int id, string sender, string recipients, string subject, string body, string searchIndex, string timestamp, int encrypted)
        {
            Id = id;
            Sender = sender;
            Recipients = recipients;
            Subject = subject;
            Body = body;
            SearchIndex = searchIndex;
            Timestamp = timestamp;
            Encrypted = encrypted;
        }
    }

    public struct DataItem
    {
        public int Key;
        public string Value;
        public DataItem(int key, string value)
        {
            Key = key;
            Value = value;
        }
    }

    public partial class frmMain : Form
    {
        static readonly string PasswordHash = "3nD!c0++";
        static readonly string SaltKey = "C0mP_$c!";
        static readonly string VIKey = "@1B2c3D4e5F6g7H8";

        string connString = "server=10.128.138.231;port=3333;database=encrypted_search;uid=root";

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            txtRecipients.Focus();
        }

        private void Clear()
        {
            txtRecipients.Clear();
            txtSubject.Clear();
            txtSearch.Clear();
            rtbSearchBody.Clear();
            rtbStoreBody.Clear();
            lstDocuments.Items.Clear();
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            frmCreateAccount createAccountPrompt = new frmCreateAccount();
            createAccountPrompt.Show();
            txtUsername.Text = "";
            btnLogin.Text = "Logout";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "<Not logged in>")
            {
                frmLogin loginPrompt = new frmLogin();
                loginPrompt.setPointers(txtUsername, btnLogin);
                loginPrompt.Show();
            }
            else
            {
                txtUsername.Text = "<Not logged in>";
                btnLogin.Text = "Login";
            }
        }

        private void btnStore_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            if (username == "<Not logged in>")
            {
                username = "anonymous";
            }
            string[] tmpRecipients = txtRecipients.Text.Split(' ');
            string recipients = "";
            foreach (string tmpRecipient in tmpRecipients)
            {
                recipients += tmpRecipient + " ";
            }
            recipients = recipients.Trim();
            string search_index = Generate_Search_Index(recipients + " " + txtSubject.Text + " " + rtbStoreBody.Text, false);
            string subject = Encrypt(txtSubject.Text);
            string body = Encrypt(rtbStoreBody.Text);
            string date_created = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            bool confirmation = false;

            if (txtRecipients.Text != "")
            {
                if (txtSubject.Text == "")
                {
                    if (rtbStoreBody.Text == "")
                    {
                        confirmation = MessageBox.Show("Send message without a subject or body?", "Confirm Store", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK;
                    }
                    else
                    {
                        confirmation = MessageBox.Show("Send message without a subject?", "Confirm Store", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK;
                    }
                }
                else if (rtbStoreBody.Text == "")
                {
                    confirmation = MessageBox.Show("Send message without a body?", "Confirm Store", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK;
                }
                else
                {
                    confirmation = true;
                }

                if (confirmation)
                {
                    try
                    {
                        MySqlConnection conn = new MySqlConnection(connString);
                        MySqlCommand command = conn.CreateCommand();
                        command.CommandText = "INSERT INTO documents (sender, recipients, subject, body, search_index, date_created, encrypted) values(\"" + username + "\",\"" + recipients + "\",\"" + subject + "\",\"" + body + "\",\"" + search_index + "\",\"" + date_created + "\",\"1\")";
                        conn.Open();
                        command.ExecuteNonQuery();
                        conn.Close();

                        Clear();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter at least one recipient.");
            }
        }

        private static string Generate_Search_Index(string text, bool searching)
        {
            Regex rgx = new Regex("[^a-zA-Z ]");
            string[] index = rgx.Replace(text.ToUpper(), "").Split(' ');
            string[] tempIndex = new string[index.Length];

            for (int i = 0; i < index.Length; i++)
            {
                foreach (string word in tempIndex)
                {
                    if (word == index[i])
                    {
                        index[i] = "";
                    }
                }
                tempIndex[i] = index[i];
                if (index[i].Length < 3)
                {
                    index[i] = "";
                }
            }

            string[] indexAdd = index.Concat(wildcardAdd(index)).ToArray();
            index = indexAdd.Concat(wildcardReplace(index)).ToArray();

            string search_index = "";
            foreach (string word in index)
            {
                if (!string.IsNullOrEmpty(word))
                {
                    string hashedWord = Hash_String(word);
                    if (searching)
                    {
                        search_index += word + " ";
                    }
                    search_index += hashedWord + " ";
                }
            }

            return search_index.Trim();
        }

        private static string Hash_String(string word)
        {
            SHA512 sha512 = SHA512.Create();
            byte[] data = sha512.ComputeHash(Encoding.Default.GetBytes(word));
            StringBuilder hashedWord = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                hashedWord.Append(data[i].ToString("x2"));
            }
            return hashedWord.ToString();
        }

        private void txtRecipients_TextChanged(object sender, EventArgs e)
        {
            txtRecipients.Text = txtRecipients.Text.Trim(new char[] {','});
            txtRecipients.Select(txtRecipients.Text.Length, 0);
        }

        private void tabSearch_Click(object sender, EventArgs e)
        {
            if (this.AcceptButton == btnStore)
            {
                this.AcceptButton = btnSearch;
            }
            else
            {
                this.AcceptButton = btnStore;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lstDocuments.Items.Clear();
            rtbSearchBody.Clear();
            string username = txtUsername.Text;
            if (username == "<Not logged in>")
            {
                username = "anonymous";
            }

            string[] searchTerms = Generate_Search_Index(txtSearch.Text, true).Split(' ');
            try
            {
                MySqlConnection conn = new MySqlConnection(connString);
                MySqlCommand command = conn.CreateCommand();
                conn.Open();
                command.CommandText = "SELECT COUNT(*) FROM documents";
                MySqlDataReader dr = command.ExecuteReader();
                dr.Read();
                Document[] documents = new Document[Convert.ToInt32(dr["COUNT(*)"])];
                dr.Close();
                command.CommandText = "SELECT * FROM documents ORDER BY date_created DESC";
                dr = command.ExecuteReader();
                int j = 0;
                while (dr.Read())
                {
                    bool isAllowed = Get_Permissions(username, dr);
                    if (isAllowed)
                    {
                        documents[j] = new Document(Convert.ToInt32(dr["id"]), dr["sender"].ToString(), dr["recipients"].ToString(), dr["subject"].ToString(), dr["body"].ToString(), dr["search_index"].ToString(), dr["date_created"].ToString(), Convert.ToInt32(dr["encrypted"]));
                        if (string.IsNullOrEmpty(documents[j].Subject))
                        {
                            documents[j].Subject = "<No Subject>";
                        }
                        j++;
                    }
                }
                conn.Close();

                if (!string.IsNullOrEmpty(searchTerms[0]))
                {
                    for (int i = 0; i < documents.Length; i++)
                    {
                        bool loopAgain = true;
                        foreach (string searchTerm in searchTerms)
                        {
                            if (loopAgain)
                            {
                                foreach (string word in documents[i].SearchIndex.Split(' '))
                                {
                                    if (word == searchTerm)
                                    {
                                        Append_Document(username, documents, i);
                                        loopAgain = false;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < documents.Length; i++)
                    {
                        if (documents[i].Id != 0)
                        {
                            Append_Document(username, documents, i);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            txtSearch.Clear();
        }

        private static bool Get_Permissions(string username, MySqlDataReader dr)
        {
            bool isAllowed = (dr["sender"].ToString() == username);
            if (!isAllowed)
            {
                string[] recipients = dr["recipients"].ToString().Split(' ');
                foreach (string recipient in recipients)
                {
                    if (username == recipient)
                    {
                        isAllowed = true;
                    }
                }
            }
            return isAllowed;
        }

        private void Append_Document(string username, Document[] documents, int i)
        {
            string preSubject = "";
            string recipients = string.Join(", ", documents[i].Recipients.Split(' '));
            if (documents[i].Sender == username)
            {
                preSubject = "To [" + recipients + "]";
            }
            else
            {
                preSubject = "From [" + documents[i].Sender + "]";
            }

            if (documents[i].Encrypted == 1)
            {
                lstDocuments.Items.Add(new KeyValuePair<int, string>(documents[i].Id, preSubject + ": " + Decrypt(documents[i].Subject)));
            }
            else
            {
                lstDocuments.Items.Add(new KeyValuePair<int, string>(documents[i].Id, preSubject + ": " + documents[i].Subject));
            }
        }

        private void lstDocuments_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                KeyValuePair<int, string> kvp = (KeyValuePair<int, string>)lstDocuments.SelectedItem;

                MySqlConnection conn = new MySqlConnection(connString);
                MySqlCommand command = conn.CreateCommand();
                conn.Open();
                command.CommandText = "SELECT * FROM documents WHERE id='" + kvp.Key + "'";
                MySqlDataReader dr = command.ExecuteReader();
                dr.Read();
                Document doc = new Document(Convert.ToInt32(dr["id"]), dr["sender"].ToString(), dr["recipients"].ToString(), dr["subject"].ToString(), dr["body"].ToString(), dr["search_index"].ToString(), dr["date_created"].ToString(), Convert.ToInt32(dr["encrypted"]));
                dr.Close();
                doc.Recipients = string.Join(", ", doc.Recipients.Split(' '));
                if (string.IsNullOrEmpty(doc.Subject))
                {
                    doc.Subject = "<No Subject>";
                }

                string fullText = "";
                if (doc.Sender == txtUsername.Text)
                {
                    fullText = "From [" + txtUsername.Text + "]";
                }
                else
                {
                    fullText = "To [" + doc.Recipients + "]";
                }

                if (doc.Encrypted == 1)
                {
                    fullText += " on " + doc.Timestamp + "\nEncrypted: True\nSubject: " + Decrypt(doc.Subject) + "\n\n" + Decrypt(doc.Body);
                }
                else
                {
                    fullText += " on " + doc.Timestamp + "\nEncrypted: False\nSubject: " + doc.Subject + "\n\n" + doc.Body;
                }
                rtbSearchBody.Text = fullText;

                conn.Close();
            }
            catch
            {

            }
        }

        private void rtbSearchBody_Click(object sender, EventArgs e)
        {
            lstDocuments.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            KeyValuePair<int, string> kvp = (KeyValuePair<int, string>)lstDocuments.SelectedItem;

            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand command = conn.CreateCommand();
            conn.Open();
            command.CommandText = "DELETE FROM documents WHERE id='" + kvp.Key + "'";
            command.ExecuteNonQuery();
            conn.Close();

            lstDocuments.Items.RemoveAt(lstDocuments.SelectedIndex);
            rtbSearchBody.Clear();
        }

        public static string Encrypt(string plainText)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
            var encryptor = symmetricKey.CreateEncryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));

            byte[] cipherTextBytes;

            using (var memoryStream = new System.IO.MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                    cryptoStream.FlushFinalBlock();
                    cipherTextBytes = memoryStream.ToArray();
                    cryptoStream.Close();
                }
                memoryStream.Close();
            }
            return Convert.ToBase64String(cipherTextBytes);
        }

        public static string Decrypt(string encryptedText)
        {
            byte[] cipherTextBytes = Convert.FromBase64String(encryptedText);
            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.None };

            var decryptor = symmetricKey.CreateDecryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));
            var memoryStream = new System.IO.MemoryStream(cipherTextBytes);
            var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];

            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray());
        }

        private static string[] wildcardReplace(string[] input)
        {
            int length = 0; // Size of the array

            // Calculate the size of the array:
            // There will be one new word for each letter in the input, so the
            // array will contain one slot (each slot containing one string) for
            // each character in the input
            foreach (string item in input)
            {
                if (item != "")
                {
                    length += item.Length;
                }
            }

            string[] returnArr = new string[length];    // Will contain the wildcard index terms for character replacement
            int prevLength = 0;     // Contains the length of the previous word in the index (used to navigate through the array)
            foreach (string item in input)
            {
                if (item != "")
                {
                    for (int i = 0; i < item.Length; i++)
                    {
                        // Convert one item in the input to a character array,
                        // replace one character with an asterisk, then convert
                        // it back into a string and insert in into returnArr
                        char[] temp = item.ToCharArray();
                        temp[i] = '*';
                        foreach (char character in temp)
                        {
                            returnArr[i + prevLength] += character;
                        }
                    }
                }

                prevLength += item.Length;  // Increment prevLength by the length of the previous item
            }

            return returnArr;
        }

        private static string[] wildcardAdd(string[] input)
        {
            int length = 1;
            foreach (string item in input)
            {
                if (item != "")
                {
                    length += item.Length + 1;
                }
            }

            string[] returnArr = new string[length - 1];
            int prevLength = 0;
            foreach (string item in input)
            {
                if (item != "")
                {
                    for (int i = 0; i < item.Length; i++)
                    {
                        char[] itemArr = item.ToCharArray();
                        string[] temp = new string[item.Length + 1];
                        bool atAddPosition = false;
                        for (int j = 0; j < item.Length + 1; j++)
                        {
                            if (j != i)
                            {
                                if (atAddPosition == true)
                                {
                                    temp[j] = itemArr[j - 1].ToString();
                                }
                                else
                                {
                                    temp[j] = itemArr[j].ToString();
                                }
                            }
                            else
                            {
                                atAddPosition = true;
                            }
                        }
                        temp[i] = "*";
                        foreach (string character in temp)
                        {
                            returnArr[i + prevLength] += character;
                        }
                    }
                    char[] charArr = returnArr[prevLength].ToCharArray();
                    for (int i = 0; i < charArr.Length; i++)
                    {
                        if (i != charArr.Length - 1)
                        {
                            charArr[i] = charArr[i + 1];
                        }
                        else
                        {
                            charArr[i] = '*';
                        }
                    }
                    foreach (char character in charArr)
                    {
                        returnArr[item.Length + prevLength] += character;
                    }

                    prevLength += item.Length + 1;
                }
            }

            return returnArr;
        }
    }
}
