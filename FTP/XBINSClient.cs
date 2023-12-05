using FluentFTP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Timers;
using TheUsualPlacesBrowser.IRC;

namespace TheUsualPlacesBrowser.FTP
{
    public class XBINSClient
    {
        static FtpClient Client { get; set; }

        private static string CurrentDirectory { get; set; }

        public string GetCurrentDirectory()
        {
            return CurrentDirectory;
        }

        public void InitializeXBINSFTP(XBINSCredentials Credentials)
        {
            Client = new FtpClient(Credentials.FTPServer, Credentials.FTPUsername, Credentials.FTPPassword, Convert.ToInt32(Credentials.FTPPort));
            Client.Config.SocketKeepAlive = true;
            Client.Connect();
        }

        public FtpListItem[] GetDirectoryFromFTP(string Directory)
        {
            if (Directory == @".\")
            {
                if (CurrentDirectory != "/")
                {
                    Client.SetWorkingDirectory(CurrentDirectory + @"\..");
                    CurrentDirectory = Client.GetWorkingDirectory();
                }
            }
            else
            {
                CurrentDirectory = Directory;
            }


            TheUsualPlacesBrowser.UpdateStatus($"FTP: Attempting to access {CurrentDirectory} On XBINS...");

            FtpListItem[] Items = Client.GetListing(CurrentDirectory);

            TheUsualPlacesBrowser.UpdateStatus($"FTP: Connected to XBINS.");

            return Items;
        }

        public static bool DownloadFile(string ToLocation, string DLLocation)
        {
            FtpStatus status = FtpStatus.Failed;
            try
            {
                status = Client.DownloadFile(ToLocation, DLLocation, FtpLocalExists.Overwrite, FtpVerify.OnlyChecksum);
            }
            catch (Exception ex)
            {
                TheUsualPlacesBrowser.UpdateStatus($"FTP: Failed to Download from XBINS. Access Denied.");
                System.Windows.Forms.MessageBox.Show(ex.Message + "\n" + ex.InnerException.Message);
            }

            if (status == FtpStatus.Success)
            {
                return true;
            }

            return false;
        }
    }
}
