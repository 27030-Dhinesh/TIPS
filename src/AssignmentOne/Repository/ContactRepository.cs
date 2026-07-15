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
        private readonly List<ContactInfo> _contacts = new ();

        /// <summary>
        /// Check if Contacts List is empty or not.
        /// </summary>
        /// <returns>true if Contacts list is empty, false otherwise.</returns>
        public bool IsEmpty()
        {
            return this._contacts.Count == 0;
        }

        /// <summary>
        /// Add new ContactInfo to Repo
        /// </summary>
        /// <param name="contact">ContactInfo instance</param>
        public void AddContactInfo(ContactInfo contact)
        {
            this._contacts.Add(contact);
        }

        /// <summary>
        /// Edit a ContactInfo.
        /// </summary>
        /// <param name="id">Guid of Contact to delete.</param>
        /// <param name="newContactInfo">New contact info to replace with.</param>
        /// <returns>true if edit successful, false otherwise.</returns>
        public bool EditContactInfo(Guid id, ContactInfo newContactInfo)
        {
            ContactInfo? oldContactInfo = this._contacts.Find(c => c.Id == id);
            if (oldContactInfo != null)
            {
                this._contacts.Remove(oldContactInfo);
                this._contacts.Add(newContactInfo);

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
            return this._contacts.Remove(contact);
        }

        /// <summary>
        /// Get all saved contacts
        /// </summary>
        /// <returns>List of Contacts saved. Empty List<Contact> if Contact Book is empty.</returns>
        public List<ContactInfo> GetContacts()
        {
            if (this._contacts == null || this._contacts.Count == 0)
            {
                return new List<ContactInfo>();
            }

            return this._contacts.Select(contact => contact.Clone()).ToList();
        }
    }
}
