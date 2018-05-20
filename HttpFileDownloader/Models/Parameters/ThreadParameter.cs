using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HttpFileDownloader.Parameters
{
    public class ThreadParameter : Parameter
    {
        public ThreadParameter(string directive, string value) : base(directive, value)
        {
        }

        public override bool Verify()
        {
            return base.Verify() && Regex.IsMatch(Value, "\\d+");
        }
    }
}
