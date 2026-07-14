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
            string userChoice;

            List<Contact> contactList = new List<Contact>();

            while (true)
            {
                DisplayInfo();
                userChoice = Console.ReadLine();
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

        /// <summary>
        /// Print app functionalities.
        /// </summary>
        private static void DisplayInfo()
        {
            Console.WriteLine();
            Console.WriteLine("1. Add a new contact.");
            Console.WriteLine("2. Edit a contact.");
            Console.WriteLine("3. Delete a contact");
            Console.WriteLine("4. Show all contacts");
            Console.WriteLine("5. Search contact");
            Console.WriteLine("6. Display sorted contacts");
            Console.WriteLine("7. Quit");
            Console.WriteLine("\nEnter your choice:");
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

                    Dictionary<string, string> categories = new Dictionary<string, string>()
                    {
                        {"name", c.Name}, { "phone", c.Phone }, { "email", c.Email }, { "notes", c.Notes },
                    };

                    string edit = string.Empty;
                    foreach (var key in categories.Keys)
                    {
                        EditMsg(key);
                        edit = Console.ReadLine();
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

        private static void DisplayContacts(List<Contact> contactList)
        {
            if (contactList.Count == 0)
            {
                Console.WriteLine("Contact Book is empty.");
                return;
            }

            foreach (Contact contact in contactList)
            {
                PrintContact(contact);
                Console.WriteLine("\n***********************************\n");
            }
        }

        private static string GetInput(string prompt)
        {
            string input;
            Console.WriteLine(prompt);
            input = Console.ReadLine();

            return input;
        }

        private static void PrintContact(Contact contact)
        {
            Console.WriteLine($"Name: {contact.Name}");
            Console.WriteLine($"Phone: {contact.Phone}");
            Console.WriteLine($"Email: {contact.Email}");
            Console.WriteLine($"Notes: {contact.Notes}");
        }

        private static void EditMsg(string category)
        {
            Console.WriteLine($"Do you want to edit {category} [Y]? (empty to leave as it is)");
        }
    }

    /// <summary>
    /// Contact Model class
    /// </summary>
    internal class Contact
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Contact"/> class.
        /// </summary>
        /// <param name="name">Name of the Contact</param>
        /// <param name="phone">Phone number of Contact</param>
        /// <param name="email">Email address of Contact</param>
        /// <param name="notes">Additional notes for Contact</param>
        public Contact(string name, string phone, string email, string notes)
        {
            Name = name;
            Phone = phone;
            Email = email;
            Notes = notes;
        }

        /// <summary>
        /// Gets or sets Name property
        /// </summary>
        /// <value>
        /// Name of the Contact
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Phone property
        /// </summary>
        /// <value>
        /// Phone number of the Contact
        /// </value>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets Email property
        /// </summary>
        /// <value>
        /// Email address of the Contact
        /// </value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets Notes property
        /// </summary>
        /// <value>
        /// Additional notes for the Contact
        /// </value>
        public string? Notes { get; set; }
    }
}