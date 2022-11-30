using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Interfaces
{
    public class ResponseMessage
    {
        public string Message { get; set; }
        public bool Status { get; set; }
    }
}