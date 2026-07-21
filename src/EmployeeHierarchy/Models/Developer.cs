using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeHierarchy.Models
{
    /// <summary>
    /// Model to represent the details for a Developer.
    /// </summary>
    internal class Developer : Employee
    {
        /// <summary>
        /// Gets or sets the name of the Developer.
        /// </summary>
        /// <value>The name of the Developer.</value>
        public override string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the salary of the Developer.
        /// </summary>
        /// <value>The salary of the Developer.</value>
        public override decimal Salary { get; set; } = decimal.Zero;

        /// <summary>
        /// Calculate the bonus amount for the Developer.
        /// </summary>
        /// <returns>Bonus amount for the Developer.</returns>
        public override decimal CalculateBonus()
        {
            return 0.15m * this.Salary;
        }
    }
}
