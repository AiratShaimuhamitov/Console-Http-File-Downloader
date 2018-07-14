using HttpFileDownloader.Models.Files;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private int maxSpeed;
        

        public DownloadService(List<Link> links, string outputPath, int threadCount, int maxSpeed)
        {
            this.links = links;
            this.outputPath = outputPath;
            this.threadCount = threadCount;
            this.maxSpeed = maxSpeed;
        }

        public void Download()
        {
        }
    }
}
