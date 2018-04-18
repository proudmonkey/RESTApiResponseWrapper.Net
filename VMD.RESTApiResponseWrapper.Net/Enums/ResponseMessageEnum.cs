using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace VMD.RESTApiResponseWrapper.Net.Enums
{
    public enum ResponseMessageEnum
    {
        [Description("Request successful.")]
        Success,
        [Description("Request responded with error.")]
        Failure,
        [Description("Information.")]
        Information,
        [Description("Warning.")]
        Warning,
        [Description("")]
        General
    }

}
