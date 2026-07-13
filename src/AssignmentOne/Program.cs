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

                switch (userChoice.ToUpper())
                {
                    case "A":
                        AddNewContact(contactList);
                        break;
                    case "E":
                        EditContact(contactList);
                        break;
                    case "D":
                        DeleteContact(contactList);
                        break;
                    case "S":
                        DisplayContacts(contactList);
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        /// <summary>
        /// Print app functionalities.
        /// </summary>
        private static void DisplayInfo()
        {
            Console.WriteLine();
            Console.WriteLine("[A]dd a new contact.");
            Console.WriteLine("[E]dit a contact.");
            Console.WriteLine("[D]elete a contact");
            Console.WriteLine("[S]how all contacts");
            Console.WriteLine("[Q]uit");
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
            string name = GetInput("Enter name to find:");
            for (int i = 0; i < contactList.Count; ++i)
            {
                if (string.Equals(contactList[i].Name, name, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Found a match. Enter new details:\n");
                    string newName = GetInput("Enter name:");
                    string newPhone = GetInput("Enter phone:");
                    string newEmail = GetInput("Enter email:");
                    string newNotes = GetInput("Enter notes:");

                    contactList[i] = new Contact(newName, newPhone, newEmail, newNotes);

                    Console.WriteLine("Update successful.");
                    return;
                }
            }

            Console.WriteLine("Name not found.");
        }

        private static void DeleteContact(List<Contact> contactList)
        {
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
                Console.WriteLine($"Name: {contact.Name}");
                Console.WriteLine($"Email: {contact.Email}");
                Console.WriteLine($"Phone: {contact.Phone}");
                Console.WriteLine($"Notes: {contact.Notes}");
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