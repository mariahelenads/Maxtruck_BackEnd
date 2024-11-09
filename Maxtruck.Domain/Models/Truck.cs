﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Maxtruck.Domain.Models
{
    /// <summary>
    /// Entity Truck (Caminhão).
    /// </summary>
    public class Truck : Entity
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
        public decimal Width { get; set; }

        /// <summary>
        /// Gets or sets Height.
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
        public object? AdditionalInfo { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user is active.
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets Created At.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets Updated At.
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Gets or sets User Id.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets User.
        /// </summary>
        [ForeignKey("UserId")]
        public User User { get; set; }

    }
}
