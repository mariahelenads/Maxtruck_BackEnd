using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxtruck.Domain.Models
{
    public class AuthTokenResponse
    {
        public AuthTokenResponse(Guid userId, string token)
        {
            UserId = userId;
            Token = token;  
        }
        public Guid UserId { get; set; }

        public string Token { get; set; }
    }
}
