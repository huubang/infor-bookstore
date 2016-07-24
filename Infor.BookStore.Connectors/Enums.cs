using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infor.BookStore.Connectors
{
    [Flags]
    public enum ParseOptions
    {
        None = 0,
        TrimValue = 1,
        SkipUniformLengthCheck = 2
    }
}
