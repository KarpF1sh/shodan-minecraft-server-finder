using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.CSharp.RuntimeBinder;
using minecraft_tool_standalone.Minecraft;
using minecraft_tool_standalone.Reg;
using Newtonsoft.Json;
using Shodan.Net;
using Shodan.Net.Models;

namespace minecraft_tool_standalone.Shodan
{
    internal static class ShodanQuery
    {
        public static int pages = 0;
        // Search method
        public static async Task<List<Server>> SearchAsync(Query query)
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
            List<Server> queryResults = new List<Server>();

            // Get results from shodan
            var shodanResponse = await client.SearchHosts(query: a => a.WithText(finalQuery));


            // Get results count
            SearchHostResults resultsCount = await client.SearchHostsCount(query: a => a.WithText(finalQuery));

            // Calculate pages
            pages = (int)(-1L + resultsCount.Total + 100) / 100;

            //Console.WriteLine(pages + " " + resultsCount.Total);

            try
            {
                // Loop trough results 
                foreach (var item in shodanResponse["matches"])
                {

                    //Console.WriteLine(item.ToString());
                    if (item.product == "Minecraft" && item._shodan.module == "minecraft")
                    {
                        // Add results to list
                        queryResults.Add(new Server(
                            item.ip_str.ToString(),
                            item.port.ToString(),
                            item.minecraft.version.name.ToString(),
                            FindDesc(item),
                            item.minecraft.players.online.ToString(),
                            item.minecraft.players.max.ToString(),
                            isModded(item)));
                    }
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
            return String.Format("minecraft{0}{1}{2}{3}{4}",
                   String.IsNullOrEmpty(query.Country) ? query.Country : " country:" + query.Country,
                   String.IsNullOrEmpty(query.Version) ? query.Version : " version:" + query.Version,
                   query.Players ? " -players:0" : String.Empty,
                   query.NoPlayers ? " players:0" : String.Empty,
                   " &page=" + query.Page);
        }
        private static string FindDesc(dynamic item)
        {
            // If not null
            if(item != null)
            {
                // Fix this!! The json formatting is inconsistent and needs to account all of the different description variations
                try 
                {
                    // If the text key exists
                    if (item.minecraft.description.ContainsKey("text"))
                    {
                        // Return the description.text
                        return item.minecraft.description.text.ToString();

                    }

                    // If the translate key exits
                    if (item.minecraft.description.ContainsKey("translate"))
                    {
                        // Return the translate text
                        return item.minecraft.description.translate.ToString();

                    }

                    // Return just the Description
                    return item.minecraft.description.ToString();

                    //TODO add support for displaying the extra fields!
                }
                catch (Exception ex) { Console.WriteLine(ex); }

                // Return placeholder desc
                return "-";

            }

            return null;
        }

        private static bool isModded(dynamic item)
        {
            // If not null
            if (item != null)
            {
                // If the modinfo field doesn't exist
                if (item.minecraft.modinfo == null)
                {
                    return false;
                // If it does
                } else
                {
                    return true;
                }
            }

            return false;
        }
    }
}
