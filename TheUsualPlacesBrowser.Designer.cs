namespace TheUsualPlacesBrowser
{
    partial class TheUsualPlacesBrowser
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
            this.ThemeChange = new System.Windows.Forms.Button();
            this.Credits = new System.Windows.Forms.Button();
            this.StatusPlaceholder = new System.Windows.Forms.TextBox();
            this.ConnectConsoleFTP = new System.Windows.Forms.Button();
            this.OpenLocal = new System.Windows.Forms.Button();
            this.LocalBrowser = new System.Windows.Forms.WebBrowser();
            this.StatusMessage = new System.Windows.Forms.TextBox();
            this.XBINSFTPViewer = new System.Windows.Forms.ListView();
            this.LocalFolderSelect = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // ThemeChange
            // 
            this.ThemeChange.BackColor = System.Drawing.Color.White;
            this.ThemeChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ThemeChange.ForeColor = System.Drawing.Color.MediumOrchid;
            this.ThemeChange.Location = new System.Drawing.Point(723, 3);
            this.ThemeChange.Name = "ThemeChange";
            this.ThemeChange.Size = new System.Drawing.Size(73, 23);
            this.ThemeChange.TabIndex = 1;
            this.ThemeChange.Text = "Dark Mode";
            this.ThemeChange.UseVisualStyleBackColor = false;
            this.ThemeChange.Click += new System.EventHandler(this.ChangeTheme_Click);
            // 
            // Credits
            // 
            this.Credits.BackColor = System.Drawing.Color.White;
            this.Credits.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Credits.ForeColor = System.Drawing.Color.MediumOrchid;
            this.Credits.Location = new System.Drawing.Point(732, 423);
            this.Credits.Name = "Credits";
            this.Credits.Size = new System.Drawing.Size(64, 23);
            this.Credits.TabIndex = 2;
            this.Credits.Text = "Credits";
            this.Credits.UseVisualStyleBackColor = false;
            this.Credits.Click += new System.EventHandler(this.Credits_Click);
            // 
            // StatusPlaceholder
            // 
            this.StatusPlaceholder.BackColor = System.Drawing.Color.White;
            this.StatusPlaceholder.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.StatusPlaceholder.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.StatusPlaceholder.ForeColor = System.Drawing.Color.MediumOrchid;
            this.StatusPlaceholder.Location = new System.Drawing.Point(6, 432);
            this.StatusPlaceholder.Name = "StatusPlaceholder";
            this.StatusPlaceholder.Size = new System.Drawing.Size(36, 13);
            this.StatusPlaceholder.TabIndex = 4;
            this.StatusPlaceholder.Text = "Status:";
            // 
            // ConnectConsoleFTP
            // 
            this.ConnectConsoleFTP.BackColor = System.Drawing.Color.White;
            this.ConnectConsoleFTP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConnectConsoleFTP.ForeColor = System.Drawing.Color.MediumOrchid;
            this.ConnectConsoleFTP.Location = new System.Drawing.Point(348, 3);
            this.ConnectConsoleFTP.Name = "ConnectConsoleFTP";
            this.ConnectConsoleFTP.Size = new System.Drawing.Size(110, 23);
            this.ConnectConsoleFTP.TabIndex = 5;
            this.ConnectConsoleFTP.Text = "Connect to Console";
            this.ConnectConsoleFTP.UseVisualStyleBackColor = false;
            // 
            // OpenLocal
            // 
            this.OpenLocal.BackColor = System.Drawing.Color.White;
            this.OpenLocal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenLocal.ForeColor = System.Drawing.Color.MediumOrchid;
            this.OpenLocal.Location = new System.Drawing.Point(4, 3);
            this.OpenLocal.Name = "OpenLocal";
            this.OpenLocal.Size = new System.Drawing.Size(108, 23);
            this.OpenLocal.TabIndex = 6;
            this.OpenLocal.Text = "Browse This PC";
            this.OpenLocal.UseVisualStyleBackColor = false;
            this.OpenLocal.Click += new System.EventHandler(this.OpenLocal_Click);
            // 
            // LocalBrowser
            // 
            this.LocalBrowser.Location = new System.Drawing.Point(12, 32);
            this.LocalBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.LocalBrowser.Name = "LocalBrowser";
            this.LocalBrowser.ScriptErrorsSuppressed = true;
            this.LocalBrowser.ScrollBarsEnabled = false;
            this.LocalBrowser.Size = new System.Drawing.Size(383, 385);
            this.LocalBrowser.TabIndex = 7;
            // 
            // StatusMessage
            // 
            this.StatusMessage.BackColor = System.Drawing.Color.White;
            this.StatusMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.StatusMessage.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.StatusMessage.ForeColor = System.Drawing.Color.MediumOrchid;
            this.StatusMessage.Location = new System.Drawing.Point(43, 432);
            this.StatusMessage.Name = "StatusMessage";
            this.StatusMessage.Size = new System.Drawing.Size(400, 13);
            this.StatusMessage.TabIndex = 9;
            this.StatusMessage.Text = "Not Connected";
            // 
            // XBINSFTPViewer
            // 
            this.XBINSFTPViewer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.XBINSFTPViewer.FullRowSelect = true;
            this.XBINSFTPViewer.GridLines = true;
            this.XBINSFTPViewer.HideSelection = false;
            this.XBINSFTPViewer.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.XBINSFTPViewer.Location = new System.Drawing.Point(401, 32);
            this.XBINSFTPViewer.Name = "XBINSFTPViewer";
            this.XBINSFTPViewer.Size = new System.Drawing.Size(387, 385);
            this.XBINSFTPViewer.TabIndex = 10;
            this.XBINSFTPViewer.UseCompatibleStateImageBehavior = false;
            this.XBINSFTPViewer.View = System.Windows.Forms.View.Details;
            this.XBINSFTPViewer.SelectedIndexChanged += new System.EventHandler(this.OnXBINSListItemClicked);
            // 
            // LocalFolderSelect
            // 
            this.LocalFolderSelect.Description = "Please select a Folder. The Folder will be used to store downloads and browse usi" +
    "ng the Local View.";
            this.LocalFolderSelect.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // TheUsualPlacesBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.XBINSFTPViewer);
            this.Controls.Add(this.StatusMessage);
            this.Controls.Add(this.LocalBrowser);
            this.Controls.Add(this.OpenLocal);
            this.Controls.Add(this.ConnectConsoleFTP);
            this.Controls.Add(this.StatusPlaceholder);
            this.Controls.Add(this.Credits);
            this.Controls.Add(this.ThemeChange);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "TheUsualPlacesBrowser";
            this.Text = "The Usual Places: XBINS Browser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ThemeChange;
        private System.Windows.Forms.Button Credits;
        private System.Windows.Forms.TextBox StatusPlaceholder;
        private System.Windows.Forms.Button ConnectConsoleFTP;
        private System.Windows.Forms.Button OpenLocal;
        private System.Windows.Forms.WebBrowser LocalBrowser;
        private System.Windows.Forms.TextBox StatusMessage;
        private System.Windows.Forms.ListView XBINSFTPViewer;
        private System.Windows.Forms.FolderBrowserDialog LocalFolderSelect;
    }
}

