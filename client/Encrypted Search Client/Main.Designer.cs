namespace Encrypted_Search_Client
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tabSearch = new System.Windows.Forms.TabControl();
            this.tabStore = new System.Windows.Forms.TabPage();
            this.btnStore = new System.Windows.Forms.Button();
            this.rtbStoreBody = new System.Windows.Forms.RichTextBox();
            this.lblSubject = new System.Windows.Forms.Label();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.lblRecipients = new System.Windows.Forms.Label();
            this.txtRecipients = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lstDocuments = new System.Windows.Forms.ListBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.rtbSearchBody = new System.Windows.Forms.RichTextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblIntroduction = new System.Windows.Forms.Label();
            this.lblStore = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.lblDivider2 = new System.Windows.Forms.Label();
            this.lblDivider1 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnCreateAccount = new System.Windows.Forms.Button();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblStoreBold = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabSearch.SuspendLayout();
            this.tabStore.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabSearch
            // 
            this.tabSearch.Controls.Add(this.tabStore);
            this.tabSearch.Controls.Add(this.tabPage2);
            this.tabSearch.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabSearch.Location = new System.Drawing.Point(455, 13);
            this.tabSearch.Name = "tabSearch";
            this.tabSearch.SelectedIndex = 0;
            this.tabSearch.Size = new System.Drawing.Size(583, 590);
            this.tabSearch.TabIndex = 0;
            this.tabSearch.Click += new System.EventHandler(this.tabSearch_Click);
            // 
            // tabStore
            // 
            this.tabStore.Controls.Add(this.btnStore);
            this.tabStore.Controls.Add(this.rtbStoreBody);
            this.tabStore.Controls.Add(this.lblSubject);
            this.tabStore.Controls.Add(this.txtSubject);
            this.tabStore.Controls.Add(this.lblRecipients);
            this.tabStore.Controls.Add(this.txtRecipients);
            this.tabStore.Location = new System.Drawing.Point(4, 30);
            this.tabStore.Name = "tabStore";
            this.tabStore.Padding = new System.Windows.Forms.Padding(3);
            this.tabStore.Size = new System.Drawing.Size(575, 556);
            this.tabStore.TabIndex = 0;
            this.tabStore.Text = "Store Documents";
            this.tabStore.UseVisualStyleBackColor = true;
            // 
            // btnStore
            // 
            this.btnStore.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnStore.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnStore.Location = new System.Drawing.Point(6, 520);
            this.btnStore.Name = "btnStore";
            this.btnStore.Size = new System.Drawing.Size(103, 30);
            this.btnStore.TabIndex = 3;
            this.btnStore.Text = "Store";
            this.btnStore.UseVisualStyleBackColor = true;
            this.btnStore.Click += new System.EventHandler(this.btnStore_Click);
            // 
            // rtbStoreBody
            // 
            this.rtbStoreBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbStoreBody.Location = new System.Drawing.Point(6, 80);
            this.rtbStoreBody.Name = "rtbStoreBody";
            this.rtbStoreBody.Size = new System.Drawing.Size(563, 434);
            this.rtbStoreBody.TabIndex = 2;
            this.rtbStoreBody.Text = "";
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubject.Location = new System.Drawing.Point(6, 46);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(64, 21);
            this.lblSubject.TabIndex = 3;
            this.lblSubject.Text = "Subject:";
            // 
            // txtSubject
            // 
            this.txtSubject.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSubject.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubject.Location = new System.Drawing.Point(103, 43);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(466, 28);
            this.txtSubject.TabIndex = 1;
            // 
            // lblRecipients
            // 
            this.lblRecipients.AutoSize = true;
            this.lblRecipients.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecipients.Location = new System.Drawing.Point(6, 10);
            this.lblRecipients.Name = "lblRecipients";
            this.lblRecipients.Size = new System.Drawing.Size(84, 21);
            this.lblRecipients.TabIndex = 1;
            this.lblRecipients.Text = "Recipients:";
            // 
            // txtRecipients
            // 
            this.txtRecipients.BackColor = System.Drawing.SystemColors.Window;
            this.txtRecipients.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRecipients.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecipients.Location = new System.Drawing.Point(103, 6);
            this.txtRecipients.Name = "txtRecipients";
            this.txtRecipients.Size = new System.Drawing.Size(466, 28);
            this.txtRecipients.TabIndex = 0;
            this.txtRecipients.TextChanged += new System.EventHandler(this.txtRecipients_TextChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lstDocuments);
            this.tabPage2.Controls.Add(this.txtSearch);
            this.tabPage2.Controls.Add(this.btnSearch);
            this.tabPage2.Controls.Add(this.btnDelete);
            this.tabPage2.Controls.Add(this.rtbSearchBody);
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(575, 556);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Search Documents";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lstDocuments
            // 
            this.lstDocuments.DisplayMember = "Value";
            this.lstDocuments.FormattingEnabled = true;
            this.lstDocuments.ItemHeight = 21;
            this.lstDocuments.Location = new System.Drawing.Point(6, 6);
            this.lstDocuments.Name = "lstDocuments";
            this.lstDocuments.Size = new System.Drawing.Size(562, 109);
            this.lstDocuments.TabIndex = 14;
            this.lstDocuments.ValueMember = "Key";
            this.lstDocuments.SelectedIndexChanged += new System.EventHandler(this.lstDocuments_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Location = new System.Drawing.Point(224, 522);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(345, 28);
            this.txtSearch.TabIndex = 13;
            // 
            // btnSearch
            // 
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSearch.Location = new System.Drawing.Point(115, 520);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(103, 30);
            this.btnSearch.TabIndex = 12;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDelete.Location = new System.Drawing.Point(6, 520);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(103, 30);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // rtbSearchBody
            // 
            this.rtbSearchBody.BackColor = System.Drawing.SystemColors.Window;
            this.rtbSearchBody.Cursor = System.Windows.Forms.Cursors.Default;
            this.rtbSearchBody.Location = new System.Drawing.Point(6, 130);
            this.rtbSearchBody.Name = "rtbSearchBody";
            this.rtbSearchBody.ReadOnly = true;
            this.rtbSearchBody.Size = new System.Drawing.Size(563, 384);
            this.rtbSearchBody.TabIndex = 10;
            this.rtbSearchBody.Text = "";
            this.rtbSearchBody.Click += new System.EventHandler(this.rtbSearchBody_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Tai Le", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(44, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(351, 55);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Encrypted Search";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitle.Location = new System.Drawing.Point(90, 68);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(260, 18);
            this.lblSubtitle.TabIndex = 2;
            this.lblSubtitle.Text = "Jimmy Swanbeck - Endicott College 2015";
            // 
            // lblIntroduction
            // 
            this.lblIntroduction.AutoSize = true;
            this.lblIntroduction.Font = new System.Drawing.Font("Microsoft Tai Le", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIntroduction.Location = new System.Drawing.Point(12, 118);
            this.lblIntroduction.MaximumSize = new System.Drawing.Size(430, 0);
            this.lblIntroduction.Name = "lblIntroduction";
            this.lblIntroduction.Size = new System.Drawing.Size(430, 133);
            this.lblIntroduction.TabIndex = 3;
            this.lblIntroduction.Text = resources.GetString("lblIntroduction.Text");
            // 
            // lblStore
            // 
            this.lblStore.AutoSize = true;
            this.lblStore.Font = new System.Drawing.Font("Microsoft Tai Le", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStore.Location = new System.Drawing.Point(25, 275);
            this.lblStore.MaximumSize = new System.Drawing.Size(420, 0);
            this.lblStore.Name = "lblStore";
            this.lblStore.Size = new System.Drawing.Size(419, 133);
            this.lblStore.TabIndex = 4;
            this.lblStore.Text = resources.GetString("lblStore.Text");
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Microsoft Tai Le", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(22, 417);
            this.lblSearch.MaximumSize = new System.Drawing.Size(420, 0);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(418, 133);
            this.lblSearch.TabIndex = 5;
            this.lblSearch.Text = resources.GetString("lblSearch.Text");
            // 
            // lblDivider2
            // 
            this.lblDivider2.AutoSize = true;
            this.lblDivider2.Font = new System.Drawing.Font("Microsoft Tai Le", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDivider2.Location = new System.Drawing.Point(12, 247);
            this.lblDivider2.MaximumSize = new System.Drawing.Size(430, 0);
            this.lblDivider2.Name = "lblDivider2";
            this.lblDivider2.Size = new System.Drawing.Size(429, 19);
            this.lblDivider2.TabIndex = 6;
            this.lblDivider2.Text = "______________________________________________________________________";
            // 
            // lblDivider1
            // 
            this.lblDivider1.AutoSize = true;
            this.lblDivider1.Font = new System.Drawing.Font("Microsoft Tai Le", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDivider1.Location = new System.Drawing.Point(12, 91);
            this.lblDivider1.MaximumSize = new System.Drawing.Size(430, 0);
            this.lblDivider1.Name = "lblDivider1";
            this.lblDivider1.Size = new System.Drawing.Size(429, 19);
            this.lblDivider1.TabIndex = 7;
            this.lblDivider1.Text = "______________________________________________________________________";
            // 
            // btnLogin
            // 
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Tai Le", 12F);
            this.btnLogin.Location = new System.Drawing.Point(157, 573);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(103, 30);
            this.btnLogin.TabIndex = 6;
            this.btnLogin.Text = "&Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnCreateAccount
            // 
            this.btnCreateAccount.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCreateAccount.Font = new System.Drawing.Font("Microsoft Tai Le", 12F);
            this.btnCreateAccount.Location = new System.Drawing.Point(266, 573);
            this.btnCreateAccount.Name = "btnCreateAccount";
            this.btnCreateAccount.Size = new System.Drawing.Size(175, 30);
            this.btnCreateAccount.TabIndex = 8;
            this.btnCreateAccount.Text = "&Create Account";
            this.btnCreateAccount.UseVisualStyleBackColor = true;
            this.btnCreateAccount.Click += new System.EventHandler(this.btnCreateAccount_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.SystemColors.Control;
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsername.Font = new System.Drawing.Font("Microsoft Tai Le", 12F);
            this.txtUsername.Location = new System.Drawing.Point(12, 578);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.ReadOnly = true;
            this.txtUsername.Size = new System.Drawing.Size(139, 21);
            this.txtUsername.TabIndex = 9;
            this.txtUsername.Text = "<Not logged in>";
            this.txtUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblStoreBold
            // 
            this.lblStoreBold.AutoSize = true;
            this.lblStoreBold.Font = new System.Drawing.Font("Microsoft Tai Le", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStoreBold.Location = new System.Drawing.Point(12, 275);
            this.lblStoreBold.MaximumSize = new System.Drawing.Size(430, 0);
            this.lblStoreBold.Name = "lblStoreBold";
            this.lblStoreBold.Size = new System.Drawing.Size(134, 19);
            this.lblStoreBold.TabIndex = 10;
            this.lblStoreBold.Text = "Store Documents:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 417);
            this.label1.MaximumSize = new System.Drawing.Size(430, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 19);
            this.label1.TabIndex = 11;
            this.label1.Text = "Search Documents:";
            // 
            // frmMain
            // 
            this.AcceptButton = this.btnStore;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 615);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblStoreBold);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.btnCreateAccount);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblDivider1);
            this.Controls.Add(this.lblDivider2);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.lblStore);
            this.Controls.Add(this.lblIntroduction);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.tabSearch);
            this.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximumSize = new System.Drawing.Size(1066, 653);
            this.MinimumSize = new System.Drawing.Size(1066, 653);
            this.Name = "frmMain";
            this.Text = "Encrypted Search Client";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tabSearch.ResumeLayout(false);
            this.tabStore.ResumeLayout(false);
            this.tabStore.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabSearch;
        private System.Windows.Forms.TabPage tabStore;
        private System.Windows.Forms.Label lblRecipients;
        private System.Windows.Forms.TextBox txtRecipients;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.Button btnStore;
        private System.Windows.Forms.RichTextBox rtbStoreBody;
        private System.Windows.Forms.ListBox lstDocuments;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.RichTextBox rtbSearchBody;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblIntroduction;
        private System.Windows.Forms.Label lblStore;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Label lblDivider2;
        private System.Windows.Forms.Label lblDivider1;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnCreateAccount;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblStoreBold;
        private System.Windows.Forms.Label label1;
    }
}

