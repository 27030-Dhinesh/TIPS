using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeHierarchy.Models
{
    /// <summary>
    /// Model to represent the details of a Manager.
    /// </summary>
    internal class Manager : Employee
    {
        /// <summary>
        /// Gets or sets the name of the Manager.
        /// </summary>
        /// <value>The name of the Manager.</value>
        public override string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the salary of the Manager.
        /// </summary>
        /// <value>The salary of the Manager.</value>
        public override decimal Salary { get; set; } = decimal.Zero;

        /// <summary>
        /// Calculate the bonus amount for the Manager.
        /// </summary>
        /// <returns>Bonus amount for the Manager.</returns>
        public override decimal CalculateBonus()
        {
            return 0.07m * this.Salary;
        }
    }
}
