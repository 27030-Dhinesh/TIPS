using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Models
{
    /// <summary>
    /// Represents the category to which an expense belongs.
    /// </summary>
    /// <remarks>
    /// Used to classify expenses for reporting, tracking, and budgeting purposes.
    /// </remarks>
    internal enum ExpenseCategory
    {
        /// <summary>
        /// Expenses related to food and beverages, including restaurants
        /// and groceries.
        /// </summary>
        Food,

        /// <summary>
        /// Expenses related to transportation, such as fuel, public transit,
        /// and ride-sharing services.
        /// </summary>
        Transport,

        /// <summary>
        /// Expenses incurred from purchasing goods, products, or personal items.
        /// </summary>
        Shopping,

        /// <summary>
        /// ecurring or one-time bill payments, such as utilities,
        /// rent, or subscription.
        /// </summary>
        Bills,

        /// <summary>
        /// Expenses related to leisure and recreational activities.
        /// </summary>
        Entertainment,

        /// <summary>
        /// Expenses related to medical services, treatments, medications,
        /// and health-related needs.
        /// </summary>
        Healthcare,

        /// <summary>
        /// Expenses that do not fit into any predefined category.
        /// </summary>
        Other,
    }
}
