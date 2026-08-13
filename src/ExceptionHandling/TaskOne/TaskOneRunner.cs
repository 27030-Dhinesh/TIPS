namespace ExceptionHandling.TaskOne
{
    /// <summary>
    /// Executes the workflow for demonstrating divide-by-zero exception handling.
    /// Collects user input, performs an integer division operation, and displays
    /// the result or relevant exception details.
    /// </summary>
    public class TaskOneRunner
    {
        /// <summary>
        /// Runs the divide-by-zero exception demonstration.
        /// Prompts the user for two integer values, performs division using the
        /// <see cref="Divide"/> class, and handles common runtime exceptions.
        /// </summary>
        public void Run()
        {
            int num1;
            int num2;

            try
            {
                Console.Write("Enter number 1: ");
                num1 = int.Parse(Console.ReadLine());

                Console.Write("Enter number 2: ");
                num2 = int.Parse(Console.ReadLine());

                Divide divide = new Divide(num1, num2);

                int result = divide.Quotient;

                Console.WriteLine(@$"Number 1: {num1}
Number 2: {num2}

Quotient: {result}");
            }
            catch (FormatException e)
            {
                Console.WriteLine($"FormatException:\n{e.Message}");
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine($"DivideByZeroException:\n{e.Message}");
            }
            finally
            {
                Console.WriteLine("I will print this line whether or not an exception occurred.");
            }
        }
    }
}
