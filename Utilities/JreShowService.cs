using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCorePostgreSQLDockerApp.Models;
using System.Xml.Linq;

namespace AspNetCorePostgreSQLDockerApp.Utilities
{
    public class JreShowService
    {
        public static List<JreShow> GetShows()
        {
            var showUrl = "https://spotifeed.timdorr.com/4rOoJ6Egrf8K2IrywzwOMk";
            var doc = XDocument.Load(showUrl);
            var root = doc.Root;
            return root.
                Element("channel").
                Elements("item").
                Select(x => new JreShow { 
                    Description = (string)x.Element("description"),
                    Title = (string)x.Element("title"),
                    ImageUrl = (string)x.Element("{http://www.itunes.com/dtds/podcast-1.0.dtd}image").Attribute("href"),
                    Url = (string)x.Element("link"),
                }).ToList();
        }
    }
}
