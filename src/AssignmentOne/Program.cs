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
                            manager.EditContact(id, newContact);
                        }
                        break;
                    case "3": // Delete contact by name
                        manager.Delete(name);
                        break;
                    case "4": // Show all contacts
                        manager.DisplayContacts();
                        break;
                    case "5": // Search contact by name
                        string? name = GetInput("Enter name to search:");
                        ContactInfo? c = manager.SearchContact(name);
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
                        manager.DisplayByName();
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

        private static void EditContact(List<Contact> contactList)
        {
            if (contactList.Count == 0)
            {
                Console.WriteLine("Contact Book is empty.");
                return;
            }

            string name = GetInput("Enter name to find:");
            for (int i = 0; i < contactList.Count; ++i)
            {
                if (string.Equals(contactList[i].Name, name, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Found a match. Enter new details:\n");
                    Contact c = contactList[i];

                    Dictionary<string, string> categories = new ()
                    {
                        { "name", c.Name }, { "phone", c.Phone }, { "email", c.Email }, { "notes", c.Notes },
                    };

                    string? edit = string.Empty;
                    foreach (var key in categories.Keys)
                    {
                        EditMsg(key);
                        edit = Console.ReadLine();
                        if (string.IsNullOrEmpty(edit))
                        {
                            Console.WriteLine("Invalid input.\n");
                            continue;
                        }

                        if (string.Equals(edit, "Y", StringComparison.OrdinalIgnoreCase))
                        {
                            categories[key] = GetInput($"Enter {key}");
                        }
                    }

                    contactList[i] = new Contact(
                        categories["name"],
                        categories["phone"],
                        categories["email"],
                        categories["notes"]);

                    Console.WriteLine("Update successful.");
                    return;
                }
            }

            Console.WriteLine("Name not found.");
        }
    }
}