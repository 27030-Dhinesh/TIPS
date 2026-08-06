using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Models
{
    /// <summary>
    /// Represents an income record and contains the data associated with
    /// a source of income.
    /// </summary>
    internal class Income
    {
        /// <summary>
        /// Gets or sets the unique identifier for the income record.
        /// </summary>
        /// <value>
        /// A Guid representing the unique income identifier.
        /// </value>
        internal Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the monetary amount received as income.
        /// </summary>
        /// <value>
        /// The income amount.
        /// </value>
        internal decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the date on which the income was received.
        /// </summary>
        /// <value>
        /// The date associated with the income transaction.
        /// </value>
        internal DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the category that classifies the income.
        /// </summary>
        /// <value>
        /// An <see cref="IncomeCategory"/> value representing the income type.
        /// </value>
        internal IncomeCategory Category { get; set; }
    }
}
