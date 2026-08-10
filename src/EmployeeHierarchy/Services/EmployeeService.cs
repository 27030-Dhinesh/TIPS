using EmployeeHierarchy.Models;

namespace EmployeeHierarchy.Services
{
    /// <summary>
    /// Service layer to support Employee Hierarchy task.
    /// </summary>
    internal class EmployeeService
    {
        /// <summary>
        /// Instantiate a new `type` Employee with given name and salary.
        /// </summary>
        /// <param name="name">Name of the Employee.</param>
        /// <param name="salary">Salary of the Employee.</param>
        /// <param name="type">Type of the Employee.</param>
        /// <returns>A new Employee of the specified type.</returns>
        public Employee? CreateEmployee(string name, decimal salary, EmployeeType type)
        {
            if (type == EmployeeType.Developer)
            {
                return new Developer()
                {
                    Name = name,
                    Salary = salary,
                };
            }
            else if (type == EmployeeType.Manager)
            {
                return new Manager()
                {
                    Name = name,
                    Salary = salary,
                };
            }
            else
            {
                return null;
            }
        }
    }
}
