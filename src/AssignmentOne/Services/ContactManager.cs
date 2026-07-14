using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssignmentOne.Models;

namespace AssignmentOne.Services
{
    internal class ContactManager
    {




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
