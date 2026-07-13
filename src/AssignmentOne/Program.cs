namespace Assignments
{
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

        private static string GetInput(string prompt)
        {
            string input;
            Console.WriteLine(prompt);
            input = Console.ReadLine();

            return input;
        }
    }

    internal class Contact
    {
        public Contact(string name, string phone, string email, string notes)
        {
            Name = name;
            Phone = phone;
            Email = email;
            Notes = notes;
        }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string? Notes { get; set; }
    }
}