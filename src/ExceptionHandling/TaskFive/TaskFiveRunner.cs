using ExceptionHandling.TaskTwo;

namespace ExceptionHandling.TaskFive
{
    public class TaskFiveRunner
    {
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
