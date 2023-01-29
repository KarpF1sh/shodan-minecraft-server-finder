using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minecraft_tool_standalone.Minecraft
{
    public class Server
    {
        public Server(string ip, string port, string version, string desc, string online, string max, bool modded)
        {
            this.Ip = ip;
            this.Port = port;
            this.Version = version;
            this.Desc = desc;
            this.Online = online;
            this.Max = max;
            this.Modded = modded;
        }

        public string Ip { get; set; }
        public string Port { get; set; }
        public string Version { get; set; }
        public string Desc { get; set; }
        public string Online { get; set; }
        public string Max { get; set; }
        public bool Modded { get; set; }
        
    }
}
