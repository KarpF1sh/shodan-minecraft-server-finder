using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minecraft_tool_standalone.Shodan
{
    internal class Query
    {
        public Query(string country, string version, bool players, bool noPlayers, string advanced, int page = 1)
        {
            this.Country = country;
            this.Version = version;
            this.Players = players;
            this.NoPlayers = noPlayers;
            this.Advanced = advanced;
            this.Page = page;
        }

        public string Country { get; set; }
        public string Version { get; set; }
        public bool Players { get; set; }
        public bool NoPlayers { get; set; }
        public string Advanced { get; set; }
        public int Page { get; set; }

    }
}
