using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyTools.Application.Common
{
    public class ServiceResult<T>
    {
        public bool IsError { get; set; }
        public string? ErrorMessage { get; set; }
        public T? Payload { get; set; }
    }
}
