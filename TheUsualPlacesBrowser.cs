using FluentFTP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheUsualPlacesBrowser.FTP;
using TheUsualPlacesBrowser.IRC;

namespace TheUsualPlacesBrowser
{
    public partial class TheUsualPlacesBrowser : Form
    {

        static IRCBot IRCClient = new IRCBot();
        static XBINSClient FTPClient = new XBINSClient();

        static TheUsualPlacesBrowser Instance;

        public TheUsualPlacesBrowser()
        {
            InitializeComponent();
            Instance = this;

            //Initialise Browsers...
            LoadFTPBrowserRight();
            LoadLocalPCLeft();

            //Initialise IRC First then wait for Credentials.
            Thread IRC = new Thread(IRCClient.InitialiseIRCUser);
            IRC.Start();
        }

        private static void LoadFTPBrowserRight()
        {
            //Instance.XBINSFTPViewer.Columns.Add("Type", 70, HorizontalAlignment.Left);
            Instance.XBINSFTPViewer.Columns.Add("Name", 380, HorizontalAlignment.Left);
            //Instance.XBINSFTPViewer.Columns.Add("Location", 200, HorizontalAlignment.Left);
        }

        private static void LoadLocalPCLeft()
        {
            Instance.LocalBrowser.Url = new Uri("C:/");
        }

        //Trigger for FTP after successful IRC Session:
        public static void InitialiseXBINSFTP()
        {
            FTPClient.InitializeXBINSFTP(IRCClient.XBINS_Credentials);
            
            try
            {
                FtpListItem[] elements = FTPClient.GetDirectoryFromFTP(@"\");

                foreach (FtpListItem Item in elements)
                {
                    AddItemToXBINSList(Item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private static void AddItemToXBINSList(FtpListItem FTPItem) 
        {
            if (FTPItem != null)
            {
                string[] row = {FTPItem.Name, FTPItem.Type.ToString(), FTPItem.FullName};
                ListViewItem newItem = new ListViewItem(row);

                if (Instance.InvokeRequired)
                    Instance.BeginInvoke(new Action<ListViewItem>(_AddItemToXBINSList), newItem);

                else
                    Instance.XBINSFTPViewer.Items.Add(newItem);
                    Instance.XBINSFTPViewer.View = View.Details;
            }
        }

        private static void _AddItemToXBINSList(ListViewItem Item)
        {
            Instance.XBINSFTPViewer.Items.Add(Item);
            Instance.XBINSFTPViewer.View = View.Details;
        }


        private static void AddSubItemToXBINSList(ListViewItem ExistingItem, ListViewItem NewItem)
        {
            //Not done yet.
        }
        
        public async void OnXBINSListItemClicked(object sender, EventArgs e)
        {
            if (XBINSFTPViewer.SelectedItems.Count >= 1)
            {
                string Type = XBINSFTPViewer.SelectedItems[0].SubItems[1].Text;

                if (Type == "Directory")
                {
                    string Directory = XBINSFTPViewer.SelectedItems[0].SubItems[2].Text;

                    if (Directory != "")
                    {
                        UpdateStatus($"FTP: Opening Directory: {Directory}");

                        Instance.XBINSFTPViewer.Items.Clear();

                        try
                        {
                            FtpListItem[] elements = FTPClient.GetDirectoryFromFTP(Directory);

                            if (FTPClient.GetCurrentDirectory() != @"/")
                            {
                                string[] Back = new string[] { "Back", "Directory", @".\" };
                                Instance.XBINSFTPViewer.Items.Add(new ListViewItem(Back));
                            }

                            foreach (FtpListItem Item in elements)
                            {
                                AddItemToXBINSList(Item);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                else if (Type == "File")
                {
                    string location = Instance.LocalBrowser.Url.AbsolutePath;

                    UpdateStatus($"FTP: Downloading: {XBINSFTPViewer.SelectedItems[0].SubItems[0].Text} to Local Directory: {location}");

                    bool result = XBINSClient.DownloadFile(location + @"/" + XBINSFTPViewer.SelectedItems[0].SubItems[1].Text, XBINSFTPViewer.SelectedItems[0].SubItems[2].Text);

                    if (result)
                    {
                        UpdateStatus($"FTP: Downloaded: {XBINSFTPViewer.SelectedItems[0].SubItems[0].Text}.");
                        await Task.Delay(5000);
                        UpdateStatus($"FTP: Connected to XBINS...");

                    }
                    else
                    {
                        UpdateStatus($"FTP: Download Failed: {XBINSFTPViewer.SelectedItems[0].SubItems[0].Text}...");
                        await Task.Delay(5000);
                        UpdateStatus($"FTP: Connected to XBINS...");
                    }
                }
            }

        }



        #region Theme

        public static bool IsDark = false;
        private void ChangeTheme_Click(object sender, EventArgs e)
        {
            ChangeTheme();
        }

        public void ChangeTheme()
        {
            if (IsDark == false)
            {
                ActiveForm.BackColor = Color.Black;

                OpenLocal.BackColor = Color.Black;
                OpenLocal.ForeColor = Color.Fuchsia;

                ConnectConsoleFTP.BackColor = Color.Black;
                ConnectConsoleFTP.ForeColor = Color.Fuchsia;

                ThemeChange.BackColor = Color.Black;
                ThemeChange.ForeColor = Color.Fuchsia;

                Credits.BackColor = Color.Black;
                Credits.ForeColor = Color.Fuchsia;

                StatusPlaceholder.BackColor = Color.Black;
                StatusPlaceholder.ForeColor = Color.Fuchsia;

                StatusMessage.BackColor = Color.Black;
                StatusMessage.ForeColor = Color.Fuchsia;

                ThemeChange.Text = "Light Mode";
                IsDark = true;
                return;
            }
            if (IsDark == true)
            {
                ActiveForm.BackColor = Color.White;

                OpenLocal.BackColor = Color.White;
                OpenLocal.ForeColor = Color.DarkOrchid;

                ConnectConsoleFTP.BackColor = Color.White;
                ConnectConsoleFTP.ForeColor = Color.DarkOrchid;

                ThemeChange.BackColor = Color.White;
                ThemeChange.ForeColor = Color.DarkOrchid;

                Credits.BackColor = Color.White;
                Credits.ForeColor = Color.DarkOrchid;

                StatusPlaceholder.BackColor = Color.White;
                StatusPlaceholder.ForeColor = Color.DarkOrchid;

                StatusMessage.BackColor= Color.White;
                StatusMessage.ForeColor= Color.DarkOrchid;

                ThemeChange.Text = "Dark Mode";
                IsDark = false;
                return;
            }
        }

        public static void UpdateStatus(string Message)
        {
            if (Message != null)
            {
                if (Instance.InvokeRequired)
                    Instance.BeginInvoke(new Action<string>(UpdateStatus_internal), Message);

                else
                    Instance.StatusMessage.Text = Message;
            }
        }

        private static void UpdateStatus_internal(string Message)
        {
            Instance.StatusMessage.Text = Message;
        }

        #endregion

        private void Credits_Click(object sender, EventArgs e)
        {
            var Creditz = new Credits.Credits();
            Creditz.Show();
        }

        private void OpenLocal_Click(object sender, EventArgs e)
        {
            LocalFolderSelect.Description = LocalFolderSelect.Description;

            LocalFolderSelect.ShowDialog();

            if (LocalFolderSelect.SelectedPath != "");
            {
                StatusMessage.Text = "Opened Local Storage";
                LocalBrowser.Url = new Uri(LocalFolderSelect.SelectedPath);
            }
        }

    }
}
