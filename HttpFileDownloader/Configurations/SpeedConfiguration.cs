using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HttpFileDownloader.Configurations.Interfaces;

namespace HttpFileDownloader.Configurations
{
    public class SpeedConfiguration : IConfiguration
    {
        private readonly int defaultSpeed = 1024;

        public int Speed { get; set; }

        public SpeedConfiguration(int speed)
        {
            Speed = speed == 0 ? defaultSpeed : speed;
        }
    }
}
