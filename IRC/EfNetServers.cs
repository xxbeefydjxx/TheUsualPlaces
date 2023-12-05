using System.Collections.Generic;

namespace TheUsualPlacesBrowser.IRC
{
    /// <summary>
    /// Contains a list of IRC Servers that connect to EFNet that allow bots.
    /// </summary>
    public class EfNetServers
    {
        public static List<string> UnitedStatesServers { get; set; }

        public static List<string> EuropeServers { get; set; }


        public static void InitialiseIRCLists()
        {
            UnitedStatesServers = new List<string>();
            EuropeServers = new List<string>();

            //Add all known bot friendly servers, as listed in efnet.org website:

            EuropeServers.Add("efnet.portlane.se");
            EuropeServers.Add("irc.efnet.fr");
            EuropeServers.Add("irc.efnet.nl");
            EuropeServers.Add("irc.nordunet.se");
            EuropeServers.Add("irc.underworld.no");

            UnitedStatesServers.Add("irc.choopa.net");
            UnitedStatesServers.Add("irc.colosolutions.net");
            UnitedStatesServers.Add("irc.deft.com");
            UnitedStatesServers.Add("irc.mzima.net");
        }

    }
}
