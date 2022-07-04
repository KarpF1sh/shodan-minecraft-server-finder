using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minecraft_tool_standalone.Minecraft
{
    public class Server
    {
        public Server(string ip, string port, string version, string description, string online, string max)
        {
            this.Ip = ip;
            this.Port = port;
            this.Version = version;
            this.Description = description;
            this.OnlineCount = online;
            this.MaxPlayers = max;
        }

        public string Ip { get; set; }
        public string Port { get; set; }
        public string Version { get; set; }
        public string Description { get; set; }
        public string OnlineCount { get; set; }
        public string MaxPlayers { get; set; }
        
    }
}
