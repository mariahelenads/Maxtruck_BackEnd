using Maxtruck.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxtruck.Application.Dtos
{
    public class BridgeDto
    {
        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a altura máxima permitida na via central.
        /// </summary>
        public decimal? MaxHeightCentral { get; set; }

        /// <summary>
        /// Gets or sets altura máxima via Expressa (m)
        /// </summary>
        public decimal? MaxHeightExpressway { get; set; }

        /// <summary>
        /// Gets or sets altura máxima permita via Local (m)
        /// </summary>
        public decimal? MaxHeightLocalRoad { get; set; }

        /// <summary>
        /// Gets or sets altura máxima permita via Única (m)
        /// </summary>
        public decimal? MaxHeightSingleRoad { get; set; }

        /// <summary>
        /// Gets or sets Address.
        /// </summary>
        public Address? Address { get; set; }
    }
}
