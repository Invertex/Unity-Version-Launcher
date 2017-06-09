namespace Invertex.UnityVersionLauncher
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.UnityInstallList = new System.Windows.Forms.ListBox();
            this.AuthorLink = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // UnityInstallList
            // 
            this.UnityInstallList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UnityInstallList.BackColor = System.Drawing.Color.WhiteSmoke;
            this.UnityInstallList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UnityInstallList.DisplayMember = "DisplayVersion";
            this.UnityInstallList.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UnityInstallList.FormattingEnabled = true;
            this.UnityInstallList.ItemHeight = 32;
            this.UnityInstallList.Location = new System.Drawing.Point(13, 13);
            this.UnityInstallList.Name = "UnityInstallList";
            this.UnityInstallList.Size = new System.Drawing.Size(198, 322);
            this.UnityInstallList.Sorted = true;
            this.UnityInstallList.TabIndex = 0;
            this.UnityInstallList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.OptionChosen);
            
            // 
            // AuthorLink
            // 
            this.AuthorLink.AutoSize = true;
            this.AuthorLink.BackColor = System.Drawing.Color.Transparent;
            this.AuthorLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AuthorLink.Location = new System.Drawing.Point(11, 337);
            this.AuthorLink.Name = "AuthorLink";
            this.AuthorLink.Size = new System.Drawing.Size(58, 17);
            this.AuthorLink.TabIndex = 1;
            this.AuthorLink.TabStop = true;
            this.AuthorLink.Text = "by Invertex";
            this.AuthorLink.UseCompatibleTextRendering = true;
            this.AuthorLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.AuthorLinkClicked);
            // 
            // MainWindow
            // 
            this.AccessibleDescription = "Multi-version launcher for Unity";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuBar;
            this.ClientSize = new System.Drawing.Size(223, 351);
            this.Controls.Add(this.AuthorLink);
            this.Controls.Add(this.UnityInstallList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Unity Version Launcher";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox UnityInstallList;
        private System.Windows.Forms.LinkLabel AuthorLink;
    }

}

