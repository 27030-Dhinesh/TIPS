using System.Threading;
using AssignmentOne.Models;
using AssignmentOne.Services;
using static AssignmentOne.ConsoleHelper;

namespace AssignmentOne
{
    /// <summary>
    /// Program Class - Entry Point.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main method.
        /// </summary>
        /// <param name="args">CLI arguments.</param>
        public static void Main(string[] args)
        {
            string userChoice;

            ContactManager manager = new ();

            while (true)
            {
                DisplayAppInfo();

                userChoice = GetInput("Enter your choice:");
                Console.WriteLine();

                Console.Clear();

                switch (userChoice)
                {
                    case "1": // Add a new contact
                        AddNewContact(manager);
                        break;

                    case "2": // Edit an existing contact
                        EditExistingContact(manager);
                        break;

                    case "3": // Delete contact by Guid
                        DeleteByGuid(manager);
                        break;

                    case "4": // Show all contacts
                        ShowAllContacts(manager);
                        break;

                    case "5": // Search contact by name
                        SearchByName(manager);
                        break;

                    case "6": // Show all contacts ordered by name
                        DisplayOrderByName(manager);
                        break;

                    case "7": // Exit the app
                        Console.WriteLine("Exiting application...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

                Thread.Sleep(1500);
                Console.Clear();
            }
        }

        private static void AddNewContact(ContactManager manager)
        {
            string name = GetInput("Enter the name:");
            string email = GetInput("Enter the email: ");
            string phone = GetInput("Enter the phone no.:");
            string notes = GetInput("Enter additional notes:");

            ContactInfo newContact = new ()
            {
                Name = name,
                Email = email,
                Phone = phone,
                Notes = notes,
            };
            bool operationResult = manager.Save(newContact);
            if (operationResult)
            {
                Console.WriteLine("New contact saved successful.");
            }
            else
            {
                Console.WriteLine("Failed to save contact.");
            }
        }

        private static void EditExistingContact(ContactManager manager)
        {
            if (manager.IsContactBookEmpty())
            {
                Console.WriteLine("Contact Book empty; cannot edit non-existent Contact");
                return;
            }

            string input = GetInput("Enter Guid:");
            string name, email, phone, notes;

            if (Guid.TryParse(input, out Guid id))
            {
                name = GetInput("Enter the name:");
                email = GetInput("Enter the email: ");
                phone = GetInput("Enter the phone no.:");
                notes = GetInput("Enter additional notes:");

                ContactInfo contactToEdit = new ()
                {
                    Name = name,
                    Email = email,
                    Phone = phone,
                    Notes = notes,
                };
                bool operationResult = manager.Edit(id, contactToEdit);
                if (operationResult)
                {
                    Console.WriteLine("Edit successful.");
                }
                else
                {
                    Console.WriteLine("Edit unsuccessful.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }

        private static void ShowAllContacts(ContactManager manager)
        {
            List<ContactInfo> contacts = manager.GetContacts();

            if (contacts.Count == 0)
            {
                Console.WriteLine("Contact Book is empty.");
                return;
            }

            DisplayContacts(contacts);
            Thread.Sleep(2000);
        }

        private static void DeleteByGuid(ContactManager manager)
        {
            if (manager.IsContactBookEmpty())
            {
                Console.WriteLine("Contact Book empty; cannot delete non-existent Contact");
                return;
            }

            string deleteId = GetInput("Enter GUID to delete: ");

            if (Guid.TryParse(deleteId, out Guid delId))
            {
                bool operationResult = manager.Delete(delId);
                if (operationResult)
                {
                    Console.WriteLine("Deletion successful.");
                }
                else
                {
                    Console.WriteLine("Deletion unsuccessful.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }

        private static void DisplayOrderByName(ContactManager manager)
        {
            List<ContactInfo> allContacts = manager.GetContacts();
            if (allContacts.Count == 0)
            {
                Console.WriteLine("Contact Book is empty.");
            }
            else
            {
                DisplayByName(allContacts);
            }

            Thread.Sleep(2000);
        }

        private static void SearchByName(ContactManager manager)
        {
            if (manager.IsContactBookEmpty())
            {
                Console.WriteLine("Contact Book is empty; cannot search.");
                return;
            }

            string searchName = GetInput("Enter name to search:");
            List<ContactInfo> result = manager.SearchContact(searchName);
            if (result.Count == 0)
            {
                Console.WriteLine("Contact not found.");
            }
            else
            {
                foreach (ContactInfo c in result)
                {
                    PrintContact(c);
                }
            }

            Thread.Sleep(2000);
        }

        private static void DisplayContacts(List<ContactInfo>? contacts)
        {
            if (contacts == null)
            {
                DisplayEmpty();
                return;
            }

            foreach (ContactInfo contact in contacts)
            {
                PrintContact(contact);
                Console.WriteLine("******************************\n");
            }
        }

        private static void DisplayByName(List<ContactInfo>? contacts)
        {
            if (contacts == null)
            {
                DisplayEmpty();
                return;
            }

            foreach (ContactInfo contact in contacts.OrderBy(c => c.Name))
            {
                PrintContact(contact);
                Console.WriteLine("******************************\n");
            }
        }
    }
}