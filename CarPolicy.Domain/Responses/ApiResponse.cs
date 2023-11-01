using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CarPolicy.Domain.Responses
{
    public class ApiResponse
    {
        public HttpStatusCode Status { get; set; }
        public string? Message { get; set; }
    }
}
