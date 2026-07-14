using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssignmentOne.Models;
using AssignmentOne.Repository;

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
        /// Display all available Contacts
        /// </summary>
        public void DisplayContacts()
        {
            if (_contacts.Count == 0)
            {
                DisplayEmpty();
                return;
            }

            foreach (ContactInfo contact in _contacts)
            {
                PrintContact(contact);
                Console.WriteLine("******************************");
            }
        }
    }
}
