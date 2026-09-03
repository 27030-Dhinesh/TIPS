using static UtilityLibraries.MathUtility;

namespace BasicCalculator
{
    /// <summary>
    /// Provides the entry point for the Calculator application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The entry point of the calculator application.
        /// </summary>
        /// <param name="args">
        /// The command-line arguments passed to the application.
        /// </param>
        public static void Main(string[] args)
        {
            int num1, num2;

            while (true)
            {
                Console.Clear();
                Console.Write(@"1. Addition
2. Subtration
3. Multiplication
4. Division
5. Remainder
6. Exit

Enter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice)
                    || !Enum.IsDefined(typeof(OperationEnum), choice))
                {
                    Console.WriteLine("Invalid input, aborting operation.\nPress any key to continue...");
                    Console.ReadKey();
                    continue;
                }

                OperationEnum operation = (OperationEnum)choice;

                if (operation == OperationEnum.Exit)
                {
                    Console.WriteLine("Press any key to exit...");
                    Console.ReadKey();
                    return;
                }

                if (!TryGetInput("Enter first number: ", out num1))
                {
                    Console.WriteLine("Invalid input, aborting operation.");
                    continue;
                }

                if (!TryGetInput("Enter second number: ", out num2))
                {
                    Console.WriteLine("Invalid input, aborting operation.");
                    continue;
                }

                try
                {
                    switch (operation)
                    {
                        case OperationEnum.Addition:
                            Console.WriteLine($"Addition Result: {Add(num1, num2)}");
                            break;

                        case OperationEnum.Subtraction:
                            Console.WriteLine($"Subtraction Result: {Difference(num1, num2)}");
                            break;

                        case OperationEnum.Multiplication:
                            Console.WriteLine($"Multiplication Result: {Product(num1, num2)}");
                            break;

                        case OperationEnum.Division:
                            Console.WriteLine($"Division Result: {Division(num1, num2)}");
                            break;

                        case OperationEnum.Remainder:
                            Console.WriteLine($"Remainder Result: {Remainder(num1, num2)}");
                            break;
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Some exception occurred: {e.Message}");
                }
                finally
                {
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        private static bool TryGetInput(string prompt, out int value)
        {
            for (int i = 3; i > 0;)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out value))
                {
                    return true;
                }

                Console.WriteLine($"Invalid input, {--i} tries remaining.");
            }

            value = 0;
            return false;
        }
    }
}