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