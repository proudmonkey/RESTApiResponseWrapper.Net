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
        [Description("Request responded with exceptions.")]
        Failure,
        [Description("Request denied.")]
        Information,
        [Description("Request responded with validation error(s).")]
        Warning,
        [Description("Unable to process the request.")]
        General
    }

}
