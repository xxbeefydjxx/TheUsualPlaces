using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TheUsualPlacesBrowser.Credits
{
    public partial class Credits : Form
    {
        bool isClosing = false;
        int pos = 0;
        int CredzBox;
        int DelayTime;
        string Input;
        Timer FadeIn;
        Timer FadeOut;
        Timer TextPrinter;

        public Credits()
        {
            InitializeComponent();
            TextPrinter = new Timer();
            TextPrinter.Interval = 90;
            TextPrinter.Tick += new EventHandler(Text_Tick);

            FadeIn = new Timer();
            FadeIn.Interval = 60;
            FadeIn.Tick += new EventHandler(fadeIn);

            FadeOut = new Timer();
            FadeOut.Interval = 60;
            FadeOut.Tick += new EventHandler(fadeOut);
        }

        void fadeIn(object sender, EventArgs e)
        {
            try
            {
                if (Opacity >= 1)
                    FadeIn.Stop();
                else
                    Opacity += 0.05;
            }
            catch (Exception ex)
            {
                return;
            }
        }

        void fadeOut(object sender, EventArgs e)
        {
            try
            {
                if (Opacity <= 0)
                    FadeIn.Stop();
                else
                    Opacity -= 0.05;
            }
            catch (Exception ex)
            {
                return;
            }
        }

        void Text_Tick(object sender, EventArgs e)
        {
            if (CredzBox == 1)
            {
                if (pos < Input.Length)
                {
                    CredzIntro.Text = CredzIntro.Text + Input.Substring(pos, 1);
                    ++pos;
                }
                else
                {
                    TextPrinter.Stop();
                }
            }

            if (CredzBox == 2)
            {
                if (pos < Input.Length)
                {
                    AccCredz.Text = AccCredz.Text + Input.Substring(pos, 1);
                    ++pos;
                }
                else
                {
                    TextPrinter.Stop();
                }
            }

        }

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            mediaPlayer.Stop();
            mediaPlayer.Dispose();
            FadeOut.Start();
        }

        private void PlayFile()
        {
            mediaPlayer.Stream = Properties.Resources.Quazar__Sanxion___Hybrid_Song__1_;
            mediaPlayer.Play();
        }

        private async void Credits_Load(object sender, EventArgs e)
        {
            Opacity = 0;
            FadeIn.Start();

            PlayFile();
         
            CredzBox = 1;
            Input = "xXBeefyDjXx Presents";
            CredPicture.Image = Properties.Resources.xXBeefyDjXx;
            await Task.Delay(2000);
            TextPrinter.Start();
            DelayTime = ((Input.Length * 120) + 3500);
            await Task.Delay(DelayTime);
            CredPicture.Image = null;

            CredzBox = 2;

            AccCredz.Text = null;
            pos = 0;
            Input = "'The Usual Places'\nXBINS Browser\n";
            TextPrinter.Start();
            await Task.Delay(100);
            CredPicture.Image = Properties.Resources.XBINS;
            DelayTime = ((Input.Length * 120) + 3800);
            await Task.Delay(DelayTime);


            await Task.Delay(1000);
            if (Opacity == 1)
            {
                StartCredits();
            }
        }


        private async void StartCredits()
        {
            /*
            CredPicture.Image = null;
            CredzBox = 1;
            CredzIntro.Text = null;
            AccCredz.Text = null;
            pos = 0;
            Input = "Credz\n";
            TextPrinter.Start();
            DelayTime = ((Input.Length * 120) + 1000);
            await Task.Delay(DelayTime);


            CredzBox = 2;
            CredPicture.Size = new Size(200, 200);

            //Main Tool Credits here... Copy + Paste this and change input + GIF.
            AccCredz.Text = null;
            pos = 0;
            Input = "Tool Functions + UI \n xXBeefyDjXx";
            TextPrinter.Start();
            await Task.Delay(500);
            CredPicture.Image = Properties.Resources.xXBeefyDjXx;
            DelayTime = ((Input.Length * 120) + 3000);
            await Task.Delay(DelayTime);
            CredPicture.Image = null;
            */

            //Greetz. Again Copy + Paste, change Input + GIF.

            CredzBox = 1;
            CredzIntro.Text = null;
            AccCredz.Text = null;
            pos = 0;
            Input = "Greetz!";
            TextPrinter.Start();
            DelayTime = ((Input.Length * 120) + 3500);
            await Task.Delay(DelayTime);

            CredzBox = 2;

            AccCredz.Text = null;
            pos = 0;
            Input = "The Project Liberation Team";
            TextPrinter.Start();
            CredPicture.Image = null;
            DelayTime = ((Input.Length * 120) + 4000);
            await Task.Delay(DelayTime);

            AccCredz.Text = null;
            pos = 0;
            Input = "Se7ensins Forum";
            CredPicture.Image = Properties.Resources.Se7ensins;
            await Task.Delay(2000);
            TextPrinter.Start();
            DelayTime = ((Input.Length * 120) + 4500);
            await Task.Delay(DelayTime);

            AccCredz.Text = null;
            pos = 0;
            Input = "Team Resurgent";
            CredPicture.Image = Properties.Resources.Resurgent;
            await Task.Delay(2000);
            TextPrinter.Start();
            DelayTime = ((Input.Length * 120) + 3500);
            await Task.Delay(DelayTime);
            CredPicture.Image = null;



            //Music Credits.

            CredzBox = 1;
            CredzIntro.Text = null;
            AccCredz.Text = null;
            pos = 0;
            Input = "Enjoy The Music!";

            TextPrinter.Start();
            await Task.Delay(400);
            DelayTime = ((Input.Length * 120) + 3500);
            await Task.Delay(DelayTime);

            CredzBox = 2;
            AccCredz.Text = null;
            pos = 0;
            Input = "Music: \n Quazar/Sanxion - Hybrid Song";
            TextPrinter.Start();
        }
    }
}
