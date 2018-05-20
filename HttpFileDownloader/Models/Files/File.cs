using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpFileDownloader.Models.Files
{
    public class File
    {
        public string Name { get; set; }
        public string HttpAddress { get; set; }

        public File(string HttpAddress)
        {
            this.HttpAddress = HttpAddress;
        }
    }
}
