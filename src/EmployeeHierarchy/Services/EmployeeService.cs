using EmployeeHierarchy.Models;

namespace EmployeeHierarchy.Services
{
    /// <summary>
    /// Service layer to support Employee Hierarchy task.
    /// </summary>
    internal class EmployeeService
    {
        /// <summary>
        /// Instantiate a new Developer with given name and salary.
        /// </summary>
        /// <param name="name">Name of the developer.</param>
        /// <param name="salary">Salary of the developer.</param>
        /// <returns>A new Developer Employee object.</returns>
        public Developer CreateDeveloper(string name, decimal salary)
        {
            return new Developer
            {
                Name = name,
                Salary = salary,
            };
        }

        /// <summary>
        /// Instantiate a new Manager with given name and salary.
        /// </summary>
        /// <param name="name">Name of the manager.</param>
        /// <param name="salary">Salary of the manager.</param>
        /// <returns>A new Manager Employee object.</returns>
        public Manager CreateManager(string name, decimal salary)
        {
            return new Manager
            {
                Name = name,
                Salary = salary,
            };
        }
    }
}
