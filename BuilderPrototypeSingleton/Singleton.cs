using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPrototypeSingleton
{
    public class WebSite
    {
        private static WebSite _reference;

        public string DomainName { get; set; }
        public IPAddress iPAddress { get; set; }

        private WebSite()
        {
            DomainName = "Google.com";
            iPAddress = IPAddress.Loopback;
        }


        public static WebSite GetInstance()
        {
            if (_reference is null) _reference = new WebSite();

            return _reference;
        }

        public override string ToString()
            => string.Format("Domain Name: {0}\nIP adress: {1}", DomainName, iPAddress);
    }
}
