using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpFileDownloader
{
    public interface IParameter
    {
        string Directive { get; }
        string Value { get; set; }
        bool Verify();
    }
}
