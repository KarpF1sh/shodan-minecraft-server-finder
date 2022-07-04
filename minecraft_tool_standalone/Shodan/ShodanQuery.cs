using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using minecraft_tool_standalone.Minecraft;
using minecraft_tool_standalone.Reg;
using Shodan.Net;

namespace minecraft_tool_standalone.Shodan
{
    internal static class ShodanQuery
    {
        // Search method
        public static async Task<List<ShodanData>> SearchAsync(Query query)
        {
        
            // Get key from registry
            string key = Manager.GetRegistryKey(KeyType.APIKEY);
            if (key == String.Empty)
            {
                throw new ArgumentException("No API key set");
            }
            ShodanClient client = new ShodanClient(key);

            // Build query
            string finalQuery = QueryBuild(query);

            // Create list for results
            List<ShodanData> queryResults = new List<ShodanData>();

            // Get results from shodan
            var ShodanResponse = await client.SearchHosts(query: a => a.WithText(finalQuery));

            try
            {
                // Loop trough results 
                foreach (var item in ShodanResponse["matches"])
                {
                    // Add results to list
                    queryResults.Add(new ShodanData(item.ip_str.ToString(),
                                                    item.port.ToString(),
                                                    item.data.ToString()));
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            // Return list
            return queryResults;
        }

        private static string QueryBuild(Query query)
        {
            // Create final query with magic!
            // This is hard to read I'm sorry :(
            return String.Format("minecraft {0} {1} {2} {3}",
                String.IsNullOrEmpty(query.Country) ? query.Country : "country:" + query.Country,
                String.IsNullOrEmpty(query.Version) ? query.Version : "version:" + query.Version,
                query.Players ? "-players:0" : String.Empty,
                query.NoPlayers ? "players:0" : String.Empty);
        }
    }
}
