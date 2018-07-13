using HttpFileDownloader.Configurations;
using HttpFileDownloader.Models.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpFileDownloader.Services
{
    public class DownloadService
    {
        private List<Link> links;
        private OutputConfiguration outputConfiguration;
        private SpeedConfiguration speedConfiguration;
        private ThreadConfiguration threadConfiguration;

        public DownloadService(List<Link> links)
        {
            this.links = links;
        }

        public void Download()
        {

        }
    }
}
