using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssignmentOne.Models;
using AssignmentOne.Repository;
using static AssignmentOne.Helpers;

namespace AssignmentOne.Services
{
    /// <summary>
    /// Contact Manager class
    /// </summary>
    internal class ContactManager
    {
        private readonly ContactRepository _repository;
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactManager"/> class.
        /// </summary>
        public ContactManager()
        { 
            _repository = new ContactRepository();
        }

        /// <summary>
        /// Validate a save a new Contact
        /// </summary>
        /// <param name="name">Name of the contact</param>
        /// <param name="email">Email of the contact</param>
        /// <param name="phone">Phone of the contact</param>
        /// <param name="notes">Notes for the contact</param>
        /// <returns>true if save successful, false otherwise.</returns>
        public bool Save(string name, string email, string phone, string notes)
        {
            if (!IsValidPhone(phone) || !IsValidEmail(email))
            {
                return false;
            }

            ContactInfo contactInfo = new ContactInfo()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Email = email,
                Phone = phone,
                Notes = notes,
            };

            _repository.AddContactInfo(contactInfo);
            return true;
        }

        /// <summary>
        /// Edit ContactInfo
        /// </summary>
        /// <param name="id">Guid of Contact to edit.</param>
        /// <param name="contact">ContactInfo with edited fields.</param>
        /// <returns>true if edit successful, false otherwise.</returns>
        public bool Edit(Guid id, ContactInfo contact)
        {
            return _repository.EditContactInfo(id, contact);
        }

        /// <summary>
        /// Delete a ContactInfo by name
        /// </summary>
        /// <param name="name">Name of the contact to delete</param>
        /// <returns>rue if delete successful, false otherwise.</returns>
        public bool Delete(string name)
        {
            if (_repository.IsEmpty())
            {
                return false;
            }

            string delName = GetInput("Enter name:");

            try
            {
                foreach (ContactInfo contact in _repository.GetContacts())
                {
                    if (contact.Name == delName)
                    {
                        _repository.DeleteContactInfo(contact);
                        return true;
                    }
                }

                return false;
            }
            catch (NullReferenceException e)
            {
                return false;
            }
        }

        /// <summary>
        /// Search for a ContactInfo by name.
        /// </summary>
        /// <param name="name">Name of the person to search across Contacts</param>
        /// <returns>ContactInfo if found, null otherwise.</returns>
        public ContactInfo? SearchContact(string name)
        {
            try
            {
                foreach (ContactInfo contact in _repository.GetContacts())
                {
                    if (contact.Name == name)
                    {
                        return contact; // if ContactInfo found
                    }
                }
                return null; // if ContactInfo not found and ContactRepo is non-empty.
            }
            catch (NullReferenceException e)
            {
                return null; // if ContactRepo is empty
            }
        }

        /// <summary>
        /// Get all contacts from Contact Book
        /// </summary>
        /// <returns>List<ContactInfo> all contacts</returns>
        public List<ContactInfo>? GetContacts()
        {
            return _repository.GetContacts();
        }
    }
}
