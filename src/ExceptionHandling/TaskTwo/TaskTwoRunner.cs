namespace ExceptionHandling.TaskTwo
{
    /// <summary>
    /// Executes and demonstrates array access operations along with
    /// exception handling techniques for invalid user input and
    /// out-of-range array access.
    /// </summary>
    public class TaskTwoRunner
    {
        /// <summary>
        /// Performs the array access workflow by collecting user input,
        /// creating an array, and retrieving a value from a specified index.
        /// </summary>
        /// <exception cref="IndexOutOfRangeException">
        /// Thrown when an invalid array index is accessed. The original exception
        /// is preserved as the inner exception.
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
                throw new IndexOutOfRangeException("Couldn't access element, index is out of range.", e);
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
        /// Executes the array access demonstration and handles
        /// out-of-range index exceptions with custom output.
        /// </summary>
        public void Run()
        {
            try
            {
                this.ExecuteTask();
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(@$"Caught exception with custom message:

{e.GetType()}
{e.Message}

{e.InnerException?.StackTrace}");
            }
        }

        /// <summary>
        /// Executes the array access demonstration without handling
        /// rethrown index-related exceptions.
        /// </summary>
        public void RunWithoutExceptionHandling()
        {
            this.ExecuteTask();
        }
    }
}
