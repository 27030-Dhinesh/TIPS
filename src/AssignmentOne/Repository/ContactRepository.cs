using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssignmentOne.Models;
using static AssignmentOne.Helpers;

namespace AssignmentOne.Repository
{
    /// <summary>
    /// Repository for ContactInfo
    /// </summary>
    internal class ContactRepository
    {
        private List<ContactInfo> _contacts = new List<ContactInfo>();

        /// <summary>
        /// Add new ContactInfo to Repo
        /// </summary>
        /// <param name="contact">ContactInfo instance</param>
        public void AddContactInfo(ContactInfo contact)
        {
            _contacts.Add(contact);
        }

        /// <summary>
        /// Edit a ContactInfo.
        /// </summary>
        /// <param name="oldContactInfo">Old contact info to update.</param>
        /// <param name="newContactInfo">New contact info to replace with.</param>
        /// <returns>true if edit successful, false otherwise.</returns>
        public bool EditContactInfo(ContactInfo oldContactInfo, ContactInfo newContactInfo)
        {
            if (_contacts.Contains(oldContactInfo))
            {
                _contacts.Remove(oldContactInfo);
                _contacts.Add(newContactInfo);

                return true;
            }

            return false;
        }

        /// <summary>
        /// Delete a contact from Contact Book
        /// </summary>
        /// <param name="contact">Contact to delete</param>
        /// <returns>true if deleted successfully, false otherwise</returns>
        public bool DeleteContactInfo(ContactInfo contact)
        {
            if (_contacts.Contains(contact))
            {
                _contacts.Remove(contact);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Get all saved contacts
        /// </summary>
        /// <returns>List of Contacts saved</returns>
        public List<ContactInfo> GetContacts()
        {
            return new List<ContactInfo>(_contacts);
        }
    }
}
