using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HttpFileDownloader.Configurations
{
    /// <summary>
    /// Speed in Kbps
    /// </summary>
    public class SpeedConfiguration
    {
        private readonly int _defaultSpeed = 1024;

        public int Speed { get; set; }

        /// <summary>
        /// Initialize object with kbps value
        /// </summary>
        /// <param name="speed">Kbps value</param>
        /// <param name="type">Type of speed</param>
        public SpeedConfiguration(int speed, string type)
        {
            if (speed == 0)
            {
                Speed = _defaultSpeed;
                return;
            }

            Speed = speed;
            if (type == "m")
                Speed *= 1024;
        }
    }
}
