using IrcDotNet;

namespace TheUsualPlacesBrowser.IRC
{
    public class IrcRego : IrcRegistrationInfo
    {
        public IrcRego(bool Setup) : base()
        {
            if (Setup)
            {
                NickName = "TheUsualPlacesTEST";
                Password = "TeamResurganceRULEZ";
            }
        }


    }
}
