using AssignmentOne.Services;

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
            string? userChoice;

            ContactManager manager = new ContactManager();

            while (true)
            {
                DisplayInfo();
                userChoice = Console.ReadLine();
                if (string.IsNullOrEmpty(userChoice))
                {
                    Console.WriteLine("Invalid input.\n");
                    continue;
                }

                Console.WriteLine("\n\n");

                switch (userChoice.ToUpper())
                {
                    case "1":
                        AddNewContact(contactList);
                        break;
                    case "2":
                        EditContact(contactList);
                        break;
                    case "3":
                        DeleteContact(contactList);
                        break;
                    case "4":
                        DisplayContacts(contactList);
                        break;
                    case "5":
                        SearchContact(contactList);
                        break;
                    case "6":
                        DisplaySortedContacts(contactList);
                        break;
                    case "7":
                        Console.WriteLine("Exiting application...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        private static void DisplaySortedContacts(List<Contact> contactList)
        {
            if (contactList.Count == 0)
            {
                Console.WriteLine("Contact Book is empty.");
                return;
            }

            foreach (Contact contact in contactList.OrderBy(c => c.Name))
            {
                PrintContact(contact);
                Console.WriteLine("*********************************\n");
            }
        }

        private static void SearchContact(List<Contact> contactList)
        {
            if (contactList.Count == 0)
            {
                Console.WriteLine("Contact Book is empty.");
                return;
            }

            string name = GetInput("Enter name to search:");
            foreach (Contact contact in contactList)
            {
                if (string.Equals(contact.Name, name, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("\nContact found.");
                    PrintContact(contact);
                    Console.WriteLine("*********************************\n");
                }
            }
        }

        private static void AddNewContact(List<Contact> contactList)
        {
            string name = GetInput("Enter name:");
            string phone = GetInput("Enter phone:");
            string email = GetInput("Enter email:");
            string notes = GetInput("Enter any additional notes:");

            contactList.Add(new Contact(name, phone, email, notes));
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

        private static void DeleteContact(List<Contact> contactList)
        {
            if (contactList.Count == 0)
            {
                Console.WriteLine("Contact list is empty.");
                return;
            }

            string name = GetInput("Enter name:");
            for (int i = 0; i < contactList.Count; ++i)
            {
                if (string.Equals(contactList[i].Name, name, StringComparison.OrdinalIgnoreCase))
                {
                    contactList.RemoveAt(i);
                    Console.WriteLine("Contact deleted successfully.");
                    return;
                }
            }

            Console.WriteLine("Contact not found.");
        }
    }
}