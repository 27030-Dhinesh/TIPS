using ExceptionHandling.TaskTwo;

namespace ExceptionHandling.TaskThree
{
    /// <summary>
    /// Demonstrates the use of custom exceptions when accessing array elements
    /// and provides methods for testing exception handling scenarios.
    /// </summary>
    public class TaskThreeRunner
    {
        /// <summary>
        /// Executes an array access operation using user-supplied input.
        /// </summary>
        /// <exception cref="InvalidArrayIndexException">
        /// Thrown when an attempt is made to access an array element
        /// using an invalid index.
        /// </exception>
        public void ExecuteTask()
        {
            int length;
            int index;
            int value;

            try
            {
                Console.Write("Enter length of the Array: ");
                length = int.Parse(Console.ReadLine());

                ArrayTask arrayTask = new ArrayTask(length);

                Console.Write("Enter index to access: ");
                index = int.Parse(Console.ReadLine());

                value = arrayTask.GetAt(index);
                Console.WriteLine($"Value at {index} is {value}.");
            }
            catch (FormatException e)
            {
                Console.WriteLine($"FormatException:\n{e.Message}");
            }
            catch (OverflowException e)
            {
                Console.WriteLine($"OverflowException:\n{e.Message}\nDid you enter negative size for array?");
            }
            catch (IndexOutOfRangeException e)
            {
                throw new InvalidArrayIndexException("Index out of range.", e);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Some exception occurred:\n{e.ToString()}");
            }
            finally
            {
                Console.WriteLine("I will print this line whether or not an exception occurred.");
            }
        }

        /// <summary>
        /// Executes the custom exception demonstration and handles
        /// <see cref="InvalidArrayIndexException"/> instances.
        /// </summary>
        public void Run()
        {
            try
            {
                this.ExecuteTask();
            }
            catch (InvalidArrayIndexException e)
            {
                Console.WriteLine(@$"Caught custom exception:

{e.GetType()}
{e.Message}

{e.InnerException?.StackTrace}");
            }
        }

        /// <summary>
        /// Throws a randomly selected exception for demonstration purposes.
        /// </summary>
        public void ThrowRandomException()
        {
            Exception[] exceptions =
            {
                new Exception("This is Exception."),
                new ArgumentNullException(),
                new ArgumentNullException("ArgumentNullException with custom message."),
                new OverflowException("OverflowException is thrown"),
                new ArgumentException("ArgumentException: I don't have any arguments though."),
            };

            throw exceptions[Random.Shared.Next(1, exceptions.Length + 1)];
        }
    }
}
