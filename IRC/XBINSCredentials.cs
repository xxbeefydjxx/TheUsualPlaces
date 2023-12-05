namespace TheUsualPlacesBrowser.IRC
{
    public class XBINSCredentials
    {
        public string FTPServer { get; set; }

        public string FTPPort { get; set; }

        public string FTPUsername { get; set; }

        public string FTPPassword { get; set; }

        public void ParseCredentialMessage(string IRCMessage)
        {
            //Example:
            //FTP ADDRESS: distribution.xbins.org PORT: 21 USERNAME: Guest6869 PASSWORD: emulation NOTE: This Username and Password will be deleted upon connection for security reasons. This site contains 100% homebrew files and absolutely NO warez. Brought to you by #xbins

            string[] parsedData = IRCMessage.Split(" ".ToCharArray());

            FTPServer = parsedData[5];
            FTPPort = parsedData[7];
            FTPUsername = parsedData[9];
            FTPPassword = parsedData[11];

            TheUsualPlacesBrowser.UpdateStatus("FTP: Connecting to XBINS!");

            TheUsualPlacesBrowser.InitialiseXBINSFTP();

        }
    }
}
