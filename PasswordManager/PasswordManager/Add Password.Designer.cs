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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Add_Password_Form));
            this.textBoxService = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxNote = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.labelExpiryDate = new System.Windows.Forms.Label();
            this.dateTimePickerExpiryDate = new System.Windows.Forms.DateTimePicker();
            this.CheckBoxExpire = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxPincode = new System.Windows.Forms.TextBox();
            this.buttonConfigurePassword = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxURL = new System.Windows.Forms.TextBox();
            this.buttonCopyPassword = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.buttonShowHidePassword = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.dateTimePickerCreatedDate = new System.Windows.Forms.DateTimePicker();
            this.labelCreatedDate = new System.Windows.Forms.Label();
            this.buttonShowHidePincode = new System.Windows.Forms.Button();
            this.buttonCopyPincode = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxService
            // 
            this.textBoxService.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxService.Location = new System.Drawing.Point(108, 8);
            this.textBoxService.Name = "textBoxService";
            this.textBoxService.Size = new System.Drawing.Size(500, 20);
            this.textBoxService.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Service";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Email";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 288);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Note";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxEmail.Location = new System.Drawing.Point(108, 38);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(500, 20);
            this.textBoxEmail.TabIndex = 1;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPassword.Location = new System.Drawing.Point(108, 68);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(436, 20);
            this.textBoxPassword.TabIndex = 2;
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // textBoxNote
            // 
            this.textBoxNote.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNote.Location = new System.Drawing.Point(108, 288);
            this.textBoxNote.Multiline = true;
            this.textBoxNote.Name = "textBoxNote";
            this.textBoxNote.Size = new System.Drawing.Size(500, 220);
            this.textBoxNote.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(454, 514);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // labelExpiryDate
            // 
            this.labelExpiryDate.AutoSize = true;
            this.labelExpiryDate.Location = new System.Drawing.Point(12, 254);
            this.labelExpiryDate.Name = "labelExpiryDate";
            this.labelExpiryDate.Size = new System.Drawing.Size(59, 13);
            this.labelExpiryDate.TabIndex = 0;
            this.labelExpiryDate.Text = "Expiry date";
            // 
            // dateTimePickerExpiryDate
            // 
            this.dateTimePickerExpiryDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePickerExpiryDate.Enabled = false;
            this.dateTimePickerExpiryDate.Location = new System.Drawing.Point(132, 251);
            this.dateTimePickerExpiryDate.Name = "dateTimePickerExpiryDate";
            this.dateTimePickerExpiryDate.Size = new System.Drawing.Size(476, 20);
            this.dateTimePickerExpiryDate.TabIndex = 10;
            // 
            // CheckBoxExpire
            // 
            this.CheckBoxExpire.AutoSize = true;
            this.CheckBoxExpire.Location = new System.Drawing.Point(108, 254);
            this.CheckBoxExpire.Name = "CheckBoxExpire";
            this.CheckBoxExpire.Size = new System.Drawing.Size(15, 14);
            this.CheckBoxExpire.TabIndex = 9;
            this.CheckBoxExpire.UseVisualStyleBackColor = true;
            this.CheckBoxExpire.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 154);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Pincode";
            // 
            // textBoxPincode
            // 
            this.textBoxPincode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPincode.Location = new System.Drawing.Point(108, 151);
            this.textBoxPincode.Name = "textBoxPincode";
            this.textBoxPincode.Size = new System.Drawing.Size(436, 20);
            this.textBoxPincode.TabIndex = 6;
            this.textBoxPincode.UseSystemPasswordChar = true;
            // 
            // buttonConfigurePassword
            // 
            this.buttonConfigurePassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonConfigurePassword.Location = new System.Drawing.Point(108, 108);
            this.buttonConfigurePassword.Name = "buttonConfigurePassword";
            this.buttonConfigurePassword.Size = new System.Drawing.Size(500, 23);
            this.buttonConfigurePassword.TabIndex = 5;
            this.buttonConfigurePassword.Text = "Configure password";
            this.buttonConfigurePassword.UseVisualStyleBackColor = true;
            this.buttonConfigurePassword.Click += new System.EventHandler(this.buttonConfigurePassword_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "URL";
            // 
            // textBoxURL
            // 
            this.textBoxURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxURL.Location = new System.Drawing.Point(108, 186);
            this.textBoxURL.Name = "textBoxURL";
            this.textBoxURL.Size = new System.Drawing.Size(500, 20);
            this.textBoxURL.TabIndex = 7;
            // 
            // buttonCopyPassword
            // 
            this.buttonCopyPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCopyPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonCopyPassword.ImageIndex = 0;
            this.buttonCopyPassword.ImageList = this.imageList1;
            this.buttonCopyPassword.Location = new System.Drawing.Point(582, 64);
            this.buttonCopyPassword.Name = "buttonCopyPassword";
            this.buttonCopyPassword.Size = new System.Drawing.Size(26, 26);
            this.buttonCopyPassword.TabIndex = 4;
            this.buttonCopyPassword.UseVisualStyleBackColor = true;
            this.buttonCopyPassword.Click += new System.EventHandler(this.buttonCopyPassword_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "CopyPasswordIcon.png");
            this.imageList1.Images.SetKeyName(1, "HidePasswordIcon.png");
            this.imageList1.Images.SetKeyName(2, "ShowPasswordIcon.png");
            // 
            // buttonShowHidePassword
            // 
            this.buttonShowHidePassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonShowHidePassword.ImageIndex = 1;
            this.buttonShowHidePassword.ImageList = this.imageList1;
            this.buttonShowHidePassword.Location = new System.Drawing.Point(550, 64);
            this.buttonShowHidePassword.Name = "buttonShowHidePassword";
            this.buttonShowHidePassword.Size = new System.Drawing.Size(26, 26);
            this.buttonShowHidePassword.TabIndex = 3;
            this.buttonShowHidePassword.UseVisualStyleBackColor = true;
            this.buttonShowHidePassword.Click += new System.EventHandler(this.buttonShowHidePassword_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(535, 514);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 13;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // dateTimePickerCreatedDate
            // 
            this.dateTimePickerCreatedDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePickerCreatedDate.Location = new System.Drawing.Point(108, 217);
            this.dateTimePickerCreatedDate.Name = "dateTimePickerCreatedDate";
            this.dateTimePickerCreatedDate.Size = new System.Drawing.Size(500, 20);
            this.dateTimePickerCreatedDate.TabIndex = 8;
            // 
            // labelCreatedDate
            // 
            this.labelCreatedDate.AutoSize = true;
            this.labelCreatedDate.Location = new System.Drawing.Point(12, 220);
            this.labelCreatedDate.Name = "labelCreatedDate";
            this.labelCreatedDate.Size = new System.Drawing.Size(68, 13);
            this.labelCreatedDate.TabIndex = 13;
            this.labelCreatedDate.Text = "Created date";
            // 
            // buttonShowHidePincode
            // 
            this.buttonShowHidePincode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonShowHidePincode.ImageIndex = 1;
            this.buttonShowHidePincode.ImageList = this.imageList1;
            this.buttonShowHidePincode.Location = new System.Drawing.Point(550, 147);
            this.buttonShowHidePincode.Name = "buttonShowHidePincode";
            this.buttonShowHidePincode.Size = new System.Drawing.Size(26, 26);
            this.buttonShowHidePincode.TabIndex = 14;
            this.buttonShowHidePincode.UseVisualStyleBackColor = true;
            this.buttonShowHidePincode.Click += new System.EventHandler(this.buttonShowHidePincode_Click);
            // 
            // buttonCopyPincode
            // 
            this.buttonCopyPincode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCopyPincode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonCopyPincode.ImageIndex = 0;
            this.buttonCopyPincode.ImageList = this.imageList1;
            this.buttonCopyPincode.Location = new System.Drawing.Point(582, 147);
            this.buttonCopyPincode.Name = "buttonCopyPincode";
            this.buttonCopyPincode.Size = new System.Drawing.Size(26, 26);
            this.buttonCopyPincode.TabIndex = 15;
            this.buttonCopyPincode.UseVisualStyleBackColor = true;
            this.buttonCopyPincode.Click += new System.EventHandler(this.buttonCopyPincode_Click);
            // 
            // Add_Password_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(622, 548);
            this.Controls.Add(this.buttonShowHidePincode);
            this.Controls.Add(this.buttonCopyPincode);
            this.Controls.Add(this.dateTimePickerCreatedDate);
            this.Controls.Add(this.labelCreatedDate);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonShowHidePassword);
            this.Controls.Add(this.buttonCopyPassword);
            this.Controls.Add(this.textBoxURL);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonConfigurePassword);
            this.Controls.Add(this.textBoxPincode);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.CheckBoxExpire);
            this.Controls.Add(this.dateTimePickerExpiryDate);
            this.Controls.Add(this.labelExpiryDate);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxNote);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxService);
            this.Name = "Add_Password_Form";
            this.Text = "Add_Password";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxService;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxNote;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelExpiryDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerExpiryDate;
        private System.Windows.Forms.CheckBox CheckBoxExpire;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxPincode;
        private System.Windows.Forms.Button buttonConfigurePassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxURL;
        private System.Windows.Forms.Button buttonCopyPassword;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button buttonShowHidePassword;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.DateTimePicker dateTimePickerCreatedDate;
        private System.Windows.Forms.Label labelCreatedDate;
        private System.Windows.Forms.Button buttonShowHidePincode;
        private System.Windows.Forms.Button buttonCopyPincode;
    }
}