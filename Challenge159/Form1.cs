using System;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Challenge159
{
    public partial class Form1 : Form
    {
        private const string phpSessionIdName = "PHPSESSID";
        private const string phpSessionIdValue = "ljbecct5b989gh3imvnp9otn20"; // change this one

        private const string urlHashKiller = "https://hashkiller.co.uk/sha1-decrypter.aspx";
        // "hiding" challenge url so it can not be found e.g. by google etc.
        private string urlChallenge = "https://" + (char)114 + (char)105 + (char)110 + (char)103 + (char)122 + (char)101 + (char)114 + (char)48 + (char)116 + (char)101 + (char)97 + (char)109 + (char)46 + (char)99 + (char)111 + (char)109 + (char)47 + (char)99 + (char)104 + (char)97 + (char)108 + (char)108 + (char)101 + (char)110 + (char)103 + (char)101 + (char)115 + "/159";

        private const string captchaInputId = "content1_txtCaptcha";
        private const string submitButtonId = "content1_btnSubmit";
        private const string textAreaHashId = "content1_txtInput";
        private const string textAreaBrokenId = "content1_lblResults";
        private const string brokenSpanClass = "text-green";

        private const string beginHash = "----- BEGIN HASH -----";
        private const string endHash = "----- END HASH -----";
        private const string hashDivClass = "message";
        
        public Form1()
        {
            InitializeComponent();
        }

        // for setting the cookie
        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool InternetSetCookie(string lpszUrlName, string lpszCookieName, string lpszCookieData);

        private void FormLoad(object sender, EventArgs e)
        {          
            // on form load do load also the haskiller page            
            webBrowserHashKiller.Url = new Uri(urlHashKiller);

            // prepare the cookie for challenge page
            Cookie cookie = new Cookie(phpSessionIdName, phpSessionIdValue);
            InternetSetCookie(urlChallenge, null, cookie.ToString() + "; expires = Sun, 05-Jan-2020 00:00:00 GMT");
        }        

        private void SolveClicked(object sender, EventArgs e)
        {
            AddLogLine("Solve button clicked");
            AddLogLine($"Using {phpSessionIdName}={phpSessionIdValue}");
            AddLogLine($"Using CAPTCHA: {webBrowserHashKiller.Document.GetElementById(captchaInputId).GetAttribute("value")}");

            webBrowserChallenge.DocumentCompleted += ChallengePageLoaded;
            webBrowserChallenge.Url = new Uri(urlChallenge);
        }

        private void ChallengePageLoaded(object sender, EventArgs e)
        {
            webBrowserChallenge.DocumentCompleted -= ChallengePageLoaded;

            var hash = string.Empty;

            foreach (HtmlElement div in webBrowserChallenge.Document.GetElementsByTagName("div"))
            {
                if (div.GetAttribute("classname") == hashDivClass)
                {
                    hash = div.InnerText.Replace(beginHash, string.Empty).Replace(endHash, string.Empty).Trim();
                    AddLogLine($"Using HASH: {hash}");
                }
            }

            webBrowserHashKiller.Document.GetElementById(textAreaHashId).SetAttribute("value", hash);
            webBrowserHashKiller.Document.GetElementById(submitButtonId).InvokeMember("click");

            // fucking complicated to check for change after POST within WebBrowser (hash killer page uses aspx...)
            // just set a 1 second interval and then parse the broken hash value
            Timer timer = new Timer();
            timer.Tick += new EventHandler(BrokenHashPageLoaded);
            timer.Interval = 1000;
            timer.Start();
        }

        private void BrokenHashPageLoaded(object sender, EventArgs e )
        {
            var timer = (Timer)sender;
            timer.Stop();

            var broken = string.Empty;

            foreach (HtmlElement span in webBrowserHashKiller.Document.GetElementsByTagName("span"))
            {
                if (span.GetAttribute("classname") == brokenSpanClass)
                {
                    broken = span.InnerText;
                    AddLogLine($"Broken hash: {broken}");
                }
            }

            webBrowserChallenge.Url = new Uri(urlChallenge + "/" + broken);
            AddLogLine("Check the bottom page for flag.");
        }

        private void AddLogLine(string message)
        {
            textBoxLogging.AppendText(message + Environment.NewLine);
            textBoxLogging.ScrollToCaret();
        }
    }
}