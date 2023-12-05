using IrcDotNet;
using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace TheUsualPlacesBrowser.IRC
{
    public class IRCBot
    {
        TcpClient IRC_Client;
        NetworkStream Stream;
        StreamReader Reader;
        StreamWriter Writer;

        public static string SERVER;
        private static int PORT = 6667;

        private static Random NumIdentifier = new Random();

        private static string USER { get; set; }
        private static string NICK { get; set; }

        private static string CHANNEL = "#xbins";

        public XBINSCredentials XBINS_Credentials { get; set; }

        private static void GenerateUsername()
        {
            if (USER == null)
            {
                USER = "TUP" + NumIdentifier.Next(99999);
            }
            if (NICK == null)
            {
                NICK = USER;
            }
        }

        public async void InitialiseIRCUser()
        {
            GenerateUsername();
            EfNetServers.InitialiseIRCLists();
            Connect();
        }

        private async void Connect()
        {
            int IRCServerNo = 0;
            string Server = "";
            string inputLine;
            connect:
            if (IRCServerNo <= (EfNetServers.EuropeServers.Count - 1))
            {
                Server = EfNetServers.EuropeServers[IRCServerNo];
            }
            else if (IRCServerNo <= (EfNetServers.EuropeServers.Count + EfNetServers.UnitedStatesServers.Count - 2))
            {
                Server = EfNetServers.UnitedStatesServers[IRCServerNo - EfNetServers.EuropeServers.Count];
            }
            TheUsualPlacesBrowser.UpdateStatus($"IRC: Attempting to connect to EFNET IRC via {Server}...");


            try
            {
                using (IRC_Client = new TcpClient(Server, PORT))
                {
                    Stream = IRC_Client.GetStream();
                    Reader = new StreamReader(Stream);
                    Writer = new StreamWriter(Stream);
                    Writer.WriteLine("USER" + " " + USER + " " + "Test" + " " + "Server" + " " + ": " + " " + "\n");
                    Writer.Flush();
                    Writer.WriteLine("NICK" + " " + NICK + " " + "\n");
                    Writer.Flush();


                    while ((inputLine = Reader.ReadLine()) != null)
                    {
                        Console.WriteLine("<- " + inputLine);

                        // split the lines sent from the server by spaces (seems to be the easiest way to parse them)
                        string[] splitInput = inputLine.Split(new char[] { ' ' });

                        if (splitInput[0] == "ERROR")
                        {
                            if (splitInput[2] == "Banned:")
                            {
                                TheUsualPlacesBrowser.UpdateStatus($"IRC: Banned from {Server} for {splitInput[5]} Minutes... Trying another Server!");
                                await Task.Delay(5000);
                                Disconnect();

                                IRCServerNo++;
                                goto connect;
                            }
                        }

                        if (splitInput[0] == "PING")
                        {
                            string PongReply = splitInput[1];
                            Console.WriteLine("->PONG " + PongReply);
                            Writer.WriteLine("PONG " + PongReply + "\n");
                            Writer.Flush();
                            break;
                        }

                        switch (splitInput[1])
                        {
                            case "001":
                                JoinXBinsIRC();
                                break;

                            case "366":
                                RequestXBINSCredentials();
                                break;

                            case "PRIVMSG":
                                if (await OnLocalUserMessageReceived(inputLine))
                                {
                                    return;
                                }
                                else break;

                            default:
                                break;
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                TheUsualPlacesBrowser.UpdateStatus($"IRC: FAILED to connect to EFNET IRC via {Server}...");
                IRCServerNo++;
                goto connect;
            }
        }

        private void JoinXBinsIRC()
        {
            Writer.WriteLine("JOIN " + CHANNEL + " " + "\n");
            Writer.Flush();
            TheUsualPlacesBrowser.UpdateStatus("IRC: Joining #XBINS Channel...");
        }

        public void RequestXBINSCredentials()
        {
            Writer.WriteLine("PRIVMSG xbins !list \n");
            Writer.Flush();
            TheUsualPlacesBrowser.UpdateStatus("IRC: Asking XBINS for Credentials...");
        }

        private async Task Disconnect()
        {
            // Disconnect IRC client that is connected to given server.
            Writer.WriteLine("/quit Touching Grass, back soon! \n"); //Sassy message for lols
            Writer.Flush();

            Writer.Close();
            Reader.Close();
            IRC_Client.Close();

            TheUsualPlacesBrowser.UpdateStatus("IRC: Gracefully Disconnected from EFNET...");
        }

        private async Task<bool> OnLocalUserMessageReceived(string ReceivedMessage) 
        {
            String[] SplitInput = ReceivedMessage.Split(new char[] { ' ' });
            if (SplitInput[0].Contains("xbins") && SplitInput[2] == NICK)
            {
                TheUsualPlacesBrowser.UpdateStatus("IRC: Received Credential Message  from XBINS...");
                Disconnect();
                await Task.Delay(2000);
                XBINS_Credentials = new XBINSCredentials();
                XBINS_Credentials.ParseCredentialMessage(ReceivedMessage);
                return true;
            }
            if (SplitInput[0].Contains("Guest6869")) //Test
            {
                Writer.WriteLine("PRIVMSG guest6869 :I am but a mere mortal Try me bitch!");
                Writer.Flush();
            }
            return false;
        }

    }
}
