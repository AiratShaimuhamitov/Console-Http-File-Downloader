using HttpFileDownloader.Models.Files;
using HttpFileDownloader.Parameters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace HttpFileDownloader.Services
{
    public class LinkService
    {
        public FilePathParameter PathParameter { get; set; }

        public LinkService(FilePathParameter pathParameter)
        {
            this.PathParameter = pathParameter;
        }

        public List<Link> GetFiles()
        {
            var links = new List<Link>();

            string[] lines = File.ReadAllLines(PathParameter.Value);

            foreach(var line in lines)
            {
                var path = line.Split(' ')[0];
                var name = line.Split(' ')[1];
                if (VerifyLink(path, name))
                    links.Add(new Link(path, name));
            }

            return links;
        }

        private bool VerifyLink(string path, string name)
        {
            return Regex.IsMatch(path, @"^https?://\w*.") && Regex.IsMatch(name, @"\w*.\w*");         
        }
    }
}
