using HttpFileDownloader.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HttpFileDownloader.Configurations.Interfaces;

namespace HttpFileDownloader.Configurations
{
    public class OutputConfiguration : IConfiguration
    {
        public string OutputPath { get; private set; }

        public OutputConfiguration(string outputPath)
        {
            this.OutputPath = outputPath;
        }
    }
}
