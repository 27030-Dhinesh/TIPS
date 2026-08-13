using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExceptionHandling.TaskTwo;

namespace ExceptionHandling.TaskThree
{
    public class TaskThreeRunner
    {
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
    }
}
