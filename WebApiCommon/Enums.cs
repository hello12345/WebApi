using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiCommon
{
    public class Enums
    {
        public enum ResultStatus
        {
            Success = 0,
            Failure = 1,
            Abort = 2,
            Cancel = 3,
            Warning = 4,
            Information = 5,
            NoData = 6,
            Validation = 7,
            NodData = 8
        }
    }
}
