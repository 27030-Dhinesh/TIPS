using ExceptionHandling.TaskThree;

namespace ExceptionHandling.TaskFour
{
    public class TaskFourRunner
    {
        public void Run()
        {
            AppDomain.CurrentDomain.UnhandledException += this.CurrentDomain_UnhandledException;
            TaskThreeRunner taskThreeRunner = new TaskThreeRunner();
            taskThreeRunner.ThrowRandomException();
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine($@"Unhandled exception caught.
I'm a subscriber to the *AppDomain.CurrentDomain.UnhandledException* event.");

            if (e.ExceptionObject is Exception exception)
            {
                Console.WriteLine($@"Exception Type: {exception.GetType()}
Message: {exception.Message}
Stack Trace:
{exception.StackTrace}");
            }
            else
            {
                Console.WriteLine("The sender for *AppDomain.CurrentDomain.UnhandledException* event is not an exception object.");
            }
        }
    }
}
