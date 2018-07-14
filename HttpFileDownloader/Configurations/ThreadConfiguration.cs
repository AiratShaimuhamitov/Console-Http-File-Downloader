using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HttpFileDownloader.Configurations.Interfaces;

namespace HttpFileDownloader.Configurations
{
    public class ThreadConfiguration : IConfiguration
    {
        private readonly int _defaultCount = 1;

        public int ThreadCount { get; set; }

        public ThreadConfiguration(int threadCount)
        {
            ThreadCount = threadCount == 0 ? _defaultCount : threadCount;
        }
    }
}
