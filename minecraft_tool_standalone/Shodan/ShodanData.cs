using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minecraft_tool_standalone.Shodan
{
    internal class ShodanData
    {
        public ShodanData(string ip, string port, string data)
        {
            this.Ip = ip;
            this.Port = port;
            this.Data = data;
        }

        public string Ip { get; private set; }
        public string Port { get; private set; }
        public string Data { get; private set; }

    }
}
