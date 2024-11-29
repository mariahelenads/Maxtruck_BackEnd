using Maxtruck.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxtruck.Application.Dtos
{
    public class TruckDto
    {
        /// <summary>
        /// Gets or sets Model do caminhao.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Getsor sets Brand.
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// Gets or sets Lenght.
        /// </summary>
        public decimal Lenght { get; set; }

        /// <summary>
        /// Gets or sets Width.
        /// </summary>
        public decimal Weight { get; set; }

        /// <summary>
        /// Gets or sets Height  - altura do caminhão em METROS.
        /// </summary>
        public decimal Height { get; set; }

        /// <summary>
        /// Gets or sets License Plate.
        /// </summary>
        public string LicensePlate { get; set; }

        /// <summary>
        /// Gets or sets Load Capacity.
        /// </summary>
        public decimal LoadCapacity { get; set; }

        /// <summary>
        /// Gets or sets Additional Info.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user is active.
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets User Id.
        /// </summary>
        public Guid UserId { get; set; }
    }
}
