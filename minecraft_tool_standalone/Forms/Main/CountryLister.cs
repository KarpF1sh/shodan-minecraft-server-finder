using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace minecraft_tool_standalone.Forms.Main
{
    internal static class CountryLister
    {
        
        public static List<string> getCountries()
        {
            // New array for info
            CultureInfo[] cultureInfo = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            // Create new list for coutnries
            List<string> CultureList = new List<string>();
            // Loop through
            foreach (CultureInfo culture in cultureInfo)
            {
                RegionInfo regionInfo = new RegionInfo(culture.LCID);
                if (!CultureList.Contains(regionInfo.EnglishName))
                {
                    CultureList.Add(regionInfo.EnglishName);
                }
            }

            // Sort list
            CultureList.Sort();

            // Add "none" indicator to top
            CultureList.Insert(0, "");

            // return List
            return CultureList;
        }

        //crappp!
        public static string GetCode(string country)
        {
            if (country != "")
            {
                var regions = CultureInfo.GetCultures(CultureTypes.SpecificCultures).Select(x => new RegionInfo(x.LCID));
                var englishRegion = regions.FirstOrDefault(region => region.EnglishName.Contains(country));
            
                return englishRegion.TwoLetterISORegionName;
            }
            return country;
        }
    }
}
