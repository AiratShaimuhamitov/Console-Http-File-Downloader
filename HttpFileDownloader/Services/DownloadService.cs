using HttpFileDownloader.Models.Files;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Born2Code.Net;

namespace HttpFileDownloader.Services
{
    public class DownloadService
    {
        private List<Link> links;
        private string outputPath;
        private int threadCount;
        private int speedInKbps;
        private const int BufferSize = 8192;

        public DownloadService(List<Link> links, string outputPath, int threadCount, int speedInKbps)
        {
            this.links = links;
            this.outputPath = outputPath;
            this.threadCount = threadCount;
            this.speedInKbps = speedInKbps;
        }

        public void Download()
        {
            using (var client = new WebClient())
            {
                foreach (var link in links)
                {
                    DownloadFile(link, client);
                }
            }
        }

        private void DownloadFile(Link link, WebClient client)
        {
            var sppedInBps = speedInKbps * 1024;

            using (var stream = client.OpenRead(link.HttpAddress))
            {    
                var throttledStream = new ThrottledStream(stream, sppedInBps);

                var fileName = outputPath + link.Name;

                using (var file = File.Create(fileName))
                {
                    var buffer = new byte[BufferSize];
                    var readCount = throttledStream.Read(buffer, 0, BufferSize);

                    while (readCount > 0)
                    {
                        file.Write(buffer, 0, readCount);
                        readCount = throttledStream.Read(buffer, 0, BufferSize);
                    }
                }
                throttledStream.Close();
            }
            Console.WriteLine("File {0} status - downloaded.", link.Name);
        }
    }
}
