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
        /// <summary>
        /// File name with links for downloading
        /// </summary>
        private readonly List<FileLink> _links;
        /// <summary>
        /// Output file name
        /// </summary>
        private readonly string _outputPath;
        /// <summary>
        /// Thrad count (Not supported)
        /// </summary>
        private int _threadCount;
        /// <summary>
        /// speedInKbps
        /// </summary>
        private readonly int _speedInKbps;
        /// <summary>
        /// Buffer size
        /// </summary>
        private const int BufferSize = 8192;

        /// <summary>
        /// Timer for statistics
        /// </summary>
        private Stopwatch _timer;

        /// <summary>
        /// Download service
        /// </summary>
        /// <param name="links">File name with links for downloading</param>
        /// <param name="outputPath">Output file name</param>
        /// <param name="threadCount">Thrad count (Not supported)</param>
        /// <param name="speedInKbps">Speed in kb/s</param>
        public DownloadService(List<FileLink> links, string outputPath, int threadCount, int speedInKbps)
        {
            this._links = links;
            this._outputPath = outputPath;
            this._threadCount = threadCount;
            this._speedInKbps = speedInKbps;
            _timer = new Stopwatch();
        }

        /// <summary>
        /// Start download
        /// </summary>
        public void Download()
        {
            using (var client = new WebClient())
            {
                foreach (var link in _links)
                {
                    DownloadFile(link, client);
                }
            }
        }

        private void DownloadFile(FileLink fileLink, WebClient client)
        {
            Console.WriteLine("File {0} status - started.", fileLink.Name);
            var sppedInBps = _speedInKbps * 1024;

            _timer.Start();
            using (var stream = client.OpenRead(fileLink.HttpAddress))
            {    
                var throttledStream = new ThrottledStream(stream, sppedInBps);

                var fileName = _outputPath + fileLink.Name;

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
            _timer.Stop();
            Console.WriteLine("File {0} status - downloaded in {1} seconds.", fileLink.Name, _timer.ElapsedMilliseconds / 1000);
            _timer.Reset();
        }
    }
}
