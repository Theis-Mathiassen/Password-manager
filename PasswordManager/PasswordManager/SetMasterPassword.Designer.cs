namespace PasswordManager
{
    partial class SetMasterPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetMasterPassword));
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.buttonShowHidePassword = new System.Windows.Forms.Button();
            this.buttonCopyPassword = new System.Windows.Forms.Button();
            this.buttonShowHideConfirmPassword = new System.Windows.Forms.Button();
            this.buttonCopyConfirmPassword = new System.Windows.Forms.Button();
            this.textBoxConfirmPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPassword.Location = new System.Drawing.Point(15, 25);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(299, 20);
            this.textBoxPassword.TabIndex = 0;
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter password";
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
            this.buttonShowHidePassword.Location = new System.Drawing.Point(320, 21);
            this.buttonShowHidePassword.Name = "buttonShowHidePassword";
            this.buttonShowHidePassword.Size = new System.Drawing.Size(26, 26);
            this.buttonShowHidePassword.TabIndex = 5;
            this.buttonShowHidePassword.UseVisualStyleBackColor = true;
            this.buttonShowHidePassword.Click += new System.EventHandler(this.buttonShowHidePassword_Click);
            // 
            // buttonCopyPassword
            // 
            this.buttonCopyPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCopyPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonCopyPassword.ImageIndex = 0;
            this.buttonCopyPassword.ImageList = this.imageList1;
            this.buttonCopyPassword.Location = new System.Drawing.Point(352, 21);
            this.buttonCopyPassword.Name = "buttonCopyPassword";
            this.buttonCopyPassword.Size = new System.Drawing.Size(26, 26);
            this.buttonCopyPassword.TabIndex = 6;
            this.buttonCopyPassword.UseVisualStyleBackColor = true;
            this.buttonCopyPassword.Click += new System.EventHandler(this.buttonCopyPassword_Click);
            // 
            // buttonShowHideConfirmPassword
            // 
            this.buttonShowHideConfirmPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonShowHideConfirmPassword.ImageIndex = 1;
            this.buttonShowHideConfirmPassword.ImageList = this.imageList1;
            this.buttonShowHideConfirmPassword.Location = new System.Drawing.Point(320, 78);
            this.buttonShowHideConfirmPassword.Name = "buttonShowHideConfirmPassword";
            this.buttonShowHideConfirmPassword.Size = new System.Drawing.Size(26, 26);
            this.buttonShowHideConfirmPassword.TabIndex = 8;
            this.buttonShowHideConfirmPassword.UseVisualStyleBackColor = true;
            this.buttonShowHideConfirmPassword.Click += new System.EventHandler(this.buttonShowHideConfirmPassword_Click);
            // 
            // buttonCopyConfirmPassword
            // 
            this.buttonCopyConfirmPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCopyConfirmPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonCopyConfirmPassword.ImageIndex = 0;
            this.buttonCopyConfirmPassword.ImageList = this.imageList1;
            this.buttonCopyConfirmPassword.Location = new System.Drawing.Point(352, 78);
            this.buttonCopyConfirmPassword.Name = "buttonCopyConfirmPassword";
            this.buttonCopyConfirmPassword.Size = new System.Drawing.Size(26, 26);
            this.buttonCopyConfirmPassword.TabIndex = 9;
            this.buttonCopyConfirmPassword.UseVisualStyleBackColor = true;
            this.buttonCopyConfirmPassword.Click += new System.EventHandler(this.buttonCopyConfirmPassword_Click);
            // 
            // textBoxConfirmPassword
            // 
            this.textBoxConfirmPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxConfirmPassword.Location = new System.Drawing.Point(15, 82);
            this.textBoxConfirmPassword.Name = "textBoxConfirmPassword";
            this.textBoxConfirmPassword.Size = new System.Drawing.Size(299, 20);
            this.textBoxConfirmPassword.TabIndex = 7;
            this.textBoxConfirmPassword.UseSystemPasswordChar = true;
            this.textBoxConfirmPassword.TextChanged += new System.EventHandler(this.textBoxConfirmPassword_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Confirm password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.DarkRed;
            this.label3.Location = new System.Drawing.Point(12, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Passwords does not match.";
            this.label3.Visible = false;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.Location = new System.Drawing.Point(303, 159);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 12;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(222, 159);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 13;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // SetMasterPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 194);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonShowHideConfirmPassword);
            this.Controls.Add(this.buttonCopyConfirmPassword);
            this.Controls.Add(this.textBoxConfirmPassword);
            this.Controls.Add(this.buttonShowHidePassword);
            this.Controls.Add(this.buttonCopyPassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxPassword);
            this.Name = "SetMasterPassword";
            this.Text = "SetMasterPassword";
            this.Load += new System.EventHandler(this.SetMasterPassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button buttonShowHidePassword;
        private System.Windows.Forms.Button buttonCopyPassword;
        private System.Windows.Forms.Button buttonShowHideConfirmPassword;
        private System.Windows.Forms.Button buttonCopyConfirmPassword;
        private System.Windows.Forms.TextBox textBoxConfirmPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
    }
}