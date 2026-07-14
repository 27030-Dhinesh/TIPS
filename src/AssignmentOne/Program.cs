using AssignmentOne.Models;
using AssignmentOne.Services;
using static AssignmentOne.Helpers;

namespace Assignments
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
            string? userChoice, name, email, phone, notes;

            ContactManager manager = new ContactManager();

            while (true)
            {
                DisplayAppInfo();

                userChoice = GetInput("Enter your choice:");
                Console.WriteLine("\n\n");

                switch (userChoice)
                {
                    case "1": // Add a new contact
                        name = GetInput("Enter the name:");
                        email = GetInput("Enter the email: ");
                        phone = GetInput("Ener the phone no.:");
                        notes = GetInput("Enter additional notes:");

                        manager.Save(name, email, phone, notes);
                        break;
                    case "2": // Edit an existing contact
                        string? input = GetInput("Enter Guid:");

                        ContactInfo newContact = new ContactInfo();

                        if (Guid.TryParse(input, out Guid id))
                        {
                            manager.Edit(id, newContact);
                        }
                        break;
                    case "3": // Delete contact by name
                        string? deleteName = GetInput("Enter the name:");
                        manager.Delete(deleteName);
                        break;
                    case "4": // Show all contacts
                        List<ContactInfo> contacts = manager.GetContacts();
                        DisplayContacts(contacts);
                        break;
                    case "5": // Search contact by name
                        string? searchName = GetInput("Enter name to search:");
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
                        List<ContactInfo>? allContacts = manager.GetContacts();
                        DisplayByName(allContacts);
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
                Console.WriteLine("******************************");
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
            }
        }
    }
}