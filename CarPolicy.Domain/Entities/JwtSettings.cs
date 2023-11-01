using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPolicy.Domain.Entities
{
    public class JwtSettings
    {
        public string SecretKey { get; set; }
        public int TokenExpiration { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }
    }
}
