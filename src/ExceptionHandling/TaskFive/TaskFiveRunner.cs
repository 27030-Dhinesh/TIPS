using ExceptionHandling.TaskTwo;

namespace ExceptionHandling.TaskFive
{
    /// <summary>
    /// Demonstrates how to capture and display exception stack trace
    /// information when an exception propagates to a higher level in
    /// the application.
    /// </summary>
    public class TaskFiveRunner
    {
        /// <summary>
        /// Executes the stack trace demonstration.
        /// </summary>
        public void Run()
        {
            try
            {
                TaskTwoRunner taskTwoRunner = new TaskTwoRunner();
                taskTwoRunner.RunWithoutExceptionHandling();
            }
            catch (Exception ex)
            {
                Console.WriteLine($@"Error from Task 5 (used Task 2):

Exception Type: {ex.GetType()}
Exception Stack Trace: {ex.StackTrace}");
            }
        }
    }
}
