using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPolicy.Domain.Responses
{
    public class GeneralResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
