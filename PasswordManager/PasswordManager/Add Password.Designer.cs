namespace PasswordManager
{
    partial class Add_Password_Form
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
            this.textBoxWebService = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxNote = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.ShowPasswordButton = new System.Windows.Forms.Label();
            this.CopyPasswordToClipboard = new System.Windows.Forms.Label();
            this.labelExpiryDate = new System.Windows.Forms.Label();
            this.dateTimePickerExpiryDate = new System.Windows.Forms.DateTimePicker();
            this.CheckBoxExpire = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxPincode = new System.Windows.Forms.TextBox();
            this.buttonConfigurePassword = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxWebService
            // 
            this.textBoxWebService.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxWebService.Location = new System.Drawing.Point(130, 8);
            this.textBoxWebService.Name = "textBoxWebService";
            this.textBoxWebService.Size = new System.Drawing.Size(336, 20);
            this.textBoxWebService.TabIndex = 0;
            this.textBoxWebService.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Web service";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Email";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 221);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Note";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxEmail.Location = new System.Drawing.Point(130, 38);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(336, 20);
            this.textBoxEmail.TabIndex = 5;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPassword.Location = new System.Drawing.Point(130, 68);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(301, 20);
            this.textBoxPassword.TabIndex = 6;
            this.textBoxPassword.UseSystemPasswordChar = true;
            this.textBoxPassword.TextChanged += new System.EventHandler(this.textBoxPassword_TextChanged);
            // 
            // textBoxNote
            // 
            this.textBoxNote.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNote.Location = new System.Drawing.Point(127, 221);
            this.textBoxNote.Multiline = true;
            this.textBoxNote.Name = "textBoxNote";
            this.textBoxNote.Size = new System.Drawing.Size(339, 173);
            this.textBoxNote.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(391, 411);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ShowPasswordButton
            // 
            this.ShowPasswordButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ShowPasswordButton.AutoSize = true;
            this.ShowPasswordButton.Location = new System.Drawing.Point(433, 64);
            this.ShowPasswordButton.Name = "ShowPasswordButton";
            this.ShowPasswordButton.Size = new System.Drawing.Size(34, 13);
            this.ShowPasswordButton.TabIndex = 10;
            this.ShowPasswordButton.Text = "Show";
            this.ShowPasswordButton.Click += new System.EventHandler(this.ShowPasswordButton_Click);
            // 
            // CopyPasswordToClipboard
            // 
            this.CopyPasswordToClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CopyPasswordToClipboard.AutoSize = true;
            this.CopyPasswordToClipboard.Location = new System.Drawing.Point(434, 81);
            this.CopyPasswordToClipboard.Name = "CopyPasswordToClipboard";
            this.CopyPasswordToClipboard.Size = new System.Drawing.Size(31, 13);
            this.CopyPasswordToClipboard.TabIndex = 11;
            this.CopyPasswordToClipboard.Text = "Copy";
            this.CopyPasswordToClipboard.Click += new System.EventHandler(this.CopyPasswordToClipboard_Click);
            // 
            // labelExpiryDate
            // 
            this.labelExpiryDate.AutoSize = true;
            this.labelExpiryDate.Location = new System.Drawing.Point(9, 184);
            this.labelExpiryDate.Name = "labelExpiryDate";
            this.labelExpiryDate.Size = new System.Drawing.Size(59, 13);
            this.labelExpiryDate.TabIndex = 12;
            this.labelExpiryDate.Text = "Expiry date";
            // 
            // dateTimePickerExpiryDate
            // 
            this.dateTimePickerExpiryDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePickerExpiryDate.Enabled = false;
            this.dateTimePickerExpiryDate.Location = new System.Drawing.Point(154, 184);
            this.dateTimePickerExpiryDate.Name = "dateTimePickerExpiryDate";
            this.dateTimePickerExpiryDate.Size = new System.Drawing.Size(312, 20);
            this.dateTimePickerExpiryDate.TabIndex = 13;
            // 
            // CheckBoxExpire
            // 
            this.CheckBoxExpire.AutoSize = true;
            this.CheckBoxExpire.Location = new System.Drawing.Point(124, 187);
            this.CheckBoxExpire.Name = "CheckBoxExpire";
            this.CheckBoxExpire.Size = new System.Drawing.Size(15, 14);
            this.CheckBoxExpire.TabIndex = 14;
            this.CheckBoxExpire.UseVisualStyleBackColor = true;
            this.CheckBoxExpire.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 151);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 13);
            this.label11.TabIndex = 15;
            this.label11.Text = "Pincode";
            // 
            // textBoxPincode
            // 
            this.textBoxPincode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPincode.Location = new System.Drawing.Point(130, 151);
            this.textBoxPincode.Name = "textBoxPincode";
            this.textBoxPincode.Size = new System.Drawing.Size(336, 20);
            this.textBoxPincode.TabIndex = 16;
            // 
            // buttonConfigurePassword
            // 
            this.buttonConfigurePassword.Location = new System.Drawing.Point(130, 108);
            this.buttonConfigurePassword.Name = "buttonConfigurePassword";
            this.buttonConfigurePassword.Size = new System.Drawing.Size(336, 23);
            this.buttonConfigurePassword.TabIndex = 17;
            this.buttonConfigurePassword.Text = "Configure password";
            this.buttonConfigurePassword.UseVisualStyleBackColor = true;
            this.buttonConfigurePassword.Click += new System.EventHandler(this.buttonConfigurePassword_Click);
            // 
            // Add_Password_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 446);
            this.Controls.Add(this.buttonConfigurePassword);
            this.Controls.Add(this.textBoxPincode);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.CheckBoxExpire);
            this.Controls.Add(this.dateTimePickerExpiryDate);
            this.Controls.Add(this.labelExpiryDate);
            this.Controls.Add(this.CopyPasswordToClipboard);
            this.Controls.Add(this.ShowPasswordButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxNote);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxWebService);
            this.Name = "Add_Password_Form";
            this.Text = "Add_Password";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxWebService;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxNote;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label ShowPasswordButton;
        private System.Windows.Forms.Label CopyPasswordToClipboard;
        private System.Windows.Forms.Label labelExpiryDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerExpiryDate;
        private System.Windows.Forms.CheckBox CheckBoxExpire;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxPincode;
        private System.Windows.Forms.Button buttonConfigurePassword;
    }
}