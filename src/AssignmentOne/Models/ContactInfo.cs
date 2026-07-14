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
        /// Gets or sets Unique ID of ContactInfo instance
        /// </summary>
        /// <value>
        /// Unique ID for ContactInfo instance
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets Name property
        /// </summary>
        /// <value>
        /// Name of the Contact
        /// </value>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets Phone property
        /// </summary>
        /// <value>
        /// Phone number of the Contact
        /// </value>
        public string? Phone { get; set; }

        /// <summary>
        /// Gets or sets Email property
        /// </summary>
        /// <value>
        /// Email address of the Contact
        /// </value>
        public string? Email { get; set; }

        /// <summary>
        /// Gets or sets Notes property
        /// </summary>
        /// <value>
        /// Additional notes for the Contact
        /// </value>
        public string? Notes { get; set; }
    }
}
