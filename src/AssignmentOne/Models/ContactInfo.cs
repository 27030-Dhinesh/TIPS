using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentOne.Models
{
    /// <summary>
    /// Contact Model class
    /// </summary>
    internal class ContactInfo
    {
        /// <summary>
        /// Gets Unique ID of ContactInfo instance
        /// </summary>
        /// <value>
        /// Unique ID for ContactInfo instance
        /// </value>
        public Guid Id { get; } = Guid.NewGuid();

        /// <summary>
        /// Gets or sets Name property
        /// </summary>
        /// <value>
        /// Name of the Contact
        /// </value>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets Phone property
        /// </summary>
        /// <value>
        /// Phone number of the Contact
        /// </value>
        public string Phone { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets Email property
        /// </summary>
        /// <value>
        /// Email address of the Contact
        /// </value>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets Notes property
        /// </summary>
        /// <value>
        /// Additional notes for the Contact
        /// </value>
        public string Notes { get; set; } = string.Empty;

        /// <summary>
        /// Return a deep copy of the ContactInfo object.
        /// </summary>
        /// <returns>ContactInfo deep copy object.</returns>
        public ContactInfo Clone()
        {
            return new ContactInfo
            {
                Name = this.Name,
                Phone = this.Phone,
                Email = this.Email,
                Notes = this.Notes,
            };
        }
    }
}
