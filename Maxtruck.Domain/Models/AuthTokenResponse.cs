using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxtruck.Domain.Models
{
    /// <summary>
    /// Auth Token Response.
    /// </summary>
    public class AuthTokenResponse
    {
        public AuthTokenResponse(Guid userId, string token, string name)
        {
            UserId = userId;
            Token = token;  
            Name = name;
        }

        /// <summary>
        /// Gets or sets User Id.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets Token.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        public string Name { get; set; }
    }
}
