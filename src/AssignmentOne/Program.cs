using AssignmentOne.Models;
using AssignmentOne.Services;
using static AssignmentOne.Helpers;

namespace AssignmentOne
{
    /// <summary>
    /// Program Class - Entry Point
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args">CLI arguments</param>
        public static void Main(string[] args)
        {
            string userChoice, name, email, phone, notes;
            bool operationResult;

            ContactManager manager = new ();

            while (true)
            {
                DisplayAppInfo();

                userChoice = GetInput("Enter your choice:");
                Console.WriteLine("\n");

                switch (userChoice)
                {
                    case "1": // Add a new contact
                        name = GetInput("Enter the name:");
                        email = GetInput("Enter the email: ");
                        phone = GetInput("Ener the phone no.:");
                        notes = GetInput("Enter additional notes:");

                        operationResult = manager.Save(name, email, phone, notes);
                        if (operationResult)
                        {
                            Console.WriteLine("New contact saved successful.");
                        }
                        else
                        {
                            Console.WriteLine("Failed to save contact.");
                        }

                        break;

                    case "2": // Edit an existing contact
                        if (manager.IsContactBookEmpty())
                        {
                            Console.WriteLine("Contact Book empty; cannot edit non-existent Contact");
                            break;
                        }

                        string input = GetInput("Enter Guid:");

                        if (Guid.TryParse(input, out Guid id))
                        {
                            name = GetInput("Enter the name:");
                            email = GetInput("Enter the email: ");
                            phone = GetInput("Ener the phone no.:");
                            notes = GetInput("Enter additional notes:");

                            ContactInfo newContact = new ()
                            {
                                Id = id,
                                Name = name,
                                Email = email,
                                Phone = phone,
                                Notes = notes,
                            };
                            manager.Edit(id, newContact);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input.");
                        }

                        break;

                    case "3": // Delete contact by name
                        if (manager.IsContactBookEmpty())
                        {
                            Console.WriteLine("Contact Book empty; cannot delete non-existent Contact");
                            break;
                        }

                        string deleteName = GetInput("Enter the name to delete:");
                        operationResult = manager.Delete(deleteName);
                        if (operationResult)
                        {
                            Console.WriteLine("Deletion successful.");
                        }
                        else
                        {
                            Console.WriteLine("Deletion unsuccessful.");
                        }

                        break;

                    case "4": // Show all contacts
                        List<ContactInfo> contacts = manager.GetContacts();

                        if (contacts == null)
                        {
                            Console.WriteLine("Contact Book is empty.");
                            break;
                        }

                        DisplayContacts(contacts);

                        break;

                    case "5": // Search contact by name
                        if (manager.IsContactBookEmpty())
                        {
                            Console.WriteLine("Contact Book is empty; cannot search.");
                            break;
                        }

                        string searchName = GetInput("Enter name to search:");
                        ContactInfo? c = manager.SearchContact(searchName);
                        if (c == null)
                        {
                            Console.WriteLine("Contact not found.");
                        }
                        else
                        {
                            PrintContact(c);
                        }

                        break;

                    case "6": // Show all contacts by name
                        List<ContactInfo> allContacts = manager.GetContacts();
                        if (allContacts == null)
                        {
                            Console.WriteLine("Contact Book is empty.");
                        }
                        else
                        {
                            DisplayByName(allContacts);
                        }

                        break;

                    case "7": // Exit the app
                        Console.WriteLine("Exiting application...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        /// <summary>
        /// Display all available Contacts
        /// </summary>
        /// <param name="contacts">List of all contacts</param>
        public static void DisplayContacts(List<ContactInfo>? contacts)
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

        /// <summary>
        /// Display all contacts sorted by name
        /// </summary>
        /// <param name="contacts">List of all contacts</param>
        public static void DisplayByName(List<ContactInfo>? contacts)
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