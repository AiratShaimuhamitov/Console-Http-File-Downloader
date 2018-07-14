using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HttpFileDownloader.Configurations.Interfaces;

namespace HttpFileDownloader.Configurations
{
    /// <summary>
    /// Speed in Kbps
    /// </summary>
    public class SpeedConfiguration : IConfiguration
    {
        private readonly int _defaultSpeed = 1024;

        public int Speed { get; set; }

        /// <summary>
        /// Initialize object with kbps value
        /// </summary>
        /// <param name="speed">Kbps value</param>
        public SpeedConfiguration(int speed)
        {
            Speed = speed == 0 ? _defaultSpeed : speed;
        }
    }
}
