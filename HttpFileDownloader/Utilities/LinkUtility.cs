using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using HttpFileDownloader.Models.Files;
using HttpFileDownloader.Parameters;

namespace HttpFileDownloader.Utilities
{
    public static class LinkUtility
    {

        public static List<Link> GetLinks(string fileLocation)
        {
            var links = new List<Link>();

            var lines = File.ReadAllLines(fileLocation);

            foreach(var line in lines)
            {
                var path = line.Split(' ')[0];
                var name = line.Split(' ')[1];
                if (VerifyLink(path, name))
                    links.Add(new Link(path, name));
            }

            return links;
        }

        public static bool VerifyLink(string path, string name)
        {
            return Regex.IsMatch(path, @"^https?://\w*.") && Regex.IsMatch(name, @"\w*.\w*");         
        }
    }
}
