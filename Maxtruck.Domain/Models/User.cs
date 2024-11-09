namespace Maxtruck.Domain.Models
{
    /// <summary>
    /// Entity User.
    /// </summary>
    public class User : Entity
    {
        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Document.
        /// </summary>
        public string Document { get; set; }

        /// <summary>
        /// Gets or sets Email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Get or sets Password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets CreatedAt.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets user's Trucks.
        /// </summary>
        public List<Truck> Trucks { get; set; } = new List<Truck>();
    }
}
