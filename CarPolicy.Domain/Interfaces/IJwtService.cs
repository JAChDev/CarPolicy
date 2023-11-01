using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CarPolicy.Domain.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(ClaimsIdentity claimsIdentity);
        bool ValidateToken(string token, out ClaimsPrincipal principal);
    }
}
