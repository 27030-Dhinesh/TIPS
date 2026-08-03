namespace EmployeeHierarchy.Models
{
    /// <summary>
    /// Abstract model to represent Employee details.
    /// </summary>
    internal abstract class Employee
    {
        /// <summary>
        /// Gets or sets the name of the Employee.
        /// </summary>
        /// <value>The name of the Employee.</value>
        public abstract string Name { get; set; }

        /// <summary>
        /// Gets or sets the salary of the Employee.
        /// </summary>
        /// <value>The salary of the Employee.</value>
        public abstract decimal Salary { get; set; }

        /// <summary>
        /// Calculate bonus for the Employee.
        /// </summary>
        /// <returns>Bonus amount for the Employee.</returns>
        public abstract decimal CalculateBonus();

        /// <summary>
        /// Name and Salary details of the Employee.
        /// </summary>
        /// <returns>String representation of the Employee details.</returns>
        public string PrintDetails()
        {
            return $@"{this.Name} is a/an {this.GetType().Name}, earning {this.Salary} and a bonus amount of {this.CalculateBonus():F2}";
        }
    }
}
