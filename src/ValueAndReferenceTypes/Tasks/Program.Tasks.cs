using System.Diagnostics;
using System.Runtime.CompilerServices;
using MemoryManagement.Models;

namespace MemoryManagement
{
    /// <summary>
    /// Provides the entry point for the application.
    /// </summary>
    public partial class Program
    {
        private static void ModifyInsideMethod(Student student, Teacher teacher)
        {
            Console.WriteLine("Attempting to change student name as 'Jonathan'");
            student.Name = "Jonathan";
            Console.WriteLine("Student inside the method:");
            PrintStudent(student);
            Console.WriteLine();

            Console.WriteLine("Attempting to change teacher name as 'Joanna'");
            teacher.Name = "Joanna";
            Console.WriteLine("Teacher inside the method:");
            PrintTeacher(teacher);
            Console.WriteLine();
        }

        private static void ProfileStackAndHeapMemory()
        {
            ProfileStackMemory();

            ProfileHeapMemory();
        }

        private static void ProfileStackMemory()
        {
            DisplayMemoryUsageOfExplicitLayoutStruct();
            Console.WriteLine();
            DisplayMemoryUsageOfPoint();
        }

        private static void ProfileHeapMemory()
        {
            long bytesBefore = GC.GetAllocatedBytesForCurrentThread();
            List<Point> points = new (100_000);
            long bytesAfter = GC.GetAllocatedBytesForCurrentThread();

            GC.KeepAlive(points);

            long allocatedBytes = bytesAfter - bytesBefore;
            Console.WriteLine($"Heap bytes allocated by this operation: {allocatedBytes} bytes. (Expected: 0 for value types)");
        }

        private static void DisplayMemoryUsageOfExplicitLayoutStruct()
        {
            // Measure structural size in memory
            int structSize = Unsafe.SizeOf<ExplicitLayoutStruct>();
            Console.WriteLine($"Size of struct in memory: {structSize} bytes");

            // Measure heap allocation impact
            long bytesBefore = GC.GetAllocatedBytesForCurrentThread();

            // Instantiate the struct
            ExplicitLayoutStruct explicitLayoutStruct = default;

            // Dummy operation to prevent compiler optimization discarding the variable
            GC.KeepAlive(explicitLayoutStruct);

            long bytesAfter = GC.GetAllocatedBytesForCurrentThread();
            long allocatedBytes = bytesAfter - bytesBefore;

            Console.WriteLine($"Heap bytes allocated by this operation: {allocatedBytes} bytes. (Expected: 0 for value types)");
        }

        private static void DisplayMemoryUsageOfPoint()
        {
            int expectedMemoryUsage = sizeof(int) * 2; // 8 bytes

            // sizeof(Point) - will only compile in an unsafe block
            // because Point is a user-defined struct containing only
            // value types.
            // sizeof(Point) will only compile in an unsafe block if Point is a user-defined struct containing only value types.
            unsafe
            {
                // sizeof() gives the exact size of the struct, including its internal alignment padding
                int actualMemoryUsage = sizeof(Point);
                int padding = actualMemoryUsage - expectedMemoryUsage;

                Console.WriteLine($"-> Pure Data Size: {expectedMemoryUsage} bytes");
                Console.WriteLine($"-> Actual Struct Size (with padding): {actualMemoryUsage} bytes");
                Console.WriteLine($"-> Padding/Overhead: {padding} bytes");
            }
        }

        private static void BurstMemoryUsage()
        {
            List<Student> students = new ();

            for (long i = 0; i < 1_000_000_000; ++i)
            {
                Student student = new Student(100, "Jonathan");

                if (i % 5_000 == 0)
                {
                    students.Add(student);
                }

                if (i % 10_000 == 0)
                {
                    GC.Collect();
                }
            }
        }

        private static void PrintStudent(Student student)
        {
            Console.WriteLine($"Register Number: {student.RegisterNumber}\nName: {student.Name}");
        }

        private static void PrintTeacher(Teacher teacher)
        {
            Console.WriteLine($"Register Number: {teacher.EnrollmentNumber}\nName: {teacher.Name}");
        }
    }
}
