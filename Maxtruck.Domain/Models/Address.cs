namespace Maxtruck.Domain.Models
{
    /// <summary>
    /// Address.
    /// </summary>
    public class Address
    {
        /// <summary>
        /// Gets or sets Street.
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Gets or sets City.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets State.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets Zip Code (CEP).
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// Gets or sets Neighborhood.
        /// </summary>
        public string Neighborhood { get; set; }

        /// <summary>
        /// Gets or sets Country.
        /// </summary>
        public string Country { get; set; }
    }
}
