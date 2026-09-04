using MemoryManagement.Models;

namespace MemoryManagement
{
    /// <summary>
    /// Provides the entry point for the application.
    /// </summary>
    public partial class Program
    {
        /// <summary>
        /// Executes the application and serves as its main entry point.
        /// </summary>
        /// <param name="args">
        /// The command-line arguments passed to the application.
        /// </param>
        public static void Main(string[] args)
        {
            Student student = new Student(100, "John");
            Teacher teacher = new Teacher(100, "Joan");

            while (true)
            {
                Console.Write(@$"Memory Management

1. Value and Reference types - modification inside a method
2. Stack and Heap Memory Profiling
3.
4.
5. Exit

Enter your choice: ");

                ConsoleKey userChoice = Console.ReadKey().Key;
                Console.WriteLine();

                switch (userChoice)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Console.WriteLine("Student before modification:");
                        PrintStudent(student);
                        Console.WriteLine();
                        Console.WriteLine("Teacher before modification:");
                        PrintTeacher(teacher);
                        Console.WriteLine();

                        ModifyInsideMethod(student, teacher);

                        Console.WriteLine("Student after modification:");
                        PrintStudent(student);
                        Console.WriteLine();
                        Console.WriteLine("Teacher after modification:");
                        PrintTeacher(teacher);
                        Console.WriteLine();
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        ProfileStackAndHeapMemory();
                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        BurstMemoryUsage();
                        break;

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        break;

                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        Console.WriteLine("Press any key to exit...");
                        Console.ReadKey();
                        return;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
