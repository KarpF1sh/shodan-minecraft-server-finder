using minecraft_tool_standalone.Shodan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minecraft_tool_standalone.Minecraft
{
    internal static class ServerFinder
    {
        public static async Task<List<Server>> GetServersAsync(Query query)
        {
            // Final list of servers
            List<Server> servers = new List<Server>();

            // New shodan query
            List<ShodanData> results = await ShodanQuery.SearchAsync(query);

            // Loop through shodan results
            foreach (var result in results)
            {
                // Get data result and pass it the parser
                ServerData serverData = ServerDataParser.Parse(result.Data);

                // Parse Data and add to list
                servers.Add(new Server(result.Ip,
                            result.Port,
                            serverData.GetDataValues(DataType.VERSION),
                            serverData.GetDataValues(DataType.DESCRIPTION),
                            serverData.GetDataValues(DataType.ONLINE),
                            serverData.GetDataValues(DataType.MAX)));
            }

            // Return list of servers
            return servers;
        }
    }
}
