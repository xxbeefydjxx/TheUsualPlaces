namespace TheUsualPlacesBrowser.Credits
{
    partial class Credits
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Credits));
            this.CredzIntro = new System.Windows.Forms.Label();
            this.CredPicture = new System.Windows.Forms.PictureBox();
            this.AccCredz = new System.Windows.Forms.Label();
            this.mediaPlayer = new System.Media.SoundPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.CredPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // CredzIntro
            // 
            this.CredzIntro.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.CredzIntro.ForeColor = System.Drawing.Color.Fuchsia;
            this.CredzIntro.Location = new System.Drawing.Point(9, 11);
            this.CredzIntro.Name = "CredzIntro";
            this.CredzIntro.Size = new System.Drawing.Size(566, 49);
            this.CredzIntro.TabIndex = 3;
            this.CredzIntro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CredPicture
            // 
            this.CredPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CredPicture.BackColor = System.Drawing.Color.Black;
            this.CredPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.CredPicture.Location = new System.Drawing.Point(185, 72);
            this.CredPicture.Margin = new System.Windows.Forms.Padding(0);
            this.CredPicture.MaximumSize = new System.Drawing.Size(214, 217);
            this.CredPicture.MinimumSize = new System.Drawing.Size(214, 217);
            this.CredPicture.Name = "CredPicture";
            this.CredPicture.Size = new System.Drawing.Size(214, 217);
            this.CredPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.CredPicture.TabIndex = 4;
            this.CredPicture.TabStop = false;
            // 
            // AccCredz
            // 
            this.AccCredz.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.AccCredz.ForeColor = System.Drawing.Color.Fuchsia;
            this.AccCredz.Location = new System.Drawing.Point(9, 295);
            this.AccCredz.Name = "AccCredz";
            this.AccCredz.Size = new System.Drawing.Size(566, 57);
            this.AccCredz.TabIndex = 5;
            this.AccCredz.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Credits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.AccCredz);
            this.Controls.Add(this.CredPicture);
            this.Controls.Add(this.CredzIntro);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Credits";
            this.Text = "Credits";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.Load += new System.EventHandler(this.Credits_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CredPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label CredzIntro;
        private System.Windows.Forms.PictureBox CredPicture;
        private System.Windows.Forms.Label AccCredz;
        private System.Media.SoundPlayer mediaPlayer;
    }
}